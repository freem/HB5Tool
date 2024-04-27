
namespace HB5Tool
{
	partial class LogoFileEditor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogoFileEditor));
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tssLabelFilePath = new System.Windows.Forms.ToolStripStatusLabel();
			this.lvLogos = new System.Windows.Forms.ListView();
			this.cmsLogoContext = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.exportDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportPNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.logoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.importPNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importRawLogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1.SuspendLayout();
			this.cmsLogoContext.SuspendLayout();
			this.menuStrip1.SuspendLayout();
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
			// lvLogos
			// 
			this.lvLogos.ContextMenuStrip = this.cmsLogoContext;
			this.lvLogos.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvLogos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvLogos.HideSelection = false;
			this.lvLogos.Location = new System.Drawing.Point(0, 24);
			this.lvLogos.MultiSelect = false;
			this.lvLogos.Name = "lvLogos";
			this.lvLogos.Size = new System.Drawing.Size(624, 315);
			this.lvLogos.TabIndex = 2;
			this.lvLogos.UseCompatibleStateImageBehavior = false;
			// 
			// cmsLogoContext
			// 
			this.cmsLogoContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportDataToolStripMenuItem,
            this.exportPNGToolStripMenuItem,
            this.toolStripSeparator1,
            this.importRawLogoToolStripMenuItem,
            this.importPNGToolStripMenuItem});
			this.cmsLogoContext.Name = "cmsLogoContext";
			this.cmsLogoContext.Size = new System.Drawing.Size(181, 120);
			// 
			// exportDataToolStripMenuItem
			// 
			this.exportDataToolStripMenuItem.Name = "exportDataToolStripMenuItem";
			this.exportDataToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.exportDataToolStripMenuItem.Text = "Export &Raw Logo...";
			this.exportDataToolStripMenuItem.Click += new System.EventHandler(this.exportDataToolStripMenuItem_Click);
			// 
			// exportPNGToolStripMenuItem
			// 
			this.exportPNGToolStripMenuItem.Name = "exportPNGToolStripMenuItem";
			this.exportPNGToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.exportPNGToolStripMenuItem.Text = "Export &PNG...";
			this.exportPNGToolStripMenuItem.Click += new System.EventHandler(this.exportPNGToolStripMenuItem_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.AllowMerge = false;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(624, 24);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// logoToolStripMenuItem
			// 
			this.logoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.logoToolStripMenuItem.Name = "logoToolStripMenuItem";
			this.logoToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
			this.logoToolStripMenuItem.Text = "&Logo";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
			// 
			// importPNGToolStripMenuItem
			// 
			this.importPNGToolStripMenuItem.Name = "importPNGToolStripMenuItem";
			this.importPNGToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.importPNGToolStripMenuItem.Text = "&Import PNG...";
			this.importPNGToolStripMenuItem.Click += new System.EventHandler(this.importPNGToolStripMenuItem_Click);
			// 
			// importRawLogoToolStripMenuItem
			// 
			this.importRawLogoToolStripMenuItem.Name = "importRawLogoToolStripMenuItem";
			this.importRawLogoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.importRawLogoToolStripMenuItem.Text = "Import Raw Logo...";
			this.importRawLogoToolStripMenuItem.Click += new System.EventHandler(this.importRawLogoToolStripMenuItem_Click);
			// 
			// LogoFileEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 361);
			this.Controls.Add(this.lvLogos);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LogoFileEditor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Logo File Editor";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LogoFileEditor_FormClosed);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.cmsLogoContext.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel tssLabelFilePath;
		private System.Windows.Forms.ListView lvLogos;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem logoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip cmsLogoContext;
		private System.Windows.Forms.ToolStripMenuItem exportDataToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportPNGToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem importPNGToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem importRawLogoToolStripMenuItem;
	}
}