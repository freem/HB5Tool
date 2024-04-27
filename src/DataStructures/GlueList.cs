using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HB5Tool
{
	// xxx: this is broken


	/// <summary>
	/// An entry in GLUELIST.BIN.
	/// </summary>
	public class GlueListEntry
	{
		/// <summary>
		/// Encoded filename for this entry.
		/// </summary>
		public byte[] EncodedName;

		/// <summary>
		/// Unknown value 1.
		/// </summary>
		public short Unknown1;

		/// <summary>
		/// Unknown value 2.
		/// </summary>
		public short Unknown2;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public GlueListEntry()
		{
			EncodedName = null;
			Unknown1 = 0;
			Unknown2 = 0;
		}

		public GlueListEntry(BinaryReader br)
		{
			ReadData(br);
		}

		public void ReadData(BinaryReader br)
		{
			// filename; read up to and including the terminating 0x00
			List<byte> name = new List<byte>();
			while (br.PeekChar() != 0)
			{
				name.Add(br.ReadByte());
			}
			name.Add(br.ReadByte());
			EncodedName = name.ToArray();

			// the two unknown shorts after the filename
			Unknown1 = BitConverter.ToInt16(br.ReadBytes(2), 0);
			Unknown2 = BitConverter.ToInt16(br.ReadBytes(2), 0);
		}
	}

	/// <summary>
	/// Representation of GLUELIST.BIN.
	/// </summary>
	public class GlueList
	{
		// todo: header bullshit
		public byte[] HeaderTemp;

		// the 0x00,0x00,0x01,0x00 part

		// the 0x18 byte part x2

		// the actual stuff I care about
		public List<GlueListEntry> Entries;

		public GlueList()
		{
			HeaderTemp = null;
			Entries = null;
		}

		public GlueList(BinaryReader br)
		{
			ReadData(br);
		}

		public void ReadData(BinaryReader br)
		{
			HeaderTemp = br.ReadBytes(0x34);

			Entries = new List<GlueListEntry>();
			while (br.BaseStream.Position < br.BaseStream.Length-2)
			{
				Entries.Add(new GlueListEntry(br));
			}
		}
	}
}
