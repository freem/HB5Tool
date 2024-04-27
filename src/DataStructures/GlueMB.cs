using System;
using System.Collections.Generic;
using System.IO;

namespace HB5Tool
{
	// Note: Playstation .glu files are different than this, ever so slightly!

	/// <summary>
	/// A single entry in the Glue file's index area.
	/// Length is 0x16 bytes in the PC version, 0x18 bytes on PS1.
	/// </summary>
	/// Note: each entry is meant to end with 0x00, 0x4C. (PC version)
	/// The former is implied from the end of the string.
	/// The latter is intentional, yet currently unknown.
	public class GlueEntry
	{
		/// <summary>
		/// Maximum filename length for a GlueEntry.
		/// (old 8.3 format names)
		/// </summary>
		public static readonly int MAX_FILENAME_LENGTH = 12;

		#region Class Members
		/// <summary>
		/// File length.
		/// </summary>
		public UInt32 Length;

		/// <summary>
		/// File offset in archive.
		/// </summary>
		public UInt32 Offset;

		/// <summary>
		/// Human readable filename.
		/// </summary>
		public string Filename;

		/// <summary>
		/// "Encoded" filename as it exists in the archive.
		/// The "encoding" involves adding 0x60 to every char.
		/// </summary>
		public byte[] EncodedName;

		public byte Unknown1;
		public byte Unknown2;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public GlueEntry()
		{
			Length = 0;
			Offset = 0;
			Unknown1 = 0;
			Unknown2 = 0;
			Filename = string.Empty;
			EncodedName = null;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public GlueEntry(BinaryReader br, bool _ps1 = false)
		{
			ReadData(br, _ps1);
		}
		#endregion

		#region Binary Read/Write
		/// <summary>
		/// Read a GlueEntry using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br, bool _ps1 = false)
		{
			byte[] tmp = br.ReadBytes(4);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(tmp);
			}
			Length = BitConverter.ToUInt32(tmp, 0);

			tmp = br.ReadBytes(4);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(tmp);
			}
			Offset = BitConverter.ToUInt32(tmp, 0);

			// read encoded filename (including any extra bytes)
			EncodedName = br.ReadBytes(MAX_FILENAME_LENGTH);

			// convert filename
			bool finishedDecoding = false;
			Filename = string.Empty;
			for (int i = 0; i < MAX_FILENAME_LENGTH; i++)
			{
				if (EncodedName[i] == 0 && !finishedDecoding)
				{
					finishedDecoding = true;
				}

				if (EncodedName[i] != 0 && !finishedDecoding)
				{
					Filename += (char)(EncodedName[i] - 0x60);
				}
			}

			// final two byte combo; unknown purpose.

			// in HB5CDROM.BIN and HB5DEMO.BIN, these are always 0x00,0x00.
			// files added to HARDBALL.BIN using add2glue.exe also use 0x00,0x00.

			// HARDBALL.BIN differs based on version and install type.
			// - 0x00,0x44 (original hb5, minimal install)
			// - 0x00,0x4C (original hb5 & hb5 enhanced v5.14, full install)
			// - 0x00,0x52 (hb5 enhanced v5.13 only, full install)
			Unknown1 = br.ReadByte();
			Unknown2 = br.ReadByte();

			if (_ps1)
			{
				// extra 2 bytes on ps1 .glu files
				br.ReadBytes(2);
			}
		}
		#endregion
	}

	/// <summary>
	/// Hardball 5 .BIN (or maybe even HB5_PSX.GLU) data files.
	/// </summary>
	public class GlueMB
	{
		/// <summary>
		/// Header bytes.
		/// </summary>
		public static readonly byte[] GLUE_HEADER = { 0x4D, 0x42 }; // "MB", for Mike Benna, who presumably came up with the format.

		#region Class Members
		/// <summary>
		/// Number of files in archive.
		/// </summary>
		public short NumFiles;

		/// <summary>
		/// Files in this archive.
		/// Does not include the file data itself.
		/// </summary>
		public List<GlueEntry> Entries;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public GlueMB()
		{
			NumFiles = 0;
			Entries = null;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public GlueMB(BinaryReader br, bool _ps1 = false)
		{
			ReadData(br, _ps1);
		}
		#endregion

		/// <summary>
		/// Read a Glue/MB archive using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		/// <param name="_ps1">If true, this is a PS1 HB5 .glu file</param>
		public void ReadData(BinaryReader br, bool _ps1)
		{
			// header check
			byte[] _header = br.ReadBytes(2);
			if (_header[0] == GLUE_HEADER[0] && _header[1] == GLUE_HEADER[1])
			{
				byte[] tmp = br.ReadBytes(2);
				if (!BitConverter.IsLittleEndian)
				{
					Array.Reverse(tmp);
				}
				NumFiles = BitConverter.ToInt16(tmp, 0);

				Entries = new List<GlueEntry>();
				for (int i = 0; i < NumFiles; i++)
				{
					Entries.Add(new GlueEntry(br,_ps1));
				}
			}
		}

		/// <summary>
		/// Export a file from a Glue/MB archive.
		/// </summary>
		/// <param name="_idx">File index to extract.</param>
		/// <param name="_inReader">BinaryReader instance to use.</param>
		/// <param name="_outWriter">BinaryWriter instance to use.</param>
		/// <returns></returns>
		public bool ExportFile(int _idx, BinaryReader _inReader, BinaryWriter _outWriter)
		{
			if (_idx < 0 || _idx > NumFiles)
			{
				return false;
			}

			_inReader.BaseStream.Seek(Entries[_idx].Offset, SeekOrigin.Begin);
			_outWriter.Write(_inReader.ReadBytes((int)Entries[_idx].Length));

			return true;
		}

		#region Filename Encode/Decode Routines
		/// <summary>
		/// Decode an encoded filename.
		/// </summary>
		/// <param name="_in">Byte array with encoded filename.</param>
		/// <returns>A string with the decoded filename.</returns>
		public static string DecodeName(byte[] _in)
		{
			string decoded = string.Empty;
			for (int i = 0; i < _in.Length; i++)
			{
				decoded += (char)(_in[i] - 0x60);
			}
			return decoded;
		}

		/// <summary>
		/// Encode an unencoded filename.
		/// </summary>
		/// <param name="_in">Filename to encode.</param>
		/// <returns>Byte array with the encoded filename.</returns>
		public static byte[] EncodeName(string _in)
		{
			byte[] encoded = new byte[_in.Length];
			for (int i = 0; i < _in.Length; i++)
			{
				encoded[i] = (byte)(_in[i] + 0x60);
			}
			return encoded;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="_in"></param>
		/// <returns></returns>
		public static string EncodedToHexString(byte[] _in)
		{
			string hexOut = string.Empty;
			foreach (byte b in _in)
			{
				hexOut += string.Format("{0:X2}",b);
			}
			return hexOut;
		}
		#endregion
	}
}
