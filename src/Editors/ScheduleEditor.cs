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
	public partial class ScheduleEditor : Form
	{
		/// <summary>
		/// Provided solely so the main form can hide the Window menu if the last form is closed.
		/// </summary>
		public event EventHandler CloseFormCallback;

		public ScheduleFile CurSchedule;

		public string FilePath;

		public ScheduleEditor(string _filePath, ScheduleFile.ScheduleLeagueTypes _type, ScheduleFile.ScheduleLengthTypes _len)
		{
			InitializeComponent();

			FilePath = _filePath;
			tssLabelFilePath.Text = FilePath;
			Text = string.Format("Schedule Editor - {0}", Path.GetFileName(FilePath));

			using (FileStream fs = new FileStream(FilePath, FileMode.Open))
			{
				using (BinaryReader br = new BinaryReader(fs))
				{
					CurSchedule = new ScheduleFile(br,_type,_len);
				}
			}

			StringBuilder sb = new StringBuilder();
			sb.AppendLine(string.Format("Schedule Type: {0}", CurSchedule.ScheduleLeague));
			sb.AppendLine(string.Format("Schedule Length: {0}", CurSchedule.ScheduleLength));
			sb.AppendLine(string.Format("Header value: 0x{0:X4}",CurSchedule.HeaderValue));
			sb.AppendLine(string.Format("Num. Table Entries: 0x{0:X4}",CurSchedule.NumEntries));
			sb.AppendLine();
			sb.AppendLine("Table Values");
			int counter = 0;
			foreach (ScheduleTableEntry tabent in CurSchedule.Entries)
			{
				sb.AppendLine(string.Format("[Table Entry {0}]", counter++));
				sb.AppendLine(string.Format("Flags: 0x{0:X2}", tabent.Flags));
				sb.AppendLine(string.Format("Num Games: 0x{0:X2}", tabent.NumGames));
				sb.AppendLine(string.Format("Start Date: 0x{0:X2}", tabent.StartDate));
				sb.AppendLine(string.Format("End Date: 0x{0:X2}", tabent.EndDate));
				sb.AppendLine();
			}

			sb.AppendLine();

			foreach (KeyValuePair<int, List<ScheduleGame>> week in CurSchedule.Games)
			{
				sb.AppendLine(string.Format("Week #{0}", week.Key));
				foreach (ScheduleGame game in week.Value)
				{
					sb.AppendLine(string.Format("0x{0:X2} 0x{1:X2} 0x{2:X2} (0x{3:X2} vs. 0x{4:X2})", game.Date, game.Data[0], game.Data[1], game.GetTeam1(), game.GetTeam2()));
				}
				sb.AppendLine();
			}

			tbOutput.Text = sb.ToString();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
			CloseFormCallback?.Invoke(this, e);
		}

		private void ScheduleEditor_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseFormCallback?.Invoke(this, e);
		}
	}
}
