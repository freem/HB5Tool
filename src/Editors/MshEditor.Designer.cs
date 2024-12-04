
namespace HB5Tool
{
	partial class MshEditor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MshEditor));
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tssLabelFilePath = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.mSHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lvMshFiles = new System.Windows.Forms.ListView();
			this.chFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cmsMshFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.extractFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportPNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tbOutput = new System.Windows.Forms.TextBox();
			this.statusStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.cmsMshFiles.SuspendLayout();
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
            this.mSHToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(624, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// mSHToolStripMenuItem
			// 
			this.mSHToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.mSHToolStripMenuItem.Name = "mSHToolStripMenuItem";
			this.mSHToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
			this.mSHToolStripMenuItem.Text = "&MSH";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// lvMshFiles
			// 
			this.lvMshFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFilename});
			this.lvMshFiles.ContextMenuStrip = this.cmsMshFiles;
			this.lvMshFiles.GridLines = true;
			this.lvMshFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvMshFiles.HideSelection = false;
			this.lvMshFiles.Location = new System.Drawing.Point(12, 27);
			this.lvMshFiles.Name = "lvMshFiles";
			this.lvMshFiles.Size = new System.Drawing.Size(136, 309);
			this.lvMshFiles.TabIndex = 3;
			this.lvMshFiles.UseCompatibleStateImageBehavior = false;
			this.lvMshFiles.View = System.Windows.Forms.View.Details;
			this.lvMshFiles.SelectedIndexChanged += new System.EventHandler(this.lvMshFiles_SelectedIndexChanged);
			// 
			// chFilename
			// 
			this.chFilename.Text = "Filename";
			this.chFilename.Width = 108;
			// 
			// cmsMshFiles
			// 
			this.cmsMshFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractFilesToolStripMenuItem,
            this.exportPNGToolStripMenuItem});
			this.cmsMshFiles.Name = "cmsMshFiles";
			this.cmsMshFiles.Size = new System.Drawing.Size(154, 48);
			// 
			// extractFilesToolStripMenuItem
			// 
			this.extractFilesToolStripMenuItem.Name = "extractFilesToolStripMenuItem";
			this.extractFilesToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.extractFilesToolStripMenuItem.Text = "&Extract File(s)...";
			this.extractFilesToolStripMenuItem.Click += new System.EventHandler(this.extractFilesToolStripMenuItem_Click);
			// 
			// exportPNGToolStripMenuItem
			// 
			this.exportPNGToolStripMenuItem.Name = "exportPNGToolStripMenuItem";
			this.exportPNGToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.exportPNGToolStripMenuItem.Text = "Export PNG...";
			this.exportPNGToolStripMenuItem.Click += new System.EventHandler(this.exportPNGToolStripMenuItem_Click);
			// 
			// tbOutput
			// 
			this.tbOutput.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbOutput.Location = new System.Drawing.Point(154, 27);
			this.tbOutput.MaxLength = 65535;
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.ReadOnly = true;
			this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbOutput.Size = new System.Drawing.Size(458, 309);
			this.tbOutput.TabIndex = 4;
			// 
			// MshEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 361);
			this.Controls.Add(this.tbOutput);
			this.Controls.Add(this.lvMshFiles);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MshEditor";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "MSH Editor";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MshEditor_FormClosed);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.cmsMshFiles.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel tssLabelFilePath;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem mSHToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ListView lvMshFiles;
		private System.Windows.Forms.ColumnHeader chFilename;
		private System.Windows.Forms.TextBox tbOutput;
		private System.Windows.Forms.ContextMenuStrip cmsMshFiles;
		private System.Windows.Forms.ToolStripMenuItem extractFilesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportPNGToolStripMenuItem;
	}
}