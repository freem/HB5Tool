using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Threading.Tasks;

namespace HB5Tool
{
	/// <summary>
	/// An image found inside of a MSH file.
	/// </summary>
	public class ImageMsh
	{
		#region Class Members
		/// <summary>
		/// Image width.
		/// </summary>
		/// offset 0
		public short Width;

		/// <summary>
		/// Image height.
		/// </summary>
		/// offset 2
		public short Height;

		/// <summary>
		/// Image X/horizontal offset. Negative values move the image to the right...?
		/// </summary>
		/// offset 4
		public short OffsetX;

		/// <summary>
		/// Image Y/vertical offset. Negative values move the image downward...?
		/// </summary>
		/// offset 6
		public short OffsetY;

		/// <summary>
		/// Unknown value
		/// </summary>
		/// offset 8
		public short Unknown;

		/// <summary>
		/// Image flags.
		/// </summary>
		/// offset 0xA
		public short Flags;

		// data size
		/// <summary>
		/// Size of the pixel data.
		/// </summary>
		/// offset 0xC
		public ushort DataSize;

		/// <summary>
		/// Image pixel data.
		/// </summary>
		public byte[] ImageData;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public ImageMsh()
		{
			Width = 0;
			Height = 0;
			OffsetX = 0;
			OffsetY = 0;
			Unknown = 0;
			Flags = 0;
			DataSize = 0;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader</param>
		public ImageMsh(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		/// <summary>
		/// Read an MSH image using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			Width = BitConverter.ToInt16(br.ReadBytes(2),0);
			Height = BitConverter.ToInt16(br.ReadBytes(2),0);
			OffsetX = BitConverter.ToInt16(br.ReadBytes(2),0);
			OffsetY = BitConverter.ToInt16(br.ReadBytes(2),0);
			Unknown = BitConverter.ToInt16(br.ReadBytes(2),0);
			Flags = BitConverter.ToInt16(br.ReadBytes(2),0);
			DataSize = BitConverter.ToUInt16(br.ReadBytes(2),0);
			ImageData = br.ReadBytes(DataSize);
		}

		/// <summary>
		/// Is this image compressed or not?
		/// </summary>
		/// <returns>True if the most significant bit of the Flags is set, false otherwise.</returns>
		public bool IsCompressed()
		{
			return (Flags & 0x8000) != 0;
		}

		/// <summary>
		/// Is this image 4bpp?
		/// </summary>
		/// <returns>True if the second most significant bit of the Flags is set, false otherwise.</returns>
		public bool Is4BPP()
		{
			return (Flags & 0x4000) != 0;
		}
	}
}
