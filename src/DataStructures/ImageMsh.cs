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
			BitmapData bData = outBitmap.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

			bool differingStride = false;
			if (Math.Abs(bData.Stride) != Width)
			{
				differingStride = true;
			}

			// use default palette. it may not be the correct one, however...
			ColorPalette colPal = outBitmap.Palette;
			DefaultData.DefaultPalette.CopyTo(colPal.Entries, 0);
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
					// compressed 8bpp
					byte[] rawPixels;
					if (differingStride)
					{
						rawPixels = new byte[Math.Abs(bData.Stride) * Height];
					}
					else
					{
						rawPixels = new byte[Width * Height];
					}

					MemoryStream inMS = new MemoryStream(ImageData);
					BinaryReader inBR = new BinaryReader(inMS);

					MemoryStream outMS = new MemoryStream();
					BinaryWriter outBW = new BinaryWriter(outMS);

					int numPixProcessed = 0;
					bool processEmpty = true;
					for (int y = 0; y < Height; y++)
					{
						// for each row:
						// - start with number of empty pixels on left
						// - alternate between regular runs and empty runs until end of line
						//   (regular run is length followed by that many bytes).
						// - end with number of empty pixels on right
						// need to keep track of the number of pixels processed per row

						numPixProcessed = 0;

						// left side empty pixels
						int numEmptyLeftSide = inBR.ReadByte();
						Console.WriteLine(String.Format("left side empty pixels: {0}",numEmptyLeftSide));
						if (numEmptyLeftSide > 0)
						{
							for (int i = 0; i < numEmptyLeftSide; i++)
							{
								outBW.Write((byte)0);
							}
							numPixProcessed += numEmptyLeftSide;
						}

						// then alternate between regular pixel runs and empty pixel runs
						// todo: check if an empty run will complete a row.
						processEmpty = false;

						while (numPixProcessed < Width)
						{
							Console.WriteLine(String.Format("pixels processed: {0}/{1}", numPixProcessed, Width));
							if (processEmpty)
							{
								// empty pixel run
								int emptyRunLength = inBR.ReadByte();
								Console.WriteLine(String.Format("empty run: {0}", emptyRunLength));
								if (emptyRunLength > 0)
								{
									for (int i = 0; i < emptyRunLength; i++)
									{
										outBW.Write((byte)0);
									}
									numPixProcessed += emptyRunLength;
								}

								if (numPixProcessed == Width)
								{
									Console.WriteLine("HEY! we're done with this row!");
									processEmpty = false;
								}

								// next will be a regular pixel run, unless we've reached the end of the row or image.
								processEmpty = false;
							}
							else
							{
								// pixel data run
								int runLength = inBR.ReadByte();
								Console.WriteLine(String.Format("data run: {0}", runLength));
								byte[] pixelRun = inBR.ReadBytes(runLength);
								
								outBW.Write(pixelRun);
								numPixProcessed += runLength;

								// next will be an empty pixel data run, even if that length is 0.
								processEmpty = true;
							}
						}

						if (processEmpty)
						{
							Console.WriteLine("still wants to process empty");
							// the last empty pixel run for this row
							int emptyRunLength = inBR.ReadByte();
							Console.WriteLine(String.Format("right side empty pixels: {0}", emptyRunLength));
							if (emptyRunLength > 0)
							{
								for (int i = 0; i < emptyRunLength; i++)
								{
									outBW.Write((byte)0);
								}
								numPixProcessed += emptyRunLength;
							}
						}

						if (numPixProcessed < Math.Abs(bData.Stride))
						{
							for (int i = 0; i < Math.Abs(bData.Stride) - numPixProcessed; i++)
							{
								outBW.Write((byte)0);
							}
						}

						Console.WriteLine(String.Format("pixels processed this row: {0}/{1}", numPixProcessed, Width));
					}

					rawPixels = outMS.ToArray();

					inBR.Dispose();
					outBW.Dispose();

					//bData = outBitmap.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
					IntPtr imageDataPtr = bData.Scan0;
					int numBytes = Math.Abs(bData.Stride) * Height;
					byte[] bPixels = new byte[numBytes];
					Marshal.Copy(imageDataPtr, bPixels, 0, numBytes);
					bPixels = rawPixels;
					Marshal.Copy(bPixels, 0, imageDataPtr, bPixels.Length);
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
					//bData = outBitmap.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
					IntPtr imageDataPtr = bData.Scan0;
					int numBytes = Math.Abs(bData.Stride) * Height;
					//int numBytes = Width * Height;
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
