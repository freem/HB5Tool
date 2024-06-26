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
	public partial class TeamEditor : Form
	{
		/// <summary>
		/// Source of the Team's data.
		/// </summary>
		public enum TeamDataSources
		{
			/// <summary>
			/// Team export (*.hb5)
			/// </summary>
			TeamExport = 0,

			/// <summary>
			/// League data (*.lgd)
			/// </summary>
			League = 1,

			/// <summary>
			/// Not a valid source
			/// </summary>
			Invalid = -1
		}

		/// <summary>
		/// Provided solely so the main form can hide the Window menu if the last form is closed.
		/// </summary>
		public event EventHandler CloseFormCallback;

		#region Class Members
		/// <summary>
		/// Data source for this team.
		/// </summary>
		public TeamDataSources DataSource;

		/// <summary>
		/// Path to file containing this team's data.
		/// </summary>
		public string FilePath;

		/// <summary>
		/// Team index, only used if the source is League.
		/// </summary>
		public int TeamIndex = -1;

		/// <summary>
		/// Have any changes been made?
		/// </summary>
		public bool ChangesMade;

		// temporary
		public ExportTeam TeamDataExp;
		#endregion

		public TeamEditor(TeamDataSources _src, string _filePath, int _idx = -1)
		{
			InitializeComponent();
			ChangesMade = false;

			DataSource = _src;
			FilePath = _filePath;
			if (_idx != -1)
			{
				TeamIndex = _idx;
			}

			tssLabelFilePath.Text = FilePath;

			// xxx temporary
			LoadData_TeamExport();

			UpdateTitle();
			tbTeamName.Text = TeamDataExp.Name;
			tbTeamOwner.Text = TeamDataExp.Owner;
			tbStadium.Text = string.Format("0x{0:X2} ({1})", TeamDataExp.Stadium, DefaultData.StadiumList[TeamDataExp.Stadium]);
			tbStarPlayerIndex.Text = string.Format("0x{0:X2}", TeamDataExp.StarPlayer);
			tbSummary.Text = TeamDataExp.Summary;

			nudHatColor.Value = TeamDataExp.CapColor;
			nudTrimColor.Value = TeamDataExp.TrimColor;
			pHatColor.BackColor = DefaultData.CapTrimColors[TeamDataExp.CapColor];
			pTrimColor.BackColor = DefaultData.CapTrimColors[TeamDataExp.TrimColor];

			// transparency hack; avoids modifying TeamLogo's bitmap
			Bitmap tempLogo = (Bitmap)TeamDataExp.Logo.LogoBitmap.Clone();

			ColorPalette cpal = tempLogo.Palette;
			cpal.Entries[0] = Color.FromArgb(0, 0, 0, 0);
			tempLogo.Palette = cpal;

			pbLogo.Image = tempLogo;

			StringBuilder sb = new StringBuilder();
			sb.AppendLine(string.Format("Value at 0x50: 0x{0:X2}", TeamDataExp.Unknown_50));
			sb.AppendLine();

			sb.AppendLine(string.Format("Number of Starting Pitchers: {0}", TeamDataExp.NumStartingPitchers));
			sb.AppendLine();

			sb.AppendLine("Slider Values:");
			sb.AppendLine(string.Format("0x{0:X2} 0x{1:X2} 0x{2:X2} 0x{3:X2}", TeamDataExp.SliderValues[0], TeamDataExp.SliderValues[1], TeamDataExp.SliderValues[2], TeamDataExp.SliderValues[3]));
			tbOutput.Text = sb.ToString();
		}

		private void UpdateTitle()
		{
			Text = string.Format("Team Editor{0} - {1}", ChangesMade ? "*" : "", TeamDataExp.Name);
		}

		private void LoadData_TeamExport()
		{
			using (FileStream fs = new FileStream(FilePath, FileMode.Open))
			{
				using (BinaryReader br = new BinaryReader(fs))
				{
					TeamDataExp = new ExportTeam(br);
				}
			}
		}

		private void LoadData_League(int _idx = -1)
		{
		}

		private void saveChangesToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void importToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("no import functionality yet", "HB5Tool");
		}

		private void exportToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("no export functionality yet", "HB5Tool");
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
			CloseFormCallback?.Invoke(this, e);
		}

		private void TeamEditor_FormClosed(object sender, FormClosedEventArgs e)
		{
			CloseFormCallback?.Invoke(this, e);
		}

		private void exportRawLogoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Export Raw Logo";
			sfd.Filter = string.Format("{0}|{1}", SharedStrings.LogoFilter, SharedStrings.AllFilter);
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
				{
					using (BinaryWriter bw = new BinaryWriter(fs))
					{
						TeamDataExp.Logo.WriteData(bw);
					}
				}
			}
		}

		private void exportPNGToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Export Logo as PNG";
			sfd.Filter = string.Format("{0}|{1}", SharedStrings.PngFilter, SharedStrings.AllFilter);
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				TeamDataExp.Logo.ExportImage(sfd.FileName);
			}
		}

		private void nudHatColor_ValueChanged(object sender, EventArgs e)
		{
			pHatColor.BackColor = DefaultData.CapTrimColors[TeamDataExp.CapColor];
		}

		private void nudTrimColor_ValueChanged(object sender, EventArgs e)
		{
			pTrimColor.BackColor = DefaultData.CapTrimColors[TeamDataExp.TrimColor];
		}
	}
}
