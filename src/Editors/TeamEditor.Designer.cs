
namespace HB5Tool
{
	partial class TeamEditor
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamEditor));
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tssLabelFilePath = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.teamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tbTeamName = new System.Windows.Forms.TextBox();
			this.lblName = new System.Windows.Forms.Label();
			this.lblTeamOwner = new System.Windows.Forms.Label();
			this.tbTeamOwner = new System.Windows.Forms.TextBox();
			this.gbSummary = new System.Windows.Forms.GroupBox();
			this.tbSummary = new System.Windows.Forms.TextBox();
			this.tbStadium = new System.Windows.Forms.TextBox();
			this.tbStarPlayerIndex = new System.Windows.Forms.TextBox();
			this.lblHomeStadium = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.pbLogo = new System.Windows.Forms.PictureBox();
			this.cmsLogo = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.exportRawLogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportPNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tbOutput = new System.Windows.Forms.TextBox();
			this.lblHatColor = new System.Windows.Forms.Label();
			this.nudHatColor = new System.Windows.Forms.NumericUpDown();
			this.pHatColor = new System.Windows.Forms.Panel();
			this.lblTrimColor = new System.Windows.Forms.Label();
			this.nudTrimColor = new System.Windows.Forms.NumericUpDown();
			this.pTrimColor = new System.Windows.Forms.Panel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tpSummary = new System.Windows.Forms.TabPage();
			this.tpRoster = new System.Windows.Forms.TabPage();
			this.gbManagerSliders = new System.Windows.Forms.GroupBox();
			this.statusStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.gbSummary.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
			this.cmsLogo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudHatColor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudTrimColor)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tpSummary.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLabelFilePath});
			this.statusStrip1.Location = new System.Drawing.Point(0, 451);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(624, 22);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tssLabelFilePath
			// 
			this.tssLabelFilePath.Name = "tssLabelFilePath";
			this.tssLabelFilePath.Size = new System.Drawing.Size(58, 17);
			this.tssLabelFilePath.Text = "[file path]";
			// 
			// menuStrip1
			// 
			this.menuStrip1.AllowMerge = false;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.teamToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(624, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// teamToolStripMenuItem
			// 
			this.teamToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveChangesToolStripMenuItem,
            this.toolStripSeparator1,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
			this.teamToolStripMenuItem.Name = "teamToolStripMenuItem";
			this.teamToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
			this.teamToolStripMenuItem.Text = "&Team";
			// 
			// saveChangesToolStripMenuItem
			// 
			this.saveChangesToolStripMenuItem.Name = "saveChangesToolStripMenuItem";
			this.saveChangesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveChangesToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.saveChangesToolStripMenuItem.Text = "&Save Changes";
			this.saveChangesToolStripMenuItem.Click += new System.EventHandler(this.saveChangesToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(184, 6);
			// 
			// importToolStripMenuItem
			// 
			this.importToolStripMenuItem.Name = "importToolStripMenuItem";
			this.importToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
			this.importToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.importToolStripMenuItem.Text = "&Import...";
			this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.exportToolStripMenuItem.Text = "&Export...";
			this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(184, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// tbTeamName
			// 
			this.tbTeamName.Location = new System.Drawing.Point(53, 27);
			this.tbTeamName.MaxLength = 20;
			this.tbTeamName.Name = "tbTeamName";
			this.tbTeamName.ReadOnly = true;
			this.tbTeamName.Size = new System.Drawing.Size(189, 20);
			this.tbTeamName.TabIndex = 2;
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(12, 30);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(35, 13);
			this.lblName.TabIndex = 3;
			this.lblName.Text = "&Name";
			// 
			// lblTeamOwner
			// 
			this.lblTeamOwner.AutoSize = true;
			this.lblTeamOwner.Location = new System.Drawing.Point(248, 30);
			this.lblTeamOwner.Name = "lblTeamOwner";
			this.lblTeamOwner.Size = new System.Drawing.Size(68, 13);
			this.lblTeamOwner.TabIndex = 4;
			this.lblTeamOwner.Text = "Team Owner";
			// 
			// tbTeamOwner
			// 
			this.tbTeamOwner.Location = new System.Drawing.Point(322, 27);
			this.tbTeamOwner.MaxLength = 15;
			this.tbTeamOwner.Name = "tbTeamOwner";
			this.tbTeamOwner.ReadOnly = true;
			this.tbTeamOwner.Size = new System.Drawing.Size(162, 20);
			this.tbTeamOwner.TabIndex = 5;
			// 
			// gbSummary
			// 
			this.gbSummary.Controls.Add(this.tbSummary);
			this.gbSummary.Location = new System.Drawing.Point(6, 6);
			this.gbSummary.Name = "gbSummary";
			this.gbSummary.Size = new System.Drawing.Size(230, 139);
			this.gbSummary.TabIndex = 6;
			this.gbSummary.TabStop = false;
			this.gbSummary.Text = "&Summary";
			// 
			// tbSummary
			// 
			this.tbSummary.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbSummary.Location = new System.Drawing.Point(6, 19);
			this.tbSummary.MaxLength = 159;
			this.tbSummary.Multiline = true;
			this.tbSummary.Name = "tbSummary";
			this.tbSummary.ReadOnly = true;
			this.tbSummary.Size = new System.Drawing.Size(218, 114);
			this.tbSummary.TabIndex = 0;
			this.tbSummary.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tbStadium
			// 
			this.tbStadium.Location = new System.Drawing.Point(335, 6);
			this.tbStadium.Name = "tbStadium";
			this.tbStadium.ReadOnly = true;
			this.tbStadium.Size = new System.Drawing.Size(143, 20);
			this.tbStadium.TabIndex = 7;
			// 
			// tbStarPlayerIndex
			// 
			this.tbStarPlayerIndex.Location = new System.Drawing.Point(335, 32);
			this.tbStarPlayerIndex.Name = "tbStarPlayerIndex";
			this.tbStarPlayerIndex.ReadOnly = true;
			this.tbStarPlayerIndex.Size = new System.Drawing.Size(143, 20);
			this.tbStarPlayerIndex.TabIndex = 8;
			// 
			// lblHomeStadium
			// 
			this.lblHomeStadium.AutoSize = true;
			this.lblHomeStadium.Location = new System.Drawing.Point(242, 9);
			this.lblHomeStadium.Name = "lblHomeStadium";
			this.lblHomeStadium.Size = new System.Drawing.Size(76, 13);
			this.lblHomeStadium.TabIndex = 9;
			this.lblHomeStadium.Text = "&Home Stadium";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(242, 35);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(87, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "St&ar Player Index";
			// 
			// pbLogo
			// 
			this.pbLogo.ContextMenuStrip = this.cmsLogo;
			this.pbLogo.Location = new System.Drawing.Point(564, 27);
			this.pbLogo.Name = "pbLogo";
			this.pbLogo.Size = new System.Drawing.Size(48, 32);
			this.pbLogo.TabIndex = 11;
			this.pbLogo.TabStop = false;
			// 
			// cmsLogo
			// 
			this.cmsLogo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportRawLogoToolStripMenuItem,
            this.exportPNGToolStripMenuItem});
			this.cmsLogo.Name = "cmsLogo";
			this.cmsLogo.Size = new System.Drawing.Size(173, 48);
			// 
			// exportRawLogoToolStripMenuItem
			// 
			this.exportRawLogoToolStripMenuItem.Name = "exportRawLogoToolStripMenuItem";
			this.exportRawLogoToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.exportRawLogoToolStripMenuItem.Text = "Export &Raw Logo...";
			this.exportRawLogoToolStripMenuItem.Click += new System.EventHandler(this.exportRawLogoToolStripMenuItem_Click);
			// 
			// exportPNGToolStripMenuItem
			// 
			this.exportPNGToolStripMenuItem.Name = "exportPNGToolStripMenuItem";
			this.exportPNGToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.exportPNGToolStripMenuItem.Text = "Export &PNG...";
			this.exportPNGToolStripMenuItem.Click += new System.EventHandler(this.exportPNGToolStripMenuItem_Click);
			// 
			// tbOutput
			// 
			this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutput.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbOutput.Location = new System.Drawing.Point(12, 357);
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.ReadOnly = true;
			this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbOutput.Size = new System.Drawing.Size(600, 91);
			this.tbOutput.TabIndex = 13;
			// 
			// lblHatColor
			// 
			this.lblHatColor.AutoSize = true;
			this.lblHatColor.Location = new System.Drawing.Point(242, 59);
			this.lblHatColor.Name = "lblHatColor";
			this.lblHatColor.Size = new System.Drawing.Size(51, 13);
			this.lblHatColor.TabIndex = 14;
			this.lblHatColor.Text = "Hat Color";
			// 
			// nudHatColor
			// 
			this.nudHatColor.Enabled = false;
			this.nudHatColor.Hexadecimal = true;
			this.nudHatColor.Location = new System.Drawing.Point(335, 57);
			this.nudHatColor.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
			this.nudHatColor.Name = "nudHatColor";
			this.nudHatColor.ReadOnly = true;
			this.nudHatColor.Size = new System.Drawing.Size(61, 20);
			this.nudHatColor.TabIndex = 15;
			this.nudHatColor.ValueChanged += new System.EventHandler(this.nudHatColor_ValueChanged);
			// 
			// pHatColor
			// 
			this.pHatColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pHatColor.Location = new System.Drawing.Point(402, 58);
			this.pHatColor.Name = "pHatColor";
			this.pHatColor.Size = new System.Drawing.Size(76, 20);
			this.pHatColor.TabIndex = 16;
			// 
			// lblTrimColor
			// 
			this.lblTrimColor.AutoSize = true;
			this.lblTrimColor.Location = new System.Drawing.Point(242, 85);
			this.lblTrimColor.Name = "lblTrimColor";
			this.lblTrimColor.Size = new System.Drawing.Size(54, 13);
			this.lblTrimColor.TabIndex = 17;
			this.lblTrimColor.Text = "Trim Color";
			// 
			// nudTrimColor
			// 
			this.nudTrimColor.Enabled = false;
			this.nudTrimColor.Hexadecimal = true;
			this.nudTrimColor.Location = new System.Drawing.Point(335, 83);
			this.nudTrimColor.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
			this.nudTrimColor.Name = "nudTrimColor";
			this.nudTrimColor.ReadOnly = true;
			this.nudTrimColor.Size = new System.Drawing.Size(61, 20);
			this.nudTrimColor.TabIndex = 18;
			this.nudTrimColor.ValueChanged += new System.EventHandler(this.nudTrimColor_ValueChanged);
			// 
			// pTrimColor
			// 
			this.pTrimColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pTrimColor.Location = new System.Drawing.Point(402, 84);
			this.pTrimColor.Name = "pTrimColor";
			this.pTrimColor.Size = new System.Drawing.Size(76, 20);
			this.pTrimColor.TabIndex = 17;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tpSummary);
			this.tabControl1.Controls.Add(this.tpRoster);
			this.tabControl1.Location = new System.Drawing.Point(12, 65);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(600, 286);
			this.tabControl1.TabIndex = 1;
			// 
			// tpSummary
			// 
			this.tpSummary.Controls.Add(this.gbManagerSliders);
			this.tpSummary.Controls.Add(this.gbSummary);
			this.tpSummary.Controls.Add(this.tbStadium);
			this.tpSummary.Controls.Add(this.pTrimColor);
			this.tpSummary.Controls.Add(this.nudTrimColor);
			this.tpSummary.Controls.Add(this.lblHomeStadium);
			this.tpSummary.Controls.Add(this.lblTrimColor);
			this.tpSummary.Controls.Add(this.label3);
			this.tpSummary.Controls.Add(this.tbStarPlayerIndex);
			this.tpSummary.Controls.Add(this.pHatColor);
			this.tpSummary.Controls.Add(this.lblHatColor);
			this.tpSummary.Controls.Add(this.nudHatColor);
			this.tpSummary.Location = new System.Drawing.Point(4, 22);
			this.tpSummary.Name = "tpSummary";
			this.tpSummary.Padding = new System.Windows.Forms.Padding(3);
			this.tpSummary.Size = new System.Drawing.Size(592, 260);
			this.tpSummary.TabIndex = 0;
			this.tpSummary.Text = "Summary";
			this.tpSummary.UseVisualStyleBackColor = true;
			// 
			// tpRoster
			// 
			this.tpRoster.Location = new System.Drawing.Point(4, 22);
			this.tpRoster.Name = "tpRoster";
			this.tpRoster.Padding = new System.Windows.Forms.Padding(3);
			this.tpRoster.Size = new System.Drawing.Size(192, 74);
			this.tpRoster.TabIndex = 1;
			this.tpRoster.Text = "Roster";
			this.tpRoster.UseVisualStyleBackColor = true;
			// 
			// gbManagerSliders
			// 
			this.gbManagerSliders.Location = new System.Drawing.Point(242, 110);
			this.gbManagerSliders.Name = "gbManagerSliders";
			this.gbManagerSliders.Size = new System.Drawing.Size(344, 144);
			this.gbManagerSliders.TabIndex = 19;
			this.gbManagerSliders.TabStop = false;
			this.gbManagerSliders.Text = "Manager Sliders";
			// 
			// TeamEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 473);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.tbOutput);
			this.Controls.Add(this.pbLogo);
			this.Controls.Add(this.tbTeamOwner);
			this.Controls.Add(this.lblTeamOwner);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.tbTeamName);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TeamEditor";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Team Editor";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TeamEditor_FormClosed);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.gbSummary.ResumeLayout(false);
			this.gbSummary.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
			this.cmsLogo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudHatColor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudTrimColor)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tpSummary.ResumeLayout(false);
			this.tpSummary.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem teamToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveChangesToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel tssLabelFilePath;
		private System.Windows.Forms.TextBox tbTeamName;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblTeamOwner;
		private System.Windows.Forms.TextBox tbTeamOwner;
		private System.Windows.Forms.GroupBox gbSummary;
		private System.Windows.Forms.TextBox tbSummary;
		private System.Windows.Forms.TextBox tbStadium;
		private System.Windows.Forms.TextBox tbStarPlayerIndex;
		private System.Windows.Forms.Label lblHomeStadium;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox pbLogo;
		private System.Windows.Forms.ContextMenuStrip cmsLogo;
		private System.Windows.Forms.ToolStripMenuItem exportRawLogoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportPNGToolStripMenuItem;
		private System.Windows.Forms.TextBox tbOutput;
		private System.Windows.Forms.Label lblHatColor;
		private System.Windows.Forms.NumericUpDown nudHatColor;
		private System.Windows.Forms.Panel pHatColor;
		private System.Windows.Forms.Label lblTrimColor;
		private System.Windows.Forms.NumericUpDown nudTrimColor;
		private System.Windows.Forms.Panel pTrimColor;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tpSummary;
		private System.Windows.Forms.TabPage tpRoster;
		private System.Windows.Forms.GroupBox gbManagerSliders;
	}
}