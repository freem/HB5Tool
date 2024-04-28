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
	public partial class InstvarsEditor : Form
	{
		/// <summary>
		/// Provided solely so the main form can hide the Window menu if the last form is closed.
		/// </summary>
		public event EventHandler CloseFormCallback;

		/// <summary>
		/// Loaded INSTVARS.BIN data
		/// </summary>
		public InstVars CurInstVars;

		/// <summary>
		/// Path to INSTVARS.BIN
		/// </summary>
		public string FilePath;

		public InstvarsEditor(string _filePath)
		{
			InitializeComponent();
			FilePath = _filePath;
			tssLabelFilePath.Text = FilePath;
			Text = string.Format("INSTVARS.BIN Editor - {0}", Path.GetFileName(FilePath));

			using (FileStream fs = new FileStream(FilePath, FileMode.Open))
			{
				using (BinaryReader br = new BinaryReader(fs))
				{
					CurInstVars = new InstVars(br);
				}
			}

			StringBuilder sb = new StringBuilder();
			sb.AppendLine(string.Format("Installation Type: {0}", CurInstVars.InstallType));
			sb.AppendLine(string.Format("Unknown2: 0x{0:X4}", CurInstVars.Unknown2));
			sb.AppendLine(string.Format("Unknown4: 0x{0:X4}", CurInstVars.Unknown4));
			sb.AppendLine(string.Format("Unknown6: 0x{0:X4}", CurInstVars.Unknown6));
			sb.AppendLine(string.Format("CD-ROM Path: {0}", CurInstVars.CdRomPath));
			tbOutput.Text = sb.ToString();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
			CloseFormCallback?.Invoke(this, e);
		}

		private void InstvarsEditor_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseFormCallback?.Invoke(this, e);
		}
	}
}
