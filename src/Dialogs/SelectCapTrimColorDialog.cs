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
	public partial class SelectCapTrimColorDialog : Form
	{
		/// <summary>
		/// Which color set to use.
		/// </summary>
		public int ColorSet;

		/// <summary>
		/// If true, pull from the Legends color set instead of MLBPA.
		/// </summary>
		public bool LegendsMode;

		public SelectCapTrimColorDialog(int _col, bool _legends = false)
		{
			InitializeComponent();
			LegendsMode = _legends;

			cbColor.BeginUpdate();
			// todo: add color set names?
			for (int i = 0; i < DefaultData.CapTrimColors_MLBPA.Count; i++)
			{
				cbColor.Items.Add(string.Format("Color {0}", i));
			}
			cbColor.EndUpdate();

			if (_col > cbColor.Items.Count)
			{
				cbColor.SelectedIndex = 0;
			}
			else
			{
				cbColor.SelectedIndex = _col;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			ColorSet = cbColor.SelectedIndex;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void cbColor_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbColor.SelectedIndex < 0)
			{
				return;
			}

			// update picturebox

			Bitmap ColorSet = new Bitmap(pbPalPreview.Width, pbPalPreview.Height);
			Graphics g = Graphics.FromImage(ColorSet);
			Pen curPen;
			int swatchWidth = (pbPalPreview.Width / 8);

			for (int i = 0; i < DefaultData.CapTrimColors_MLBPA[0].Length; i++)
			{
				if (LegendsMode)
				{
					curPen = new Pen(DefaultData.CapTrimColors_Legends[cbColor.SelectedIndex][i]);
				}
				else
				{
					curPen = new Pen(DefaultData.CapTrimColors_MLBPA[cbColor.SelectedIndex][i]);
				}
				g.FillRectangle(curPen.Brush, new Rectangle(i * swatchWidth, 0, swatchWidth, pbPalPreview.Height));
			}

			pbPalPreview.Image = ColorSet;
		}
	}
}
