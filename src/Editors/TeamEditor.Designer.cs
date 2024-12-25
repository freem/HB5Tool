
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
			this.lblStarPlayer = new System.Windows.Forms.Label();
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
			this.tpMain = new System.Windows.Forms.TabPage();
			this.gbManagerSliders = new System.Windows.Forms.GroupBox();
			this.tlpManagerSliders = new System.Windows.Forms.TableLayoutPanel();
			this.tbPitcherHook = new System.Windows.Forms.TrackBar();
			this.tbStealBases = new System.Windows.Forms.TrackBar();
			this.tbRunners = new System.Windows.Forms.TrackBar();
			this.tbSacrifice = new System.Windows.Forms.TrackBar();
			this.tbOffenseDefense = new System.Windows.Forms.TrackBar();
			this.tbSpeedPower = new System.Windows.Forms.TrackBar();
			this.tbRookieVeteran = new System.Windows.Forms.TrackBar();
			this.lblSlowHook = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.tpRoster = new System.Windows.Forms.TabPage();
			this.tbRosterDump = new System.Windows.Forms.TextBox();
			this.statusStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.gbSummary.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
			this.cmsLogo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudHatColor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudTrimColor)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tpMain.SuspendLayout();
			this.gbManagerSliders.SuspendLayout();
			this.tlpManagerSliders.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbPitcherHook)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbStealBases)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbRunners)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbSacrifice)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbOffenseDefense)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbSpeedPower)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbRookieVeteran)).BeginInit();
			this.tpRoster.SuspendLayout();
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
			this.tbStadium.Location = new System.Drawing.Point(99, 151);
			this.tbStadium.Name = "tbStadium";
			this.tbStadium.ReadOnly = true;
			this.tbStadium.Size = new System.Drawing.Size(137, 20);
			this.tbStadium.TabIndex = 7;
			// 
			// tbStarPlayerIndex
			// 
			this.tbStarPlayerIndex.Location = new System.Drawing.Point(99, 177);
			this.tbStarPlayerIndex.Name = "tbStarPlayerIndex";
			this.tbStarPlayerIndex.ReadOnly = true;
			this.tbStarPlayerIndex.Size = new System.Drawing.Size(137, 20);
			this.tbStarPlayerIndex.TabIndex = 8;
			// 
			// lblHomeStadium
			// 
			this.lblHomeStadium.AutoSize = true;
			this.lblHomeStadium.Location = new System.Drawing.Point(6, 154);
			this.lblHomeStadium.Name = "lblHomeStadium";
			this.lblHomeStadium.Size = new System.Drawing.Size(76, 13);
			this.lblHomeStadium.TabIndex = 9;
			this.lblHomeStadium.Text = "&Home Stadium";
			// 
			// lblStarPlayer
			// 
			this.lblStarPlayer.AutoSize = true;
			this.lblStarPlayer.Location = new System.Drawing.Point(6, 180);
			this.lblStarPlayer.Name = "lblStarPlayer";
			this.lblStarPlayer.Size = new System.Drawing.Size(87, 13);
			this.lblStarPlayer.TabIndex = 10;
			this.lblStarPlayer.Text = "St&ar Player Index";
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
			this.lblHatColor.Location = new System.Drawing.Point(6, 205);
			this.lblHatColor.Name = "lblHatColor";
			this.lblHatColor.Size = new System.Drawing.Size(53, 13);
			this.lblHatColor.TabIndex = 14;
			this.lblHatColor.Text = "Cap Color";
			// 
			// nudHatColor
			// 
			this.nudHatColor.Enabled = false;
			this.nudHatColor.Hexadecimal = true;
			this.nudHatColor.Location = new System.Drawing.Point(93, 203);
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
			this.pHatColor.Location = new System.Drawing.Point(160, 203);
			this.pHatColor.Name = "pHatColor";
			this.pHatColor.Size = new System.Drawing.Size(76, 20);
			this.pHatColor.TabIndex = 16;
			// 
			// lblTrimColor
			// 
			this.lblTrimColor.AutoSize = true;
			this.lblTrimColor.Location = new System.Drawing.Point(6, 231);
			this.lblTrimColor.Name = "lblTrimColor";
			this.lblTrimColor.Size = new System.Drawing.Size(54, 13);
			this.lblTrimColor.TabIndex = 17;
			this.lblTrimColor.Text = "Trim Color";
			// 
			// nudTrimColor
			// 
			this.nudTrimColor.Enabled = false;
			this.nudTrimColor.Hexadecimal = true;
			this.nudTrimColor.Location = new System.Drawing.Point(93, 229);
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
			this.pTrimColor.Location = new System.Drawing.Point(160, 229);
			this.pTrimColor.Name = "pTrimColor";
			this.pTrimColor.Size = new System.Drawing.Size(76, 20);
			this.pTrimColor.TabIndex = 17;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tpMain);
			this.tabControl1.Controls.Add(this.tpRoster);
			this.tabControl1.Location = new System.Drawing.Point(12, 65);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(600, 286);
			this.tabControl1.TabIndex = 1;
			// 
			// tpMain
			// 
			this.tpMain.Controls.Add(this.gbManagerSliders);
			this.tpMain.Controls.Add(this.gbSummary);
			this.tpMain.Controls.Add(this.tbStadium);
			this.tpMain.Controls.Add(this.pTrimColor);
			this.tpMain.Controls.Add(this.nudTrimColor);
			this.tpMain.Controls.Add(this.lblHomeStadium);
			this.tpMain.Controls.Add(this.lblTrimColor);
			this.tpMain.Controls.Add(this.lblStarPlayer);
			this.tpMain.Controls.Add(this.tbStarPlayerIndex);
			this.tpMain.Controls.Add(this.pHatColor);
			this.tpMain.Controls.Add(this.lblHatColor);
			this.tpMain.Controls.Add(this.nudHatColor);
			this.tpMain.Location = new System.Drawing.Point(4, 22);
			this.tpMain.Name = "tpMain";
			this.tpMain.Padding = new System.Windows.Forms.Padding(3);
			this.tpMain.Size = new System.Drawing.Size(592, 260);
			this.tpMain.TabIndex = 0;
			this.tpMain.Text = "Main";
			this.tpMain.UseVisualStyleBackColor = true;
			// 
			// gbManagerSliders
			// 
			this.gbManagerSliders.Controls.Add(this.tlpManagerSliders);
			this.gbManagerSliders.Location = new System.Drawing.Point(242, 6);
			this.gbManagerSliders.Name = "gbManagerSliders";
			this.gbManagerSliders.Size = new System.Drawing.Size(344, 248);
			this.gbManagerSliders.TabIndex = 19;
			this.gbManagerSliders.TabStop = false;
			this.gbManagerSliders.Text = "Manager Sliders";
			// 
			// tlpManagerSliders
			// 
			this.tlpManagerSliders.ColumnCount = 3;
			this.tlpManagerSliders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpManagerSliders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpManagerSliders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpManagerSliders.Controls.Add(this.tbPitcherHook, 1, 0);
			this.tlpManagerSliders.Controls.Add(this.tbStealBases, 1, 1);
			this.tlpManagerSliders.Controls.Add(this.tbRunners, 1, 2);
			this.tlpManagerSliders.Controls.Add(this.tbSacrifice, 1, 3);
			this.tlpManagerSliders.Controls.Add(this.tbOffenseDefense, 1, 4);
			this.tlpManagerSliders.Controls.Add(this.tbSpeedPower, 1, 5);
			this.tlpManagerSliders.Controls.Add(this.tbRookieVeteran, 1, 6);
			this.tlpManagerSliders.Controls.Add(this.lblSlowHook, 0, 0);
			this.tlpManagerSliders.Controls.Add(this.label2, 2, 0);
			this.tlpManagerSliders.Controls.Add(this.label4, 0, 1);
			this.tlpManagerSliders.Controls.Add(this.label5, 2, 1);
			this.tlpManagerSliders.Controls.Add(this.label6, 0, 2);
			this.tlpManagerSliders.Controls.Add(this.label7, 2, 2);
			this.tlpManagerSliders.Controls.Add(this.label8, 0, 3);
			this.tlpManagerSliders.Controls.Add(this.label9, 2, 3);
			this.tlpManagerSliders.Controls.Add(this.label10, 0, 4);
			this.tlpManagerSliders.Controls.Add(this.label11, 2, 4);
			this.tlpManagerSliders.Controls.Add(this.label12, 0, 5);
			this.tlpManagerSliders.Controls.Add(this.label13, 2, 5);
			this.tlpManagerSliders.Controls.Add(this.label14, 0, 6);
			this.tlpManagerSliders.Controls.Add(this.label15, 2, 6);
			this.tlpManagerSliders.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpManagerSliders.Location = new System.Drawing.Point(3, 16);
			this.tlpManagerSliders.Name = "tlpManagerSliders";
			this.tlpManagerSliders.RowCount = 7;
			this.tlpManagerSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tlpManagerSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
			this.tlpManagerSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
			this.tlpManagerSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
			this.tlpManagerSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
			this.tlpManagerSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
			this.tlpManagerSliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
			this.tlpManagerSliders.Size = new System.Drawing.Size(338, 229);
			this.tlpManagerSliders.TabIndex = 0;
			// 
			// tbPitcherHook
			// 
			this.tbPitcherHook.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbPitcherHook.Enabled = false;
			this.tbPitcherHook.LargeChange = 4;
			this.tbPitcherHook.Location = new System.Drawing.Point(87, 3);
			this.tbPitcherHook.Maximum = 15;
			this.tbPitcherHook.Name = "tbPitcherHook";
			this.tbPitcherHook.Size = new System.Drawing.Size(163, 26);
			this.tbPitcherHook.TabIndex = 0;
			// 
			// tbStealBases
			// 
			this.tbStealBases.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbStealBases.Enabled = false;
			this.tbStealBases.LargeChange = 4;
			this.tbStealBases.Location = new System.Drawing.Point(87, 35);
			this.tbStealBases.Maximum = 15;
			this.tbStealBases.Name = "tbStealBases";
			this.tbStealBases.Size = new System.Drawing.Size(163, 26);
			this.tbStealBases.TabIndex = 1;
			// 
			// tbRunners
			// 
			this.tbRunners.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbRunners.Enabled = false;
			this.tbRunners.LargeChange = 4;
			this.tbRunners.Location = new System.Drawing.Point(87, 67);
			this.tbRunners.Maximum = 15;
			this.tbRunners.Name = "tbRunners";
			this.tbRunners.Size = new System.Drawing.Size(163, 26);
			this.tbRunners.TabIndex = 2;
			// 
			// tbSacrifice
			// 
			this.tbSacrifice.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbSacrifice.Enabled = false;
			this.tbSacrifice.LargeChange = 4;
			this.tbSacrifice.Location = new System.Drawing.Point(87, 99);
			this.tbSacrifice.Maximum = 15;
			this.tbSacrifice.Name = "tbSacrifice";
			this.tbSacrifice.Size = new System.Drawing.Size(163, 26);
			this.tbSacrifice.TabIndex = 3;
			// 
			// tbOffenseDefense
			// 
			this.tbOffenseDefense.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbOffenseDefense.Enabled = false;
			this.tbOffenseDefense.LargeChange = 4;
			this.tbOffenseDefense.Location = new System.Drawing.Point(87, 131);
			this.tbOffenseDefense.Maximum = 15;
			this.tbOffenseDefense.Name = "tbOffenseDefense";
			this.tbOffenseDefense.Size = new System.Drawing.Size(163, 26);
			this.tbOffenseDefense.TabIndex = 4;
			// 
			// tbSpeedPower
			// 
			this.tbSpeedPower.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbSpeedPower.Enabled = false;
			this.tbSpeedPower.LargeChange = 4;
			this.tbSpeedPower.Location = new System.Drawing.Point(87, 163);
			this.tbSpeedPower.Maximum = 15;
			this.tbSpeedPower.Name = "tbSpeedPower";
			this.tbSpeedPower.Size = new System.Drawing.Size(163, 26);
			this.tbSpeedPower.TabIndex = 5;
			// 
			// tbRookieVeteran
			// 
			this.tbRookieVeteran.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbRookieVeteran.Enabled = false;
			this.tbRookieVeteran.LargeChange = 4;
			this.tbRookieVeteran.Location = new System.Drawing.Point(87, 195);
			this.tbRookieVeteran.Maximum = 15;
			this.tbRookieVeteran.Name = "tbRookieVeteran";
			this.tbRookieVeteran.Size = new System.Drawing.Size(163, 31);
			this.tbRookieVeteran.TabIndex = 6;
			// 
			// lblSlowHook
			// 
			this.lblSlowHook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSlowHook.AutoSize = true;
			this.lblSlowHook.Location = new System.Drawing.Point(3, 9);
			this.lblSlowHook.Name = "lblSlowHook";
			this.lblSlowHook.Size = new System.Drawing.Size(78, 13);
			this.lblSlowHook.TabIndex = 7;
			this.lblSlowHook.Text = "Slow Hook";
			this.lblSlowHook.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(256, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(79, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Quick Hook";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 41);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(78, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Don\'t Steal";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(256, 41);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(79, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Steal Lots";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 73);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(78, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "Hold Runners";
			this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(256, 73);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(79, 13);
			this.label7.TabIndex = 12;
			this.label7.Text = "Push Runners";
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(3, 105);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(78, 13);
			this.label8.TabIndex = 13;
			this.label8.Text = "Sacrifice";
			this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(256, 105);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(79, 13);
			this.label9.TabIndex = 14;
			this.label9.Text = "Hit Away";
			// 
			// label10
			// 
			this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(3, 137);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(78, 13);
			this.label10.TabIndex = 15;
			this.label10.Text = "Defense";
			this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label11
			// 
			this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(256, 137);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(79, 13);
			this.label11.TabIndex = 16;
			this.label11.Text = "Offense";
			// 
			// label12
			// 
			this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(3, 169);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(78, 13);
			this.label12.TabIndex = 17;
			this.label12.Text = "Favor Speed";
			this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label13
			// 
			this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(256, 169);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(79, 13);
			this.label13.TabIndex = 18;
			this.label13.Text = "Favor Power";
			// 
			// label14
			// 
			this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(3, 204);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(78, 13);
			this.label14.TabIndex = 19;
			this.label14.Text = "Rookies";
			this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label15
			// 
			this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(256, 204);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(79, 13);
			this.label15.TabIndex = 20;
			this.label15.Text = "Veterans";
			// 
			// tpRoster
			// 
			this.tpRoster.Controls.Add(this.tbRosterDump);
			this.tpRoster.Location = new System.Drawing.Point(4, 22);
			this.tpRoster.Name = "tpRoster";
			this.tpRoster.Padding = new System.Windows.Forms.Padding(3);
			this.tpRoster.Size = new System.Drawing.Size(592, 260);
			this.tpRoster.TabIndex = 1;
			this.tpRoster.Text = "Roster";
			this.tpRoster.UseVisualStyleBackColor = true;
			// 
			// tbRosterDump
			// 
			this.tbRosterDump.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbRosterDump.Location = new System.Drawing.Point(3, 3);
			this.tbRosterDump.Multiline = true;
			this.tbRosterDump.Name = "tbRosterDump";
			this.tbRosterDump.ReadOnly = true;
			this.tbRosterDump.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbRosterDump.Size = new System.Drawing.Size(586, 254);
			this.tbRosterDump.TabIndex = 0;
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
			this.tpMain.ResumeLayout(false);
			this.tpMain.PerformLayout();
			this.gbManagerSliders.ResumeLayout(false);
			this.tlpManagerSliders.ResumeLayout(false);
			this.tlpManagerSliders.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbPitcherHook)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbStealBases)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbRunners)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbSacrifice)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbOffenseDefense)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbSpeedPower)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbRookieVeteran)).EndInit();
			this.tpRoster.ResumeLayout(false);
			this.tpRoster.PerformLayout();
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
		private System.Windows.Forms.Label lblStarPlayer;
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
		private System.Windows.Forms.TabPage tpMain;
		private System.Windows.Forms.TabPage tpRoster;
		private System.Windows.Forms.GroupBox gbManagerSliders;
		private System.Windows.Forms.TableLayoutPanel tlpManagerSliders;
		private System.Windows.Forms.TrackBar tbPitcherHook;
		private System.Windows.Forms.TrackBar tbStealBases;
		private System.Windows.Forms.TrackBar tbRunners;
		private System.Windows.Forms.TrackBar tbSacrifice;
		private System.Windows.Forms.TrackBar tbOffenseDefense;
		private System.Windows.Forms.TrackBar tbSpeedPower;
		private System.Windows.Forms.TrackBar tbRookieVeteran;
		private System.Windows.Forms.Label lblSlowHook;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox tbRosterDump;
	}
}