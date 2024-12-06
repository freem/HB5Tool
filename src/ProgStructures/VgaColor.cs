using System;
using System.Drawing;
using System.IO;

namespace HB5Tool
{
	public class VgaColor
	{
		#region Class Members
		/// <summary>
		/// Red channel value.
		/// </summary>
		public byte Red;

		/// <summary>
		/// Green channel value.
		/// </summary>
		public byte Green;

		/// <summary>
		/// Blue channel value.
		/// </summary>
		public byte Blue;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public VgaColor()
		{
			Red = 0;
			Green = 0;
			Blue = 0;
		}

		/// <summary>
		/// Constructor using specific values.
		/// </summary>
		/// <param name="_r">Red channel value.</param>
		/// <param name="_g">Green channel value.</param>
		/// <param name="_b">Blue channel value.</param>
		public VgaColor(byte _r, byte _g, byte _b)
		{
			Red = _r;
			Green = _g;
			Blue = _b;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public VgaColor(BinaryReader br)
		{
			ReadColor(br);
		}

		/// <summary>
		/// Constructor using a Color.
		/// </summary>
		/// <param name="_c">Color to convert.</param>
		public VgaColor(Color _c)
		{
			Red = (byte)(_c.R >> 2);
			Green = (byte)(_c.G >> 2);
			Blue = (byte)(_c.B >> 2);
		}
		#endregion

		/// <summary>
		/// Read a VgaColor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadColor(BinaryReader br)
		{
			Red = br.ReadByte();
			Green = br.ReadByte();
			Blue = br.ReadByte();
		}

		/// <summary>
		/// Get an 8bpp version of this VgaColor.
		/// </summary>
		/// <returns>Color</returns>
		public Color GetColor()
		{
			return Color.FromArgb((Red * 255) / 63, (Green * 255) / 63, (Blue * 255) / 63);
		}
	}
}
