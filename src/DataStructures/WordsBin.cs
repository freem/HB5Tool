using System;
using System.Collections.Generic;
using System.IO;

namespace HB5Tool
{
	/// <summary>
	/// A single entry in the WORDS.BIN table.
	/// </summary>
	public class WordsTableEntry
	{
		#region Class Members
		/// <summary>
		/// Currently unknown value.
		/// Possibly related to sound variant?
		/// </summary>
		public byte Unknown;

		/// <summary>
		/// Offset of sound data.
		/// Most significant byte is always set to 0x00.
		/// </summary>
		public UInt32 Offset;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public WordsTableEntry()
		{
			Unknown = 0;
			Offset = 0;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public WordsTableEntry(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		/// <summary>
		/// Read table entry using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			byte[] tmp = br.ReadBytes(4);
			// most significant byte
			Unknown = tmp[3];

			// HACK: Zero out topmost value so offset conversion is easier
			Offset = BitConverter.ToUInt32(tmp, 0) & 0x00FFFFFF;
		}
	}

	public class WordsBin
	{
		/*
		 * offset 0 is 0x00 for four bytes, followed by a table.
		 * this table ends at the address pointed to by the first entry.
		 * this doesn't necessarily mean all entries are used.
		 * 
		 * each entry is four bytes, typically an offset, but the most significant byte
		 * is repurposed for something currently unknown. possibly related to sound variant?
		 * 
		 * example:
		 * first entry is 40 06 00 80
		 * the actual file data is at 0x640
		 * 
		 * sound data is HMIADPCM format
		 */

		/// <summary>
		/// Entries in WORDS.BIN.
		/// </summary>
		public Dictionary<int, WordsTableEntry> Entries;

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public WordsBin()
		{
			Entries = new Dictionary<int, WordsTableEntry>();
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public WordsBin(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		/// <summary>
		/// Read WORDS.BIN data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			// first four bytes
			byte[] header = br.ReadBytes(4);

			// handle table
			Entries = new Dictionary<int, WordsTableEntry>();
			int validEntryCount = 0;
			int zeroEntryCount = 0;

			long prevPos = br.BaseStream.Position;
			byte[] first = br.ReadBytes(4);
			uint firstDataPos = BitConverter.ToUInt32(first, 0) & 0x00FFFFFF;

			br.BaseStream.Seek(prevPos, SeekOrigin.Begin);
			while (br.BaseStream.Position < firstDataPos)
			{
				// only add "valid" (i.e. not pointing to 0) entries
				WordsTableEntry wte = new WordsTableEntry(br);
				if (wte.Offset != 0)
				{
					Entries.Add(validEntryCount++, wte);
				}
				else
				{
					// keep track of how many entries point to 0
					zeroEntryCount++;
				}
			}

			if (zeroEntryCount > 0)
			{
				Console.WriteLine(String.Format("[WordsBin.ReadData] Found {0} entries pointing to 0", zeroEntryCount));
			}
		}
	}
}
