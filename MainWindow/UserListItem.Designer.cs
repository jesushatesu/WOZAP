namespace MainWindow
{
	partial class UserListItem
	{
		/// <summary> 
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором компонентов

		/// <summary> 
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.isConnectImage = new System.Windows.Forms.PictureBox();
			this.userNameLabel = new System.Windows.Forms.Label();
			this.haveMsgImage = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.isConnectImage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.haveMsgImage)).BeginInit();
			this.SuspendLayout();
			// 
			// isConnectImage
			// 
			this.isConnectImage.Location = new System.Drawing.Point(19, 13);
			this.isConnectImage.Name = "isConnectImage";
			this.isConnectImage.Size = new System.Drawing.Size(19, 20);
			this.isConnectImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.isConnectImage.TabIndex = 0;
			this.isConnectImage.TabStop = false;
			this.isConnectImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.isConnectImage_MouseClick);
			this.isConnectImage.MouseLeave += new System.EventHandler(this.isConnectImage_MouseLeave);
			this.isConnectImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.isConnectImage_MouseMove);
			// 
			// userNameLabel
			// 
			this.userNameLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.userNameLabel.Location = new System.Drawing.Point(62, 6);
			this.userNameLabel.Name = "userNameLabel";
			this.userNameLabel.Size = new System.Drawing.Size(234, 35);
			this.userNameLabel.TabIndex = 1;
			this.userNameLabel.Text = "user name";
			this.userNameLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.userNameLabel_MouseClick);
			this.userNameLabel.MouseLeave += new System.EventHandler(this.userNameLabel_MouseLeave);
			this.userNameLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.userNameLabel_MouseMove);
			// 
			// haveMsgImage
			// 
			this.haveMsgImage.BackColor = System.Drawing.Color.White;
			this.haveMsgImage.Location = new System.Drawing.Point(319, 11);
			this.haveMsgImage.Name = "haveMsgImage";
			this.haveMsgImage.Size = new System.Drawing.Size(33, 27);
			this.haveMsgImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.haveMsgImage.TabIndex = 2;
			this.haveMsgImage.TabStop = false;
			this.haveMsgImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.haveMsgImage_MouseClick);
			this.haveMsgImage.MouseLeave += new System.EventHandler(this.haveMsgImage_MouseLeave);
			this.haveMsgImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.haveMsgImage_MouseMove);
			// 
			// UserListItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.haveMsgImage);
			this.Controls.Add(this.userNameLabel);
			this.Controls.Add(this.isConnectImage);
			this.Name = "UserListItem";
			this.Size = new System.Drawing.Size(365, 49);
			this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UserListItem_MouseClick);
			this.MouseLeave += new System.EventHandler(this.UserListItem_MouseLeave);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UserListItem_MouseMove);
			((System.ComponentModel.ISupportInitialize)(this.isConnectImage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.haveMsgImage)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox isConnectImage;
		private System.Windows.Forms.Label userNameLabel;
		private System.Windows.Forms.PictureBox haveMsgImage;
	}
}
