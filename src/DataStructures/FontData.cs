using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HB5Tool
{
	/// <summary>
	/// Despite using .fnt as the extension, there are two distinct font types.
	/// </summary>
	public enum FontTypes
	{
		/// <summary>
		/// 1bpp font type, first used in Hardball 3.
		/// </summary>
		FT = 0,

		/// <summary>
		/// 4bpp font type, first used in Hardball 4.
		/// </summary>
		MF = 1,

		/// <summary>
		/// Invalid type
		/// </summary>
		Invalid = -1
	};

	/// <summary>
	/// An entry in the font character table.
	/// </summary>
	public class FontCharEntry
	{
		/// <summary>
		/// File offset for this character.
		/// Add 0xA for the real offset.
		/// </summary>
		public ushort Offset;

		/// <summary>
		/// Character width, which may or may not need to be -1
		/// </summary>
		public byte CharWidth;

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public FontCharEntry()
		{
			Offset = 0;
			CharWidth = 0;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public FontCharEntry(BinaryReader br)
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
			byte[] tmp = br.ReadBytes(2);
			Offset = BitConverter.ToUInt16(tmp, 0);
			CharWidth = br.ReadByte();
		}
	}

	/// <summary>
	/// Representation of a .FNT file.
	/// </summary>
	public class FontData
	{
		/// <summary>
		/// Header for FT/1bpp format fonts.
		/// </summary>
		public static readonly byte[] FONT_HEADER_FT = { 0x46, 0x54 }; // "FT"

		/// <summary>
		/// Header for MF/4bpp format fonts.
		/// </summary>
		public static readonly byte[] FONT_HEADER_MF = { 0x4D, 0x46 }; // "MF"

		/// <summary>
		/// Every entry in the character table needs this value added to it for the "real" address.
		/// </summary>
		public static readonly int FONT_BASE_OFFSET = 0xA;

		#region Class Members
		/// <summary>
		/// Font type.
		/// </summary>
		public FontTypes FontType;

		/// <summary>
		/// Character height.
		/// </summary>
		/// offset 2
		public short CharHeight;

		/// <summary>
		/// Default character width??
		/// </summary>
		/// offset 4
		public short DefaultWidth;

		/// <summary>
		/// Unknown value at offset 6.
		/// </summary>
		public short Unknown1;

		/// <summary>
		/// First character encoding point to use. Often 0x20.
		/// </summary>
		/// offset 8
		public byte FirstChar;

		/// <summary>
		/// Last character encoding point to use.
		/// </summary>
		/// offset 9
		public byte LastChar;

		/// <summary>
		/// Character table list.
		/// </summary>
		public Dictionary<byte,FontCharEntry> CharTable;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public FontData()
		{
			FontType = FontTypes.Invalid;
			CharHeight = 0;
			DefaultWidth = 0;
			Unknown1 = 0;
			FirstChar = 0;
			LastChar = 0;
			CharTable = null;
		}

		public FontData(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		/// <summary>
		/// Read Font data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			FontType = FontTypes.Invalid;
			byte[] hdr = br.ReadBytes(2);
			if (hdr[0] == FONT_HEADER_FT[0] && hdr[1] == FONT_HEADER_FT[1])
			{
				FontType = FontTypes.FT;
			}
			else if (hdr[0] == FONT_HEADER_MF[0] && hdr[1] == FONT_HEADER_MF[1])
			{
				FontType = FontTypes.MF;
			}

			if (FontType != FontTypes.Invalid)
			{
				// ok, we can read the rest of the file.
				byte[] tmp = br.ReadBytes(2);
				CharHeight = BitConverter.ToInt16(tmp, 0);

				tmp = br.ReadBytes(2);
				DefaultWidth = BitConverter.ToInt16(tmp, 0);

				tmp = br.ReadBytes(2);
				Unknown1 = BitConverter.ToInt16(tmp, 0);

				FirstChar = br.ReadByte();
				LastChar = br.ReadByte();

				// determine number of entries
				int numChars = (LastChar - FirstChar)+1;
				CharTable = new Dictionary<byte, FontCharEntry>();
				for (int i = 0; i < numChars; i++)
				{
					CharTable.Add((byte)(FirstChar+i), new FontCharEntry(br));
				}
			}
		}
	}
}
