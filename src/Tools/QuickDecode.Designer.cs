
namespace HB5Tool
{
	partial class QuickDecode
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
			this.tbEncodedFilename = new System.Windows.Forms.TextBox();
			this.lblEncoded = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbDecodedFilename = new System.Windows.Forms.TextBox();
			this.btnDecode = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbEncodedFilename
			// 
			this.tbEncodedFilename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbEncodedFilename.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbEncodedFilename.Location = new System.Drawing.Point(141, 12);
			this.tbEncodedFilename.MaxLength = 36;
			this.tbEncodedFilename.Name = "tbEncodedFilename";
			this.tbEncodedFilename.Size = new System.Drawing.Size(191, 23);
			this.tbEncodedFilename.TabIndex = 1;
			// 
			// lblEncoded
			// 
			this.lblEncoded.AutoSize = true;
			this.lblEncoded.Location = new System.Drawing.Point(12, 16);
			this.lblEncoded.Name = "lblEncoded";
			this.lblEncoded.Size = new System.Drawing.Size(123, 13);
			this.lblEncoded.TabIndex = 0;
			this.lblEncoded.Text = "Encoded &Filename (Hex)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Decoded File&name";
			// 
			// tbDecodedFilename
			// 
			this.tbDecodedFilename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbDecodedFilename.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbDecodedFilename.Location = new System.Drawing.Point(141, 38);
			this.tbDecodedFilename.MaxLength = 12;
			this.tbDecodedFilename.Name = "tbDecodedFilename";
			this.tbDecodedFilename.Size = new System.Drawing.Size(191, 23);
			this.tbDecodedFilename.TabIndex = 3;
			// 
			// btnDecode
			// 
			this.btnDecode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDecode.Location = new System.Drawing.Point(257, 67);
			this.btnDecode.Name = "btnDecode";
			this.btnDecode.Size = new System.Drawing.Size(75, 23);
			this.btnDecode.TabIndex = 4;
			this.btnDecode.Text = "&Decode";
			this.btnDecode.UseVisualStyleBackColor = true;
			this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
			// 
			// QuickDecode
			// 
			this.AcceptButton = this.btnDecode;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(344, 102);
			this.Controls.Add(this.btnDecode);
			this.Controls.Add(this.tbDecodedFilename);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblEncoded);
			this.Controls.Add(this.tbEncodedFilename);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "QuickDecode";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Quick Decode";
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.QuickDecode_KeyUp);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbEncodedFilename;
		private System.Windows.Forms.Label lblEncoded;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbDecodedFilename;
		private System.Windows.Forms.Button btnDecode;
	}
}