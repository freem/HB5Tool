﻿using System;
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
	public partial class CustomBinEditor : Form
	{
		/// <summary>
		/// Provided solely so the main form can hide the Window menu if the last form is closed.
		/// </summary>
		public event EventHandler CloseFormCallback;

		/// <summary>
		/// Loaded CUSTOM.BIN data
		/// </summary>
		public CustomBin CustomData;

		/// <summary>
		/// Path to CUSTOM.BIN (or equivalent)
		/// </summary>
		public string FilePath;

		public CustomBinEditor(string _filePath)
		{
			InitializeComponent();
			FilePath = _filePath;
			tssLabelFilePath.Text = FilePath;
			Text = string.Format("CUSTOM.BIN Editor - {0}", Path.GetFileName(FilePath));

			using (FileStream fs = new FileStream(FilePath, FileMode.Open))
			{
				using (BinaryReader br = new BinaryReader(fs))
				{
					CustomData = new CustomBin(br);
				}
			}

			ImageList icons = new ImageList();

			// transparency hack
			Bitmap logo_AL = CustomData.Logo_AL.LogoBitmap.Clone(new Rectangle(0,0,TeamLogo.LOGO_WIDTH,TeamLogo.LOGO_HEIGHT), PixelFormat.Format8bppIndexed);
			ColorPalette cpal = logo_AL.Palette;
			cpal.Entries[0] = Color.FromArgb(0, 0, 0, 0);
			logo_AL.Palette = cpal;

			Bitmap logo_NL = CustomData.Logo_NL.LogoBitmap.Clone(new Rectangle(0, 0, TeamLogo.LOGO_WIDTH, TeamLogo.LOGO_HEIGHT), PixelFormat.Format8bppIndexed);
			cpal = logo_NL.Palette;
			cpal.Entries[0] = Color.FromArgb(0, 0, 0, 0);
			logo_NL.Palette = cpal;

			Bitmap logo_Legends = CustomData.Logo_Legends.LogoBitmap.Clone(new Rectangle(0, 0, TeamLogo.LOGO_WIDTH, TeamLogo.LOGO_HEIGHT), PixelFormat.Format8bppIndexed);
			cpal = logo_Legends.Palette;
			cpal.Entries[0] = Color.FromArgb(0, 0, 0, 0);
			logo_Legends.Palette = cpal;

			Bitmap logo_Immortals = CustomData.Logo_Immortals.LogoBitmap.Clone(new Rectangle(0, 0, TeamLogo.LOGO_WIDTH, TeamLogo.LOGO_HEIGHT), PixelFormat.Format8bppIndexed);
			cpal = logo_Immortals.Palette;
			cpal.Entries[0] = Color.FromArgb(0, 0, 0, 0);
			logo_Immortals.Palette = cpal;

			icons.Images.Add(logo_AL);
			icons.Images.Add(logo_NL);
			icons.Images.Add(logo_Legends);
			icons.Images.Add(logo_Immortals);
			lvIcons.LargeImageList = icons;
			lvIcons.Items.Add("AL",0);
			lvIcons.Items.Add("NL",1);
			lvIcons.Items.Add("Legends",2);
			lvIcons.Items.Add("Immortals",3);
			icons.ImageSize = new Size(TeamLogo.LOGO_WIDTH, TeamLogo.LOGO_HEIGHT);

			tbStarsGame.Text = CustomData.StarsGame;
			tbPlayoffs.Text = CustomData.Playoffs;
			tbLeagueChamp.Text = CustomData.LeagueChampionships;
			tbWorldChamp.Text = CustomData.WorldChampionships;
			tbLeagueA.Text = CustomData.LeagueAmerican;
			tbLeagueN.Text = CustomData.LeagueNational;

			cbInjuries.Checked = CustomData.Injuries;
			cbComTrades.Checked = CustomData.ComputerTrades;
			cbComRejectTrades.Checked = CustomData.ComputerCanRejectTrades;
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
			CloseFormCallback?.Invoke(this, e);
		}

		private void CustomBinEditor_FormClosed(object sender, FormClosedEventArgs e)
		{
			CloseFormCallback?.Invoke(this, e);
		}

		private void saveChangesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// update internal structure with new data

			// todo: logos

			CustomData.StarsGame = tbStarsGame.Text;
			CustomData.Playoffs = tbPlayoffs.Text;
			CustomData.LeagueChampionships = tbLeagueChamp.Text;
			CustomData.WorldChampionships = tbWorldChamp.Text;
			CustomData.LeagueAmerican = tbLeagueA.Text;
			CustomData.LeagueNational = tbLeagueN.Text;

			CustomData.Injuries = cbInjuries.Checked;
			CustomData.ComputerTrades = cbComTrades.Checked;
			CustomData.ComputerCanRejectTrades = cbComRejectTrades.Checked;

			// write back whatever changes have been made
			MessageBox.Show("todo: actually write data back to the file");
		}

		private TeamLogo GetLogoFromIndex(int _idx)
		{
			switch (_idx)
			{
				case 0: return CustomData.Logo_AL;
				case 1: return CustomData.Logo_NL;
				case 2: return CustomData.Logo_Legends;
				case 3: return CustomData.Logo_Immortals;
			}
			return null;
		}

		private string[] LogoFilenames =
		{
			"AL",
			"NL",
			"Legends",
			"Immortals"
		};

		private void exportLogoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lvIcons.SelectedIndices.Count <= 0)
			{
				return;
			}

			if (lvIcons.SelectedIndices.Count > 1)
			{
				// export each selected logo
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Title = "Export Raw Logos";
				sfd.Filter = SharedStrings.AllFilter;
				sfd.FileName = "(choose a directory)";
				sfd.CheckFileExists = false;
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					// root path
					string exportPath = Path.GetDirectoryName(sfd.FileName);

					foreach (int logoNum in lvIcons.SelectedIndices)
					{
						using (FileStream fs = new FileStream(string.Format("{0}\\{1}.hb5logo", exportPath, LogoFilenames[logoNum]), FileMode.Create))
						{
							using (BinaryWriter bw = new BinaryWriter(fs))
							{
								GetLogoFromIndex(logoNum).WriteData(bw);
							}
						}
					}
				}
			}
			else
			{
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Title = "Export Raw Logo";
				sfd.Filter = string.Format("{0}|{1}", SharedStrings.LogoFilter, SharedStrings.AllFilter);
				sfd.FileName = string.Format("{0}.hb5logo", LogoFilenames[lvIcons.SelectedIndices[0]]);
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
					{
						using (BinaryWriter bw = new BinaryWriter(fs))
						{
							GetLogoFromIndex(lvIcons.SelectedIndices[0]).WriteData(bw);
						}
					}
				}
			}
		}

		private void exportPNGToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lvIcons.SelectedIndices.Count <= 0)
			{
				return;
			}

			if (lvIcons.SelectedIndices.Count > 1)
			{
				// export each selected logo
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Title = "Export Logos as PNG";
				sfd.Filter = SharedStrings.AllFilter;
				sfd.FileName = "(choose a directory)";
				sfd.CheckFileExists = false;
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					// root path
					string exportPath = Path.GetDirectoryName(sfd.FileName);

					foreach (int logoNum in lvIcons.SelectedIndices)
					{
						GetLogoFromIndex(logoNum).ExportImage(string.Format("{0}\\{1}.png", exportPath, LogoFilenames[logoNum]));
					}
				}
			}
			else
			{
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Title = "Export Logo as PNG";
				sfd.Filter = string.Format("{0}|{1}", SharedStrings.PngFilter, SharedStrings.AllFilter);
				sfd.FileName = string.Format("{0}.png", LogoFilenames[lvIcons.SelectedIndices[0]]);
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					GetLogoFromIndex(lvIcons.SelectedIndices[0]).ExportImage(sfd.FileName);
				}
			}
		}

		private void importLogoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lvIcons.SelectedIndices.Count <= 0)
			{
				return;
			}

			MessageBox.Show("not implemented yet");
		}

		private void importPNGToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lvIcons.SelectedIndices.Count <= 0)
			{
				return;
			}

			MessageBox.Show("not implemented yet");
		}
	}
}
