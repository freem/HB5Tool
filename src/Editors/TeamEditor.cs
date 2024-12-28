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

		public Dictionary<int, BatterData> Batters;

		public Dictionary<int, PitcherData> Pitchers;

		public Dictionary<int, PlayerStats> HistoricalStats;

		private int League_NumBatters = 0;

		#endregion
		
		public TeamEditor(EditorParams _params)
		{
			InitializeComponent();
			Params = _params;
			ChangesMade = false;

			tssLabelFilePath.Text = Params.Filename;
			tssEditorType.Text = SharedStrings.DataSourceStrings[Params.Source];

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
								Batters = new Dictionary<int, BatterData>();
								Pitchers = new Dictionary<int, PitcherData>();
								HistoricalStats = new Dictionary<int, PlayerStats>();

								// player data is stored based on values in TeamData.PlayerIdent
								// data is similar to player exports, but without the first two bytes

								int playerID = 1; // valid player IDs start at 1
								foreach (UInt16 s in TeamData.PlayerIdent)
								{
									ushort masked = (ushort)(s & 0x3FFF);

									if (masked != 0)
									{
										if (masked == 1)
										{
											Batters.Add(playerID, new BatterData(br));
											br.ReadBytes(6);
											HistoricalStats.Add(playerID, new PlayerStats(br));
										}
										else if (masked == 2)
										{
											Pitchers.Add(playerID, new PitcherData(br));
											br.ReadBytes(2);
											HistoricalStats.Add(playerID, new PlayerStats(br));
										}
									}

									playerID++;
								}
							}
						}
					}
					break;

				case EditorDataSources.League:
					{
						using (FileStream fs = new FileStream(Params.Filename, FileMode.Open))
						{
							using (BinaryReader br = new BinaryReader(fs))
							{
								LeagueData l = new LeagueData(br);
								TeamData = l.Teams[Params.Index];
								League_NumBatters = l.NumBatters;
								Batters = new Dictionary<int, BatterData>();
								Pitchers = new Dictionary<int, PitcherData>();
								HistoricalStats = new Dictionary<int, PlayerStats>();

								// values in TeamData.PlayerIdent are indices into the league player index.
								int playerID = 1; // valid player IDs start at 1
								string pName = string.Empty;
								foreach (UInt16 s in TeamData.PlayerIdent)
								{
									ushort masked = (ushort)(s & 0x3FFF);

									if (masked != 0)
									{
										if (masked > League_NumBatters)
										{
											Pitchers.Add(playerID, l.PitcherDatabase[masked - League_NumBatters]);
											HistoricalStats.Add(playerID, l.Stats_Historical[masked]);
										}
										else
										{
											Batters.Add(playerID, l.BatterDatabase[masked]);
											HistoricalStats.Add(playerID, l.Stats_Historical[masked]);
										}
									}

									playerID++;
								}
							}
						}
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

			if (Params.Source == EditorDataSources.TeamExport)
			{
				LoadRoster_Export();
			}
			else if (Params.Source == EditorDataSources.League)
			{
				LoadRoster_League();
			}
		}

		/// <summary>
		/// Load team roster for .hb5 team exports
		/// </summary>
		private void LoadRoster_Export()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("PlayerIdent values:");
			int playerNum = 1;
			int rosterCount = 0;
			int batterCount = 0;
			int pitcherCount = 0;
			string pDesc = string.Empty;
			string pName = string.Empty;
			foreach (UInt16 s in TeamData.PlayerIdent)
			{
				ushort masked = (ushort)(s & 0x3FFF);

				switch (masked)
				{
					case 1:
						pDesc = "[Bat]";
						if (Batters.ContainsKey(playerNum))
						{
							pName = Batters[playerNum].CommonData.Name;
						}
						else
						{
							pName = string.Format("broken batter 0x{0:X}", playerNum);
						}
						break;

					case 2:
						pDesc = "[Pit]";
						if (Pitchers.ContainsKey(playerNum))
						{
							pName = Pitchers[playerNum].CommonData.Name;
						}
						else
						{
							pName = string.Format("broken pitcher 0x{0:X}", playerNum);
						}
						break;

					default:
						pDesc = string.Empty;
						pName = string.Empty;
						break;
				}

				sb.AppendLine(string.Format("0x{0:X2} = {1:X4} {2} {3}", playerNum, s, pDesc, pName));

				if (s != 0)
				{
					++rosterCount;
				}

				if (s == 1)
				{
					++batterCount;
				}

				if (s == 2)
				{
					++pitcherCount;
				}

				playerNum++;
			}
			sb.AppendLine();
			sb.AppendLine(string.Format("Roster Count: {0} ({1} Batters, {2} Pitchers)", rosterCount, batterCount, pitcherCount));
			tbRosterDump.Text = sb.ToString();
		}

		/// <summary>
		/// Load team roster for .lgd teams
		/// </summary>
		private void LoadRoster_League()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("PlayerIdent values:");
			int playerNum = 1;
			int rosterCount = 0;
			int batterCount = 0;
			int pitcherCount = 0;
			string pDesc = string.Empty;
			string pName = string.Empty;
			foreach (UInt16 s in TeamData.PlayerIdent)
			{
				ushort masked = (ushort)(s & 0x3FFF);

				pDesc = string.Empty;
				pName = string.Empty;

				if (masked > League_NumBatters)
				{
					pDesc = "[Pit]";
					if (Pitchers.ContainsKey(playerNum))
					{
						pName = Pitchers[playerNum].CommonData.Name;
					}
					else
					{
						pName = string.Format("broken pitcher 0x{0:X}", playerNum);
					}
				}
				else if(masked != 0)
				{
					pDesc = "[Bat]";
					if (Batters.ContainsKey(playerNum))
					{
						pName = Batters[playerNum].CommonData.Name;
					}
					else
					{
						pName = string.Format("broken batter 0x{0:X}", playerNum);
					}
				}

				sb.AppendLine(string.Format("0x{0:X2} = {1:X4} {2} {3}", playerNum, s, pDesc, pName));

				if (s != 0)
				{
					++rosterCount;
				}

				if (masked <= League_NumBatters)
				{
					++batterCount;
				}

				if (masked > League_NumBatters)
				{
					++pitcherCount;
				}

				playerNum++;
			}
			sb.AppendLine();
			sb.AppendLine(string.Format("Roster Count: {0} ({1} Batters, {2} Pitchers)", rosterCount, batterCount, pitcherCount));
			tbRosterDump.Text = sb.ToString();
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
