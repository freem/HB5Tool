﻿using System;
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
			sb.AppendLine(string.Format("Sound Volume: {0}", CurDefaults.SoundVolume));
			sb.AppendLine(string.Format("Music Volume: {0}", CurDefaults.MusicVolume));
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
		}
	}
}
