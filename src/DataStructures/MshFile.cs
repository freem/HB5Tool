using System;
using System.Collections.Generic;
using System.IO;

namespace HB5Tool
{
	/// <summary>
	/// A single entry in a MSH file's filetable.
	/// </summary>
	public class MshEntry
	{
		#region Class Members
		/// <summary>
		/// File name.
		/// </summary>
		public string Name;

		/// <summary>
		/// Offset to file data (based on post-filelist location)
		/// </summary>
		public uint Offset;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public MshEntry()
		{
			Name = string.Empty;
			Offset = 0;
		}

		/// <summary>
		/// Constructor using specific values.
		/// </summary>
		/// <param name="_name">File name</param>
		/// <param name="_offset">Offset for data</param>
		public MshEntry(string _name, uint _offset)
		{
			Name = _name;

			// truncate name if necessary
			if (Name.Length > 4)
			{
				Name = Name.Substring(0, 4);
			}

			Offset = _offset;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public MshEntry(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		/// <summary>
		/// Read data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			byte[] tmp = br.ReadBytes(4);
			Name = string.Format("{0}{1}{2}{3}", (char)tmp[0], (char)tmp[1], (char)tmp[2], (char)tmp[3]);

			tmp = br.ReadBytes(4);
			Offset = BitConverter.ToUInt32(tmp, 0);
		}
	}

	/// <summary>
	/// MSH file, which appears to hold some graphics.
	/// </summary>
	public class MshFile
	{
		/// <summary>
		/// MSH header bytes
		/// these are assumed based on all known files
		/// </summary>
		public static readonly byte[] MSH_HEADER = { 0x01,0x13 };

		#region Class Members
		/// <summary>
		/// Number of files in this MSH file.
		/// </summary>
		public short NumFiles;

		// other header bytes
		public byte Unknown4;
		public byte Unknown5;
		public byte Unknown6;
		public byte Unknown7;

		/// <summary>
		/// File list.
		/// </summary>
		public List<MshEntry> FileList;

		public Dictionary<MshEntry, ImageMsh> Images;

		/// <summary>
		/// The offset at which file data starts.
		/// </summary>
		public uint FileStartOffset;

		/// <summary>
		/// Length of MSH file, used to calculate the file size of the last entry.
		/// </summary>
		public uint FileLength;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public MshFile()
		{
			NumFiles = 0;
			Unknown4 = 0;
			Unknown5 = 0;
			Unknown6 = 0;
			Unknown7 = 0;
			FileList = null;
			Images = null;
			FileStartOffset = 0;
			FileLength = 0;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public MshFile(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		/// <summary>
		/// Read data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			// header bytes
			byte[] tmp = br.ReadBytes(2);
			if (tmp[0] == MSH_HEADER[0] && tmp[1] == MSH_HEADER[1])
			{
				FileLength = (uint)br.BaseStream.Length;

				// num files
				tmp = br.ReadBytes(2);
				NumFiles = BitConverter.ToInt16(tmp, 0);

				// 4 other bytes
				Unknown4 = br.ReadByte();
				Unknown5 = br.ReadByte();
				Unknown6 = br.ReadByte();
				Unknown7 = br.ReadByte();

				// file list
				FileList = new List<MshEntry>();
				for (int i = 0; i < NumFiles; i++)
				{
					FileList.Add(new MshEntry(br));
				}
				FileStartOffset = (uint)br.BaseStream.Position;

				// read file data
				Images = new Dictionary<MshEntry, ImageMsh>();
				foreach (MshEntry entry in FileList)
				{
					br.BaseStream.Seek(FileStartOffset + entry.Offset, SeekOrigin.Begin);
					Images.Add(entry, new ImageMsh(br));
				}
			}
		}

		/// <summary>
		/// Extract a file from the MSH file.
		/// </summary>
		/// <param name="_idx">File index to export.</param>
		/// <param name="_inReader">BinaryReader instance to use.</param>
		/// <param name="_outWriter">BinaryWriter instance to use.</param>
		/// <returns>True if extraction was successful, false otherwise.</returns>
		public bool ExtractFile(int _idx, BinaryReader _inReader, BinaryWriter _outWriter)
		{
			// can't extract negative index or an index outside the bounds
			if (_idx < 0 || _idx > NumFiles)
			{
				return false;
			}

			_inReader.BaseStream.Seek(FileStartOffset + FileList[_idx].Offset, SeekOrigin.Begin);
			if (_idx == NumFiles - 1)
			{
				// extract last file; use file length as ending offset
				_outWriter.Write(_inReader.ReadBytes((int)(FileLength - (FileList[_idx].Offset + FileStartOffset))));
			}
			else
			{
				// extract anything but the last file
				_outWriter.Write(_inReader.ReadBytes((int)(FileList[_idx + 1].Offset - FileList[_idx].Offset)));
			}

			return true;
		}
	}
}
