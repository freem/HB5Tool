namespace HB5Tool
{
	partial class DriverListViewer
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DriverListViewer));
			this.tbDriverList = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// tbDriverList
			// 
			this.tbDriverList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbDriverList.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbDriverList.Location = new System.Drawing.Point(0, 0);
			this.tbDriverList.Multiline = true;
			this.tbDriverList.Name = "tbDriverList";
			this.tbDriverList.ReadOnly = true;
			this.tbDriverList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbDriverList.Size = new System.Drawing.Size(632, 373);
			this.tbDriverList.TabIndex = 0;
			// 
			// DriverListViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(632, 373);
			this.Controls.Add(this.tbDriverList);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DriverListViewer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Driver List Viewer";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbDriverList;
	}
}