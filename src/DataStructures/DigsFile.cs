using System;
using System.Collections.Generic;
using System.IO;

namespace HB5Tool
{
	/// <summary>
	/// A single entry in the table of dig entries.
	/// </summary>
	public class DigEntry
	{
		#region Class Members
		/// <summary>
		/// File offset, relative to data start location.
		/// </summary>
		public uint Offset;

		/// <summary>
		/// File length.
		/// </summary>
		public ushort Length;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public DigEntry()
		{
			Offset = 0;
			Length = 0;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public DigEntry(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		/// <summary>
		/// Read entry data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			Offset = BitConverter.ToUInt32(br.ReadBytes(4),0);
			Length = BitConverter.ToUInt16(br.ReadBytes(2), 0);
		}
	}

	/// <summary>
	/// "Digs" file, which contains digitized samples.
	/// Examples include DIGS.BIN and TEAMSDIG.BIN.
	/// </summary>
	public class DigsFile
	{
		#region Class Members
		/// <summary>
		/// Unknown value at offset 0.
		/// Often (always?) 0x00.
		/// </summary>
		public short Unknown;

		/// <summary>
		/// Number of sounds in this digs file.
		/// </summary>
		/// offset 2
		public short NumEntries;

		/// <summary>
		/// Offset of the table of sound entries.
		/// </summary>
		/// offset 4
		public uint TableOffset;

		/// <summary>
		/// Offset where sound data begins.
		/// </summary>
		/// offset 8
		public uint DataOffset;

		/// <summary>
		/// Table of entries in this dig file.
		/// </summary>
		public List<DigEntry> TableEntries;
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public DigsFile()
		{
			Unknown = 0;
			NumEntries = 0;
			TableOffset = 0;
			DataOffset = 0;
			TableEntries = null;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public DigsFile(BinaryReader br)
		{
			ReadData(br);
		}

		/// <summary>
		/// Read digs file using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			Unknown = BitConverter.ToInt16(br.ReadBytes(2),0);
			NumEntries = BitConverter.ToInt16(br.ReadBytes(2),0);
			TableOffset = BitConverter.ToUInt32(br.ReadBytes(4),0);
			DataOffset = BitConverter.ToUInt32(br.ReadBytes(4),0);

			// read table entries before trying to deal with data
			br.BaseStream.Seek(TableOffset,SeekOrigin.Begin);
			TableEntries = new List<DigEntry>();
			for (int i = 0; i < NumEntries; i++)
			{
				TableEntries.Add(new DigEntry(br));
			}

			// if you're going to bother with the data, seek back
			//br.BaseStream.Seek(DataOffset, SeekOrigin.Begin);
		}

		public byte[] ExportFile(int digNum, BinaryReader br)
		{
			br.BaseStream.Seek(DataOffset + TableEntries[digNum].Offset, SeekOrigin.Begin);
			return br.ReadBytes(TableEntries[digNum].Length);
		}
	}
}
