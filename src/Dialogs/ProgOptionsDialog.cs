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
	public partial class ProgOptionsDialog : Form
	{
		/// <summary>
		/// Path to HardBall 5 installation.
		/// </summary>
		public string Hb5InstallPath;

		/// <summary>
		/// Path to a league to load as an override.
		/// </summary>
		public string LeagueOverridePath;

		/// <summary>
		/// Path to default PICS.BIN to use.
		/// </summary>
		public string DefaultPicsBinPath;

		public ProgOptionsDialog()
		{
			InitializeComponent();

			Hb5InstallPath = Properties.Settings.Default.HB5InstallDir;
			tbHb5DataPath.Text = Hb5InstallPath;

			DefaultPicsBinPath = Properties.Settings.Default.DefaultPicsBinPath;
			tbPicsBinPath.Text = DefaultPicsBinPath;

			LeagueOverridePath = Properties.Settings.Default.LeagueOverridePath;
			tbOverrideDefaultLeague.Text = LeagueOverridePath;
			cbOverrideDefaultLeague.Checked = !LeagueOverridePath.Equals(string.Empty);
			tbOverrideDefaultLeague.Enabled = cbOverrideDefaultLeague.Checked;
			btnOpenLeaguePath.Enabled = cbOverrideDefaultLeague.Checked;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			#region HB5 Install Path
			// make sure it's a valid path; empty is valid
			if (!tbHb5DataPath.Text.Equals(string.Empty))
			{
				if (!Directory.Exists(Path.GetDirectoryName(tbHb5DataPath.Text)))
				{
					MessageBox.Show("If setting an install path, it must exist.", "HB5Tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
			Hb5InstallPath = tbHb5DataPath.Text;
			#endregion

			#region Default PICS.BIN
			if (!tbPicsBinPath.Text.Equals(string.Empty))
			{
				if (!File.Exists(Path.GetFullPath(tbPicsBinPath.Text)))
				{
					MessageBox.Show("If setting a default PICS.BIN, it must exist.", "HB5Tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
			DefaultPicsBinPath = tbPicsBinPath.Text;
			#endregion

			// todo: handle das bullshitten
			if (cbOverrideDefaultLeague.Checked)
			{
				// validate textbox
				if (tbOverrideDefaultLeague.Text.Equals(string.Empty) || !File.Exists(tbOverrideDefaultLeague.Text))
				{
					MessageBox.Show("If setting a default league override, it must exist.", "HB5Tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				LeagueOverridePath = tbOverrideDefaultLeague.Text;
			}
			else
			{
				LeagueOverridePath = string.Empty;
			}
			
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
			// open a directory
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select HardBall 5 Installation Directory";
			ofd.CheckFileExists = false;
			ofd.CheckPathExists = true;
			ofd.FileName = "(choose a directory)";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				tbHb5DataPath.Text = Path.GetDirectoryName(ofd.FileName);
			}
		}

		private void btnOpenLeaguePath_Click(object sender, EventArgs e)
		{
			// open a file
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Set League as Default";
			ofd.Filter = SharedStrings.LeagueFilter;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				tbOverrideDefaultLeague.Text = Path.GetFullPath(ofd.FileName);
			}
		}

		private void cbOverrideDefaultLeague_CheckedChanged(object sender, EventArgs e)
		{
			tbOverrideDefaultLeague.Enabled = cbOverrideDefaultLeague.Checked;
			btnOpenLeaguePath.Enabled = cbOverrideDefaultLeague.Checked;
		}

		private void btnOpenPicsPath_Click(object sender, EventArgs e)
		{
			// open a file
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Set Default PICS.BIN";
			ofd.Filter = SharedStrings.AllFilter;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				tbPicsBinPath.Text = Path.GetFullPath(ofd.FileName);
			}
		}
	}
}
