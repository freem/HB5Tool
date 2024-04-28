
namespace HB5Tool
{
	partial class PicsEditor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PicsEditor));
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tssLabelFilePath = new System.Windows.Forms.ToolStripStatusLabel();
			this.tbOutput = new System.Windows.Forms.TextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.picsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lbPicList = new System.Windows.Forms.ListBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.extractFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportPNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pbPic = new System.Windows.Forms.PictureBox();
			this.statusStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbPic)).BeginInit();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLabelFilePath});
			this.statusStrip1.Location = new System.Drawing.Point(0, 339);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(624, 22);
			this.statusStrip1.TabIndex = 3;
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
			this.tbOutput.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbOutput.Location = new System.Drawing.Point(154, 153);
			this.tbOutput.MaxLength = 65535;
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.ReadOnly = true;
			this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbOutput.Size = new System.Drawing.Size(458, 183);
			this.tbOutput.TabIndex = 6;
			// 
			// menuStrip1
			// 
			this.menuStrip1.AllowMerge = false;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.picsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(624, 24);
			this.menuStrip1.TabIndex = 7;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// picsToolStripMenuItem
			// 
			this.picsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.picsToolStripMenuItem.Name = "picsToolStripMenuItem";
			this.picsToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.picsToolStripMenuItem.Text = "&Pics";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// lbPicList
			// 
			this.lbPicList.ContextMenuStrip = this.contextMenuStrip1;
			this.lbPicList.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbPicList.FormattingEnabled = true;
			this.lbPicList.ItemHeight = 15;
			this.lbPicList.Location = new System.Drawing.Point(12, 27);
			this.lbPicList.Name = "lbPicList";
			this.lbPicList.ScrollAlwaysVisible = true;
			this.lbPicList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lbPicList.Size = new System.Drawing.Size(136, 304);
			this.lbPicList.TabIndex = 8;
			this.lbPicList.SelectedIndexChanged += new System.EventHandler(this.lbPicList_SelectedIndexChanged);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractFileToolStripMenuItem,
            this.exportPNGToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(145, 48);
			// 
			// extractFileToolStripMenuItem
			// 
			this.extractFileToolStripMenuItem.Name = "extractFileToolStripMenuItem";
			this.extractFileToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.extractFileToolStripMenuItem.Text = "&Extract File...";
			this.extractFileToolStripMenuItem.Click += new System.EventHandler(this.extractFileToolStripMenuItem_Click);
			// 
			// exportPNGToolStripMenuItem
			// 
			this.exportPNGToolStripMenuItem.Name = "exportPNGToolStripMenuItem";
			this.exportPNGToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.exportPNGToolStripMenuItem.Text = "Export &PNG...";
			this.exportPNGToolStripMenuItem.Click += new System.EventHandler(this.exportPNGToolStripMenuItem_Click);
			// 
			// pbPic
			// 
			this.pbPic.Location = new System.Drawing.Point(154, 27);
			this.pbPic.MinimumSize = new System.Drawing.Size(128, 120);
			this.pbPic.Name = "pbPic";
			this.pbPic.Size = new System.Drawing.Size(128, 120);
			this.pbPic.TabIndex = 9;
			this.pbPic.TabStop = false;
			// 
			// PicsEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 361);
			this.Controls.Add(this.pbPic);
			this.Controls.Add(this.lbPicList);
			this.Controls.Add(this.tbOutput);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PicsEditor";
			this.Text = "Pics Editor";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PicsEditor_FormClosed);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbPic)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel tssLabelFilePath;
		private System.Windows.Forms.TextBox tbOutput;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem picsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ListBox lbPicList;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem extractFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportPNGToolStripMenuItem;
		private System.Windows.Forms.PictureBox pbPic;
	}
}