namespace MainWindow
{
	partial class MessageItem
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.messageTexBox = new System.Windows.Forms.TextBox();
			this.timeMsgTextBox = new System.Windows.Forms.TextBox();
			this.isReadTexBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// messageTexBox
			// 
			this.messageTexBox.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.messageTexBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.messageTexBox.Location = new System.Drawing.Point(0, 19);
			this.messageTexBox.Multiline = true;
			this.messageTexBox.Name = "messageTexBox";
			this.messageTexBox.ReadOnly = true;
			this.messageTexBox.Size = new System.Drawing.Size(318, 32);
			this.messageTexBox.TabIndex = 0;
			// 
			// timeMsgTextBox
			// 
			this.timeMsgTextBox.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.timeMsgTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.timeMsgTextBox.Location = new System.Drawing.Point(0, 0);
			this.timeMsgTextBox.Name = "timeMsgTextBox";
			this.timeMsgTextBox.ReadOnly = true;
			this.timeMsgTextBox.Size = new System.Drawing.Size(219, 15);
			this.timeMsgTextBox.TabIndex = 1;
			// 
			// isReadTexBox
			// 
			this.isReadTexBox.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.isReadTexBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.isReadTexBox.Location = new System.Drawing.Point(218, 0);
			this.isReadTexBox.Name = "isReadTexBox";
			this.isReadTexBox.ReadOnly = true;
			this.isReadTexBox.Size = new System.Drawing.Size(100, 15);
			this.isReadTexBox.TabIndex = 2;
			// 
			// MessageItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(this.isReadTexBox);
			this.Controls.Add(this.timeMsgTextBox);
			this.Controls.Add(this.messageTexBox);
			this.MaximumSize = new System.Drawing.Size(318, 0);
			this.MinimumSize = new System.Drawing.Size(318, 79);
			this.Name = "MessageItem";
			this.Size = new System.Drawing.Size(318, 79);
			this.Load += new System.EventHandler(this.MessageItem_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox messageTexBox;
		private System.Windows.Forms.TextBox timeMsgTextBox;
		private System.Windows.Forms.TextBox isReadTexBox;
	}
}
