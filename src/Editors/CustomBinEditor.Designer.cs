
namespace HB5Tool
{
	partial class CustomBinEditor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomBinEditor));
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tssLabelFilePath = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lvIcons = new System.Windows.Forms.ListView();
			this.cmsLogos = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.exportLogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportPNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gbNames = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.lblStarsGame = new System.Windows.Forms.Label();
			this.lblPlayoffs = new System.Windows.Forms.Label();
			this.lblLeagueChamp = new System.Windows.Forms.Label();
			this.lblWorldChamp = new System.Windows.Forms.Label();
			this.lblLeagueA = new System.Windows.Forms.Label();
			this.lblLeagueL = new System.Windows.Forms.Label();
			this.tbStarsGame = new System.Windows.Forms.TextBox();
			this.tbPlayoffs = new System.Windows.Forms.TextBox();
			this.tbLeagueChamp = new System.Windows.Forms.TextBox();
			this.tbWorldChamp = new System.Windows.Forms.TextBox();
			this.tbLeagueA = new System.Windows.Forms.TextBox();
			this.tbLeagueN = new System.Windows.Forms.TextBox();
			this.gbOptions = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.cbInjuries = new System.Windows.Forms.CheckBox();
			this.cbComTrades = new System.Windows.Forms.CheckBox();
			this.cbComRejectTrades = new System.Windows.Forms.CheckBox();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.importLogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importPNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.cmsLogos.SuspendLayout();
			this.gbNames.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.gbOptions.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLabelFilePath});
			this.statusStrip1.Location = new System.Drawing.Point(0, 339);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(624, 22);
			this.statusStrip1.TabIndex = 1;
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
            this.customToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(624, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// customToolStripMenuItem
			// 
			this.customToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveChangesToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
			this.customToolStripMenuItem.Name = "customToolStripMenuItem";
			this.customToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.customToolStripMenuItem.Text = "&Custom";
			// 
			// saveChangesToolStripMenuItem
			// 
			this.saveChangesToolStripMenuItem.Name = "saveChangesToolStripMenuItem";
			this.saveChangesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.saveChangesToolStripMenuItem.Text = "&Save Changes";
			this.saveChangesToolStripMenuItem.Click += new System.EventHandler(this.saveChangesToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// lvIcons
			// 
			this.lvIcons.ContextMenuStrip = this.cmsLogos;
			this.lvIcons.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvIcons.HideSelection = false;
			this.lvIcons.Location = new System.Drawing.Point(12, 27);
			this.lvIcons.Name = "lvIcons";
			this.lvIcons.Size = new System.Drawing.Size(121, 309);
			this.lvIcons.TabIndex = 0;
			this.lvIcons.TileSize = new System.Drawing.Size(168, 32);
			this.lvIcons.UseCompatibleStateImageBehavior = false;
			// 
			// cmsLogos
			// 
			this.cmsLogos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportLogoToolStripMenuItem,
            this.exportPNGToolStripMenuItem,
            this.toolStripSeparator2,
            this.importLogoToolStripMenuItem,
            this.importPNGToolStripMenuItem});
			this.cmsLogos.Name = "cmsLogos";
			this.cmsLogos.Size = new System.Drawing.Size(150, 98);
			// 
			// exportLogoToolStripMenuItem
			// 
			this.exportLogoToolStripMenuItem.Name = "exportLogoToolStripMenuItem";
			this.exportLogoToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.exportLogoToolStripMenuItem.Text = "&Export Logo...";
			this.exportLogoToolStripMenuItem.Click += new System.EventHandler(this.exportLogoToolStripMenuItem_Click);
			// 
			// exportPNGToolStripMenuItem
			// 
			this.exportPNGToolStripMenuItem.Name = "exportPNGToolStripMenuItem";
			this.exportPNGToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.exportPNGToolStripMenuItem.Text = "Export &PNG...";
			this.exportPNGToolStripMenuItem.Click += new System.EventHandler(this.exportPNGToolStripMenuItem_Click);
			// 
			// gbNames
			// 
			this.gbNames.Controls.Add(this.tableLayoutPanel2);
			this.gbNames.Location = new System.Drawing.Point(139, 27);
			this.gbNames.Name = "gbNames";
			this.gbNames.Size = new System.Drawing.Size(473, 192);
			this.gbNames.TabIndex = 1;
			this.gbNames.TabStop = false;
			this.gbNames.Text = "&Names";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.tableLayoutPanel2.Controls.Add(this.lblStarsGame, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.lblPlayoffs, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.lblLeagueChamp, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.lblWorldChamp, 0, 3);
			this.tableLayoutPanel2.Controls.Add(this.lblLeagueA, 0, 4);
			this.tableLayoutPanel2.Controls.Add(this.lblLeagueL, 0, 5);
			this.tableLayoutPanel2.Controls.Add(this.tbStarsGame, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.tbPlayoffs, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.tbLeagueChamp, 1, 2);
			this.tableLayoutPanel2.Controls.Add(this.tbWorldChamp, 1, 3);
			this.tableLayoutPanel2.Controls.Add(this.tbLeagueA, 1, 4);
			this.tableLayoutPanel2.Controls.Add(this.tbLeagueN, 1, 5);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 6;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(467, 173);
			this.tableLayoutPanel2.TabIndex = 2;
			// 
			// lblStarsGame
			// 
			this.lblStarsGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblStarsGame.AutoSize = true;
			this.lblStarsGame.Location = new System.Drawing.Point(3, 7);
			this.lblStarsGame.Name = "lblStarsGame";
			this.lblStarsGame.Size = new System.Drawing.Size(134, 13);
			this.lblStarsGame.TabIndex = 3;
			this.lblStarsGame.Text = "&Stars Game";
			// 
			// lblPlayoffs
			// 
			this.lblPlayoffs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPlayoffs.AutoSize = true;
			this.lblPlayoffs.Location = new System.Drawing.Point(3, 35);
			this.lblPlayoffs.Name = "lblPlayoffs";
			this.lblPlayoffs.Size = new System.Drawing.Size(134, 13);
			this.lblPlayoffs.TabIndex = 5;
			this.lblPlayoffs.Text = "&Playoffs";
			// 
			// lblLeagueChamp
			// 
			this.lblLeagueChamp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblLeagueChamp.AutoSize = true;
			this.lblLeagueChamp.Location = new System.Drawing.Point(3, 63);
			this.lblLeagueChamp.Name = "lblLeagueChamp";
			this.lblLeagueChamp.Size = new System.Drawing.Size(134, 13);
			this.lblLeagueChamp.TabIndex = 7;
			this.lblLeagueChamp.Text = "&League Championships";
			// 
			// lblWorldChamp
			// 
			this.lblWorldChamp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblWorldChamp.AutoSize = true;
			this.lblWorldChamp.Location = new System.Drawing.Point(3, 91);
			this.lblWorldChamp.Name = "lblWorldChamp";
			this.lblWorldChamp.Size = new System.Drawing.Size(134, 13);
			this.lblWorldChamp.TabIndex = 9;
			this.lblWorldChamp.Text = "&World Championship";
			// 
			// lblLeagueA
			// 
			this.lblLeagueA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblLeagueA.AutoSize = true;
			this.lblLeagueA.Location = new System.Drawing.Point(3, 119);
			this.lblLeagueA.Name = "lblLeagueA";
			this.lblLeagueA.Size = new System.Drawing.Size(134, 13);
			this.lblLeagueA.TabIndex = 11;
			this.lblLeagueA.Text = "&American League";
			// 
			// lblLeagueL
			// 
			this.lblLeagueL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblLeagueL.AutoSize = true;
			this.lblLeagueL.Location = new System.Drawing.Point(3, 150);
			this.lblLeagueL.Name = "lblLeagueL";
			this.lblLeagueL.Size = new System.Drawing.Size(134, 13);
			this.lblLeagueL.TabIndex = 13;
			this.lblLeagueL.Text = "&National League";
			// 
			// tbStarsGame
			// 
			this.tbStarsGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbStarsGame.Location = new System.Drawing.Point(143, 4);
			this.tbStarsGame.MaxLength = 23;
			this.tbStarsGame.Name = "tbStarsGame";
			this.tbStarsGame.ReadOnly = true;
			this.tbStarsGame.Size = new System.Drawing.Size(321, 20);
			this.tbStarsGame.TabIndex = 4;
			// 
			// tbPlayoffs
			// 
			this.tbPlayoffs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbPlayoffs.Location = new System.Drawing.Point(143, 32);
			this.tbPlayoffs.MaxLength = 23;
			this.tbPlayoffs.Name = "tbPlayoffs";
			this.tbPlayoffs.ReadOnly = true;
			this.tbPlayoffs.Size = new System.Drawing.Size(321, 20);
			this.tbPlayoffs.TabIndex = 6;
			// 
			// tbLeagueChamp
			// 
			this.tbLeagueChamp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbLeagueChamp.Location = new System.Drawing.Point(143, 60);
			this.tbLeagueChamp.MaxLength = 23;
			this.tbLeagueChamp.Name = "tbLeagueChamp";
			this.tbLeagueChamp.ReadOnly = true;
			this.tbLeagueChamp.Size = new System.Drawing.Size(321, 20);
			this.tbLeagueChamp.TabIndex = 8;
			// 
			// tbWorldChamp
			// 
			this.tbWorldChamp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbWorldChamp.Location = new System.Drawing.Point(143, 88);
			this.tbWorldChamp.MaxLength = 23;
			this.tbWorldChamp.Name = "tbWorldChamp";
			this.tbWorldChamp.ReadOnly = true;
			this.tbWorldChamp.Size = new System.Drawing.Size(321, 20);
			this.tbWorldChamp.TabIndex = 10;
			// 
			// tbLeagueA
			// 
			this.tbLeagueA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbLeagueA.Location = new System.Drawing.Point(143, 116);
			this.tbLeagueA.MaxLength = 23;
			this.tbLeagueA.Name = "tbLeagueA";
			this.tbLeagueA.ReadOnly = true;
			this.tbLeagueA.Size = new System.Drawing.Size(321, 20);
			this.tbLeagueA.TabIndex = 12;
			// 
			// tbLeagueN
			// 
			this.tbLeagueN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbLeagueN.Location = new System.Drawing.Point(143, 146);
			this.tbLeagueN.MaxLength = 23;
			this.tbLeagueN.Name = "tbLeagueN";
			this.tbLeagueN.ReadOnly = true;
			this.tbLeagueN.Size = new System.Drawing.Size(321, 20);
			this.tbLeagueN.TabIndex = 14;
			// 
			// gbOptions
			// 
			this.gbOptions.Controls.Add(this.tableLayoutPanel1);
			this.gbOptions.Location = new System.Drawing.Point(139, 225);
			this.gbOptions.Name = "gbOptions";
			this.gbOptions.Size = new System.Drawing.Size(473, 111);
			this.gbOptions.TabIndex = 15;
			this.gbOptions.TabStop = false;
			this.gbOptions.Text = "&Options";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.cbInjuries, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.cbComTrades, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.cbComRejectTrades, 0, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(467, 92);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// cbInjuries
			// 
			this.cbInjuries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbInjuries.AutoSize = true;
			this.cbInjuries.Enabled = false;
			this.cbInjuries.Location = new System.Drawing.Point(3, 6);
			this.cbInjuries.Name = "cbInjuries";
			this.cbInjuries.Size = new System.Drawing.Size(461, 17);
			this.cbInjuries.TabIndex = 16;
			this.cbInjuries.Text = "&Injuries can occur";
			this.cbInjuries.UseVisualStyleBackColor = true;
			// 
			// cbComTrades
			// 
			this.cbComTrades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbComTrades.AutoSize = true;
			this.cbComTrades.Enabled = false;
			this.cbComTrades.Location = new System.Drawing.Point(3, 36);
			this.cbComTrades.Name = "cbComTrades";
			this.cbComTrades.Size = new System.Drawing.Size(461, 17);
			this.cbComTrades.TabIndex = 17;
			this.cbComTrades.Text = "Computer makes &trades";
			this.cbComTrades.UseVisualStyleBackColor = true;
			// 
			// cbComRejectTrades
			// 
			this.cbComRejectTrades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbComRejectTrades.AutoSize = true;
			this.cbComRejectTrades.Enabled = false;
			this.cbComRejectTrades.Location = new System.Drawing.Point(3, 67);
			this.cbComRejectTrades.Name = "cbComRejectTrades";
			this.cbComRejectTrades.Size = new System.Drawing.Size(461, 17);
			this.cbComRejectTrades.TabIndex = 18;
			this.cbComRejectTrades.Text = "Computer can &reject trades";
			this.cbComRejectTrades.UseVisualStyleBackColor = true;
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(146, 6);
			// 
			// importLogoToolStripMenuItem
			// 
			this.importLogoToolStripMenuItem.Name = "importLogoToolStripMenuItem";
			this.importLogoToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.importLogoToolStripMenuItem.Text = "&Import Logo...";
			this.importLogoToolStripMenuItem.Click += new System.EventHandler(this.importLogoToolStripMenuItem_Click);
			// 
			// importPNGToolStripMenuItem
			// 
			this.importPNGToolStripMenuItem.Name = "importPNGToolStripMenuItem";
			this.importPNGToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.importPNGToolStripMenuItem.Text = "Import P&NG...";
			this.importPNGToolStripMenuItem.Click += new System.EventHandler(this.importPNGToolStripMenuItem_Click);
			// 
			// CustomBinEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 361);
			this.Controls.Add(this.gbOptions);
			this.Controls.Add(this.gbNames);
			this.Controls.Add(this.lvIcons);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(640, 400);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(640, 400);
			this.Name = "CustomBinEditor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "CUSTOM.BIN Editor";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CustomBinEditor_FormClosed);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.cmsLogos.ResumeLayout(false);
			this.gbNames.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.gbOptions.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel tssLabelFilePath;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem customToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ListView lvIcons;
		private System.Windows.Forms.GroupBox gbNames;
		private System.Windows.Forms.GroupBox gbOptions;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.CheckBox cbInjuries;
		private System.Windows.Forms.CheckBox cbComTrades;
		private System.Windows.Forms.CheckBox cbComRejectTrades;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Label lblStarsGame;
		private System.Windows.Forms.Label lblPlayoffs;
		private System.Windows.Forms.Label lblLeagueChamp;
		private System.Windows.Forms.Label lblWorldChamp;
		private System.Windows.Forms.Label lblLeagueA;
		private System.Windows.Forms.Label lblLeagueL;
		private System.Windows.Forms.TextBox tbStarsGame;
		private System.Windows.Forms.TextBox tbPlayoffs;
		private System.Windows.Forms.TextBox tbLeagueChamp;
		private System.Windows.Forms.TextBox tbWorldChamp;
		private System.Windows.Forms.TextBox tbLeagueA;
		private System.Windows.Forms.TextBox tbLeagueN;
		private System.Windows.Forms.ToolStripMenuItem saveChangesToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ContextMenuStrip cmsLogos;
		private System.Windows.Forms.ToolStripMenuItem exportLogoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportPNGToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem importLogoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem importPNGToolStripMenuItem;
	}
}