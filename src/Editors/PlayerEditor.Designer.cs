
namespace HB5Tool
{
	partial class PlayerEditor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerEditor));
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tssLabelFilePath = new System.Windows.Forms.ToolStripStatusLabel();
			this.tbName = new System.Windows.Forms.TextBox();
			this.lblName = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lblJerseyNum = new System.Windows.Forms.Label();
			this.nudJerseyNum = new System.Windows.Forms.NumericUpDown();
			this.lblPlayerType = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.tbRatings = new System.Windows.Forms.TextBox();
			this.tbStats = new System.Windows.Forms.TextBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tpRatings = new System.Windows.Forms.TabPage();
			this.tpStats = new System.Windows.Forms.TabPage();
			this.statusStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudJerseyNum)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tpRatings.SuspendLayout();
			this.tpStats.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLabelFilePath});
			this.statusStrip1.Location = new System.Drawing.Point(0, 353);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(634, 22);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tssLabelFilePath
			// 
			this.tssLabelFilePath.Name = "tssLabelFilePath";
			this.tssLabelFilePath.Size = new System.Drawing.Size(58, 17);
			this.tssLabelFilePath.Text = "[file path]";
			// 
			// tbName
			// 
			this.tbName.Location = new System.Drawing.Point(53, 26);
			this.tbName.MaxLength = 16;
			this.tbName.Name = "tbName";
			this.tbName.ReadOnly = true;
			this.tbName.Size = new System.Drawing.Size(182, 20);
			this.tbName.TabIndex = 1;
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(12, 29);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(35, 13);
			this.lblName.TabIndex = 2;
			this.lblName.Text = "&Name";
			// 
			// menuStrip1
			// 
			this.menuStrip1.AllowMerge = false;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(634, 24);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
			this.fileToolStripMenuItem.Text = "&Player";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.saveToolStripMenuItem.Text = "&Save Changes";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
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
			// lblJerseyNum
			// 
			this.lblJerseyNum.AutoSize = true;
			this.lblJerseyNum.Location = new System.Drawing.Point(241, 29);
			this.lblJerseyNum.Name = "lblJerseyNum";
			this.lblJerseyNum.Size = new System.Drawing.Size(77, 13);
			this.lblJerseyNum.TabIndex = 4;
			this.lblJerseyNum.Text = "Jersey Number";
			// 
			// nudJerseyNum
			// 
			this.nudJerseyNum.Enabled = false;
			this.nudJerseyNum.Location = new System.Drawing.Point(324, 27);
			this.nudJerseyNum.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
			this.nudJerseyNum.Name = "nudJerseyNum";
			this.nudJerseyNum.ReadOnly = true;
			this.nudJerseyNum.Size = new System.Drawing.Size(53, 20);
			this.nudJerseyNum.TabIndex = 5;
			// 
			// lblPlayerType
			// 
			this.lblPlayerType.AutoSize = true;
			this.lblPlayerType.Location = new System.Drawing.Point(383, 29);
			this.lblPlayerType.Name = "lblPlayerType";
			this.lblPlayerType.Size = new System.Drawing.Size(66, 13);
			this.lblPlayerType.TabIndex = 6;
			this.lblPlayerType.Text = "Player Type:";
			// 
			// tbRatings
			// 
			this.tbRatings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbRatings.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbRatings.Location = new System.Drawing.Point(3, 3);
			this.tbRatings.Multiline = true;
			this.tbRatings.Name = "tbRatings";
			this.tbRatings.ReadOnly = true;
			this.tbRatings.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbRatings.Size = new System.Drawing.Size(596, 266);
			this.tbRatings.TabIndex = 0;
			// 
			// tbStats
			// 
			this.tbStats.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbStats.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbStats.Location = new System.Drawing.Point(3, 3);
			this.tbStats.Multiline = true;
			this.tbStats.Name = "tbStats";
			this.tbStats.ReadOnly = true;
			this.tbStats.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbStats.Size = new System.Drawing.Size(596, 266);
			this.tbStats.TabIndex = 0;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tpRatings);
			this.tabControl1.Controls.Add(this.tpStats);
			this.tabControl1.Location = new System.Drawing.Point(12, 52);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(610, 298);
			this.tabControl1.TabIndex = 1;
			// 
			// tpRatings
			// 
			this.tpRatings.Controls.Add(this.tbRatings);
			this.tpRatings.Location = new System.Drawing.Point(4, 22);
			this.tpRatings.Name = "tpRatings";
			this.tpRatings.Padding = new System.Windows.Forms.Padding(3);
			this.tpRatings.Size = new System.Drawing.Size(602, 272);
			this.tpRatings.TabIndex = 0;
			this.tpRatings.Text = "Ratings";
			this.tpRatings.UseVisualStyleBackColor = true;
			// 
			// tpStats
			// 
			this.tpStats.Controls.Add(this.tbStats);
			this.tpStats.Location = new System.Drawing.Point(4, 22);
			this.tpStats.Name = "tpStats";
			this.tpStats.Padding = new System.Windows.Forms.Padding(3);
			this.tpStats.Size = new System.Drawing.Size(602, 272);
			this.tpStats.TabIndex = 1;
			this.tpStats.Text = "Statistics";
			this.tpStats.UseVisualStyleBackColor = true;
			// 
			// PlayerEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(634, 375);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.lblPlayerType);
			this.Controls.Add(this.nudJerseyNum);
			this.Controls.Add(this.lblJerseyNum);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.tbName);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PlayerEditor";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Player Editor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayerEditor_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PlayerEditor_FormClosed);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudJerseyNum)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tpRatings.ResumeLayout(false);
			this.tpRatings.PerformLayout();
			this.tpStats.ResumeLayout(false);
			this.tpStats.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel tssLabelFilePath;
		private System.Windows.Forms.TextBox tbName;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.Label lblJerseyNum;
		private System.Windows.Forms.NumericUpDown nudJerseyNum;
		private System.Windows.Forms.Label lblPlayerType;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TextBox tbRatings;
		private System.Windows.Forms.TextBox tbStats;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tpRatings;
		private System.Windows.Forms.TabPage tpStats;
	}
}