﻿
namespace HB5Tool
{
	partial class AboutBox
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
			this.okButton = new System.Windows.Forms.Button();
			this.labelProductName = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblThanks = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.okButton.Location = new System.Drawing.Point(237, 76);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 24;
			this.okButton.Text = "&OK";
			// 
			// labelProductName
			// 
			this.labelProductName.Location = new System.Drawing.Point(54, 9);
			this.labelProductName.MaximumSize = new System.Drawing.Size(320, 17);
			this.labelProductName.MinimumSize = new System.Drawing.Size(160, 17);
			this.labelProductName.Name = "labelProductName";
			this.labelProductName.Size = new System.Drawing.Size(258, 17);
			this.labelProductName.TabIndex = 25;
			this.labelProductName.Text = "Product Name";
			this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::HB5Tool.Properties.Resources.hb5ico;
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(36, 36);
			this.pictureBox1.TabIndex = 26;
			this.pictureBox1.TabStop = false;
			// 
			// lblThanks
			// 
			this.lblThanks.AutoSize = true;
			this.lblThanks.Location = new System.Drawing.Point(54, 26);
			this.lblThanks.Name = "lblThanks";
			this.lblThanks.Size = new System.Drawing.Size(263, 39);
			this.lblThanks.TabIndex = 27;
			this.lblThanks.Text = "EXTREMELY EARLY PROOF OF CONCEPT\r\nDeveloped by freem\r\nSpecial Thanks: MindSpan, f" +
    "or developing HardBall 5.";
			// 
			// AboutBox
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.okButton;
			this.ClientSize = new System.Drawing.Size(324, 111);
			this.Controls.Add(this.lblThanks);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.labelProductName);
			this.Controls.Add(this.okButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutBox";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About HB5Tool";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Label labelProductName;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lblThanks;
	}
}
