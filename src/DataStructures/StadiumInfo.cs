using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HB5Tool
{
	/// <summary>
	/// Stadium types.
	/// </summary>
	public enum StadiumTypes
	{
		Outdoor = 0,
		Dome_Permanent = 1,
		Dome_Retractable = 2
	}

	/// <summary>
	/// Turf/Grass types.
	/// </summary>
	public enum TurfTypes
	{
		Natural = 0,
		Artificial = 1
	}

	/// <summary>
	/// Stadium information (INFO%02d.BIN)
	/// </summary>
	public class StadiumInfo
	{
		#region Constants
		/// <summary>
		/// Number of colors in custom color sets 1 and 2.
		/// </summary>
		public static readonly int STADIUM_COLOR_SET_1_COUNT = 16;

		/// <summary>
		/// Number of colors in custom color set 3.
		/// </summary>
		public static readonly int STADIUM_COLOR_SET_3_COUNT = 12;

		/// <summary>
		/// Number of colors in custom color set 4.
		/// </summary>
		public static readonly int STADIUM_COLOR_SET_4_COUNT = 8;
		#endregion

		#region Class Members
		/// <summary>
		/// Byte with unknown purpose. Often 0x4C, but sometimes 0x4D.
		/// </summary>
		// offset 0
		public byte Unknown1;

		/// <summary>
		/// Stadium type.
		/// </summary>
		// offset 1
		public StadiumTypes StadiumType;

		/// <summary>
		/// Turf type.
		/// </summary>
		// offset 2
		public TurfTypes TurfType;

		// offset 3
		public byte Unknown2;

		/// <summary>
		/// Maximum attendance value.
		/// </summary>
		// offset 4
		public UInt16 MaxAttendance;

		// offsets 0x06-0x11 (inclusive) unknown

		/// <summary>
		/// Stadium name.
		/// </summary>
		/// offset 0x12; max length unknown
		public string Name;

		/// <summary>
		/// Stadium description. 0x78 max length.
		/// </summary>
		/// offset 0x3A
		public string Description;

		// offsets 0xB2-0xBB (inclusive) unknown

		/// <summary>
		/// Custom color set 1. 16 colors starting at palette index 0x20.
		/// </summary>
		// offsets 0xBC-0xEB (inclusive)
		public VgaColor[] ColorSet1;

		/// <summary>
		/// Custom color set 2. 16 colors starting at palette index 0x30.
		/// </summary>
		// offsets 0xEC-0x11B (inclusive)
		public VgaColor[] ColorSet2;

		/// <summary>
		/// Custom color set 3. 12 colors starting at pal index 0x40.
		/// </summary>
		// offsets 0x11C-0x13F (inclusive)
		public VgaColor[] ColorSet3;

		/// <summary>
		/// Custom color set 4. 8 colors starting at pal index 0xB8
		/// </summary>
		// offsets 0x140-0x157 (inclusive)
		public VgaColor[] ColorSet4;

		// offset 0x158-EOF currently unknown
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public StadiumInfo()
		{
			Unknown1 = 0;
			StadiumType = StadiumTypes.Outdoor;
			TurfType = TurfTypes.Natural;
			Unknown2 = 0;
			MaxAttendance = 0;
			Name = String.Empty;
			Description = String.Empty;
			ColorSet1 = new VgaColor[STADIUM_COLOR_SET_1_COUNT];
			ColorSet2 = new VgaColor[STADIUM_COLOR_SET_1_COUNT];
			ColorSet3 = new VgaColor[STADIUM_COLOR_SET_3_COUNT];
			ColorSet4 = new VgaColor[STADIUM_COLOR_SET_4_COUNT];
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public StadiumInfo(BinaryReader br)
		{
			ReadData(br);
		}

		/// <summary>
		/// Read StadiumInfo data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			Unknown1 = br.ReadByte();
			StadiumType = (StadiumTypes)br.ReadByte();
			TurfType = (TurfTypes)br.ReadByte();
			Unknown2 = br.ReadByte();

			byte[] tmp = br.ReadBytes(2);
			MaxAttendance = BitConverter.ToUInt16(tmp, 0);

			// offsets 0x06-0x11 unknown, skip for now

			// maximum name length is unknown, try reading to 0x39 maximum
			br.BaseStream.Seek(0x12, SeekOrigin.Begin);
			bool nameFinished = false;
			for (int i = 0; i < 40; i++)
			{
				char c = (char)br.ReadByte();

				if (c == 0 && !nameFinished)
				{
					nameFinished = true;
				}

				if (c != 0 && !nameFinished)
				{
					Name += c;
				}
			}

			// stadium description is 0x78 chars maximum
			br.BaseStream.Seek(0x3A, SeekOrigin.Begin);
			bool descFinished = false;
			for (int i = 0; i < 0x78; i++)
			{
				char c = (char)br.ReadByte();

				if (c == 0 && !descFinished)
				{
					descFinished = true;
				}

				if (c != 0 && !descFinished)
				{
					Description += c;
				}
			}

			// some unknown values precede the custom colors

			// get custom colors
			br.BaseStream.Seek(0xBC, SeekOrigin.Begin);
			ColorSet1 = new VgaColor[STADIUM_COLOR_SET_1_COUNT];
			for (int i = 0; i < STADIUM_COLOR_SET_1_COUNT; i++)
			{
				ColorSet1[i] = new VgaColor(br);
			}

			ColorSet2 = new VgaColor[STADIUM_COLOR_SET_1_COUNT];
			for (int i = 0; i < STADIUM_COLOR_SET_1_COUNT; i++)
			{
				ColorSet2[i] = new VgaColor(br);
			}

			ColorSet3 = new VgaColor[STADIUM_COLOR_SET_3_COUNT];
			for (int i = 0; i < STADIUM_COLOR_SET_3_COUNT; i++)
			{
				ColorSet3[i] = new VgaColor(br);
			}

			ColorSet4 = new VgaColor[STADIUM_COLOR_SET_4_COUNT];
			for (int i = 0; i < STADIUM_COLOR_SET_4_COUNT; i++)
			{
				ColorSet4[i] = new VgaColor(br);
			}
		}
	}
}
