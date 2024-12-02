using System;
using System.Collections.Generic;
using System.IO;

namespace HB5Tool
{
	/// <summary>
	/// Data found in ANNOUNCE.BIN
	/// </summary>
	public class AnnounceBin
	{
		/// <summary>
		/// Number of entries.
		/// </summary>
		public short NumEntries;

		/// <summary>
		/// Table of file offsets for each announcer entry.
		/// </summary>
		public UInt32[] EntryTable;

		/// <summary>
		/// Total length of ANNOUNCE.BIN file in bytes.
		/// </summary>
		public long FileLength;

		/// <summary>
		/// Sounds in ANNOUNCE.BIN, indexed based on their location in the EntryTable.
		/// </summary>
		public Dictionary<int, byte[]> Entries;

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public AnnounceBin()
		{
			NumEntries = 0;
			FileLength = 0;
			EntryTable = null;
			Entries = null;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public AnnounceBin(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		/// <summary>
		/// Read ANNOUNCE.BIN data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			FileLength = br.BaseStream.Length;
			NumEntries = BitConverter.ToInt16(br.ReadBytes(2),0);
			EntryTable = new UInt32[NumEntries];
			for (int i = 0; i < NumEntries; i++)
			{
				EntryTable[i] = BitConverter.ToUInt32(br.ReadBytes(4), 0);
			}

			Entries = new Dictionary<int, byte[]>(NumEntries);
			for (int i = 0; i < NumEntries; i++)
			{
				int size = 0;
				if (i == NumEntries - 1)
				{
					size = (int)(FileLength - EntryTable[i]);
				}
				else
				{
					size = (int)(EntryTable[i + 1] - EntryTable[i]);
				}
				br.BaseStream.Seek(EntryTable[i], SeekOrigin.Begin);
				Entries.Add(i, br.ReadBytes(size));
			}

		}
	}
}
