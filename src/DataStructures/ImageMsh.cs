using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

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

		public Bitmap DecodeImage()
		{
			// xxx: 8bpp assumption
			Bitmap outBitmap = new Bitmap(Width, Height, PixelFormat.Format8bppIndexed);

			// palette stuff is tricky; assume player pal for now
			ColorPalette colPal = outBitmap.Palette;
			DefaultData.PlayerPicSafePalette.CopyTo(colPal.Entries, 0);
			outBitmap.Palette = colPal;

			//BitmapData bData = outBitmap.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
			//IntPtr imageDataPtr = bData.Scan0;
			//int numBytes = Math.Abs(bData.Stride) * Height;
			//byte[] bPixels = new byte[numBytes];
			//Marshal.Copy(imageDataPtr, bPixels, 0, numBytes);
			//bPixels = pixelData.ToArray();
			//Marshal.Copy(bPixels, 0, imageDataPtr, numBytes);
			//saveTarget.UnlockBits(bData);

			if (IsCompressed())
			{
				if (Is4BPP())
				{
					// compressed 4bpp, idk how to handle these
				}
				else
				{
					// compressed 8bpp, i only semi-know how to handle these.
					byte[] rawPixels = new byte[Width * Height];

					MemoryStream inMS = new MemoryStream(ImageData);
					BinaryReader inBR = new BinaryReader(inMS);

					MemoryStream outMS = new MemoryStream();
					BinaryWriter outBW = new BinaryWriter(outMS);

					int numPixProcessed = 0;
					bool processEmpty = true;
					bool rowComplete = false;
					for (int y = 0; y < Height; y++)
					{
						// for each row:
						// - start with number of empty pixels on left
						// - alternate between regular runs and empty runs until end of line
						//   (regular run is length followed by that many bytes).
						// - end with number of empty pixels on right
						// need to keep track of the number of pixels processed per row

						// todo: check if an empty run will complete a row.


						// todo: below code is not 100% correct, needs better handling
						while (numPixProcessed < Width)
						{
							Console.WriteLine(string.Format("row {0} col {1}/{2}", y, numPixProcessed, Width));
							if (processEmpty)
							{
								// read byte, write out that many transparent pixels
								int numEmpty = inBR.ReadByte();
								Console.WriteLine(string.Format("empty pixel run: 0x{0:X2}", numEmpty));
								if (numEmpty > 0)
								{
									for (int i = 0; i < numEmpty; i++)
									{
										outBW.Write((byte)0);
									}
									numPixProcessed += numEmpty;
								}

								// flip the switch (though it may get re-flipped if this is the end of the row)
								processEmpty = false;
							}
							else
							{
								// read byte, get number of bytes from value, write pixels
								int numPix = inBR.ReadByte();
								Console.WriteLine(string.Format("pixel run: 0x{0:X2}", numPix));
								byte[] pixelRun = inBR.ReadBytes(numPix);
								
								outBW.Write(pixelRun);
								numPixProcessed += numPix;

								for (int i = 0; i < numPix; i++)
								{
									Console.Write(string.Format("{0:X2} ",pixelRun[i]));
								}
								Console.WriteLine();

								// flip the switch
								processEmpty = true;
							}
						}
						Console.WriteLine(string.Format("processed pixels: {0}", numPixProcessed));

						// reset values for next row
						numPixProcessed = 0;
						processEmpty = true;
					}

					rawPixels = outMS.ToArray();

					inBR.Dispose();
					outBW.Dispose();

					BitmapData bData = outBitmap.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
					IntPtr imageDataPtr = bData.Scan0;
					//int numBytes = Math.Abs(bData.Stride) * Height;
					int numBytes = Width * Height;
					byte[] bPixels = new byte[numBytes];
					Marshal.Copy(imageDataPtr, bPixels, 0, numBytes);
					bPixels = rawPixels;
					Marshal.Copy(bPixels, 0, imageDataPtr, numBytes);
					outBitmap.UnlockBits(bData);
				}
			}
			else
			{
				if (Is4BPP())
				{
					// 4bpp uncompressed. does this even exist?
				}
				else
				{
					// uncompressed? let's just dump the pixels then.
					BitmapData bData = outBitmap.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
					IntPtr imageDataPtr = bData.Scan0;
					//int numBytes = Math.Abs(bData.Stride) * Height;
					int numBytes = Width * Height;
					byte[] bPixels = new byte[numBytes];
					Marshal.Copy(imageDataPtr, bPixels, 0, numBytes);
					bPixels = ImageData;
					Marshal.Copy(bPixels, 0, imageDataPtr, numBytes);
					outBitmap.UnlockBits(bData);
				}
			}

			return outBitmap;
		}
	}
}
