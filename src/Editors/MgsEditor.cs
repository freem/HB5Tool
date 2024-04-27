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
	public partial class MgsEditor : Form
	{
		/// <summary>
		/// Provided solely so the main form can hide the Window menu if the last form is closed.
		/// </summary>
		public event EventHandler CloseFormCallback;

		/// <summary>
		/// Current active MGS file.
		/// </summary>
		public MgsFile CurMgsFile;

		/// <summary>
		/// Path to MGS file.
		/// </summary>
		public string FilePath;

		public MgsEditor(string _filePath)
		{
			InitializeComponent();
			FilePath = _filePath;
			tssLabelFilePath.Text = FilePath;
			Text = string.Format("MGS Editor - {0}", Path.GetFileName(FilePath));

			using (FileStream fs = new FileStream(FilePath, FileMode.Open))
			{
				using (BinaryReader br = new BinaryReader(fs))
				{
					CurMgsFile = new MgsFile(br);
				}
			}

			StringBuilder sb = new StringBuilder();
			sb.AppendLine(string.Format("Number of Entries: {0}", CurMgsFile.NumEntries));

			sb.AppendLine();
			sb.AppendLine("[Entry Offsets]");
			for (int i = 0; i < CurMgsFile.Offsets.Count; i++)
			{
				sb.AppendLine(string.Format("#{0}: 0x{1:X}",i,CurMgsFile.Offsets[i]));
			}

			tbOutput.Text = sb.ToString();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
			CloseFormCallback?.Invoke(this, e);
		}

		private void MgsEditor_FormClosed(object sender, FormClosedEventArgs e)
		{
			CloseFormCallback?.Invoke(this, e);
		}
	}
}
