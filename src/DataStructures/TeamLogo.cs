using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace HB5Tool
{
	/// <summary>
	/// A team logo; 48x32px worth of data using a fixed palette.
	/// </summary>
	public class TeamLogo
	{
		/// <summary>
		/// Logo width, in pixels.
		/// </summary>
		public static readonly int LOGO_WIDTH = 48;

		/// <summary>
		/// Logo height, in pixels.
		/// </summary>
		public static readonly int LOGO_HEIGHT = 32;

		#region Class Members
		/// <summary>
		/// Logo pixel data.
		/// </summary>
		public byte[] PixelData;

		/// <summary>
		/// Logo as a Bitmap object.
		/// </summary>
		public Bitmap LogoBitmap;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public TeamLogo()
		{
			PixelData = null;
			LogoBitmap = null;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public TeamLogo(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		/// <summary>
		/// Read logo data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			PixelData = br.ReadBytes(LOGO_HEIGHT*LOGO_WIDTH);

			LogoBitmap = new Bitmap(LOGO_WIDTH, LOGO_HEIGHT, PixelFormat.Format8bppIndexed);

			// enforce logo-safe palette
			ColorPalette logoPal = LogoBitmap.Palette;
			DefaultData.LogoSafePalette.CopyTo(logoPal.Entries, 0);
			LogoBitmap.Palette = logoPal;

			BitmapData bData = LogoBitmap.LockBits(new Rectangle(0, 0, LOGO_WIDTH, LOGO_HEIGHT), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
			IntPtr imageDataPtr = bData.Scan0;
			int numBytes = Math.Abs(bData.Stride) * LOGO_HEIGHT;
			byte[] bPixels = new byte[numBytes];
			Marshal.Copy(imageDataPtr, bPixels, 0, numBytes);
			bPixels = PixelData;
			Marshal.Copy(bPixels, 0, imageDataPtr, numBytes);
			LogoBitmap.UnlockBits(bData);
		}

		/// <summary>
		/// Write raw logo data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			bw.Write(PixelData);
		}

		/// <summary>
		/// Export logo as a PNG file.
		/// </summary>
		/// <param name="_fileName">Exported filename.</param>
		public void ExportImage(string _fileName)
		{
			LogoBitmap.Save(_fileName, ImageFormat.Png);
		}

		/// <summary>
		/// Import an image as a logo.
		/// </summary>
		/// <param name="_fileName">Path to 8bpp indexed PNG file to convert.</param>
		/// <returns></returns>
		public bool ImportImage(string _fileName)
		{
			Bitmap loadTarget = new Bitmap(LOGO_WIDTH, LOGO_HEIGHT, PixelFormat.Format8bppIndexed);
			// enforce logo-safe palette
			ColorPalette logoPal = loadTarget.Palette;
			DefaultData.LogoSafePalette.CopyTo(logoPal.Entries, 0);
			loadTarget.Palette = logoPal;

			Bitmap inBmp = new Bitmap(_fileName);
			loadTarget = inBmp.Clone(new Rectangle(0, 0, LOGO_WIDTH, LOGO_HEIGHT), PixelFormat.Format8bppIndexed);
			inBmp.Dispose();

			BitmapData bmData = loadTarget.LockBits(new Rectangle(0, 0, LOGO_WIDTH, LOGO_HEIGHT), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
			IntPtr inDataPtr = bmData.Scan0;
			int numBytes = Math.Abs(bmData.Stride) * LOGO_HEIGHT;
			byte[] bPixels = new byte[numBytes];
			Marshal.Copy(inDataPtr, bPixels, 0, numBytes);
			PixelData = bPixels;
			loadTarget.UnlockBits(bmData);

			return true;
		}
	}
}
