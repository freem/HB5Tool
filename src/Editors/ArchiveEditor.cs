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
	public partial class ArchiveEditor : Form
	{
		/// <summary>
		/// Provided solely so the main form can hide the Window menu if the last form is closed.
		/// </summary>
		public event EventHandler CloseFormCallback;

		#region Members
		/// <summary>
		/// Current active archive file.
		/// </summary>
		public GlueMB CurArchive;

		/// <summary>
		/// Path to archive file.
		/// </summary>
		public string FilePath;
		#endregion

		public ArchiveEditor(string _filePath, bool _ps1Version = false)
		{
			InitializeComponent();
			FilePath = _filePath;
			tssLabelFilePath.Text = FilePath;
			Text = string.Format("Archive Editor - {0}",Path.GetFileName(FilePath));

			using (FileStream fs = new FileStream(FilePath, FileMode.Open))
			{
				using (BinaryReader br = new BinaryReader(fs))
				{
					CurArchive = new GlueMB(br, _ps1Version);
				}
			}

			lvArchiveFiles.BeginUpdate();
			for (int i = 0; i < CurArchive.Entries.Count; i++)
			{
				GlueEntry entry = CurArchive.Entries[i];
				ListViewItem lvi = new ListViewItem(entry.Filename);
				lvi.Tag = i;
				lvArchiveFiles.Items.Add(lvi);
			}
			lvArchiveFiles.EndUpdate();

			StringBuilder sb = new StringBuilder();
			sb.AppendLine(string.Format("Number of files: {0}", CurArchive.NumFiles));
			sb.AppendLine();
			foreach (GlueEntry entry in CurArchive.Entries)
			{
				sb.AppendLine(string.Format("Length: 0x{0:X}; Offset: 0x{1:X}", entry.Length, entry.Offset));

				sb.Append("Encoded Filename: ");
				foreach (byte b in entry.EncodedName)
				{
					sb.Append(string.Format("{0:X2}",b));
				}
				sb.AppendLine();

				sb.AppendLine(string.Format("Decoded Filename: {0}",entry.Filename));
				sb.AppendLine(string.Format("Unknown Bytes: 0x{0:X2}, 0x{1:X2}",entry.Unknown1,entry.Unknown2));
				sb.AppendLine();
			}
			tbOutput.Text = sb.ToString();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
			CloseFormCallback?.Invoke(this, e);
		}

		private void extractFilesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lvArchiveFiles.SelectedItems.Count <= 0)
			{
				return;
			}

			// figure out file count
			if (lvArchiveFiles.SelectedItems.Count > 1)
			{
				// extract multiple files.
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Title = "Export files from Archive";
				sfd.Filter = SharedStrings.AllFilter;
				sfd.FileName = "(choose a directory)";
				sfd.CheckFileExists = false;
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					// root path
					string exportPath = Path.GetDirectoryName(sfd.FileName);

					FileStream inFile = new FileStream(FilePath, FileMode.Open);
					BinaryReader inReader = new BinaryReader(inFile);

					foreach (ListViewItem lvi in lvArchiveFiles.SelectedItems)
					{
						GlueEntry entry = CurArchive.Entries[int.Parse(lvi.Tag.ToString())];
						using (FileStream fs = new FileStream(string.Format("{0}\\{1}", exportPath, entry.Filename), FileMode.Create))
						{
							using (BinaryWriter bw = new BinaryWriter(fs))
							{
								inFile.Seek(entry.Offset, SeekOrigin.Begin);
								bw.Write(inReader.ReadBytes((int)entry.Length));
							}
						}
					}

					inReader.Dispose();
				}
			}
			else
			{
				// extract single file
				GlueEntry entry = CurArchive.Entries[int.Parse(lvArchiveFiles.SelectedItems[0].Tag.ToString())];

				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Title = "Export file from Archive";
				sfd.Filter = SharedStrings.AllFilter;
				sfd.FileName = entry.Filename;
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					FileStream outFile = new FileStream(sfd.FileName, FileMode.Create);
					BinaryWriter outWriter = new BinaryWriter(outFile);

					FileStream inFile = new FileStream(FilePath, FileMode.Open);
					BinaryReader inReader = new BinaryReader(inFile);

					inFile.Seek(entry.Offset, SeekOrigin.Begin);
					outWriter.Write(inReader.ReadBytes((int)entry.Length));

					outWriter.Flush();
					inReader.Dispose();
					outWriter.Dispose();
				}
			}
		}

		private void lvArchiveFiles_SelectedIndexChanged(object sender, EventArgs e)
		{
			lvArchiveFiles.ContextMenuStrip = (lvArchiveFiles.SelectedItems.Count > 0) ? cmsArchiveFiles : null;
		}

		private void ArchiveEditor_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseFormCallback?.Invoke(this, e);
		}

		private void ArchiveEditor_FormClosed(object sender, FormClosedEventArgs e)
		{
			CloseFormCallback?.Invoke(this, e);
		}
	}
}
