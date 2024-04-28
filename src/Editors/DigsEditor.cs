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
	public partial class DigsEditor : Form
	{
		/// <summary>
		/// Provided solely so the main form can hide the Window menu if the last form is closed.
		/// </summary>
		public event EventHandler CloseFormCallback;

		public DigsFile CurDigsFile;

		public string FilePath;

		public DigsEditor(string _path)
		{
			InitializeComponent();
			FilePath = _path;
			tssLabelFilePath.Text = FilePath;
			Text = string.Format("Digital Sounds Editor - {0}", Path.GetFileName(FilePath));

			using (FileStream fs = new FileStream(FilePath, FileMode.Open))
			{
				using (BinaryReader br = new BinaryReader(fs))
				{
					CurDigsFile = new DigsFile(br);
				}
			}

			lbDigsList.BeginUpdate();
			for (int i = 0; i < CurDigsFile.TableEntries.Count; i++)
			{
				lbDigsList.Items.Add(string.Format("Sound {0}", i));
			}
			lbDigsList.EndUpdate();

			StringBuilder sb = new StringBuilder();
			sb.AppendLine(string.Format("Num. Entries: {0}",CurDigsFile.NumEntries));
			sb.AppendLine(string.Format("Table Offset: 0x{0:X}",CurDigsFile.TableOffset));
			sb.AppendLine(string.Format("Data Offset: 0x{0:X}",CurDigsFile.DataOffset));
			sb.AppendLine();

			sb.AppendLine("Table Entries");
			int count = 0;
			foreach (DigEntry entry in CurDigsFile.TableEntries)
			{
				sb.AppendLine(string.Format("#{2} Offset: 0x{0:X}; Length 0x{1:X}", entry.Offset, entry.Length, count++));
			}
			tbOutput.Text = sb.ToString();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
			CloseFormCallback?.Invoke(this, e);
		}

		private void exportSoundToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lbDigsList.SelectedIndex < 0)
			{
				return;
			}

			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Export Sound";
			sfd.FileName = string.Format("dig{0}.h16", lbDigsList.SelectedIndex);
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				byte[] digData;
				using (FileStream inFS = new FileStream(FilePath, FileMode.Open))
				{
					using (BinaryReader br = new BinaryReader(inFS))
					{
						digData = CurDigsFile.ExportFile(lbDigsList.SelectedIndex, br);
					}
				}
				using (FileStream outFS = new FileStream(sfd.FileName, FileMode.Create))
				{
					using (BinaryWriter bw = new BinaryWriter(outFS))
					{
						bw.Write(digData);
					}
				}
			}
		}

		private void DigsEditor_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseFormCallback?.Invoke(this, e);
		}
	}
}
