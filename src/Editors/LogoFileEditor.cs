using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HB5Tool
{
	/// <summary>
	/// Editor for LOGOFILE.BIN
	/// </summary>
	public partial class LogoFileEditor : Form
	{
		/// <summary>
		/// Provided solely so the main form can hide the Window menu if the last form is closed.
		/// </summary>
		public event EventHandler CloseFormCallback;

		/// <summary>
		/// Path to current logo file.
		/// </summary>
		public string FilePath;

		/// <summary>
		/// Number of logos in logo file.
		/// </summary>
		public short NumLogos;

		/// <summary>
		/// Logos in the logo file.
		/// </summary>
		public List<TeamLogo> Logos;

		public LogoFileEditor(string _filePath)
		{
			InitializeComponent();

			FilePath = _filePath;
			tssLabelFilePath.Text = FilePath;

			using (FileStream fs = new FileStream(FilePath, FileMode.Open))
			{
				using (BinaryReader br = new BinaryReader(fs))
				{
					NumLogos = BitConverter.ToInt16(br.ReadBytes(2), 0);
					Logos = new List<TeamLogo>();
					for (int i = 0; i < NumLogos; i++)
					{
						Logos.Add(new TeamLogo(br));
					}
				}
			}

			ImageList icons = new ImageList();
			icons.ImageSize = new Size(TeamLogo.LOGO_WIDTH, TeamLogo.LOGO_HEIGHT);
			foreach (TeamLogo l in Logos)
			{
				// transparency hack
				ColorPalette cpal = l.LogoBitmap.Palette;
				cpal.Entries[0] = Color.FromArgb(0,0,0,0);
				l.LogoBitmap.Palette = cpal;

				icons.Images.Add(l.LogoBitmap);
			}
			lvLogos.LargeImageList = icons;
			for (int i = 0; i < NumLogos; i++)
			{
				lvLogos.Items.Add(string.Format("Logo {0}", i), i);
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
			CloseFormCallback?.Invoke(this, e);
		}

		private void LogoFileEditor_FormClosed(object sender, FormClosedEventArgs e)
		{
			CloseFormCallback?.Invoke(this, e);
		}

		private void exportPNGToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lvLogos.SelectedItems.Count <= 0)
			{
				return;
			}

			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Export Logo as PNG";
			sfd.Filter = string.Format("{0}|{1}", SharedStrings.PngFilter, SharedStrings.AllFilter);
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				Logos[lvLogos.SelectedIndices[0]].ExportImage(sfd.FileName);
			}
		}

		private void exportDataToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lvLogos.SelectedItems.Count <= 0)
			{
				return;
			}

			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Export Raw Logo";
			sfd.Filter = string.Format("{0}|{1}", SharedStrings.LogoFilter, SharedStrings.AllFilter);
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
				{
					using (BinaryWriter bw = new BinaryWriter(fs))
					{
						Logos[lvLogos.SelectedIndices[0]].WriteData(bw);
					}
				}
			}
		}

		private void importPNGToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Import Logo from PNG";
			ofd.Filter = SharedStrings.PngFilter;
			ofd.Multiselect = false;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				// you need to be sure this file doesn't suck

				// update logo and update display
			}
		}

		private void importRawLogoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Import Logo";
			ofd.Filter = SharedStrings.LogoFilter;
			ofd.Multiselect = false;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				// update logo and update display
			}
		}
	}
}
