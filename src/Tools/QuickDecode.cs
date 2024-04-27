using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HB5Tool
{
	public partial class QuickDecode : Form
	{
		public QuickDecode()
		{
			InitializeComponent();
		}

		private void btnDecode_Click(object sender, EventArgs e)
		{
			if (tbEncodedFilename.Text.Equals(string.Empty))
			{
				// can't decode an empty string
				return;
			}

			// sanitize input
			tbEncodedFilename.Text = tbEncodedFilename.Text.Replace(" ", string.Empty);

			// todo: remove any non-hex characters

			if (tbEncodedFilename.Text.Length % 2 != 0)
			{
				// can't have an odd number of characters in the box
				return;
			}

			int numChars = tbEncodedFilename.Text.Length / 2;
			bool finishedDecoding = false;
			tbDecodedFilename.Clear();
			for (int i = 0; i < numChars; i++)
			{
				byte b = Convert.ToByte(tbEncodedFilename.Text.Substring(i*2, 2), 16);
				
				if (b == 0 && !finishedDecoding)
				{
					finishedDecoding = true;
				}

				if (b !=0 && !finishedDecoding)
				{
					tbDecodedFilename.Text += (char)(b - 0x60);
				}
			}
		}

		private void tbEncodedFilename_TextChanged(object sender, EventArgs e)
		{
			tbEncodedFilename.Text = tbEncodedFilename.Text.Replace(" ", string.Empty);
		}

		private void QuickDecode_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}
	}
}
