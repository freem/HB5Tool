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
	public partial class WordsBinEditor : Form
	{
		/// <summary>
		/// Provided solely so the main form can hide the Window menu if the last form is closed.
		/// </summary>
		public event EventHandler CloseFormCallback;

		public WordsBin CurWordsBin;

		public string FilePath;

		public WordsBinEditor(string _filePath)
		{
			InitializeComponent();

			FilePath = _filePath;
			tssLabelFilePath.Text = FilePath;
			Text = string.Format("WORDS.BIN Editor - {0}", Path.GetFileName(FilePath));

			using (FileStream fs = new FileStream(FilePath, FileMode.Open))
			{
				using (BinaryReader br = new BinaryReader(fs))
				{
					CurWordsBin = new WordsBin(br);
				}

				StringBuilder sb = new StringBuilder();
				sb.AppendLine(string.Format("Number of Entries: {0}", CurWordsBin.Entries.Count));
				sb.AppendLine();

				sb.AppendLine("Entry List");
				for (int i = 0; i < CurWordsBin.Entries.Count; i++)
				{
					sb.AppendLine(string.Format("Entry {0} at offset 0x{1:X}; upper byte 0x{2:X2}", i, CurWordsBin.Entries[i].Offset, CurWordsBin.Entries[i].Unknown));
				}

				tbOutput.Text = sb.ToString();
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
			CloseFormCallback?.Invoke(this, e);
		}

		private void WordsBinEditor_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseFormCallback?.Invoke(this, e);
		}
	}
}
