using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HB5Tool
{
	public partial class StadiumInfoEditor : Form
	{
		/// <summary>
		/// Provided solely so the main form can hide the Window menu if the last form is closed.
		/// </summary>
		public event EventHandler CloseFormCallback;

		/// <summary>
		/// Current active MGS file.
		/// </summary>
		public StadiumInfo CurStadiumInfoFile;

		/// <summary>
		/// Path to MGS file.
		/// </summary>
		public string FilePath;

		public StadiumInfoEditor(string _filePath)
		{
			InitializeComponent();
			FilePath = _filePath;
			tssLabelFilePath.Text = FilePath;
			Text = string.Format("Stadium Info Editor - {0}", Path.GetFileName(FilePath));

			using (FileStream fs = new FileStream(FilePath, FileMode.Open))
			{
				using (BinaryReader br = new BinaryReader(fs))
				{
					CurStadiumInfoFile = new StadiumInfo(br);
				}
			}

			StringBuilder sb = new StringBuilder();
			sb.AppendLine(String.Format("Unknown at offset 0: 0x{0:X2}", CurStadiumInfoFile.Unknown1));
			sb.AppendLine(String.Format("Stadium Type: 0x{0:X2} ({1})", (byte)CurStadiumInfoFile.StadiumType, CurStadiumInfoFile.StadiumType));
			sb.AppendLine(String.Format("Turf Type: 0x{0:X2} ({1})", (byte)CurStadiumInfoFile.TurfType, CurStadiumInfoFile.TurfType));
			sb.AppendLine(String.Format("Unknown at offset 3: 0x{0:X2}", CurStadiumInfoFile.Unknown2));
			sb.AppendLine(String.Format("Maximum Attendance: {0} (0x{0:X4})", CurStadiumInfoFile.MaxAttendance));
			sb.AppendLine(String.Format("Name: {0}", CurStadiumInfoFile.Name));
			sb.AppendLine(String.Format("Description: {0}", CurStadiumInfoFile.Description));
			sb.AppendLine();

			sb.AppendLine("Custom Color Set 1 (16 colors at palette index 0x20)");
			for (int i = 0; i < CurStadiumInfoFile.ColorSet1.Length; i++)
			{
				VgaColor c = CurStadiumInfoFile.ColorSet1[i];
				sb.AppendLine(String.Format("[{0:D2}] 8bpp rgb {1}", i, c.GetColor().ToString()));
			}
			sb.AppendLine();

			sb.AppendLine("Custom Color Set 2 (16 colors at palette index 0x30)");
			for (int i = 0; i < CurStadiumInfoFile.ColorSet2.Length; i++)
			{
				VgaColor c = CurStadiumInfoFile.ColorSet2[i];
				sb.AppendLine(String.Format("[{0:D2}] 8bpp rgb {1}", i, c.GetColor().ToString()));
			}
			sb.AppendLine();

			sb.AppendLine("Custom Color Set 3 (12 colors at palette index 0x40)");
			for (int i = 0; i < CurStadiumInfoFile.ColorSet3.Length; i++)
			{
				VgaColor c = CurStadiumInfoFile.ColorSet3[i];
				sb.AppendLine(String.Format("[{0:D2}] 8bpp rgb {1}", i, c.GetColor().ToString()));
			}
			sb.AppendLine();

			sb.AppendLine("Custom Color Set 4 (8 colors at palette index 0xB8)");
			for (int i = 0; i < CurStadiumInfoFile.ColorSet4.Length; i++)
			{
				VgaColor c = CurStadiumInfoFile.ColorSet4[i];
				sb.AppendLine(String.Format("[{0:D2}] 8bpp rgb {1}", i, c.GetColor().ToString()));
			}
			sb.AppendLine();

			tbOutput.Text = sb.ToString();

			// color sets
			Bitmap ColorSet1 = new Bitmap(pbColorSet1.Width, pbColorSet1.Height);
			Graphics g = Graphics.FromImage(ColorSet1);
			Pen curPen;

			int swatchWidth = (pbColorSet1.Width / 16);
			for (int i = 0; i < CurStadiumInfoFile.ColorSet1.Length; i++)
			{
				curPen = new Pen(CurStadiumInfoFile.ColorSet1[i].GetColor());
				g.FillRectangle(curPen.Brush, new Rectangle(i*swatchWidth, 0, swatchWidth, pbColorSet1.Height));
			}
			pbColorSet1.Image = ColorSet1;

			Bitmap ColorSet2 = new Bitmap(pbColorSet2.Width, pbColorSet2.Height);
			g = Graphics.FromImage(ColorSet2);
			for (int i = 0; i < CurStadiumInfoFile.ColorSet2.Length; i++)
			{
				curPen = new Pen(CurStadiumInfoFile.ColorSet2[i].GetColor());
				g.FillRectangle(curPen.Brush, new Rectangle(i * swatchWidth, 0, swatchWidth, pbColorSet2.Height));
			}
			pbColorSet2.Image = ColorSet2;

			swatchWidth = (pbColorSet3.Width / 12);
			Bitmap ColorSet3 = new Bitmap(pbColorSet3.Width, pbColorSet3.Height);
			g = Graphics.FromImage(ColorSet3);
			for (int i = 0; i < CurStadiumInfoFile.ColorSet3.Length; i++)
			{
				curPen = new Pen(CurStadiumInfoFile.ColorSet3[i].GetColor());
				g.FillRectangle(curPen.Brush, new Rectangle(i * swatchWidth, 0, swatchWidth, pbColorSet3.Height));
			}
			pbColorSet3.Image = ColorSet3;

			//CurStadiumInfoFile.ColorSet4
			swatchWidth = (pbColorSet4.Width / 8);
			Bitmap ColorSet4 = new Bitmap(pbColorSet4.Width, pbColorSet4.Height);
			g = Graphics.FromImage(ColorSet4);
			for (int i = 0; i < CurStadiumInfoFile.ColorSet4.Length; i++)
			{
				curPen = new Pen(CurStadiumInfoFile.ColorSet4[i].GetColor());
				g.FillRectangle(curPen.Brush, new Rectangle(i * swatchWidth, 0, swatchWidth, pbColorSet4.Height));
			}
			pbColorSet4.Image = ColorSet4;

			g.Dispose();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
			CloseFormCallback?.Invoke(this, e);
		}

		private void StadiumInfoEditor_FormClosed(object sender, FormClosedEventArgs e)
		{
			CloseFormCallback?.Invoke(this, e);
		}
	}
}
