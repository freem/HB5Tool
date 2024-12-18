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
	public partial class DefaultsBinEditor : Form
	{
		#region Value to String Arrays
		public readonly string[] HomeRunDerbyPitchCounts = { "3", "5", "10", "20" };

		public readonly string[] DisplayModes = { "Pitcher", "Batter", "Pitcher/Batter" };

		public readonly string[] BattingPractice_PitchZones =
		{
			"Center",
			"High/Low",
			"Inside/Outside",
			"Random"
		};
		#endregion

		/// <summary>
		/// Provided solely so the main form can hide the Window menu if the last form is closed.
		/// </summary>
		public event EventHandler CloseFormCallback;

		/// <summary>
		/// Loaded DEFAULTS.BIN data
		/// </summary>
		public DefaultsBin CurDefaults;

		/// <summary>
		/// Path to DEFAULTS.BIN (or equivalent)
		/// </summary>
		public string FilePath;

		public DefaultsBinEditor(string _filePath)
		{
			InitializeComponent();
			FilePath = _filePath;
			tssLabelFilePath.Text = FilePath;
			Text = string.Format("DEFAULTS.BIN Editor - {0}", Path.GetFileName(FilePath));

			using (FileStream fs = new FileStream(FilePath, FileMode.Open))
			{
				using (BinaryReader br = new BinaryReader(fs))
				{
					CurDefaults = new DefaultsBin(br);
				}
			}

			StringBuilder sb = new StringBuilder();

			sb.AppendLine(string.Format("Current League File: {0}", CurDefaults.CurLeagueFile));
			sb.AppendLine();

			sb.AppendLine(string.Format("Team 1 Control Set: 0x{0:X2}", CurDefaults.ControlSet1));
			sb.AppendLine(string.Format("Team 2 Control Set: 0x{0:X2}", CurDefaults.ControlSet2));
			sb.AppendLine(string.Format("Team 1 Control: 0x{0:X2}", CurDefaults.ControlTeam1));
			sb.AppendLine(string.Format("Team 2 Control: 0x{0:X2}", CurDefaults.ControlTeam2));

			sb.AppendLine(string.Format("Exhibition Team 1: 0x{0:X2}", CurDefaults.ExhibitionTeam1));
			sb.AppendLine(string.Format("Exhibition Team 2: 0x{0:X2}", CurDefaults.ExhibitionTeam2));
			sb.AppendLine();

			sb.AppendLine(string.Format("View Options: 0x{0:X4}", CurDefaults.ViewOptions));
			sb.AppendLine(string.Format("Display Mode: 0x{0:X4} ({1})", CurDefaults.DisplayMode, DisplayModes[CurDefaults.DisplayMode]));
			sb.AppendLine();

			sb.AppendLine(string.Format("Team 1 Play Level Settings: 0x{0:X4}", CurDefaults.PlayLevelSettings_Team1));
			sb.AppendLine(string.Format("Team 2 Play Level Settings: 0x{0:X4}", CurDefaults.PlayLevelSettings_Team2));
			sb.AppendLine(string.Format("Team 1 Manager Settings: 0x{0:X4}", CurDefaults.ManagerSettings_Team1));
			sb.AppendLine(string.Format("Team 2 Manager Settings: 0x{0:X4}", CurDefaults.ManagerSettings_Team2));
			sb.AppendLine(string.Format("Team 1 Skill Level: 0x{0:X4}", CurDefaults.Skill_Team1));
			sb.AppendLine(string.Format("Team 2 Skill Level: 0x{0:X4}", CurDefaults.Skill_Team2));
			sb.AppendLine();

			sb.AppendLine(string.Format("Game Speed: 0x{0:X4}", CurDefaults.GameSpeed));
			sb.AppendLine(string.Format("One Pitch Mode: {0}", (CurDefaults.OnePitchMode & 0x8000) != 0 ? "On" : "Off"));
			sb.AppendLine();

			sb.AppendLine(string.Format("Batting Practice Pitches: 0x{0:X4}", CurDefaults.BattingPractice_Pitches));
			sb.AppendLine(string.Format("Batting Practice Pitch Zone: 0x{0:X4} ({1})", CurDefaults.BattingPractice_PitchZone, BattingPractice_PitchZones[CurDefaults.BattingPractice_PitchZone]));
			sb.AppendLine();

			sb.AppendLine(string.Format("Practice/HR Derby Team: 0x{0:X2}", CurDefaults.PracticeTeam));
			sb.AppendLine(string.Format("HR Derby Pitch Count: 0x{0:X2} ({1} pitches)", CurDefaults.HomeRunDerbyPitchCount, HomeRunDerbyPitchCounts[CurDefaults.HomeRunDerbyPitchCount]));
			sb.AppendLine();

			sb.AppendLine(string.Format("Sound Volume: {0} ({1}%)", CurDefaults.SoundVolume, ((float)CurDefaults.SoundVolume/DefaultsBin.VOLUME_MAX)*100));
			sb.AppendLine(string.Format("Music Volume: {0} ({1}%)", CurDefaults.MusicVolume, ((float)CurDefaults.MusicVolume/DefaultsBin.VOLUME_MAX)*100));
			sb.AppendLine(string.Format("Game Music Volume: {0} ({1}%)", CurDefaults.GameMusicVolume, ((float)CurDefaults.GameMusicVolume / DefaultsBin.VOLUME_MAX)*100));
			sb.AppendLine(string.Format("Sound Toggles: 0x{0:X4}", CurDefaults.SoundToggles));
			sb.AppendLine();

			sb.AppendLine(string.Format("Initial Setup Value: 0x{0:X4}", CurDefaults.InitialSetup));
			sb.AppendLine();

			sb.AppendLine("Sound Card Settings");
			sb.AppendLine(string.Format("Type: 0x{0:X4}", CurDefaults.SoundCard_Type));
			sb.AppendLine(string.Format("Port: 0x{0:X2}", CurDefaults.SoundCard_Port));
			sb.AppendLine(string.Format("IRQ:  {0}", CurDefaults.SoundCard_IRQ));
			sb.AppendLine(string.Format("DMA:  {0}", CurDefaults.SoundCard_DMA));
			sb.AppendLine();

			sb.AppendLine("Home Run Derby High Scores");
			sb.AppendLine(string.Format("3 Pitches:  {0} - {1} points", CurDefaults.HomeRunDerbyName_3, CurDefaults.HomeRunDerbyScore_3));
			sb.AppendLine(string.Format("5 Pitches:  {0} - {1} points", CurDefaults.HomeRunDerbyName_5, CurDefaults.HomeRunDerbyScore_5));
			sb.AppendLine(string.Format("10 Pitches: {0} - {1} points", CurDefaults.HomeRunDerbyName_10, CurDefaults.HomeRunDerbyScore_10));
			sb.AppendLine(string.Format("20 Pitches: {0} - {1} points", CurDefaults.HomeRunDerbyName_20, CurDefaults.HomeRunDerbyScore_20));

			tbOutput.Text = sb.ToString();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
			CloseFormCallback?.Invoke(this, e);
		}

		private void DefaultsBinEditor_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseFormCallback?.Invoke(this, e);
		}
	}
}
