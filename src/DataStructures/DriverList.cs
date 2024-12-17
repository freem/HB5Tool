using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HB5Tool
{
	/// <summary>
	/// All entries are 64 (0x40) bytes long.
	/// </summary>
	public class DriverListEntry
	{
		/// <summary>
		/// Maximum driver name length, including null terminator.
		/// </summary>
		public readonly int MAX_NAME_LENGTH = 60;

		/// <summary>
		/// Identifier value written to DEFAULTS.BIN.
		/// </summary>
		public int Identifier;

		/// <summary>
		/// Friendly/displayed name.
		/// </summary>
		public string DisplayName;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public DriverListEntry()
		{
			Identifier = 0;
			DisplayName = String.Empty;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public DriverListEntry(BinaryReader br)
		{
			DisplayName = String.Empty;
			ReadData(br);
		}

		/// <summary>
		/// Read a DriverListEntry using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			Identifier = BitConverter.ToInt32(br.ReadBytes(4), 0);

			// if the identifier is 0, this is the end of the list, so don't bother dealing with it.

			if (Identifier != 0)
			{
				// read string
				bool nameFinished = false;
				for (int i = 0; i < MAX_NAME_LENGTH; i++)
				{
					char c = (char)br.ReadByte();

					if (c == 0 && !nameFinished)
					{
						nameFinished = true;
					}

					if (c != 0 && !nameFinished)
					{
						DisplayName += c;
					}
				}
			}
		}
	}

	/// <summary>
	/// Representation of DRVRLIST.BIN
	/// </summary>
	public class DriverList
	{
		/// <summary>
		/// Data start offset.
		/// </summary>
		/// offset 0
		public int DataStartOffset;

		/// <summary>
		/// Total data length, including this value.
		/// </summary>
		/// offset 4
		public int DataTotalLength;

		public List<DriverListEntry> Entries;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public DriverList()
		{
			DataStartOffset = 0;
			DataTotalLength = 0;
			Entries = new List<DriverListEntry>();
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public DriverList(BinaryReader br)
		{
			ReadData(br);
		}

		/// <summary>
		/// Read DriverList data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			DataStartOffset = BitConverter.ToInt32(br.ReadBytes(4), 0);
			DataTotalLength = BitConverter.ToInt32(br.ReadBytes(4), 0);

			// seek to start offset
			br.BaseStream.Seek(DataStartOffset, SeekOrigin.Begin);
			Entries = new List<DriverListEntry>();

			bool validEntry = true;
			while (validEntry)
			{
				DriverListEntry entry = new DriverListEntry(br);
				if (entry.Identifier == 0)
				{
					validEntry = false;
					break;
				}
				else
				{
					Entries.Add(entry);
				}
			}

		}
	}
}
