namespace MainWindow
{
	partial class UserWindow
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserWindow));
			this.mainFoneSingIn = new System.Windows.Forms.Panel();
			this.msgPanel = new System.Windows.Forms.Panel();
			this.msgFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.msgButton = new System.Windows.Forms.Button();
			this.msgTextBox = new System.Windows.Forms.TextBox();
			this.userWindowLeft = new System.Windows.Forms.Panel();
			this.PanelListUsers = new System.Windows.Forms.FlowLayoutPanel();
			this.userInfoBox = new System.Windows.Forms.Panel();
			this.userName = new System.Windows.Forms.Label();
			this.buttonLogOut = new System.Windows.Forms.Button();
			this.topblokAuth = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.wozzup = new System.Windows.Forms.Label();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.buttonMinimized = new System.Windows.Forms.PictureBox();
			this.closeButton = new System.Windows.Forms.PictureBox();
			this.mainFoneSingIn.SuspendLayout();
			this.msgPanel.SuspendLayout();
			this.panel1.SuspendLayout();
			this.userWindowLeft.SuspendLayout();
			this.userInfoBox.SuspendLayout();
			this.topblokAuth.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonMinimized)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.closeButton)).BeginInit();
			this.SuspendLayout();
			// 
			// mainFoneSingIn
			// 
			this.mainFoneSingIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(191)))), ((int)(((byte)(239)))));
			this.mainFoneSingIn.Controls.Add(this.msgPanel);
			this.mainFoneSingIn.Controls.Add(this.userWindowLeft);
			this.mainFoneSingIn.Controls.Add(this.topblokAuth);
			this.mainFoneSingIn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainFoneSingIn.Location = new System.Drawing.Point(0, 0);
			this.mainFoneSingIn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.mainFoneSingIn.Name = "mainFoneSingIn";
			this.mainFoneSingIn.Size = new System.Drawing.Size(1041, 574);
			this.mainFoneSingIn.TabIndex = 1;
			// 
			// msgPanel
			// 
			this.msgPanel.Controls.Add(this.msgFlowPanel);
			this.msgPanel.Controls.Add(this.panel1);
			this.msgPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.msgPanel.Location = new System.Drawing.Point(397, 34);
			this.msgPanel.Name = "msgPanel";
			this.msgPanel.Size = new System.Drawing.Size(644, 540);
			this.msgPanel.TabIndex = 8;
			// 
			// msgFlowPanel
			// 
			this.msgFlowPanel.AutoScroll = true;
			this.msgFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.msgFlowPanel.Location = new System.Drawing.Point(0, 0);
			this.msgFlowPanel.Name = "msgFlowPanel";
			this.msgFlowPanel.Size = new System.Drawing.Size(644, 473);
			this.msgFlowPanel.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Controls.Add(this.msgButton);
			this.panel1.Controls.Add(this.msgTextBox);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 473);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(644, 67);
			this.panel1.TabIndex = 0;
			// 
			// msgButton
			// 
			this.msgButton.Location = new System.Drawing.Point(512, 16);
			this.msgButton.Name = "msgButton";
			this.msgButton.Size = new System.Drawing.Size(120, 39);
			this.msgButton.TabIndex = 1;
			this.msgButton.Text = "send";
			this.msgButton.UseVisualStyleBackColor = true;
			this.msgButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.msgButton_MouseClick);
			// 
			// msgTextBox
			// 
			this.msgTextBox.Location = new System.Drawing.Point(19, 16);
			this.msgTextBox.Multiline = true;
			this.msgTextBox.Name = "msgTextBox";
			this.msgTextBox.Size = new System.Drawing.Size(478, 39);
			this.msgTextBox.TabIndex = 0;
			this.msgTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.msgTextBox_KeyDown);
			// 
			// userWindowLeft
			// 
			this.userWindowLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(90)))), ((int)(((byte)(170)))));
			this.userWindowLeft.Controls.Add(this.PanelListUsers);
			this.userWindowLeft.Controls.Add(this.userInfoBox);
			this.userWindowLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.userWindowLeft.Location = new System.Drawing.Point(0, 34);
			this.userWindowLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.userWindowLeft.Name = "userWindowLeft";
			this.userWindowLeft.Size = new System.Drawing.Size(397, 540);
			this.userWindowLeft.TabIndex = 7;
			// 
			// PanelListUsers
			// 
			this.PanelListUsers.AutoScroll = true;
			this.PanelListUsers.BackColor = System.Drawing.Color.White;
			this.PanelListUsers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PanelListUsers.Location = new System.Drawing.Point(0, 60);
			this.PanelListUsers.Name = "PanelListUsers";
			this.PanelListUsers.Size = new System.Drawing.Size(397, 480);
			this.PanelListUsers.TabIndex = 1;
			// 
			// userInfoBox
			// 
			this.userInfoBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(111)))), ((int)(((byte)(249)))));
			this.userInfoBox.Controls.Add(this.userName);
			this.userInfoBox.Controls.Add(this.buttonLogOut);
			this.userInfoBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.userInfoBox.Location = new System.Drawing.Point(0, 0);
			this.userInfoBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.userInfoBox.Name = "userInfoBox";
			this.userInfoBox.Size = new System.Drawing.Size(397, 60);
			this.userInfoBox.TabIndex = 0;
			// 
			// userName
			// 
			this.userName.AutoSize = true;
			this.userName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.userName.Location = new System.Drawing.Point(12, 14);
			this.userName.Name = "userName";
			this.userName.Size = new System.Drawing.Size(133, 29);
			this.userName.TabIndex = 1;
			this.userName.Text = "LoginUser";
			// 
			// buttonLogOut
			// 
			this.buttonLogOut.Location = new System.Drawing.Point(300, 14);
			this.buttonLogOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonLogOut.Name = "buttonLogOut";
			this.buttonLogOut.Size = new System.Drawing.Size(91, 30);
			this.buttonLogOut.TabIndex = 0;
			this.buttonLogOut.Text = "log out";
			this.buttonLogOut.UseVisualStyleBackColor = true;
			this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
			// 
			// topblokAuth
			// 
			this.topblokAuth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(128)))), ((int)(((byte)(182)))));
			this.topblokAuth.Controls.Add(this.panel2);
			this.topblokAuth.Controls.Add(this.buttonMinimized);
			this.topblokAuth.Controls.Add(this.closeButton);
			this.topblokAuth.Dock = System.Windows.Forms.DockStyle.Top;
			this.topblokAuth.Location = new System.Drawing.Point(0, 0);
			this.topblokAuth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.topblokAuth.Name = "topblokAuth";
			this.topblokAuth.Size = new System.Drawing.Size(1041, 34);
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
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(161, 34);
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
			this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(161, 34);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// buttonMinimized
			// 
			this.buttonMinimized.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonMinimized.Image = ((System.Drawing.Image)(resources.GetObject("buttonMinimized.Image")));
			this.buttonMinimized.Location = new System.Drawing.Point(973, 2);
			this.buttonMinimized.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
			this.closeButton.Location = new System.Drawing.Point(1004, 2);
			this.closeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(25, 25);
			this.closeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.closeButton.TabIndex = 3;
			this.closeButton.TabStop = false;
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			this.closeButton.MouseEnter += new System.EventHandler(this.closeButton_MouseEnter);
			this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
			// 
			// UserWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1041, 574);
			this.Controls.Add(this.mainFoneSingIn);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "UserWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "UserWindow";
			this.Load += new System.EventHandler(this.UserWindow_Load);
			this.mainFoneSingIn.ResumeLayout(false);
			this.msgPanel.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.userWindowLeft.ResumeLayout(false);
			this.userInfoBox.ResumeLayout(false);
			this.userInfoBox.PerformLayout();
			this.topblokAuth.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonMinimized)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.closeButton)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel mainFoneSingIn;
		private System.Windows.Forms.Panel topblokAuth;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label wozzup;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox buttonMinimized;
		private System.Windows.Forms.PictureBox closeButton;
		private new System.Windows.Forms.Panel userWindowLeft;
		private System.Windows.Forms.Panel userInfoBox;
		private System.Windows.Forms.Label userName;
		private System.Windows.Forms.Button buttonLogOut;
		private System.Windows.Forms.FlowLayoutPanel PanelListUsers;
		private System.Windows.Forms.Panel msgPanel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button msgButton;
		private System.Windows.Forms.TextBox msgTextBox;
		private System.Windows.Forms.FlowLayoutPanel msgFlowPanel;
	}
}