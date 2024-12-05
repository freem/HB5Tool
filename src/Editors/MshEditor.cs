using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HB5Tool
{
	public partial class MshEditor : Form
	{
		/// <summary>
		/// Provided solely so the main form can hide the Window menu if the last form is closed.
		/// </summary>
		public event EventHandler CloseFormCallback;

		/// <summary>
		/// Current active MSH file.
		/// </summary>
		public MshFile CurFile;

		/// <summary>
		/// Path to MSH file.
		/// </summary>
		public string FilePath;

		public MshEditor(string _filePath)
		{
			InitializeComponent();
			FilePath = _filePath;
			tssLabelFilePath.Text = FilePath;
			Text = string.Format("MSH Editor - {0}", Path.GetFileName(FilePath));

			using (FileStream fs = new FileStream(FilePath, FileMode.Open))
			{
				using (BinaryReader br = new BinaryReader(fs))
				{
					CurFile = new MshFile(br);
				}
			}

			lvMshFiles.BeginUpdate();
			for (int i = 0; i < CurFile.FileList.Count; i++)
			{
				MshEntry entry = CurFile.FileList[i];
				ListViewItem lvi = new ListViewItem(entry.Name);
				lvi.Tag = i;
				lvMshFiles.Items.Add(lvi);
			}
			lvMshFiles.EndUpdate();

			PrintArchiveInfo();
		}

		private void PrintArchiveInfo()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(string.Format("Number of files: {0}", CurFile.NumFiles));
			sb.AppendLine(string.Format("Unknown 4: 0x{0:X2}", CurFile.Unknown4));
			sb.AppendLine(string.Format("Unknown 5: 0x{0:X2}", CurFile.Unknown5));
			sb.AppendLine(string.Format("Unknown 6: 0x{0:X2}", CurFile.Unknown6));
			sb.AppendLine(string.Format("Unknown 7: 0x{0:X2}", CurFile.Unknown7));
			sb.AppendLine();
			sb.AppendLine("File List");

			foreach (MshEntry entry in CurFile.FileList)
			{
				sb.AppendLine(string.Format("{0} at offset 0x{1:X} (0x{2:X})", entry.Name, entry.Offset, CurFile.FileStartOffset + entry.Offset));
			}
			tbOutput.Text = sb.ToString();
		}

		private void lvMshFiles_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lvMshFiles.SelectedIndices.Count <= 0)
			{
				PrintArchiveInfo();
				return;
			}

			if (lvMshFiles.SelectedIndices.Count > 1)
			{
				tbOutput.Clear();
				return;
			}

			ImageMsh img = CurFile.Images[CurFile.FileList[lvMshFiles.SelectedIndices[0]]];

			tbOutput.Clear();

			StringBuilder sb = new StringBuilder();
			sb.AppendLine(string.Format("Width: {0}", img.Width));
			sb.AppendLine(string.Format("Height: {0}", img.Height));
			sb.AppendLine(string.Format("X Offset: {0}", img.OffsetX));
			sb.AppendLine(string.Format("Y Offset: {0}", img.OffsetY));
			sb.AppendLine(string.Format("Unknown: 0x{0:X4}", img.Unknown));
			sb.AppendLine(string.Format("Flags: 0x{0:X4}", img.Flags));
			if ((img.Flags & 0x8000) != 0)
			{
				sb.AppendLine("image uses RLE");
			}
			if ((img.Flags & 0x4000) != 0)
			{
				sb.AppendLine("4bpp image");
			}
			sb.AppendLine(string.Format("Data Size: 0x{0:X4}", img.DataSize));
			tbOutput.Text = sb.ToString();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
			CloseFormCallback?.Invoke(this, e);
		}

		private void extractFilesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lvMshFiles.SelectedItems.Count <= 0)
			{
				return;
			}

			// figure out file count
			if (lvMshFiles.SelectedIndices.Count > 1)
			{
				// extract multiple files
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Title = "Export files from MSH";
				sfd.Filter = SharedStrings.AllFilter;
				sfd.FileName = "(choose a directory)";
				sfd.CheckFileExists = false;
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					// root path
					string exportPath = Path.GetDirectoryName(sfd.FileName);

					FileStream inFile = new FileStream(FilePath, FileMode.Open);
					BinaryReader inReader = new BinaryReader(inFile);

					foreach (ListViewItem lvi in lvMshFiles.SelectedItems)
					{
						int entryIndex = int.Parse(lvi.Tag.ToString());
						using (FileStream fs = new FileStream(string.Format("{0}\\{1}", exportPath, CurFile.FileList[entryIndex].Name), FileMode.Create))
						{
							using (BinaryWriter bw = new BinaryWriter(fs))
							{
								CurFile.ExtractFile(entryIndex, inReader, bw);
							}
						}
					}

					inReader.Dispose();
				}
			}
			else
			{
				// extract single file
				int entryIndex = int.Parse(lvMshFiles.SelectedItems[0].Tag.ToString());
				MshEntry entry = CurFile.FileList[entryIndex];

				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Title = "Export file from MSH";
				sfd.Filter = SharedStrings.AllFilter;
				sfd.FileName = entry.Name;
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					FileStream outFile = new FileStream(sfd.FileName, FileMode.Create);
					BinaryWriter outWriter = new BinaryWriter(outFile);

					FileStream inFile = new FileStream(FilePath, FileMode.Open);
					BinaryReader inReader = new BinaryReader(inFile);
					CurFile.ExtractFile(entryIndex, inReader, outWriter);
					outWriter.Flush();
					inReader.Dispose();
					outWriter.Dispose();
				}
			}
		}

		private void MshEditor_FormClosed(object sender, FormClosedEventArgs e)
		{
			CloseFormCallback?.Invoke(this, e);
		}

		private void exportPNGToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lvMshFiles.SelectedItems.Count <= 0)
			{
				return;
			}

			if (lvMshFiles.SelectedIndices.Count > 1)
			{
				MessageBox.Show("multiple PNG export is still todo.");

				// figure out which items in the selection can't be dealt with yet (i.e. they're 4BPP)

				/*
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Title = "Export PNG Files";
				sfd.Filter = SharedStrings.AllFilter;
				sfd.FileName = "(choose a directory)";
				sfd.CheckFileExists = false;
				if (sfd.ShowDialog() == DialogResult.OK)
				{

				}
				*/
			}
			else
			{
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Title = "Export PNG";
				sfd.Filter = SharedStrings.PngFilter;
				sfd.FileName = string.Format("{0}.png", lvMshFiles.SelectedItems[0].Text);
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					int entryIndex = int.Parse(lvMshFiles.SelectedItems[0].Tag.ToString());
					MshEntry entry = CurFile.FileList[entryIndex];

					if (CurFile.Images[entry].Is4BPP())
					{
						MessageBox.Show("I haven't written any 4BPP handlers yet, sorry");
						return;
					}

					Bitmap outBitmap = CurFile.Images[entry].DecodeImage();
					outBitmap.Save(sfd.FileName, ImageFormat.Png);
				}
			}
		}
	}
}
