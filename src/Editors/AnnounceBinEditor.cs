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
	public partial class AnnounceBinEditor : Form
	{
		public AnnounceBin CurAnnounceBin;

		public string FilePath;

		public AnnounceBinEditor(string _filePath)
		{
			InitializeComponent();

			FilePath = _filePath;
			tssLabelFilePath.Text = FilePath;
			Text = string.Format("ANNOUNCER.BIN Editor - {0}", Path.GetFileName(FilePath));

			using (FileStream fs = new FileStream(FilePath, FileMode.Open))
			{
				using (BinaryReader br = new BinaryReader(fs))
				{
					CurAnnounceBin = new AnnounceBin(br);
				}
			}

			StringBuilder sb = new StringBuilder();
			sb.AppendLine(string.Format("Number of Entries: {0}",CurAnnounceBin.NumEntries));
			sb.AppendLine();

			sb.AppendLine("Entry List");
			for (int i = 0; i < CurAnnounceBin.NumEntries; i++)
			{
				sb.AppendLine(string.Format("Entry {0} at offset 0x{1:X}",i,CurAnnounceBin.EntryTable[i]));
			}

			sb.AppendLine();
			foreach (KeyValuePair<int,byte[]> entry in CurAnnounceBin.Entries)
			{
				sb.AppendLine(string.Format("Entry {0} (0x{1:X})", entry.Key, CurAnnounceBin.EntryTable[entry.Key]));
				foreach (byte b in entry.Value)
				{
					sb.Append(string.Format("{0:X2} ",b));
				}
				sb.AppendLine();
				sb.AppendLine();
			}

			tbOutput.Text = sb.ToString();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
