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
	public partial class LeagueEditor : Form
	{
		/// <summary>
		/// Provided solely so the main form can hide the Window menu if the last form is closed.
		/// </summary>
		public event EventHandler CloseFormCallback;

		/// <summary>
		/// Path to League file.
		/// </summary>
		public string FilePath;

		public LeagueData CurLeague;

		public LeagueEditor(string _filePath)
		{
			InitializeComponent();
			FilePath = _filePath;
			tssLabelFilePath.Text = FilePath;
			Text = string.Format("League Editor - {0}", Path.GetFileName(FilePath));

			using (FileStream fs = new FileStream(FilePath, FileMode.Open))
			{
				using (BinaryReader br = new BinaryReader(fs))
				{
					CurLeague = new LeagueData(br);
				}
			}

			StringBuilder sb = new StringBuilder();

			sb.AppendLine(string.Format("Start of League Data: 0x{0:X}",CurLeague.LgInfoOffset));
			sb.AppendLine();
			sb.AppendLine("Entries");
			foreach (LeagueDataEntry lde in CurLeague.DataSections)
			{
				sb.AppendLine("----------------");
				sb.AppendLine(string.Format("Data Type: 0x{0:X2} ({1})",lde.DataType, (LeagueDataTypes)lde.DataType));
				sb.AppendLine(string.Format("Unknowns: 0x{0:X2}, 0x{1:X2}, 0x{2:X2}",lde.Unknown1, lde.Unknown2, lde.Unknown3));
				sb.AppendLine(string.Format("Offset 0x{0:X} (0x{1:X})",lde.Offset, lde.Offset + CurLeague.LgInfoOffset));
				sb.AppendLine(string.Format("Length 0x{0:X}",lde.Length));
			}
			sb.AppendLine();

			sb.AppendLine(string.Format("Number of Players: {0}", CurLeague.NumPlayers));
			sb.AppendLine(string.Format("Number of Batters: {0}", CurLeague.NumBatters));
			sb.AppendLine(string.Format("Number of Pitchers: {0}", CurLeague.NumPlayers-CurLeague.NumBatters));
			tbOutput.Text = sb.ToString();

			sb.Clear();
			sb.AppendLine(string.Format("League Type: {0}", CurLeague.LeagueType));
			sb.AppendLine(string.Format("Number of Teams: {0}", CurLeague.NumDefinedTeams));
			sb.AppendLine("[Division Team Counts]");
			sb.AppendLine(string.Format("Division 1: {0} teams", CurLeague.DivisionTeams[0]));
			sb.AppendLine(string.Format("Division 2: {0} teams", CurLeague.DivisionTeams[1]));
			sb.AppendLine(string.Format("Division 3: {0} teams", CurLeague.DivisionTeams[2]));
			sb.AppendLine(string.Format("Division 4: {0} teams", CurLeague.DivisionTeams[3]));
			sb.AppendLine(string.Format("Division 5: {0} teams", CurLeague.DivisionTeams[4]));
			sb.AppendLine(string.Format("Division 6: {0} teams", CurLeague.DivisionTeams[5]));

			sb.AppendLine();
			for (int i = 0; i < CurLeague.Teams.Count; i++)
			{
				sb.AppendLine(string.Format("Team {0}: {1}", i, CurLeague.Teams[i].Name));
			}

			tbLeagueInfo.Text = sb.ToString();

			lbBatters.BeginUpdate();
			foreach (KeyValuePair<int,ExportPlayer> b in CurLeague.BatterDatabase)
			{
				lbBatters.Items.Add(b.Value.Name);
			}
			lbBatters.EndUpdate();

			lbPitchers.BeginUpdate();
			foreach (KeyValuePair<int, ExportPlayer> p in CurLeague.PitcherDatabase)
			{
				lbPitchers.Items.Add(p.Value.Name);
			}
			lbPitchers.EndUpdate();

			lbTeams.BeginUpdate();
			for (int i = 0; i < CurLeague.Teams.Count; i++)
			{
				lbTeams.Items.Add(CurLeague.Teams[i].Name);
			}
			lbTeams.EndUpdate();

			sb.Clear();
			int lineCounter = 0;
			foreach (byte b in CurLeague.ScheduleData)
			{
				sb.Append(string.Format("{0:X2} ",b));
				++lineCounter;
				if (lineCounter > 0 && lineCounter % 16 == 0)
				{
					sb.AppendLine();
					lineCounter = 0;
				}
			}
			tbSchedule.Text = sb.ToString();

			sb.Clear();
			lineCounter = 0;
			foreach (byte b in CurLeague.Unknown4Values)
			{
				sb.Append(string.Format("{0:X2} ", b));
				++lineCounter;
				if (lineCounter > 0 && lineCounter % 16 == 0)
				{
					sb.AppendLine();
					lineCounter = 0;
				}
			}
			tbUnk4.Text = sb.ToString();

			sb.Clear();
			lineCounter = 0;
			foreach (byte b in CurLeague.Unknown6Values)
			{
				sb.Append(string.Format("{0:X2} ", b));
				++lineCounter;
				if (lineCounter > 0 && lineCounter % 16 == 0)
				{
					sb.AppendLine();
					lineCounter = 0;
				}
			}
			tbUnk6.Text = sb.ToString();

			sb.Clear();
			lineCounter = 0;
			foreach (byte b in CurLeague.UnknownBValues)
			{
				sb.Append(string.Format("{0:X2} ", b));
				++lineCounter;
				if (lineCounter > 0 && lineCounter % 16 == 0)
				{
					sb.AppendLine();
					lineCounter = 0;
				}
			}
			tbUnkB.Text = sb.ToString();

			sb.Clear();
			lineCounter = 0;
			foreach (byte b in CurLeague.UnknownCValues)
			{
				sb.Append(string.Format("{0:X2} ", b));
				++lineCounter;
				if (lineCounter > 0 && lineCounter % 16 == 0)
				{
					sb.AppendLine();
					lineCounter = 0;
				}
			}
			tbUnkC.Text = sb.ToString();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
			CloseFormCallback?.Invoke(this, e);
		}

		private void LeagueEditor_FormClosed(object sender, FormClosedEventArgs e)
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
						CurLeague.Teams[lbTeams.SelectedIndex].Logo.WriteData(bw);
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
				CurLeague.Teams[lbTeams.SelectedIndex].Logo.ExportImage(sfd.FileName);
			}
		}

		private void lbTeams_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbTeams.SelectedIndex < 0)
			{
				tbTeamOutput.Clear();
				return;
			}

			ExportTeam CurTeam = CurLeague.Teams[lbTeams.SelectedIndex];

			// transparency hack; avoids modifying TeamLogo's bitmap
			Bitmap tempLogo = (Bitmap)CurTeam.Logo.LogoBitmap.Clone();

			ColorPalette cpal = tempLogo.Palette;
			cpal.Entries[0] = Color.FromArgb(0, 0, 0, 0);
			tempLogo.Palette = cpal;

			pbLogo.Image = tempLogo;

			pHatColor.BackColor = DefaultData.CapTrimColors[CurTeam.CapColor];
			pTrimColor.BackColor = DefaultData.CapTrimColors[CurTeam.TrimColor];

			StringBuilder sb = new StringBuilder();
			sb.AppendLine("[Batting Orders]");
			sb.Append("vs. RHP: ");
			for (int i = 0; i < CurTeam.BattingOrder_RHP.Length; i++)
			{
				sb.Append(string.Format("0x{0:X2} ", CurTeam.BattingOrder_RHP[i]));
			}
			sb.AppendLine();

			sb.Append("vs. LHP: ");
			for (int i = 0; i < CurTeam.BattingOrder_LHP.Length; i++)
			{
				sb.Append(string.Format("0x{0:X2} ", CurTeam.BattingOrder_LHP[i]));
			}
			sb.AppendLine();
			sb.AppendLine();

			sb.AppendLine("[Fielding Positions]");
			sb.Append("vs. RHP: ");
			for (int i = 0; i < CurTeam.FieldingPositions_RHP.Length; i++)
			{
				sb.Append(string.Format("0x{0:X2} ", CurTeam.FieldingPositions_RHP[i]));
			}
			sb.AppendLine();

			sb.Append("vs. LHP: ");
			for (int i = 0; i < CurTeam.FieldingPositions_LHP.Length; i++)
			{
				sb.Append(string.Format("0x{0:X2} ", CurTeam.FieldingPositions_LHP[i]));
			}
			sb.AppendLine();
			sb.AppendLine();

			sb.AppendLine(string.Format("Number of Pitchers in Starting Rotation: {0}", CurTeam.NumStartingPitchers));

			tbTeamOutput.Text = sb.ToString();
		}

		private void lbBatters_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbBatters.SelectedIndex < 0)
			{
				lblBatterID.Text = "No Batter selected";
				return;
			}

			lblBatterID.Text = string.Format("Batter ID: 0x{0:X4}", lbBatters.SelectedIndex+1);
		}

		private void lbPitchers_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbPitchers.SelectedIndex < 0)
			{
				lblPitcherID.Text = "No Pitcher selected";
				return;
			}

			lblPitcherID.Text = string.Format("Pitcher ID: 0x{0:X4} (0x{1:X4})", lbPitchers.SelectedIndex + 1, CurLeague.NumBatters + lbPitchers.SelectedIndex + 1);
		}
	}
}
