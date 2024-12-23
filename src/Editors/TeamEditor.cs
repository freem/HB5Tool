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
		/// Provided solely so the main form can hide the Window menu if the last form is closed.
		/// </summary>
		public event EventHandler CloseFormCallback;

		#region Class Members
		/// <summary>
		/// Editor parameters.
		/// </summary>
		public EditorParams Params;

		/// <summary>
		/// Have any changes been made?
		/// </summary>
		public bool ChangesMade;

		public TeamCommonData TeamData;

		//public ExportTeam ExportTeamData;
		//public LeagueTeam LeagueTeamData;

		#endregion
		
		public TeamEditor(EditorParams _params)
		{
			InitializeComponent();
			Params = _params;
			ChangesMade = false;

			tssLabelFilePath.Text = Params.Filename;

			// load team data based on params
			switch (Params.Source)
			{
				case EditorDataSources.TeamExport:
					{
						using (FileStream fs = new FileStream(Params.Filename, FileMode.Open))
						{
							using (BinaryReader br = new BinaryReader(fs))
							{
								TeamData = new TeamCommonData(br);
							}
						}
					}
					break;

				case EditorDataSources.League:
					{
						/*
						using (FileStream fs = new FileStream(Params.Filename, FileMode.Open))
						{
							using (BinaryReader br = new BinaryReader(fs))
							{
								LeagueData l = new LeagueData(br);
								l.Teams[Params.Index];
							}
						}
						*/
					}
					break;

				default:
					// anything else is invalid
					break;
			}

			UpdateTitle();
			SetupData();
		}
	
		private void SetupData()
		{
			tbTeamName.Text = TeamData.Name;
			tbTeamOwner.Text = TeamData.Owner;
			tbStadium.Text = string.Format("0x{0:X2} ({1})", TeamData.Stadium, DefaultData.StadiumList[TeamData.Stadium]);
			tbStarPlayerIndex.Text = string.Format("0x{0:X2}", TeamData.StarPlayer);
			tbSummary.Text = TeamData.Summary;

			nudHatColor.Value = TeamData.CapColor;
			nudTrimColor.Value = TeamData.TrimColor;

			// xxx: assumes MLBPA colors, doesn't handle using 0xC and higher in MLBPA teams
			pHatColor.BackColor = DefaultData.CapTrimColors_MLBPA[TeamData.CapColor][4];
			pTrimColor.BackColor = DefaultData.CapTrimColors_MLBPA[TeamData.TrimColor][4];

			// transparency hack; avoids modifying TeamLogo's bitmap
			Bitmap tempLogo = (Bitmap)TeamData.Logo.LogoBitmap.Clone();

			ColorPalette cpal = tempLogo.Palette;
			cpal.Entries[0] = Color.FromArgb(0, 0, 0, 0);
			tempLogo.Palette = cpal;

			pbLogo.Image = tempLogo;

			tbPitcherHook.Value = TeamData.GetManagerSlider_Hook();
			tbStealBases.Value = TeamData.GetManagerSlider_Steal();
			tbRunners.Value = TeamData.GetManagerSlider_Runners();
			tbSacrifice.Value = TeamData.GetManagerSlider_Sacrifice();
			tbOffenseDefense.Value = TeamData.GetManagerSlider_OffenseDefense();
			tbSpeedPower.Value = TeamData.GetManagerSlider_SpeedPower();
			tbRookieVeteran.Value = TeamData.GetManagerSlider_RookieVeteran();

			StringBuilder sb = new StringBuilder();
			sb.AppendLine(string.Format("Value at 0x50: 0x{0:X2}", TeamData.Unknown_50));
			sb.AppendLine();

			sb.AppendLine(string.Format("Number of Starting Pitchers: {0}", TeamData.NumStartingPitchers));
			sb.AppendLine();

			sb.AppendLine("Unknown_5A values:");
			foreach (byte b in TeamData.Unknown_5A)
			{
				sb.Append(string.Format("0x{0:X2} ", b));
			}
			sb.AppendLine(Environment.NewLine);

			sb.AppendLine(string.Format("Value at 0x070D: 0x{0:X2}", TeamData.Unknown_70D));
			sb.AppendLine();

			sb.AppendLine("Unknown_75E values:");
			foreach (byte b in TeamData.Unknown_75E)
			{
				sb.Append(string.Format("0x{0:X2} ", b));
			}
			sb.AppendLine(Environment.NewLine);

			sb.AppendLine("Slider Values:");
			sb.AppendLine(string.Format("0x{0:X2} 0x{1:X2} 0x{2:X2} 0x{3:X2}", TeamData.SliderValues[0], TeamData.SliderValues[1], TeamData.SliderValues[2], TeamData.SliderValues[3]));
			tbOutput.Text = sb.ToString();
		}

		private void UpdateTitle()
		{
			Text = string.Format("Team Editor{0} - {1}", ChangesMade ? "*" : "", TeamData.Name);
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
						TeamData.Logo.WriteData(bw);
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
				TeamData.Logo.ExportImage(sfd.FileName);
			}
		}

		private void nudHatColor_ValueChanged(object sender, EventArgs e)
		{
			pHatColor.BackColor = DefaultData.CapTrimColors_MLBPA[TeamData.CapColor][4];
		}

		private void nudTrimColor_ValueChanged(object sender, EventArgs e)
		{
			pTrimColor.BackColor = DefaultData.CapTrimColors_MLBPA[TeamData.TrimColor][4];
		}
	}
}
