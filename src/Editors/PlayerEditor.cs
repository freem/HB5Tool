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
	public partial class PlayerEditor : Form
	{
		/// <summary>
		/// Source of the player's data.
		/// This makes a difference, since league and team exports operate differently from player exports.
		/// </summary>
		public enum PlayerDataSources
		{
			/// <summary>
			/// Player export (*.btr, *.pit)
			/// </summary>
			PlayerExport = 0,

			/// <summary>
			/// Team export (*.hb5)
			/// </summary>
			TeamExport = 1,

			/// <summary>
			/// League data (*.lgd)
			/// </summary>
			League = 2,

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
		/// Editor parameters.
		/// </summary>
		public EditorParams Params;

		/// <summary>
		/// Data source for this player.
		/// </summary>
		/// deprecated, to be replaced with Params.Source
		public PlayerDataSources DataSource;

		/// <summary>
		/// Path to file containing this player's data.
		/// </summary>
		/// deprecated, to be replaced with Params.Filename
		public string FilePath;

		/// <summary>
		/// Player index, only used if the source is Team Export or League.
		/// </summary>
		/// deprecated, to be replaced with Params.Index
		public int PlayerIndex = -1;

		/// <summary>
		/// Have any changes been made?
		/// </summary>
		public bool ChangesMade;

		/// <summary>
		/// Set this to true when writing back data for Team Exports and Leagues.
		/// Unnecessary for player exports.
		/// </summary>
		public bool ChangesSaved;

		// temporary
		public ExportPlayer PlayerDataExp;

		// less temporary
		public BatterData Batter;
		public PitcherData Pitcher;
		public PlayerStats Stats;

		#endregion

		public PlayerEditor(EditorParams _params)
		{
			InitializeComponent();
			ChangesMade = false;
			ChangesSaved = false;

			Params = _params;

			if (Params.Source == EditorDataSources.PlayerExport)
			{
				// direct file read
				tssLabelFilePath.Text = Params.Filename;

				// temporary!!
				using (FileStream fs = new FileStream(Params.Filename, FileMode.Open))
				{
					using (BinaryReader br = new BinaryReader(fs))
					{
						PlayerDataExp = new ExportPlayer(br);
					}
				}
			}
			else if (Params.Source == EditorDataSources.TeamExport)
			{
				//Params.Index into team roster
				tssLabelFilePath.Text = string.Format("{0} | Player Index {1}", Params.Filename, Params.Index);

				using (FileStream fs = new FileStream(Params.Filename, FileMode.Open))
				{
					using (BinaryReader br = new BinaryReader(fs))
					{
						TeamCommonData team = new TeamCommonData(br);
						ushort pType = team.PlayerIdent[Params.Index]; // 1 = batter, 2 = pitcher

						// location will already be at first player data.
						// each player is 0x194 bytes (same size as an exported player, sans the two header bytes)
					}
				}
			}
			else if (Params.Source == EditorDataSources.League)
			{
				//Params.Index into league player DB
				tssLabelFilePath.Text = string.Format("{0} | Player Index {1}", Params.Filename, Params.Index);

				using (FileStream fs = new FileStream(Params.Filename, FileMode.Open))
				{
					using (BinaryReader br = new BinaryReader(fs))
					{
						LeagueData lgd = new LeagueData(br);
						PlayerTypes pType = lgd.GetPlayerTypeFromID(Params.Index);
						if (pType == PlayerTypes.Batter)
						{
							Icon = Properties.Resources.icon_batter;
							Pitcher = null;
							Batter = lgd.BatterDatabase[Params.Index];
							Stats = lgd.Stats_Lifetime[Params.Index];
						}
						else if (pType == PlayerTypes.Pitcher)
						{
							Icon = Properties.Resources.icon_pitcher;
							Batter = null;
							Pitcher = lgd.PitcherDatabase[Params.Index - lgd.NumBatters];
							Stats = lgd.Stats_Lifetime[Params.Index];
						}
					}
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="_src">Player data source.</param>
		/// <param name="_filePath">Path to file containing player data.</param>
		/// <param name="_idx">Player index to load. Optional for _src==PlayerExport; required for all others.</param>
		public PlayerEditor(PlayerDataSources _src, string _filePath, int _idx = -1)
		{
			InitializeComponent();
			ChangesMade = false;

			DataSource = _src;
			FilePath = _filePath;
			if (_idx != -1)
			{
				PlayerIndex = _idx;
			}

			tssLabelFilePath.Text = FilePath;

			switch (_src)
			{
				case PlayerDataSources.PlayerExport:
					LoadData_PlayerExport();
					break;

				case PlayerDataSources.TeamExport:
					//LoadData_TeamExport(_idx);
					break;

				case PlayerDataSources.League:
					//LoadData_League(_idx);
					break;
			}

			if (PlayerDataExp.PlayerType == PlayerTypes.Batter)
			{
				Icon = Properties.Resources.icon_batter;
			}
			else if(PlayerDataExp.PlayerType == PlayerTypes.Pitcher)
			{
				Icon = Properties.Resources.icon_pitcher;
			}

			UpdateTitle();
			tbName.Text = PlayerDataExp.Name;
			nudJerseyNum.Value = PlayerDataExp.JerseyNum;
			lblPlayerType.Text = string.Format("Player Type: {0}", PlayerDataExp.PlayerType.ToString());
			PopulateData();
		}

		private void UpdateTitle()
		{
			Text = string.Format("Player Editor{0} - {1}", ChangesMade ? "*" : "", PlayerDataExp.Name);
		}

		public void LoadData_PlayerExport()
		{
			// player data export; the easiest
			using (FileStream fs = new FileStream(FilePath, FileMode.Open))
			{
				using (BinaryReader br = new BinaryReader(fs))
				{
					PlayerDataExp = new ExportPlayer(br);
				}
			}
		}

		public void LoadData_TeamExport(int _idx)
		{
			// player data from team export (similar to regular export)
		}

		public void LoadData_League(int _idx)
		{
			// player data from league (everything is in pieces)
		}

		public void PopulateData()
		{
			// todo: this could be a source other than PlayerDataExp
			StringBuilder sb = new StringBuilder();

			// [shared values]
			sb.AppendLine(string.Format("Picture Index: 0x{0:X4} (0x{1:X4})", PlayerDataExp.PictureIndex, (PlayerDataExp.PictureIndex & 0x0FFF)));
			sb.AppendLine(string.Format("Name Call Index: 0x{0:X4} (0x{1:X4})", PlayerDataExp.NameCall, (PlayerDataExp.NameCall & 0x0FFF)));
			sb.AppendLine(string.Format("Age: {0}", PlayerDataExp.Age));
			sb.AppendLine(string.Format("Experience: {0}", PlayerDataExp.Experience));
			sb.AppendLine(string.Format("Speed: {0}", PlayerDataExp.RunSpeed));
			sb.AppendLine(string.Format("Fielding Ability: {0}", PlayerDataExp.FieldingAbility));
			sb.AppendLine(string.Format("Close/Late: {0}", PlayerDataExp.CloseLate));
			sb.AppendLine(string.Format("Runners in Scoring Position: {0}", PlayerDataExp.ScoringPosition));
			sb.AppendLine(string.Format("Unknown 3: 0x{0:X2}", PlayerDataExp.Unknown3));
			//sb.AppendLine(string.Format("Throws: {0}", (PlayerCommonData.HandTypes)PlayerDataExp.GetHand_Throw()));
			//sb.AppendLine(string.Format("Bats: {0}", (PlayerCommonData.HandTypes)PlayerDataExp.GetHand_Bat()));
			sb.AppendLine(string.Format("Streak: {0}", PlayerDataExp.Streak));
			//sb.AppendLine(string.Format("Skin Color: {0}", (PlayerCommonData.SkinColors)PlayerDataExp.GetSkinColor()));

			// [position-specific rating values]
			if (PlayerDataExp.PlayerType == PlayerTypes.Batter)
			{
				// at the plate
				//sb.AppendLine(string.Format("Position: {0}", (BatterData.FieldingPositions)(PlayerDataExp.GetPosition())));
				sb.AppendLine(string.Format("Home/Away: {0}", PlayerDataExp.HomeAway));
				sb.AppendLine(string.Format("Contact: {0}", PlayerDataExp.ContactHit));
				sb.AppendLine(string.Format("Power: {0}", PlayerDataExp.PowerHit));
				sb.AppendLine(string.Format("Arm: {0}", PlayerDataExp.Arm));

				// secondary position only: 0 is shown as "-"
				if (PlayerDataExp.SecondaryPosition == BatterData.FieldingPositions.Pitcher)
				{
					sb.AppendLine("Secondary Position: -");
				}
				else
				{
					sb.AppendLine(string.Format("Secondary Position: {0}", PlayerDataExp.SecondaryPosition));
				}

				sb.AppendLine(string.Format("Fielding Ability 2: {0}", PlayerDataExp.SecondaryFieldingAbility));
				sb.AppendLine(string.Format("Groundout %: {0}", PlayerDataExp.GroundoutPct));
				sb.AppendLine(string.Format("Pull %: {0}", PlayerDataExp.PullPct));
				sb.AppendLine(string.Format("vs. LHP: {0}", PlayerDataExp.VersusLefties));

				sb.AppendLine(string.Format("batter unused@0x2A: 0x{0:X2}", PlayerDataExp.Batter_Unused2A));
				sb.AppendLine(string.Format("batter unused@0x2B: 0x{0:X2}", PlayerDataExp.Batter_Unused2B));
				sb.AppendLine(string.Format("batter unused@0x2C: 0x{0:X2}", PlayerDataExp.Batter_Unused2C));
			}
			else if (PlayerDataExp.PlayerType == PlayerTypes.Pitcher)
			{
				// there's going to be a pitching change
				sb.AppendLine(string.Format("vs. LHB: {0}",PlayerDataExp.VersusLefties));
				sb.AppendLine(string.Format("Stamina: {0}",PlayerDataExp.Stamina));
				sb.AppendLine(string.Format("Accuracy: {0}",PlayerDataExp.Accuracy));
				sb.AppendLine(string.Format("Fastball: {0}",PlayerDataExp.Fastball));
				sb.AppendLine(string.Format("Curveball: {0}",PlayerDataExp.Curveball));
				sb.AppendLine(string.Format("Changeup: {0}",PlayerDataExp.ChangeUp));
				sb.AppendLine(string.Format("Slider: {0}",PlayerDataExp.Slider));
				sb.AppendLine(string.Format("Sinker: {0}",PlayerDataExp.Sinker));
				sb.AppendLine(string.Format("Knuckleball: {0}",PlayerDataExp.Knuckleball));
				sb.AppendLine(string.Format("Screwball: {0}",PlayerDataExp.Screwball));
				sb.AppendLine(string.Format("Home/Away: {0}", PlayerDataExp.HomeAway));
				sb.AppendLine(string.Format("Pitcher Type: {0}", PlayerDataExp.PitcherType));
			}

			sb.AppendLine(string.Format("unknown@0x2D: 0x{0:X2}",PlayerDataExp.Unused2D));
			sb.AppendLine(string.Format("unknown@0x2E: 0x{0:X2}",PlayerDataExp.Unused2E));
			sb.AppendLine(string.Format("unknown@0x2F: 0x{0:X2}",PlayerDataExp.Unused2F));

			tbRatings.Text = sb.ToString();

			// stat values currently not handled
			sb.Clear();

			for (int i = 0; i < PlayerDataExp.StatDump.Length/2; i++)
			{
				sb.AppendLine(string.Format("offset 0x{1:X}: 0x{0:X4}",BitConverter.ToInt16(PlayerDataExp.StatDump, i*2), 0x30+(i*2)));
			}
			tbStats.Text = sb.ToString();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// todo: this should just be Close()
			if (ChangesMade)
			{
				// omg, omg, omgggggg
			}

			Close();
			CloseFormCallback?.Invoke(this, e);
		}

		/// <summary>
		/// Import data over current player.
		/// Works best with Team or League modes.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void importToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("no import functionality yet","HB5Tool");
		}

		/// <summary>
		/// Export player data to another file.
		/// </summary>
		private void exportToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("no export functionality yet", "HB5Tool");
		}

		private void PlayerEditor_FormClosing(object sender, FormClosingEventArgs e)
		{
			// this one should have the "omg" question
			CloseFormCallback?.Invoke(this, e);
		}

		private void PlayerEditor_FormClosed(object sender, FormClosedEventArgs e)
		{
			CloseFormCallback?.Invoke(this, e);
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Nope.", "HB5Tool");
		}
	}
}
