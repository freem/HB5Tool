using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace HB5Tool
{
	/// <summary>
	/// A single entry in the table of picture entries.
	/// </summary>
	public class PicsTableEntry
	{
		#region Class Members
		/// <summary>
		/// File offset, relative to data start location.
		/// </summary>
		public uint Offset;

		/// <summary>
		/// File length.
		/// </summary>
		public ushort Length;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public PicsTableEntry()
		{
			Offset = 0;
			Length = 0;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public PicsTableEntry(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		/// <summary>
		/// Read entry data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			Offset = BitConverter.ToUInt32(br.ReadBytes(4), 0);
			Length = BitConverter.ToUInt16(br.ReadBytes(2), 0);
		}
	}

	/// <summary>
	/// Representation of PICS.BIN.
	/// </summary>
	public class PicsBin
	{
		/// <summary>
		/// All player pics are 128px wide maximum.
		/// </summary>
		public static readonly int PLAYER_PIC_WIDTH = 128;

		/// <summary>
		/// All player pics are 120px tall maximum.
		/// </summary>
		public static readonly int PLAYER_PIC_HEIGHT = 120;

		#region Class Members
		/// <summary>
		/// Unknown value 1; 0x00
		/// </summary>
		public byte Unknown1;

		/// <summary>
		/// Unknown value 2; 0x00
		/// </summary>
		public byte Unknown2;

		/// <summary>
		/// Number of entries.
		/// </summary>
		public short NumEntries;

		/// <summary>
		/// File offset of the entry table.
		/// </summary>
		public UInt32 TableOffset;

		/// <summary>
		/// File offset where picture data begins.
		/// </summary>
		public UInt32 DataOffset;

		/// <summary>
		/// Entries in this Pics file.
		/// </summary>
		public List<PicsTableEntry> Entries;

		/// <summary>
		/// Each picture's data.
		/// </summary>
		public Dictionary<int, byte[]> PicData;

		/// <summary>
		/// Rendered Bitmaps
		/// </summary>
		public Dictionary<int, Bitmap> RenderedPics;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public PicsBin()
		{
			Unknown1 = 0;
			Unknown2 = 0;
			NumEntries = 0;
			TableOffset = 0;
			DataOffset = 0;
			Entries = null;
			PicData = null;
			RenderedPics = null;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public PicsBin(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		/// <summary>
		/// Read Pics data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			Unknown1 = br.ReadByte();
			Unknown2 = br.ReadByte();

			NumEntries = BitConverter.ToInt16(br.ReadBytes(2),0);
			TableOffset = BitConverter.ToUInt32(br.ReadBytes(4), 0);
			DataOffset = BitConverter.ToUInt32(br.ReadBytes(4), 0);

			br.BaseStream.Seek(TableOffset,SeekOrigin.Begin);
			Entries = new List<PicsTableEntry>();
			for (int i = 0; i < NumEntries; i++)
			{
				Entries.Add(new PicsTableEntry(br));
			}

			// grab pixel data
			PicData = new Dictionary<int, byte[]>();
			// note: "proper" picture ordering starts at 0x0001
			int picNum = 0;
			foreach (PicsTableEntry pte in Entries)
			{
				PicData.Add(picNum, ExtractPic(picNum, br));
				++picNum;
			}

			// convert each image so they can be displayed in the UI
			RenderedPics = new Dictionary<int, Bitmap>();
			foreach (KeyValuePair<int,byte[]> pic in PicData)
			{
				RenderedPics.Add(pic.Key, ToBitmap(pic.Value));
			}
		}

		public byte[] ExtractPic(int picNum, BinaryReader br)
		{
			br.BaseStream.Seek(DataOffset + Entries[picNum].Offset, SeekOrigin.Begin);
			return br.ReadBytes(Entries[picNum].Length);
		}

		public Bitmap ToBitmap(byte[] _inPixels)
		{
			MemoryStream inData = new MemoryStream(_inPixels);
			BinaryReader inReader = new BinaryReader(inData);
			List<byte> pixelData = new List<byte>();

			// handle initial 0x00 value.
			byte value = inReader.ReadByte();

			// read loop until end of data
			while (inData.Position < inData.Length)
			{
				value = inReader.ReadByte();
				if ((value & 0xC0) >= 0xC0)
				{
					if (inData.Position == inData.Length)
					{
						Console.WriteLine(String.Format("[PicsBin.ToBitmap] Unexpected end of data after RLE byte (value 0x{0:X2}, length=0x{1:X2})", value, (value&0x3F)));
						break;
					}

					// run of pixels; length is this byte & 0x3F; value is next byte
					int len = (value & 0x3F);
					value = inReader.ReadByte();
					for (int i = 0; i < len; i++)
					{
						pixelData.Add(value);
					}
				}
				else
				{
					// raw pixel, insert as-is and go to next byte
					pixelData.Add(value);
				}
			}
			inReader.Dispose();

			Bitmap saveTarget = new Bitmap(PLAYER_PIC_WIDTH, PLAYER_PIC_HEIGHT, PixelFormat.Format8bppIndexed);
			// enforce pic-safe palette
			ColorPalette picPal = saveTarget.Palette;
			DefaultData.PlayerPicSafePalette.CopyTo(picPal.Entries, 0);
			saveTarget.Palette = picPal;

			// copy pixels
			BitmapData bData = saveTarget.LockBits(new Rectangle(0, 0, PLAYER_PIC_WIDTH, PLAYER_PIC_HEIGHT), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
			IntPtr imageDataPtr = bData.Scan0;
			int numBytes = Math.Abs(bData.Stride) * PLAYER_PIC_HEIGHT;
			byte[] bPixels = new byte[numBytes];
			Marshal.Copy(imageDataPtr, bPixels, 0, numBytes);

			// XXX HACK
			if (pixelData.Count < numBytes)
			{
				for (int i = 0; i < (numBytes - pixelData.Count); i++)
				{
					pixelData.Add((byte)0);
				}
			}
			else if(pixelData.Count > numBytes)
			{
				// wait, picture is too big??
				Console.WriteLine(String.Format("[PicsBin.ToBitmap] pixelData.Count {0} > numBytes {1} ???", pixelData.Count, numBytes));
			}

			bPixels = pixelData.ToArray();
			Marshal.Copy(bPixels, 0, imageDataPtr, numBytes);
			saveTarget.UnlockBits(bData);

			return saveTarget;
		}

		public bool ImportImage()
		{
			// write 0x00 as first byte
			// then the challenging part, encoding the image

			// color 0x0D is used for transparency.

			// if a color from 0xC0-0xFF needs to be written, then it needs a command first,
			// even if it's just one pixel.

			// need to determine if a run length is required; maximum amount is 63 bytes (0xFF).
			// so if the run is longer, it needs to be converted to two or more runs.

			return true;
		}

		// first byte is always 0x00
		// then check byte value; if byte & 0xC0 != 0, this is a repeat command.
		public void ExportPic(string _outFile, int picNum)
		{
			// todo: refactor this; this was just the test run
			MemoryStream inData = new MemoryStream(PicData[picNum]);
			BinaryReader inReader = new BinaryReader(inData);

			List<byte> pixelData = new List<byte>();

			// handle initial 0x00 value.
			byte value = inReader.ReadByte();
			while (inData.Position < inData.Length)
			{
				value = inReader.ReadByte();
				if ((value & 0xC0) >= 0xC0)
				{
					// run of pixels; length is this byte & 0x3F; value is next byte
					int len = (value & 0x3F);
					value = inReader.ReadByte();
					for (int i = 0; i < len; i++)
					{
						pixelData.Add(value);
					}
				}
				else
				{
					// raw pixel, insert as-is and go to next byte
					pixelData.Add(value);
				}
			}
			inReader.Dispose();

			Bitmap saveTarget = new Bitmap(PLAYER_PIC_WIDTH, PLAYER_PIC_HEIGHT, PixelFormat.Format8bppIndexed);
			// enforce pic-safe palette
			ColorPalette picPal = saveTarget.Palette;
			DefaultData.PlayerPicSafePalette.CopyTo(picPal.Entries, 0);
			saveTarget.Palette = picPal;

			// copy pixels
			BitmapData bData = saveTarget.LockBits(new Rectangle(0, 0, PLAYER_PIC_WIDTH, PLAYER_PIC_HEIGHT), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
			IntPtr imageDataPtr = bData.Scan0;
			int numBytes = Math.Abs(bData.Stride) * PLAYER_PIC_HEIGHT;
			byte[] bPixels = new byte[numBytes];
			Marshal.Copy(imageDataPtr, bPixels, 0, numBytes);

			// XXX HACK
			if (pixelData.Count < numBytes)
			{
				for (int i = 0; i < (numBytes - pixelData.Count); i++)
				{
					pixelData.Add((byte)0);
				}
			}
			else if (pixelData.Count > numBytes)
			{
				// wait, picture is too big??
				Console.WriteLine(String.Format("[PicsBin.ExportPic] pixelData.Count {0} > numBytes {1} ???", pixelData.Count, numBytes));
			}

			bPixels = pixelData.ToArray();
			Marshal.Copy(bPixels, 0, imageDataPtr, numBytes);
			saveTarget.UnlockBits(bData);
			saveTarget.Save(_outFile, ImageFormat.Png);
		}
	}
}
