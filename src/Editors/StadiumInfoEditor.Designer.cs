namespace HB5Tool
{
	partial class StadiumInfoEditor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StadiumInfoEditor));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.stadiumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tssLabelFilePath = new System.Windows.Forms.ToolStripStatusLabel();
			this.tbOutput = new System.Windows.Forms.TextBox();
			this.tlpColors = new System.Windows.Forms.TableLayoutPanel();
			this.lblColorSet1 = new System.Windows.Forms.Label();
			this.lblColorSet2 = new System.Windows.Forms.Label();
			this.lblColorSet3 = new System.Windows.Forms.Label();
			this.lblColorSet4 = new System.Windows.Forms.Label();
			this.pbColorSet1 = new System.Windows.Forms.PictureBox();
			this.pbColorSet2 = new System.Windows.Forms.PictureBox();
			this.pbColorSet3 = new System.Windows.Forms.PictureBox();
			this.pbColorSet4 = new System.Windows.Forms.PictureBox();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.tlpColors.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbColorSet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbColorSet2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbColorSet3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbColorSet4)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.AllowMerge = false;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stadiumToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(624, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// stadiumToolStripMenuItem
			// 
			this.stadiumToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.stadiumToolStripMenuItem.Name = "stadiumToolStripMenuItem";
			this.stadiumToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
			this.stadiumToolStripMenuItem.Text = "&Stadium";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
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
			// tbOutput
			// 
			this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutput.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbOutput.Location = new System.Drawing.Point(12, 24);
			this.tbOutput.MaxLength = 65535;
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.ReadOnly = true;
			this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbOutput.Size = new System.Drawing.Size(600, 186);
			this.tbOutput.TabIndex = 4;
			// 
			// tlpColors
			// 
			this.tlpColors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpColors.ColumnCount = 2;
			this.tlpColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tlpColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.tlpColors.Controls.Add(this.lblColorSet1, 0, 0);
			this.tlpColors.Controls.Add(this.lblColorSet2, 0, 1);
			this.tlpColors.Controls.Add(this.lblColorSet3, 0, 2);
			this.tlpColors.Controls.Add(this.lblColorSet4, 0, 3);
			this.tlpColors.Controls.Add(this.pbColorSet1, 1, 0);
			this.tlpColors.Controls.Add(this.pbColorSet2, 1, 1);
			this.tlpColors.Controls.Add(this.pbColorSet3, 1, 2);
			this.tlpColors.Controls.Add(this.pbColorSet4, 1, 3);
			this.tlpColors.Location = new System.Drawing.Point(12, 216);
			this.tlpColors.Name = "tlpColors";
			this.tlpColors.RowCount = 4;
			this.tlpColors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpColors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpColors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpColors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpColors.Size = new System.Drawing.Size(600, 120);
			this.tlpColors.TabIndex = 5;
			// 
			// lblColorSet1
			// 
			this.lblColorSet1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblColorSet1.AutoSize = true;
			this.lblColorSet1.Location = new System.Drawing.Point(3, 8);
			this.lblColorSet1.Name = "lblColorSet1";
			this.lblColorSet1.Size = new System.Drawing.Size(174, 13);
			this.lblColorSet1.TabIndex = 0;
			this.lblColorSet1.Text = "Custom Color Set 1 (0x20-0x2F)";
			// 
			// lblColorSet2
			// 
			this.lblColorSet2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblColorSet2.AutoSize = true;
			this.lblColorSet2.Location = new System.Drawing.Point(3, 38);
			this.lblColorSet2.Name = "lblColorSet2";
			this.lblColorSet2.Size = new System.Drawing.Size(174, 13);
			this.lblColorSet2.TabIndex = 1;
			this.lblColorSet2.Text = "Custom Color Set 2 (0x30-0x3F)";
			// 
			// lblColorSet3
			// 
			this.lblColorSet3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblColorSet3.AutoSize = true;
			this.lblColorSet3.Location = new System.Drawing.Point(3, 68);
			this.lblColorSet3.Name = "lblColorSet3";
			this.lblColorSet3.Size = new System.Drawing.Size(174, 13);
			this.lblColorSet3.TabIndex = 2;
			this.lblColorSet3.Text = "Custom Color Set 3 (0x40-0x4B)";
			// 
			// lblColorSet4
			// 
			this.lblColorSet4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblColorSet4.AutoSize = true;
			this.lblColorSet4.Location = new System.Drawing.Point(3, 98);
			this.lblColorSet4.Name = "lblColorSet4";
			this.lblColorSet4.Size = new System.Drawing.Size(174, 13);
			this.lblColorSet4.TabIndex = 3;
			this.lblColorSet4.Text = "Custom Color Set 4 (0xB8-0xBF)";
			// 
			// pbColorSet1
			// 
			this.pbColorSet1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbColorSet1.Location = new System.Drawing.Point(183, 3);
			this.pbColorSet1.Name = "pbColorSet1";
			this.pbColorSet1.Size = new System.Drawing.Size(414, 24);
			this.pbColorSet1.TabIndex = 4;
			this.pbColorSet1.TabStop = false;
			// 
			// pbColorSet2
			// 
			this.pbColorSet2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbColorSet2.Location = new System.Drawing.Point(183, 33);
			this.pbColorSet2.Name = "pbColorSet2";
			this.pbColorSet2.Size = new System.Drawing.Size(414, 24);
			this.pbColorSet2.TabIndex = 5;
			this.pbColorSet2.TabStop = false;
			// 
			// pbColorSet3
			// 
			this.pbColorSet3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbColorSet3.Location = new System.Drawing.Point(183, 63);
			this.pbColorSet3.Name = "pbColorSet3";
			this.pbColorSet3.Size = new System.Drawing.Size(414, 24);
			this.pbColorSet3.TabIndex = 6;
			this.pbColorSet3.TabStop = false;
			// 
			// pbColorSet4
			// 
			this.pbColorSet4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbColorSet4.Location = new System.Drawing.Point(183, 93);
			this.pbColorSet4.Name = "pbColorSet4";
			this.pbColorSet4.Size = new System.Drawing.Size(414, 24);
			this.pbColorSet4.TabIndex = 7;
			this.pbColorSet4.TabStop = false;
			// 
			// StadiumInfoEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 361);
			this.Controls.Add(this.tlpColors);
			this.Controls.Add(this.tbOutput);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "StadiumInfoEditor";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Stadium Info Editor";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StadiumInfoEditor_FormClosed);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.tlpColors.ResumeLayout(false);
			this.tlpColors.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbColorSet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbColorSet2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbColorSet3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbColorSet4)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem stadiumToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel tssLabelFilePath;
		private System.Windows.Forms.TextBox tbOutput;
		private System.Windows.Forms.TableLayoutPanel tlpColors;
		private System.Windows.Forms.Label lblColorSet1;
		private System.Windows.Forms.Label lblColorSet2;
		private System.Windows.Forms.Label lblColorSet3;
		private System.Windows.Forms.Label lblColorSet4;
		private System.Windows.Forms.PictureBox pbColorSet1;
		private System.Windows.Forms.PictureBox pbColorSet2;
		private System.Windows.Forms.PictureBox pbColorSet3;
		private System.Windows.Forms.PictureBox pbColorSet4;
	}
}