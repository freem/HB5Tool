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
	public partial class PicsEditor : Form
	{
		public PicsBin CurPicsFile;

		public string FilePath;

		public PicsEditor(string _path)
		{
			InitializeComponent();
			FilePath = _path;
			tssLabelFilePath.Text = FilePath;
			Text = string.Format("Pics Editor - {0}", Path.GetFileName(FilePath));

			using (FileStream fs = new FileStream(FilePath, FileMode.Open))
			{
				using (BinaryReader br = new BinaryReader(fs))
				{
					CurPicsFile = new PicsBin(br);
				}
			}

			lbPicList.BeginUpdate();
			// start counting from 1 so values found in player data line up
			for (int i = 1; i <= CurPicsFile.Entries.Count; i++)
			{
				lbPicList.Items.Add(string.Format("0x{0:X4}",i));
			}
			lbPicList.EndUpdate();

			StringBuilder sb = new StringBuilder();
			sb.AppendLine(string.Format("Num. Entries: {0}", CurPicsFile.NumEntries));
			sb.AppendLine(string.Format("Table Offset: 0x{0:X}", CurPicsFile.TableOffset));
			sb.AppendLine(string.Format("Data Offset: 0x{0:X}", CurPicsFile.DataOffset));
			sb.AppendLine();

			sb.AppendLine("Table Entries");
			foreach (PicsTableEntry entry in CurPicsFile.Entries)
			{
				sb.AppendLine(string.Format("Offset: 0x{0:X}; Length 0x{1:X}", entry.Offset, entry.Length));
			}
			tbOutput.Text = sb.ToString();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void extractFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lbPicList.SelectedIndex < 0)
			{
				return;
			}

			if (lbPicList.SelectedIndices.Count > 1)
			{
				// multiple export
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Title = "Export Pictures from Archive";
				sfd.Filter = SharedStrings.AllFilter;
				sfd.FileName = "(choose a directory)";
				sfd.CheckFileExists = false;
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					// root path
					string exportPath = Path.GetDirectoryName(sfd.FileName);

					FileStream inFile = new FileStream(FilePath, FileMode.Open);
					BinaryReader inReader = new BinaryReader(inFile);

					foreach (int picNum in lbPicList.SelectedIndices)
					{
						using (FileStream fs = new FileStream(string.Format("{0}\\pic{1}.bin", exportPath, picNum), FileMode.Create))
						{
							using (BinaryWriter bw = new BinaryWriter(fs))
							{
								inFile.Seek(CurPicsFile.Entries[picNum].Offset, SeekOrigin.Begin);
								bw.Write(inReader.ReadBytes((int)CurPicsFile.Entries[picNum].Length));
							}
						}
					}
					inReader.Dispose();
				}
			}
			else
			{
				// single export
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Title = "Export Picture";
				sfd.FileName = string.Format("pic{0}.bin", lbPicList.SelectedIndex);
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					byte[] picData;
					using (FileStream inFS = new FileStream(FilePath, FileMode.Open))
					{
						using (BinaryReader br = new BinaryReader(inFS))
						{
							picData = CurPicsFile.ExtractPic(lbPicList.SelectedIndex, br);
						}
					}
					using (FileStream outFS = new FileStream(sfd.FileName, FileMode.Create))
					{
						using (BinaryWriter bw = new BinaryWriter(outFS))
						{
							bw.Write(picData);
						}
					}
				}
			}
		}

		private void exportPNGToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lbPicList.SelectedIndex < 0)
			{
				return;
			}

			if (lbPicList.SelectedIndices.Count > 1)
			{
				// multiple export
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Title = "Export Multiple PNGs";
				sfd.Filter = SharedStrings.AllFilter;
				sfd.FileName = "(choose a directory)";
				sfd.CheckFileExists = false;
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					// root path
					string exportPath = Path.GetDirectoryName(sfd.FileName);
					foreach (int picNum in lbPicList.SelectedIndices)
					{
						CurPicsFile.RenderedPics[picNum].Save(string.Format("{0}\\pic{1}.png",exportPath,picNum), ImageFormat.Png);
					}
				}
			}
			else
			{
				// single export
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Title = "Export Picture as PNG";
				sfd.Filter = string.Format("{0}|{1}", SharedStrings.PngFilter, SharedStrings.AllFilter);
				sfd.FileName = string.Format("{0}.png", lbPicList.SelectedIndex);
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					CurPicsFile.ExportPic(sfd.FileName, lbPicList.SelectedIndex);
				}
			}
		}

		private void lbPicList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbPicList.SelectedIndex < 0)
			{
				return;
			}

			if (lbPicList.SelectedIndices.Count > 1)
			{
				// display the first selected pic
				pbPic.Image = CurPicsFile.RenderedPics[lbPicList.SelectedIndices[0]];
			}
			else
			{
				pbPic.Image = CurPicsFile.RenderedPics[lbPicList.SelectedIndex];
			}
		}
	}
}
