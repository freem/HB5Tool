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
	public partial class FontEditor : Form
	{
		/// <summary>
		/// Provided solely so the main form can hide the Window menu if the last form is closed.
		/// </summary>
		public event EventHandler CloseFormCallback;

		/// <summary>
		/// Currently loaded font data.
		/// </summary>
		public FontData CurFont;

		/// <summary>
		/// Path to loaded .FNT file.
		/// </summary>
		public string FilePath;

		public FontEditor(string _filePath)
		{
			InitializeComponent();
			FilePath = _filePath;
			tssLabelFilePath.Text = FilePath;
			Text = string.Format("Font Editor - {0}", Path.GetFileName(FilePath));

			using (FileStream fs = new FileStream(FilePath, FileMode.Open))
			{
				using (BinaryReader br = new BinaryReader(fs))
				{
					CurFont = new FontData(br);
				}
			}

			StringBuilder sb = new StringBuilder();
			sb.AppendLine(string.Format("Font Type: {0} ({1}bpp)", CurFont.FontType, CurFont.FontType == FontTypes.MF ? "4" : "1"));
			sb.AppendLine(string.Format("Character Height: {0}",CurFont.CharHeight));
			sb.AppendLine(string.Format("Default Width?: {0}",CurFont.DefaultWidth));
			sb.AppendLine(string.Format("Unknown1: 0x{0:X4}",CurFont.Unknown1));
			sb.AppendLine(string.Format("Character Range: 0x{0:X2}-0x{1:X2} ('{2}' - '{3}')",
				CurFont.FirstChar, CurFont.LastChar, (char)CurFont.FirstChar, (char)CurFont.LastChar));

			sb.AppendLine();
			sb.AppendLine("[Character Table Entries]");
			foreach (KeyValuePair<byte,FontCharEntry> ctEntry in CurFont.CharTable)
			{
				sb.AppendLine(string.Format("[0x{0:X2} '{1}'] Offset 0x{2:X} (0x{4:X}), Char width {3}", ctEntry.Key, (char)ctEntry.Key,
					ctEntry.Value.Offset, ctEntry.Value.CharWidth, ctEntry.Value.Offset+FontData.FONT_BASE_OFFSET));
			}
			
			tbOutput.Text = sb.ToString();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
			CloseFormCallback?.Invoke(this, e);
		}

		private void FontEditor_FormClosed(object sender, FormClosedEventArgs e)
		{
			CloseFormCallback?.Invoke(this, e);
		}
	}
}
