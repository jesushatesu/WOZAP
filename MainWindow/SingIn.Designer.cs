namespace MainWindow
{
	partial class SingInWindow
	{
		private System.ComponentModel.IContainer components = null;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SingInWindow));
			this.mainFoneSingIn = new System.Windows.Forms.Panel();
			this.topblokAuth = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.wozzup = new System.Windows.Forms.Label();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.buttonMinimized = new System.Windows.Forms.PictureBox();
			this.closeButton = new System.Windows.Forms.PictureBox();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.loginLine = new System.Windows.Forms.TextBox();
			this.labelAuthorization = new System.Windows.Forms.Label();
			this.buttonSingIn = new System.Windows.Forms.Button();
			this.mainFoneSingIn.SuspendLayout();
			this.topblokAuth.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonMinimized)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.closeButton)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			this.SuspendLayout();
			// 
			// mainFoneSingIn
			// 
			this.mainFoneSingIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(191)))), ((int)(((byte)(239)))));
			this.mainFoneSingIn.Controls.Add(this.topblokAuth);
			this.mainFoneSingIn.Controls.Add(this.pictureBox3);
			this.mainFoneSingIn.Controls.Add(this.loginLine);
			this.mainFoneSingIn.Controls.Add(this.labelAuthorization);
			this.mainFoneSingIn.Controls.Add(this.buttonSingIn);
			this.mainFoneSingIn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainFoneSingIn.Location = new System.Drawing.Point(0, 0);
			this.mainFoneSingIn.Name = "mainFoneSingIn";
			this.mainFoneSingIn.Size = new System.Drawing.Size(756, 438);
			this.mainFoneSingIn.TabIndex = 0;
			// 
			// topblokAuth
			// 
			this.topblokAuth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(128)))), ((int)(((byte)(182)))));
			this.topblokAuth.Controls.Add(this.panel2);
			this.topblokAuth.Controls.Add(this.buttonMinimized);
			this.topblokAuth.Controls.Add(this.closeButton);
			this.topblokAuth.Location = new System.Drawing.Point(0, 0);
			this.topblokAuth.Name = "topblokAuth";
			this.topblokAuth.Size = new System.Drawing.Size(756, 35);
			this.topblokAuth.TabIndex = 6;
			this.topblokAuth.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topblokAuth_MouseDown);
			this.topblokAuth.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topblokAuth_MouseMove);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.wozzup);
			this.panel2.Controls.Add(this.pictureBox4);
			this.panel2.Controls.Add(this.pictureBox1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(161, 35);
			this.panel2.TabIndex = 5;
			// 
			// wozzup
			// 
			this.wozzup.AutoSize = true;
			this.wozzup.Font = new System.Drawing.Font("Segoe Print", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.wozzup.Location = new System.Drawing.Point(37, 2);
			this.wozzup.Name = "wozzup";
			this.wozzup.Size = new System.Drawing.Size(89, 33);
			this.wozzup.TabIndex = 2;
			this.wozzup.Text = "Wozzup";
			// 
			// pictureBox4
			// 
			this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
			this.pictureBox4.Location = new System.Drawing.Point(9, 4);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(27, 27);
			this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox4.TabIndex = 1;
			this.pictureBox4.TabStop = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(161, 35);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// buttonMinimized
			// 
			this.buttonMinimized.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonMinimized.Image = ((System.Drawing.Image)(resources.GetObject("buttonMinimized.Image")));
			this.buttonMinimized.Location = new System.Drawing.Point(688, 3);
			this.buttonMinimized.Name = "buttonMinimized";
			this.buttonMinimized.Size = new System.Drawing.Size(25, 25);
			this.buttonMinimized.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.buttonMinimized.TabIndex = 4;
			this.buttonMinimized.TabStop = false;
			this.buttonMinimized.Click += new System.EventHandler(this.buttonMinimized_Click);
			this.buttonMinimized.MouseEnter += new System.EventHandler(this.buttonMinimized_MouseEnter);
			this.buttonMinimized.MouseLeave += new System.EventHandler(this.buttonMinimized_MouseLeave);
			// 
			// closeButton
			// 
			this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(128)))), ((int)(((byte)(182)))));
			this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
			this.closeButton.Location = new System.Drawing.Point(719, 3);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(25, 25);
			this.closeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.closeButton.TabIndex = 3;
			this.closeButton.TabStop = false;
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			this.closeButton.MouseEnter += new System.EventHandler(this.closeButton_MouseEnter);
			this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
			// 
			// pictureBox3
			// 
			this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
			this.pictureBox3.Location = new System.Drawing.Point(160, 202);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(30, 30);
			this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox3.TabIndex = 5;
			this.pictureBox3.TabStop = false;
			// 
			// loginLine
			// 
			this.loginLine.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.loginLine.Location = new System.Drawing.Point(206, 202);
			this.loginLine.Multiline = true;
			this.loginLine.Name = "loginLine";
			this.loginLine.Size = new System.Drawing.Size(344, 32);
			this.loginLine.TabIndex = 2;
			this.loginLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loginLine_KeyDown);
			// 
			// labelAuthorization
			// 
			this.labelAuthorization.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelAuthorization.Font = new System.Drawing.Font("Segoe Print", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelAuthorization.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.labelAuthorization.Location = new System.Drawing.Point(0, 0);
			this.labelAuthorization.Name = "labelAuthorization";
			this.labelAuthorization.Size = new System.Drawing.Size(756, 247);
			this.labelAuthorization.TabIndex = 1;
			this.labelAuthorization.Text = "Authorization";
			this.labelAuthorization.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// buttonSingIn
			// 
			this.buttonSingIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(246)))), ((int)(((byte)(29)))));
			this.buttonSingIn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonSingIn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.buttonSingIn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(247)))), ((int)(((byte)(174)))));
			this.buttonSingIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonSingIn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonSingIn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.buttonSingIn.Location = new System.Drawing.Point(257, 263);
			this.buttonSingIn.Name = "buttonSingIn";
			this.buttonSingIn.Size = new System.Drawing.Size(249, 47);
			this.buttonSingIn.TabIndex = 0;
			this.buttonSingIn.Text = "Sing in";
			this.buttonSingIn.UseVisualStyleBackColor = false;
			this.buttonSingIn.Click += new System.EventHandler(this.buttonSingIn_Click);
			// 
			// SingInWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(756, 438);
			this.Controls.Add(this.mainFoneSingIn);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "SingInWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SingIn";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SingInWindow_KeyDown);
			this.mainFoneSingIn.ResumeLayout(false);
			this.mainFoneSingIn.PerformLayout();
			this.topblokAuth.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonMinimized)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.closeButton)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel mainFoneSingIn;
		private System.Windows.Forms.Button buttonSingIn;
		private System.Windows.Forms.Label labelAuthorization;
		private System.Windows.Forms.TextBox loginLine;
		private System.Windows.Forms.PictureBox buttonMinimized;
		private System.Windows.Forms.PictureBox closeButton;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.Panel topblokAuth;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label wozzup;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}