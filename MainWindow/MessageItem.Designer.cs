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
			this.flowLayoutPanelWithPanelMsg = new System.Windows.Forms.FlowLayoutPanel();
			this.panelWithMsg = new System.Windows.Forms.Panel();
			this.flowLayoutPanelWithPanelMsg.SuspendLayout();
			this.panelWithMsg.SuspendLayout();
			this.SuspendLayout();
			// 
			// messageTexBox
			// 
			this.messageTexBox.BackColor = System.Drawing.Color.White;
			this.messageTexBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.messageTexBox.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.messageTexBox.Location = new System.Drawing.Point(3, 24);
			this.messageTexBox.Multiline = true;
			this.messageTexBox.Name = "messageTexBox";
			this.messageTexBox.ReadOnly = true;
			this.messageTexBox.Size = new System.Drawing.Size(361, 52);
			this.messageTexBox.TabIndex = 0;
			// 
			// timeMsgTextBox
			// 
			this.timeMsgTextBox.BackColor = System.Drawing.Color.White;
			this.timeMsgTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.timeMsgTextBox.ForeColor = System.Drawing.Color.Gray;
			this.timeMsgTextBox.Location = new System.Drawing.Point(0, 3);
			this.timeMsgTextBox.Name = "timeMsgTextBox";
			this.timeMsgTextBox.ReadOnly = true;
			this.timeMsgTextBox.Size = new System.Drawing.Size(219, 15);
			this.timeMsgTextBox.TabIndex = 1;
			// 
			// isReadTexBox
			// 
			this.isReadTexBox.BackColor = System.Drawing.Color.White;
			this.isReadTexBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.isReadTexBox.ForeColor = System.Drawing.Color.Gray;
			this.isReadTexBox.Location = new System.Drawing.Point(289, 3);
			this.isReadTexBox.Name = "isReadTexBox";
			this.isReadTexBox.ReadOnly = true;
			this.isReadTexBox.Size = new System.Drawing.Size(75, 15);
			this.isReadTexBox.TabIndex = 2;
			// 
			// flowLayoutPanelWithPanelMsg
			// 
			this.flowLayoutPanelWithPanelMsg.Controls.Add(this.panelWithMsg);
			this.flowLayoutPanelWithPanelMsg.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanelWithPanelMsg.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanelWithPanelMsg.Name = "flowLayoutPanelWithPanelMsg";
			this.flowLayoutPanelWithPanelMsg.Size = new System.Drawing.Size(618, 79);
			this.flowLayoutPanelWithPanelMsg.TabIndex = 3;
			// 
			// panelWithMsg
			// 
			this.panelWithMsg.BackColor = System.Drawing.Color.White;
			this.panelWithMsg.Controls.Add(this.messageTexBox);
			this.panelWithMsg.Controls.Add(this.timeMsgTextBox);
			this.panelWithMsg.Controls.Add(this.isReadTexBox);
			this.panelWithMsg.Location = new System.Drawing.Point(3, 3);
			this.panelWithMsg.Name = "panelWithMsg";
			this.panelWithMsg.Size = new System.Drawing.Size(370, 73);
			this.panelWithMsg.TabIndex = 2;
			// 
			// MessageItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(191)))), ((int)(((byte)(239)))));
			this.Controls.Add(this.flowLayoutPanelWithPanelMsg);
			this.MaximumSize = new System.Drawing.Size(614, 0);
			this.MinimumSize = new System.Drawing.Size(614, 79);
			this.Name = "MessageItem";
			this.Size = new System.Drawing.Size(618, 79);
			this.Load += new System.EventHandler(this.MessageItem_Load);
			this.flowLayoutPanelWithPanelMsg.ResumeLayout(false);
			this.panelWithMsg.ResumeLayout(false);
			this.panelWithMsg.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox messageTexBox;
		private System.Windows.Forms.TextBox timeMsgTextBox;
		private System.Windows.Forms.TextBox isReadTexBox;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelWithPanelMsg;
		private System.Windows.Forms.Panel panelWithMsg;
	}
}
