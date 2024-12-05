
namespace HB5Tool
{
	partial class ProgOptionsDialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgOptionsDialog));
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lblHb5DataPath = new System.Windows.Forms.Label();
			this.tbHb5DataPath = new System.Windows.Forms.TextBox();
			this.btnOpenDataPath = new System.Windows.Forms.Button();
			this.cbOverrideDefaultLeague = new System.Windows.Forms.CheckBox();
			this.tbOverrideDefaultLeague = new System.Windows.Forms.TextBox();
			this.btnOpenLeaguePath = new System.Windows.Forms.Button();
			this.helpProvider1 = new System.Windows.Forms.HelpProvider();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(296, 93);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "&OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(377, 93);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// lblHb5DataPath
			// 
			this.lblHb5DataPath.AutoSize = true;
			this.lblHb5DataPath.Location = new System.Drawing.Point(12, 15);
			this.lblHb5DataPath.Name = "lblHb5DataPath";
			this.lblHb5DataPath.Size = new System.Drawing.Size(80, 13);
			this.lblHb5DataPath.TabIndex = 0;
			this.lblHb5DataPath.Text = "&Hardball 5 Path";
			// 
			// tbHb5DataPath
			// 
			this.helpProvider1.SetHelpString(this.tbHb5DataPath, "Path to a Hardball 5 installation.");
			this.tbHb5DataPath.Location = new System.Drawing.Point(98, 12);
			this.tbHb5DataPath.Name = "tbHb5DataPath";
			this.helpProvider1.SetShowHelp(this.tbHb5DataPath, true);
			this.tbHb5DataPath.Size = new System.Drawing.Size(273, 20);
			this.tbHb5DataPath.TabIndex = 1;
			// 
			// btnOpenDataPath
			// 
			this.btnOpenDataPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOpenDataPath.Location = new System.Drawing.Point(377, 12);
			this.btnOpenDataPath.Name = "btnOpenDataPath";
			this.btnOpenDataPath.Size = new System.Drawing.Size(75, 23);
			this.btnOpenDataPath.TabIndex = 2;
			this.btnOpenDataPath.Text = "Open...";
			this.btnOpenDataPath.UseVisualStyleBackColor = true;
			this.btnOpenDataPath.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// cbOverrideDefaultLeague
			// 
			this.cbOverrideDefaultLeague.AutoSize = true;
			this.cbOverrideDefaultLeague.Location = new System.Drawing.Point(12, 45);
			this.cbOverrideDefaultLeague.Name = "cbOverrideDefaultLeague";
			this.helpProvider1.SetShowHelp(this.cbOverrideDefaultLeague, false);
			this.cbOverrideDefaultLeague.Size = new System.Drawing.Size(142, 17);
			this.cbOverrideDefaultLeague.TabIndex = 5;
			this.cbOverrideDefaultLeague.Text = "Override Default League";
			this.cbOverrideDefaultLeague.UseVisualStyleBackColor = true;
			this.cbOverrideDefaultLeague.CheckedChanged += new System.EventHandler(this.cbOverrideDefaultLeague_CheckedChanged);
			// 
			// tbOverrideDefaultLeague
			// 
			this.tbOverrideDefaultLeague.Location = new System.Drawing.Point(160, 43);
			this.tbOverrideDefaultLeague.Name = "tbOverrideDefaultLeague";
			this.tbOverrideDefaultLeague.Size = new System.Drawing.Size(211, 20);
			this.tbOverrideDefaultLeague.TabIndex = 6;
			// 
			// btnOpenLeaguePath
			// 
			this.btnOpenLeaguePath.Location = new System.Drawing.Point(377, 41);
			this.btnOpenLeaguePath.Name = "btnOpenLeaguePath";
			this.btnOpenLeaguePath.Size = new System.Drawing.Size(75, 23);
			this.btnOpenLeaguePath.TabIndex = 7;
			this.btnOpenLeaguePath.Text = "Open...";
			this.btnOpenLeaguePath.UseVisualStyleBackColor = true;
			this.btnOpenLeaguePath.Click += new System.EventHandler(this.btnOpenLeaguePath_Click);
			// 
			// ProgOptionsDialog
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(464, 128);
			this.Controls.Add(this.btnOpenLeaguePath);
			this.Controls.Add(this.tbOverrideDefaultLeague);
			this.Controls.Add(this.cbOverrideDefaultLeague);
			this.Controls.Add(this.btnOpenDataPath);
			this.Controls.Add(this.tbHb5DataPath);
			this.Controls.Add(this.lblHb5DataPath);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ProgOptionsDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Program Options";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lblHb5DataPath;
		private System.Windows.Forms.TextBox tbHb5DataPath;
		private System.Windows.Forms.Button btnOpenDataPath;
		private System.Windows.Forms.CheckBox cbOverrideDefaultLeague;
		private System.Windows.Forms.TextBox tbOverrideDefaultLeague;
		private System.Windows.Forms.Button btnOpenLeaguePath;
		private System.Windows.Forms.HelpProvider helpProvider1;
	}
}