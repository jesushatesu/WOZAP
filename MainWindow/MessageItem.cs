using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainWindow
{
	public partial class MessageItem : UserControl
	{
		private string _idMsg;
		private string _msg;
		private string _time;
		private bool _isRead;
		private bool _isModificat;
		private string _fromUser;

		public MessageItem(string msg, string timeMsg, string idMsg, string fromUser, bool myMsg)
		{
			InitializeComponent();
			_idMsg = idMsg;
			_isRead = false;
			_isModificat = false;
			_msg = msg;
			_time = timeMsg;
			_fromUser = fromUser;
			if (myMsg)
				this.flowLayoutPanelWithPanelMsg.FlowDirection = FlowDirection.RightToLeft;
		}

		private void MessageItem_Load(object sender, EventArgs e)
		{
			this.timeMsgTextBox.Text = _time;
			this.messageTexBox.Text = _msg;
			this.isReadTexBox.Text = "shipped";
		}

		public string GetFromUser()
		{
			return _fromUser;
		}

		public string GetMsg()
		{
			return _msg;
		}

		public void SetMsg(string newMsg)
		{
			_msg = newMsg;
		}

		public bool GetIsModificat()
		{
			return _isModificat;
		}

		public void SetIsModificat(bool isMod)
		{
			_isModificat = isMod;
		}

		public string GetIdMsg()
		{
			return _idMsg;
		}

		public string GetTimeMsg()
		{
			return _time;
		}

		public bool GetIsRead()
		{
			return _isRead;
		}

		public void SetIsRead(bool isRead)
		{
			_isRead = isRead;
			this.isReadTexBox.Text = "read";
		}
	}
}
