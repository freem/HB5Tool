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
		/// Performs housekeeping cleanup for ActiveLeagueEditors in MainForm.
		/// </summary>
		public event EventHandler LeagueEditorFormCloseCallback;

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
				sb.AppendLine("------------------------");
				sb.AppendLine(string.Format("Data Type: 0x{0:X2} ({1})",lde.DataType, (LeagueDataTypes)lde.DataType));
				sb.AppendLine(string.Format("Unknowns: 0x{0:X2}, 0x{1:X2}, 0x{2:X2}",lde.Unknown1, lde.Unknown2, lde.Unknown3));
				sb.AppendLine(string.Format("Offset 0x{0:X} (0x{1:X})",lde.Offset, lde.Offset + CurLeague.LgInfoOffset));
				sb.AppendLine(string.Format("Length 0x{0:X}",lde.Length));
			}
			sb.AppendLine();

			sb.AppendLine(string.Format("Number of Players:  {0}", CurLeague.NumPlayers));
			sb.AppendLine(string.Format("Number of Batters:  {0}", CurLeague.NumBatters));
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
			foreach (KeyValuePair<int,BatterData> b in CurLeague.BatterDatabase)
			{
				if (b.Value.CommonData.Name != null)
				{
					lbBatters.Items.Add(b.Value.CommonData.Name);
				}
				else
				{
					lbBatters.Items.Add(String.Format("(batter {0} null)",b.Key));
				}
				
			}
			lbBatters.EndUpdate();

			lbPitchers.BeginUpdate();
			foreach (KeyValuePair<int, PitcherData> p in CurLeague.PitcherDatabase)
			{
				if (p.Value.CommonData.Name != null)
				{
					lbPitchers.Items.Add(p.Value.CommonData.Name);
				}
				else
				{
					lbPitchers.Items.Add(String.Format("(pitcher {0} null)", p.Key));
				}
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
				if (lineCounter > 0 && lineCounter % 24 == 0)
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

			// stats list
			cbPlayerStats.BeginUpdate();
			foreach (KeyValuePair<int,BatterData> b in CurLeague.BatterDatabase)
			{
				string pName = b.Value.CommonData.Name;
				if (pName != null)
				{
					cbPlayerStats.Items.Add(pName);
				}
				else
				{
					cbPlayerStats.Items.Add(string.Format("batter 0x{0:X}", b.Key));
				}
			}
			foreach (KeyValuePair<int, PitcherData> p in CurLeague.PitcherDatabase)
			{
				string pName = p.Value.CommonData.Name;
				if (pName != null)
				{
					cbPlayerStats.Items.Add(pName);
				}
				else
				{
					cbPlayerStats.Items.Add(string.Format("pitcher 0x{0:X}", p.Key));
				}
			}
			cbPlayerStats.EndUpdate();
		}

		// todo: if any team editors have been opened from this league on form closing, go through and handle each team form

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
			LeagueEditorFormCloseCallback?.Invoke(this, e);
			CloseFormCallback?.Invoke(this, e);
		}

		private void LeagueEditor_FormClosed(object sender, FormClosedEventArgs e)
		{
			LeagueEditorFormCloseCallback?.Invoke(this, e);
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

		private void UpdateCapTrimColors(TeamCommonData CurTeam)
		{
			// Hat and Trim colors depend on league type.
			if (CurLeague.LeagueType == LeagueTypes.MLBPA)
			{
				// It is possible to use the Legends colors in a MLBPA league, but this requires hacking.
				// I am unsure if the reverse is possible (not likely).
				if (CurTeam.CapColor >= DefaultData.CapTrimColors_MLBPA.Count)
				{
					pHatColor.BackColor = DefaultData.CapTrimColors_Legends[CurTeam.CapColor - DefaultData.CapTrimColors_MLBPA.Count][4];
					pTrimColor.BackColor = DefaultData.CapTrimColors_Legends[CurTeam.TrimColor - DefaultData.CapTrimColors_MLBPA.Count][4];
				}
				else
				{
					pHatColor.BackColor = DefaultData.CapTrimColors_MLBPA[CurTeam.CapColor][4];
					pTrimColor.BackColor = DefaultData.CapTrimColors_MLBPA[CurTeam.TrimColor][4];
				}
			}
			else if (CurLeague.LeagueType == LeagueTypes.Legends)
			{
				pHatColor.BackColor = DefaultData.CapTrimColors_Legends[CurTeam.CapColor][4];
				pTrimColor.BackColor = DefaultData.CapTrimColors_Legends[CurTeam.TrimColor][4];
			}

			toolTip1.SetToolTip(pHatColor, string.Format("Color {0}", CurTeam.CapColor));
			toolTip1.SetToolTip(pTrimColor, string.Format("Color {0}", CurTeam.TrimColor));
		}

		private void lbTeams_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbTeams.SelectedIndex < 0)
			{
				tbTeamOutput.Clear();
				return;
			}

			TeamCommonData CurTeam = CurLeague.Teams[lbTeams.SelectedIndex];

			// transparency hack; avoids modifying TeamLogo's bitmap
			Bitmap tempLogo = (Bitmap)CurTeam.Logo.LogoBitmap.Clone();

			ColorPalette cpal = tempLogo.Palette;
			cpal.Entries[0] = Color.FromArgb(0, 0, 0, 0);
			tempLogo.Palette = cpal;

			pbLogo.Image = tempLogo;

			UpdateCapTrimColors(CurTeam);

			// handle star player image
			if (Program.GlobalPicsBin != null)
			{
				byte starPlayer = CurTeam.StarPlayer;
				ushort starID = (ushort)(CurTeam.PlayerIdent[starPlayer] & 0x3FFF);
				int picNum = 0;
				if (starID > 0)
				{
					if (starID > CurLeague.NumBatters)
					{
						if ((CurLeague.PitcherDatabase[starID - CurLeague.NumBatters].CommonData.PictureIndex & 0x3FFF) == 0)
						{
							picNum = 1;
						}
						else
						{
							picNum = (CurLeague.PitcherDatabase[starID - CurLeague.NumBatters].CommonData.PictureIndex - 1) & 0x3FFF;
						}
					}
					else
					{
						if ((CurLeague.BatterDatabase[starID].CommonData.PictureIndex & 0x3FFF) == 0)
						{
							picNum = 0;
						}
						else
						{
							picNum = (CurLeague.BatterDatabase[starID].CommonData.PictureIndex - 1) & 0x3FFF;
						}
					}
				}

				if (starID != 0)
				{
					pbStarPlayer.Image = Program.GlobalPicsBin.RenderedPics[picNum];
				}
				else
				{
					pbStarPlayer.Image = null;
				}
			}

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
			sb.AppendLine(Environment.NewLine);

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
			sb.AppendLine(Environment.NewLine);

			sb.AppendLine(string.Format("Unknown_50 value: 0x{0:X2}", CurTeam.Unknown_50));
			sb.AppendLine(string.Format("Stadium: 0x{0:X2} ({1})", CurTeam.Stadium, DefaultData.StadiumList[CurTeam.Stadium]));
			sb.AppendLine(string.Format("Star Player index: 0x{0:X2}", CurTeam.StarPlayer));

			sb.AppendLine(string.Format("Number of Pitchers in Starting Rotation: {0}", CurTeam.NumStartingPitchers));
			sb.AppendLine();

			sb.AppendLine("Unknown_5A values:");
			foreach (byte b in CurTeam.Unknown_5A)
			{
				sb.Append(string.Format("{0:X2} ", b));
			}
			sb.AppendLine(Environment.NewLine);

			sb.AppendLine(string.Format("Unknown_70D value: 0x{0:X2}", CurTeam.Unknown_70D));

			sb.AppendLine("PlayerIdent values:");
			int playerNum = 1;
			foreach (UInt16 s in CurTeam.PlayerIdent)
			{
				ushort masked = (ushort)(s & 0x3FFF);
				string pName = string.Empty;

				if (masked > CurLeague.NumBatters)
				{
					pName = CurLeague.PitcherDatabase[masked - CurLeague.NumBatters].CommonData.Name;
				}
				else if(masked > 0)
				{
					pName = CurLeague.BatterDatabase[masked].CommonData.Name;
				}

				if (masked != 0)
				{
					sb.AppendLine(string.Format("0x{0:X2} = {1:X4} ({2:X4}) - {3}{4}", playerNum, s, masked, pName, CurTeam.StarPlayer == playerNum-1 ? "*" : ""));
				}
				else
				{
					sb.AppendLine(string.Format("0x{0:X2} = {1:X4}{2}", playerNum, s, CurTeam.StarPlayer == playerNum-1 ? "*" : ""));
				}
				playerNum++;
			}
			sb.AppendLine(Environment.NewLine);

			sb.AppendLine("Unknown_75E values:");
			foreach (byte b in CurTeam.Unknown_75E)
			{
				sb.Append(string.Format("{0:X2} ", b));
			}
			sb.AppendLine(Environment.NewLine);

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

		private void pHatColor_MouseClick(object sender, MouseEventArgs e)
		{
			if (lbTeams.SelectedIndex < 0)
			{
				return;
			}

			SelectCapTrimColorDialog cd = new SelectCapTrimColorDialog(CurLeague.Teams[lbTeams.SelectedIndex].CapColor, CurLeague.LeagueType == LeagueTypes.Legends);
			if (cd.ShowDialog() == DialogResult.OK)
			{
				// update hat color
				//CurLeague.Teams[lbTeams.SelectedIndex].CapColor = (byte)cd.ColorSet;
				//UpdateCapTrimColors(CurLeague.Teams[lbTeams.SelectedIndex]);
			}
		}

		private void pTrimColor_MouseClick(object sender, MouseEventArgs e)
		{
			if (lbTeams.SelectedIndex < 0)
			{
				return;
			}

			SelectCapTrimColorDialog cd = new SelectCapTrimColorDialog(CurLeague.Teams[lbTeams.SelectedIndex].TrimColor, CurLeague.LeagueType == LeagueTypes.Legends);
			if (cd.ShowDialog() == DialogResult.OK)
			{
				// update trim color
				//CurLeague.Teams[lbTeams.SelectedIndex].TrimColor = (byte)cd.ColorSet;
				//UpdateCapTrimColors(CurLeague.Teams[lbTeams.SelectedIndex]);
			}
		}

		private void btnEditTeam_Click(object sender, EventArgs e)
		{
			if (lbTeams.SelectedIndex < 0)
			{
				return;
			}

			EditorParams param = new EditorParams(EditorDataSources.League, FilePath, lbTeams.SelectedIndex);

			if (EditorManager.Teams.ContainsKey(param))
			{
				EditorManager.Teams[param].BringToFront();
				EditorManager.Teams[param].Activate();
			}
			else
			{
				TeamEditor tEd = new TeamEditor(param);
				EditorManager.Teams.Add(param, tEd);
				tEd.CloseFormCallback += ((MainForm)this.Parent.Parent).TeamEditor_CloseFormCallback;
				tEd.MdiParent = (Form)this.Parent.Parent;
				tEd.Show();
			}
		}

		private void cbPlayerStats_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbPlayerStats.SelectedIndex < 0)
			{
				tbStatsHistorical.Clear();
				tbStatsSeason.Clear();
				tbStatsWeekly.Clear();
				tbStatsLifetime.Clear();
				return;
			}

			StringBuilder sb = new StringBuilder();

			int pNum = cbPlayerStats.SelectedIndex;

			int colCount = 0;
			foreach (byte b in CurLeague.Stats_Historical[pNum].StatsData)
			{
				sb.Append(string.Format("{0:X2} ", b));
				++colCount;
				if (colCount == 16)
				{
					sb.AppendLine();
					colCount = 0;
				}
			}
			tbStatsHistorical.Text = sb.ToString();

			sb.Clear();
			colCount = 0;
			foreach (byte b in CurLeague.Stats_Season[pNum].StatsData)
			{
				sb.Append(string.Format("{0:X2} ", b));
				++colCount;
				if (colCount == 16)
				{
					sb.AppendLine();
					colCount = 0;
				}
			}
			tbStatsSeason.Text = sb.ToString();

			sb.Clear();
			colCount = 0;
			foreach (byte b in CurLeague.Stats_Weekly[pNum].StatsData)
			{
				sb.Append(string.Format("{0:X2} ", b));
				++colCount;
				if (colCount == 16)
				{
					sb.AppendLine();
					colCount = 0;
				}
			}
			tbStatsWeekly.Text = sb.ToString();

			sb.Clear();
			colCount = 0;
			foreach (byte b in CurLeague.Stats_Lifetime[pNum].StatsData)
			{
				sb.Append(string.Format("{0:X2} ", b));
				++colCount;
				if (colCount == 16)
				{
					sb.AppendLine();
					colCount = 0;
				}
			}
			tbStatsLifetime.Text = sb.ToString();
		}
	}
}
