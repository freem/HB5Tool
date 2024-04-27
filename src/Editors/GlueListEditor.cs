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
	public partial class GlueListEditor : Form
	{
		/// <summary>
		/// Current active gluelist file.
		/// </summary>
		public GlueList CurGlueList;

		/// <summary>
		/// Path to gluelist file.
		/// </summary>
		public string FilePath;

		public GlueListEditor(string _filePath)
		{
			InitializeComponent();
			FilePath = _filePath;
			tssLabelFilePath.Text = FilePath;
			Text = string.Format("Gluelist Editor - {0}", Path.GetFileName(FilePath));

			using (FileStream fs = new FileStream(FilePath, FileMode.Open))
			{
				using (BinaryReader br = new BinaryReader(fs))
				{
					CurGlueList = new GlueList(br);
				}
			}

			StringBuilder sb = new StringBuilder();
			foreach (GlueListEntry entry in CurGlueList.Entries)
			{
				sb.Append("Encoded Filename: ");
				foreach (byte b in entry.EncodedName)
				{
					sb.Append(string.Format("{0:X2}", b));
				}
				sb.AppendLine();

				sb.AppendLine(string.Format("Decoded Filename: {0}", GlueMB.DecodeName(entry.EncodedName)));
				sb.AppendLine(string.Format("Unknown Bytes: 0x{0:X2}, 0x{1:X2}", entry.Unknown1, entry.Unknown2));
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
