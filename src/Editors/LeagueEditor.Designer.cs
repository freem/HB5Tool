﻿
namespace HB5Tool
{
	partial class LeagueEditor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeagueEditor));
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tssLabelFilePath = new System.Windows.Forms.ToolStripStatusLabel();
			this.leagueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.tbOutput = new System.Windows.Forms.TextBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tpGeneral = new System.Windows.Forms.TabPage();
			this.tpLeagueInfo = new System.Windows.Forms.TabPage();
			this.tbLeagueInfo = new System.Windows.Forms.TextBox();
			this.tpPlayers = new System.Windows.Forms.TabPage();
			this.tlpPlayers = new System.Windows.Forms.TableLayoutPanel();
			this.gbBatters = new System.Windows.Forms.GroupBox();
			this.lblBatterID = new System.Windows.Forms.Label();
			this.lbBatters = new System.Windows.Forms.ListBox();
			this.gbPitchers = new System.Windows.Forms.GroupBox();
			this.lblPitcherID = new System.Windows.Forms.Label();
			this.lbPitchers = new System.Windows.Forms.ListBox();
			this.tpTeams = new System.Windows.Forms.TabPage();
			this.btnEditTeam = new System.Windows.Forms.Button();
			this.pbStarPlayer = new System.Windows.Forms.PictureBox();
			this.tbTeamOutput = new System.Windows.Forms.TextBox();
			this.lblTrimColor = new System.Windows.Forms.Label();
			this.lblHatColor = new System.Windows.Forms.Label();
			this.pTrimColor = new System.Windows.Forms.Panel();
			this.pHatColor = new System.Windows.Forms.Panel();
			this.pbLogo = new System.Windows.Forms.PictureBox();
			this.cmsLogo = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.exportRawLogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportPNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lbTeams = new System.Windows.Forms.ListBox();
			this.tpSchedule = new System.Windows.Forms.TabPage();
			this.tbSchedule = new System.Windows.Forms.TextBox();
			this.tpUnknown4 = new System.Windows.Forms.TabPage();
			this.tbUnk4 = new System.Windows.Forms.TextBox();
			this.tpUnknown6 = new System.Windows.Forms.TabPage();
			this.tbUnk6 = new System.Windows.Forms.TextBox();
			this.tpUnknownB = new System.Windows.Forms.TabPage();
			this.tbUnkB = new System.Windows.Forms.TextBox();
			this.tpUnknownC = new System.Windows.Forms.TabPage();
			this.tbUnkC = new System.Windows.Forms.TextBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.tpStats = new System.Windows.Forms.TabPage();
			this.lblStatsPlayer = new System.Windows.Forms.Label();
			this.cbPlayerStats = new System.Windows.Forms.ComboBox();
			this.tcPlayerStats = new System.Windows.Forms.TabControl();
			this.tpStatsSeason = new System.Windows.Forms.TabPage();
			this.tpStatsWeekly = new System.Windows.Forms.TabPage();
			this.tpStatsHistorical = new System.Windows.Forms.TabPage();
			this.tpStatsLifetime = new System.Windows.Forms.TabPage();
			this.tbStatsHistorical = new System.Windows.Forms.TextBox();
			this.tbStatsSeason = new System.Windows.Forms.TextBox();
			this.tbStatsWeekly = new System.Windows.Forms.TextBox();
			this.tbStatsLifetime = new System.Windows.Forms.TextBox();
			this.statusStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tpGeneral.SuspendLayout();
			this.tpLeagueInfo.SuspendLayout();
			this.tpPlayers.SuspendLayout();
			this.tlpPlayers.SuspendLayout();
			this.gbBatters.SuspendLayout();
			this.gbPitchers.SuspendLayout();
			this.tpTeams.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbStarPlayer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
			this.cmsLogo.SuspendLayout();
			this.tpSchedule.SuspendLayout();
			this.tpUnknown4.SuspendLayout();
			this.tpUnknown6.SuspendLayout();
			this.tpUnknownB.SuspendLayout();
			this.tpUnknownC.SuspendLayout();
			this.tpStats.SuspendLayout();
			this.tcPlayerStats.SuspendLayout();
			this.tpStatsSeason.SuspendLayout();
			this.tpStatsWeekly.SuspendLayout();
			this.tpStatsHistorical.SuspendLayout();
			this.tpStatsLifetime.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLabelFilePath});
			this.statusStrip1.Location = new System.Drawing.Point(0, 353);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(634, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tssLabelFilePath
			// 
			this.tssLabelFilePath.Name = "tssLabelFilePath";
			this.tssLabelFilePath.Size = new System.Drawing.Size(58, 17);
			this.tssLabelFilePath.Text = "[file path]";
			// 
			// leagueToolStripMenuItem
			// 
			this.leagueToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.leagueToolStripMenuItem.Name = "leagueToolStripMenuItem";
			this.leagueToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
			this.leagueToolStripMenuItem.Text = "&League";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.AllowMerge = false;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leagueToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(634, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// tbOutput
			// 
			this.tbOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbOutput.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbOutput.Location = new System.Drawing.Point(3, 3);
			this.tbOutput.MaxLength = 65535;
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.ReadOnly = true;
			this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbOutput.Size = new System.Drawing.Size(620, 297);
			this.tbOutput.TabIndex = 2;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tpGeneral);
			this.tabControl1.Controls.Add(this.tpLeagueInfo);
			this.tabControl1.Controls.Add(this.tpPlayers);
			this.tabControl1.Controls.Add(this.tpTeams);
			this.tabControl1.Controls.Add(this.tpSchedule);
			this.tabControl1.Controls.Add(this.tpUnknown4);
			this.tabControl1.Controls.Add(this.tpUnknown6);
			this.tabControl1.Controls.Add(this.tpUnknownB);
			this.tabControl1.Controls.Add(this.tpUnknownC);
			this.tabControl1.Controls.Add(this.tpStats);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 24);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(634, 329);
			this.tabControl1.TabIndex = 3;
			// 
			// tpGeneral
			// 
			this.tpGeneral.Controls.Add(this.tbOutput);
			this.tpGeneral.Location = new System.Drawing.Point(4, 22);
			this.tpGeneral.Name = "tpGeneral";
			this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tpGeneral.Size = new System.Drawing.Size(626, 303);
			this.tpGeneral.TabIndex = 0;
			this.tpGeneral.Text = "General";
			this.tpGeneral.UseVisualStyleBackColor = true;
			// 
			// tpLeagueInfo
			// 
			this.tpLeagueInfo.Controls.Add(this.tbLeagueInfo);
			this.tpLeagueInfo.Location = new System.Drawing.Point(4, 22);
			this.tpLeagueInfo.Name = "tpLeagueInfo";
			this.tpLeagueInfo.Size = new System.Drawing.Size(626, 303);
			this.tpLeagueInfo.TabIndex = 3;
			this.tpLeagueInfo.Text = "Info";
			this.tpLeagueInfo.UseVisualStyleBackColor = true;
			// 
			// tbLeagueInfo
			// 
			this.tbLeagueInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbLeagueInfo.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbLeagueInfo.Location = new System.Drawing.Point(0, 0);
			this.tbLeagueInfo.MaxLength = 65535;
			this.tbLeagueInfo.Multiline = true;
			this.tbLeagueInfo.Name = "tbLeagueInfo";
			this.tbLeagueInfo.ReadOnly = true;
			this.tbLeagueInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbLeagueInfo.Size = new System.Drawing.Size(626, 303);
			this.tbLeagueInfo.TabIndex = 3;
			// 
			// tpPlayers
			// 
			this.tpPlayers.Controls.Add(this.tlpPlayers);
			this.tpPlayers.Location = new System.Drawing.Point(4, 22);
			this.tpPlayers.Name = "tpPlayers";
			this.tpPlayers.Padding = new System.Windows.Forms.Padding(3);
			this.tpPlayers.Size = new System.Drawing.Size(626, 303);
			this.tpPlayers.TabIndex = 1;
			this.tpPlayers.Text = "Players";
			this.tpPlayers.UseVisualStyleBackColor = true;
			// 
			// tlpPlayers
			// 
			this.tlpPlayers.ColumnCount = 2;
			this.tlpPlayers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpPlayers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpPlayers.Controls.Add(this.gbBatters, 0, 0);
			this.tlpPlayers.Controls.Add(this.gbPitchers, 1, 0);
			this.tlpPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpPlayers.Location = new System.Drawing.Point(3, 3);
			this.tlpPlayers.Name = "tlpPlayers";
			this.tlpPlayers.RowCount = 1;
			this.tlpPlayers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpPlayers.Size = new System.Drawing.Size(620, 297);
			this.tlpPlayers.TabIndex = 4;
			// 
			// gbBatters
			// 
			this.gbBatters.Controls.Add(this.lblBatterID);
			this.gbBatters.Controls.Add(this.lbBatters);
			this.gbBatters.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbBatters.Location = new System.Drawing.Point(3, 3);
			this.gbBatters.Name = "gbBatters";
			this.gbBatters.Size = new System.Drawing.Size(304, 291);
			this.gbBatters.TabIndex = 2;
			this.gbBatters.TabStop = false;
			this.gbBatters.Text = "&Batters";
			// 
			// lblBatterID
			// 
			this.lblBatterID.AutoSize = true;
			this.lblBatterID.Location = new System.Drawing.Point(6, 257);
			this.lblBatterID.Name = "lblBatterID";
			this.lblBatterID.Size = new System.Drawing.Size(90, 13);
			this.lblBatterID.TabIndex = 1;
			this.lblBatterID.Text = "Batter ID: 0x0000";
			// 
			// lbBatters
			// 
			this.lbBatters.FormattingEnabled = true;
			this.lbBatters.Location = new System.Drawing.Point(3, 16);
			this.lbBatters.Name = "lbBatters";
			this.lbBatters.ScrollAlwaysVisible = true;
			this.lbBatters.Size = new System.Drawing.Size(293, 238);
			this.lbBatters.TabIndex = 0;
			this.lbBatters.SelectedIndexChanged += new System.EventHandler(this.lbBatters_SelectedIndexChanged);
			// 
			// gbPitchers
			// 
			this.gbPitchers.Controls.Add(this.lblPitcherID);
			this.gbPitchers.Controls.Add(this.lbPitchers);
			this.gbPitchers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbPitchers.Location = new System.Drawing.Point(313, 3);
			this.gbPitchers.Name = "gbPitchers";
			this.gbPitchers.Size = new System.Drawing.Size(304, 291);
			this.gbPitchers.TabIndex = 3;
			this.gbPitchers.TabStop = false;
			this.gbPitchers.Text = "&Pitchers";
			// 
			// lblPitcherID
			// 
			this.lblPitcherID.AutoSize = true;
			this.lblPitcherID.Location = new System.Drawing.Point(6, 257);
			this.lblPitcherID.Name = "lblPitcherID";
			this.lblPitcherID.Size = new System.Drawing.Size(95, 13);
			this.lblPitcherID.TabIndex = 2;
			this.lblPitcherID.Text = "Pitcher ID: 0x0000";
			// 
			// lbPitchers
			// 
			this.lbPitchers.FormattingEnabled = true;
			this.lbPitchers.Location = new System.Drawing.Point(4, 16);
			this.lbPitchers.Name = "lbPitchers";
			this.lbPitchers.ScrollAlwaysVisible = true;
			this.lbPitchers.Size = new System.Drawing.Size(293, 238);
			this.lbPitchers.TabIndex = 1;
			this.lbPitchers.SelectedIndexChanged += new System.EventHandler(this.lbPitchers_SelectedIndexChanged);
			// 
			// tpTeams
			// 
			this.tpTeams.Controls.Add(this.btnEditTeam);
			this.tpTeams.Controls.Add(this.pbStarPlayer);
			this.tpTeams.Controls.Add(this.tbTeamOutput);
			this.tpTeams.Controls.Add(this.lblTrimColor);
			this.tpTeams.Controls.Add(this.lblHatColor);
			this.tpTeams.Controls.Add(this.pTrimColor);
			this.tpTeams.Controls.Add(this.pHatColor);
			this.tpTeams.Controls.Add(this.pbLogo);
			this.tpTeams.Controls.Add(this.lbTeams);
			this.tpTeams.Location = new System.Drawing.Point(4, 22);
			this.tpTeams.Name = "tpTeams";
			this.tpTeams.Size = new System.Drawing.Size(626, 303);
			this.tpTeams.TabIndex = 2;
			this.tpTeams.Text = "Teams";
			this.tpTeams.UseVisualStyleBackColor = true;
			// 
			// btnEditTeam
			// 
			this.btnEditTeam.Location = new System.Drawing.Point(169, 102);
			this.btnEditTeam.Name = "btnEditTeam";
			this.btnEditTeam.Size = new System.Drawing.Size(75, 23);
			this.btnEditTeam.TabIndex = 24;
			this.btnEditTeam.Text = "danger!!";
			this.btnEditTeam.UseVisualStyleBackColor = true;
			this.btnEditTeam.Click += new System.EventHandler(this.btnEditTeam_Click);
			// 
			// pbStarPlayer
			// 
			this.pbStarPlayer.Location = new System.Drawing.Point(490, 5);
			this.pbStarPlayer.MaximumSize = new System.Drawing.Size(128, 120);
			this.pbStarPlayer.MinimumSize = new System.Drawing.Size(128, 120);
			this.pbStarPlayer.Name = "pbStarPlayer";
			this.pbStarPlayer.Size = new System.Drawing.Size(128, 120);
			this.pbStarPlayer.TabIndex = 23;
			this.pbStarPlayer.TabStop = false;
			// 
			// tbTeamOutput
			// 
			this.tbTeamOutput.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbTeamOutput.Location = new System.Drawing.Point(169, 131);
			this.tbTeamOutput.MaxLength = 65535;
			this.tbTeamOutput.Multiline = true;
			this.tbTeamOutput.Name = "tbTeamOutput";
			this.tbTeamOutput.ReadOnly = true;
			this.tbTeamOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbTeamOutput.Size = new System.Drawing.Size(449, 169);
			this.tbTeamOutput.TabIndex = 22;
			// 
			// lblTrimColor
			// 
			this.lblTrimColor.AutoSize = true;
			this.lblTrimColor.Location = new System.Drawing.Point(171, 36);
			this.lblTrimColor.Name = "lblTrimColor";
			this.lblTrimColor.Size = new System.Drawing.Size(54, 13);
			this.lblTrimColor.TabIndex = 21;
			this.lblTrimColor.Text = "Trim Color";
			// 
			// lblHatColor
			// 
			this.lblHatColor.AutoSize = true;
			this.lblHatColor.Location = new System.Drawing.Point(174, 10);
			this.lblHatColor.Name = "lblHatColor";
			this.lblHatColor.Size = new System.Drawing.Size(51, 13);
			this.lblHatColor.TabIndex = 20;
			this.lblHatColor.Text = "Hat Color";
			// 
			// pTrimColor
			// 
			this.pTrimColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pTrimColor.Location = new System.Drawing.Point(231, 29);
			this.pTrimColor.Name = "pTrimColor";
			this.pTrimColor.Size = new System.Drawing.Size(76, 20);
			this.pTrimColor.TabIndex = 19;
			this.pTrimColor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pTrimColor_MouseClick);
			// 
			// pHatColor
			// 
			this.pHatColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pHatColor.Location = new System.Drawing.Point(231, 3);
			this.pHatColor.Name = "pHatColor";
			this.pHatColor.Size = new System.Drawing.Size(76, 20);
			this.pHatColor.TabIndex = 18;
			this.pHatColor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pHatColor_MouseClick);
			// 
			// pbLogo
			// 
			this.pbLogo.ContextMenuStrip = this.cmsLogo;
			this.pbLogo.Location = new System.Drawing.Point(323, 3);
			this.pbLogo.Name = "pbLogo";
			this.pbLogo.Size = new System.Drawing.Size(48, 32);
			this.pbLogo.TabIndex = 12;
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
			// lbTeams
			// 
			this.lbTeams.FormattingEnabled = true;
			this.lbTeams.Location = new System.Drawing.Point(8, 3);
			this.lbTeams.Name = "lbTeams";
			this.lbTeams.ScrollAlwaysVisible = true;
			this.lbTeams.Size = new System.Drawing.Size(155, 290);
			this.lbTeams.TabIndex = 0;
			this.lbTeams.SelectedIndexChanged += new System.EventHandler(this.lbTeams_SelectedIndexChanged);
			// 
			// tpSchedule
			// 
			this.tpSchedule.Controls.Add(this.tbSchedule);
			this.tpSchedule.Location = new System.Drawing.Point(4, 22);
			this.tpSchedule.Name = "tpSchedule";
			this.tpSchedule.Padding = new System.Windows.Forms.Padding(3);
			this.tpSchedule.Size = new System.Drawing.Size(626, 303);
			this.tpSchedule.TabIndex = 4;
			this.tpSchedule.Text = "Schedule";
			this.tpSchedule.UseVisualStyleBackColor = true;
			// 
			// tbSchedule
			// 
			this.tbSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbSchedule.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbSchedule.Location = new System.Drawing.Point(3, 3);
			this.tbSchedule.MaxLength = 65535;
			this.tbSchedule.Multiline = true;
			this.tbSchedule.Name = "tbSchedule";
			this.tbSchedule.ReadOnly = true;
			this.tbSchedule.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbSchedule.Size = new System.Drawing.Size(620, 297);
			this.tbSchedule.TabIndex = 3;
			// 
			// tpUnknown4
			// 
			this.tpUnknown4.Controls.Add(this.tbUnk4);
			this.tpUnknown4.Location = new System.Drawing.Point(4, 22);
			this.tpUnknown4.Name = "tpUnknown4";
			this.tpUnknown4.Padding = new System.Windows.Forms.Padding(3);
			this.tpUnknown4.Size = new System.Drawing.Size(626, 303);
			this.tpUnknown4.TabIndex = 5;
			this.tpUnknown4.Text = "Unknown4";
			this.tpUnknown4.UseVisualStyleBackColor = true;
			// 
			// tbUnk4
			// 
			this.tbUnk4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbUnk4.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbUnk4.Location = new System.Drawing.Point(3, 3);
			this.tbUnk4.MaxLength = 65535;
			this.tbUnk4.Multiline = true;
			this.tbUnk4.Name = "tbUnk4";
			this.tbUnk4.ReadOnly = true;
			this.tbUnk4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbUnk4.Size = new System.Drawing.Size(620, 297);
			this.tbUnk4.TabIndex = 4;
			// 
			// tpUnknown6
			// 
			this.tpUnknown6.Controls.Add(this.tbUnk6);
			this.tpUnknown6.Location = new System.Drawing.Point(4, 22);
			this.tpUnknown6.Name = "tpUnknown6";
			this.tpUnknown6.Padding = new System.Windows.Forms.Padding(3);
			this.tpUnknown6.Size = new System.Drawing.Size(626, 303);
			this.tpUnknown6.TabIndex = 8;
			this.tpUnknown6.Text = "Unknown6";
			this.tpUnknown6.UseVisualStyleBackColor = true;
			// 
			// tbUnk6
			// 
			this.tbUnk6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbUnk6.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbUnk6.Location = new System.Drawing.Point(3, 3);
			this.tbUnk6.MaxLength = 65535;
			this.tbUnk6.Multiline = true;
			this.tbUnk6.Name = "tbUnk6";
			this.tbUnk6.ReadOnly = true;
			this.tbUnk6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbUnk6.Size = new System.Drawing.Size(620, 297);
			this.tbUnk6.TabIndex = 5;
			// 
			// tpUnknownB
			// 
			this.tpUnknownB.Controls.Add(this.tbUnkB);
			this.tpUnknownB.Location = new System.Drawing.Point(4, 22);
			this.tpUnknownB.Name = "tpUnknownB";
			this.tpUnknownB.Padding = new System.Windows.Forms.Padding(3);
			this.tpUnknownB.Size = new System.Drawing.Size(626, 303);
			this.tpUnknownB.TabIndex = 6;
			this.tpUnknownB.Text = "UnknownB";
			this.tpUnknownB.UseVisualStyleBackColor = true;
			// 
			// tbUnkB
			// 
			this.tbUnkB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbUnkB.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbUnkB.Location = new System.Drawing.Point(3, 3);
			this.tbUnkB.MaxLength = 65535;
			this.tbUnkB.Multiline = true;
			this.tbUnkB.Name = "tbUnkB";
			this.tbUnkB.ReadOnly = true;
			this.tbUnkB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbUnkB.Size = new System.Drawing.Size(620, 297);
			this.tbUnkB.TabIndex = 4;
			// 
			// tpUnknownC
			// 
			this.tpUnknownC.Controls.Add(this.tbUnkC);
			this.tpUnknownC.Location = new System.Drawing.Point(4, 22);
			this.tpUnknownC.Name = "tpUnknownC";
			this.tpUnknownC.Padding = new System.Windows.Forms.Padding(3);
			this.tpUnknownC.Size = new System.Drawing.Size(626, 303);
			this.tpUnknownC.TabIndex = 7;
			this.tpUnknownC.Text = "UnknownC";
			this.tpUnknownC.UseVisualStyleBackColor = true;
			// 
			// tbUnkC
			// 
			this.tbUnkC.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbUnkC.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbUnkC.Location = new System.Drawing.Point(3, 3);
			this.tbUnkC.MaxLength = 65535;
			this.tbUnkC.Multiline = true;
			this.tbUnkC.Name = "tbUnkC";
			this.tbUnkC.ReadOnly = true;
			this.tbUnkC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbUnkC.Size = new System.Drawing.Size(620, 297);
			this.tbUnkC.TabIndex = 4;
			// 
			// tpStats
			// 
			this.tpStats.Controls.Add(this.tcPlayerStats);
			this.tpStats.Controls.Add(this.cbPlayerStats);
			this.tpStats.Controls.Add(this.lblStatsPlayer);
			this.tpStats.Location = new System.Drawing.Point(4, 22);
			this.tpStats.Name = "tpStats";
			this.tpStats.Padding = new System.Windows.Forms.Padding(3);
			this.tpStats.Size = new System.Drawing.Size(626, 303);
			this.tpStats.TabIndex = 9;
			this.tpStats.Text = "Stats";
			this.tpStats.UseVisualStyleBackColor = true;
			// 
			// lblStatsPlayer
			// 
			this.lblStatsPlayer.AutoSize = true;
			this.lblStatsPlayer.Location = new System.Drawing.Point(9, 9);
			this.lblStatsPlayer.Name = "lblStatsPlayer";
			this.lblStatsPlayer.Size = new System.Drawing.Size(36, 13);
			this.lblStatsPlayer.TabIndex = 0;
			this.lblStatsPlayer.Text = "&Player";
			// 
			// cbPlayerStats
			// 
			this.cbPlayerStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbPlayerStats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPlayerStats.FormattingEnabled = true;
			this.cbPlayerStats.Location = new System.Drawing.Point(107, 6);
			this.cbPlayerStats.Name = "cbPlayerStats";
			this.cbPlayerStats.Size = new System.Drawing.Size(511, 21);
			this.cbPlayerStats.TabIndex = 1;
			this.cbPlayerStats.SelectedIndexChanged += new System.EventHandler(this.cbPlayerStats_SelectedIndexChanged);
			// 
			// tcPlayerStats
			// 
			this.tcPlayerStats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tcPlayerStats.Controls.Add(this.tpStatsHistorical);
			this.tcPlayerStats.Controls.Add(this.tpStatsSeason);
			this.tcPlayerStats.Controls.Add(this.tpStatsWeekly);
			this.tcPlayerStats.Controls.Add(this.tpStatsLifetime);
			this.tcPlayerStats.Location = new System.Drawing.Point(6, 33);
			this.tcPlayerStats.Name = "tcPlayerStats";
			this.tcPlayerStats.SelectedIndex = 0;
			this.tcPlayerStats.Size = new System.Drawing.Size(614, 264);
			this.tcPlayerStats.TabIndex = 2;
			// 
			// tpStatsSeason
			// 
			this.tpStatsSeason.Controls.Add(this.tbStatsSeason);
			this.tpStatsSeason.Location = new System.Drawing.Point(4, 22);
			this.tpStatsSeason.Name = "tpStatsSeason";
			this.tpStatsSeason.Padding = new System.Windows.Forms.Padding(3);
			this.tpStatsSeason.Size = new System.Drawing.Size(606, 238);
			this.tpStatsSeason.TabIndex = 0;
			this.tpStatsSeason.Text = "Season";
			this.tpStatsSeason.UseVisualStyleBackColor = true;
			// 
			// tpStatsWeekly
			// 
			this.tpStatsWeekly.Controls.Add(this.tbStatsWeekly);
			this.tpStatsWeekly.Location = new System.Drawing.Point(4, 22);
			this.tpStatsWeekly.Name = "tpStatsWeekly";
			this.tpStatsWeekly.Padding = new System.Windows.Forms.Padding(3);
			this.tpStatsWeekly.Size = new System.Drawing.Size(606, 238);
			this.tpStatsWeekly.TabIndex = 1;
			this.tpStatsWeekly.Text = "Weekly";
			this.tpStatsWeekly.UseVisualStyleBackColor = true;
			// 
			// tpStatsHistorical
			// 
			this.tpStatsHistorical.Controls.Add(this.tbStatsHistorical);
			this.tpStatsHistorical.Location = new System.Drawing.Point(4, 22);
			this.tpStatsHistorical.Name = "tpStatsHistorical";
			this.tpStatsHistorical.Size = new System.Drawing.Size(606, 238);
			this.tpStatsHistorical.TabIndex = 2;
			this.tpStatsHistorical.Text = "Historical";
			this.tpStatsHistorical.UseVisualStyleBackColor = true;
			// 
			// tpStatsLifetime
			// 
			this.tpStatsLifetime.Controls.Add(this.tbStatsLifetime);
			this.tpStatsLifetime.Location = new System.Drawing.Point(4, 22);
			this.tpStatsLifetime.Name = "tpStatsLifetime";
			this.tpStatsLifetime.Size = new System.Drawing.Size(606, 238);
			this.tpStatsLifetime.TabIndex = 3;
			this.tpStatsLifetime.Text = "Lifetime";
			this.tpStatsLifetime.UseVisualStyleBackColor = true;
			// 
			// tbStatsHistorical
			// 
			this.tbStatsHistorical.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbStatsHistorical.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbStatsHistorical.Location = new System.Drawing.Point(0, 0);
			this.tbStatsHistorical.Multiline = true;
			this.tbStatsHistorical.Name = "tbStatsHistorical";
			this.tbStatsHistorical.ReadOnly = true;
			this.tbStatsHistorical.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbStatsHistorical.Size = new System.Drawing.Size(606, 238);
			this.tbStatsHistorical.TabIndex = 0;
			// 
			// tbStatsSeason
			// 
			this.tbStatsSeason.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbStatsSeason.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbStatsSeason.Location = new System.Drawing.Point(3, 3);
			this.tbStatsSeason.Multiline = true;
			this.tbStatsSeason.Name = "tbStatsSeason";
			this.tbStatsSeason.ReadOnly = true;
			this.tbStatsSeason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbStatsSeason.Size = new System.Drawing.Size(600, 232);
			this.tbStatsSeason.TabIndex = 1;
			// 
			// tbStatsWeekly
			// 
			this.tbStatsWeekly.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbStatsWeekly.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbStatsWeekly.Location = new System.Drawing.Point(3, 3);
			this.tbStatsWeekly.Multiline = true;
			this.tbStatsWeekly.Name = "tbStatsWeekly";
			this.tbStatsWeekly.ReadOnly = true;
			this.tbStatsWeekly.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbStatsWeekly.Size = new System.Drawing.Size(600, 232);
			this.tbStatsWeekly.TabIndex = 1;
			// 
			// tbStatsLifetime
			// 
			this.tbStatsLifetime.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbStatsLifetime.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbStatsLifetime.Location = new System.Drawing.Point(0, 0);
			this.tbStatsLifetime.Multiline = true;
			this.tbStatsLifetime.Name = "tbStatsLifetime";
			this.tbStatsLifetime.ReadOnly = true;
			this.tbStatsLifetime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbStatsLifetime.Size = new System.Drawing.Size(606, 238);
			this.tbStatsLifetime.TabIndex = 1;
			// 
			// LeagueEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(634, 375);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LeagueEditor";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "League Editor";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LeagueEditor_FormClosed);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tpGeneral.ResumeLayout(false);
			this.tpGeneral.PerformLayout();
			this.tpLeagueInfo.ResumeLayout(false);
			this.tpLeagueInfo.PerformLayout();
			this.tpPlayers.ResumeLayout(false);
			this.tlpPlayers.ResumeLayout(false);
			this.gbBatters.ResumeLayout(false);
			this.gbBatters.PerformLayout();
			this.gbPitchers.ResumeLayout(false);
			this.gbPitchers.PerformLayout();
			this.tpTeams.ResumeLayout(false);
			this.tpTeams.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbStarPlayer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
			this.cmsLogo.ResumeLayout(false);
			this.tpSchedule.ResumeLayout(false);
			this.tpSchedule.PerformLayout();
			this.tpUnknown4.ResumeLayout(false);
			this.tpUnknown4.PerformLayout();
			this.tpUnknown6.ResumeLayout(false);
			this.tpUnknown6.PerformLayout();
			this.tpUnknownB.ResumeLayout(false);
			this.tpUnknownB.PerformLayout();
			this.tpUnknownC.ResumeLayout(false);
			this.tpUnknownC.PerformLayout();
			this.tpStats.ResumeLayout(false);
			this.tpStats.PerformLayout();
			this.tcPlayerStats.ResumeLayout(false);
			this.tpStatsSeason.ResumeLayout(false);
			this.tpStatsSeason.PerformLayout();
			this.tpStatsWeekly.ResumeLayout(false);
			this.tpStatsWeekly.PerformLayout();
			this.tpStatsHistorical.ResumeLayout(false);
			this.tpStatsHistorical.PerformLayout();
			this.tpStatsLifetime.ResumeLayout(false);
			this.tpStatsLifetime.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel tssLabelFilePath;
		private System.Windows.Forms.ToolStripMenuItem leagueToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.TextBox tbOutput;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tpGeneral;
		private System.Windows.Forms.TabPage tpPlayers;
		private System.Windows.Forms.TabPage tpTeams;
		private System.Windows.Forms.TableLayoutPanel tlpPlayers;
		private System.Windows.Forms.GroupBox gbBatters;
		private System.Windows.Forms.ListBox lbBatters;
		private System.Windows.Forms.GroupBox gbPitchers;
		private System.Windows.Forms.ListBox lbPitchers;
		private System.Windows.Forms.ListBox lbTeams;
		private System.Windows.Forms.PictureBox pbLogo;
		private System.Windows.Forms.ContextMenuStrip cmsLogo;
		private System.Windows.Forms.ToolStripMenuItem exportRawLogoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportPNGToolStripMenuItem;
		private System.Windows.Forms.Panel pTrimColor;
		private System.Windows.Forms.Panel pHatColor;
		private System.Windows.Forms.Label lblTrimColor;
		private System.Windows.Forms.Label lblHatColor;
		private System.Windows.Forms.TabPage tpLeagueInfo;
		private System.Windows.Forms.TextBox tbLeagueInfo;
		private System.Windows.Forms.TextBox tbTeamOutput;
		private System.Windows.Forms.TabPage tpSchedule;
		private System.Windows.Forms.TextBox tbSchedule;
		private System.Windows.Forms.TabPage tpUnknown4;
		private System.Windows.Forms.TabPage tpUnknownB;
		private System.Windows.Forms.TabPage tpUnknownC;
		private System.Windows.Forms.TextBox tbUnk4;
		private System.Windows.Forms.TextBox tbUnkB;
		private System.Windows.Forms.TextBox tbUnkC;
		private System.Windows.Forms.TabPage tpUnknown6;
		private System.Windows.Forms.TextBox tbUnk6;
		private System.Windows.Forms.Label lblBatterID;
		private System.Windows.Forms.Label lblPitcherID;
		private System.Windows.Forms.PictureBox pbStarPlayer;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button btnEditTeam;
		private System.Windows.Forms.TabPage tpStats;
		private System.Windows.Forms.TabControl tcPlayerStats;
		private System.Windows.Forms.TabPage tpStatsSeason;
		private System.Windows.Forms.TabPage tpStatsWeekly;
		private System.Windows.Forms.ComboBox cbPlayerStats;
		private System.Windows.Forms.Label lblStatsPlayer;
		private System.Windows.Forms.TabPage tpStatsHistorical;
		private System.Windows.Forms.TabPage tpStatsLifetime;
		private System.Windows.Forms.TextBox tbStatsHistorical;
		private System.Windows.Forms.TextBox tbStatsSeason;
		private System.Windows.Forms.TextBox tbStatsWeekly;
		private System.Windows.Forms.TextBox tbStatsLifetime;
	}
}