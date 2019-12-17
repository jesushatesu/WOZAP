﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MainWindow.ServiceChat;
using MainWindow.Properties;

namespace MainWindow
{
	public partial class UserWindow : Form, IServiceCallback
	{
		private SingInWindow _singInWindow;
		private string _userName;
		private List<ChatUser> _allChatUsers;
		private Point _lastPoint;
		private int _idCurrentUserItem;
		private List<UserListItem> _userListItems;
		private ServiceClient _client;

		public UserWindow(string userName, SingInWindow singInWindow)
		{
			InitializeComponent();
			
			_idCurrentUserItem = -1;
			_userName = userName;
			_singInWindow = singInWindow;
			this.userName.Text = userName;
			_allChatUsers = new List<ChatUser>();
			_userListItems = new List<UserListItem>();
		}

		// --------- callbacks ------------

		public void MsgCallback(string fromUser, string toUser, string msgWithTime)
		{
			if (toUser != _userName | msgWithTime == "")
				return;

			// format msgWithTime: "some msg 12.11.19"
			string[] words = msgWithTime.Split(new char[] { ' ' });
			string timeMsg = DateTime.Now.ToString();
			if (words.Length > 2)
			{
				timeMsg = words[words.Length - 2];
				timeMsg += words[words.Length - 1];
				words[words.Length - 1] = "";
				words[words.Length - 2] = "";
			}

			string msgWithoutTime = String.Join(" ", words);
			if (msgWithoutTime == "  " | msgWithoutTime == "\n  ")
				return;

			int indexUser = -1;
			for (int i = 0; i < _allChatUsers.Count; ++i)
				if (_allChatUsers[i].userName == fromUser)
				{
					indexUser = i;
					break;
				} 

			if (indexUser != -1)
			{
				MessageItem msgItem = new MessageItem(msgWithoutTime, timeMsg,
							_userName + fromUser + timeMsg, fromUser, false);

				_allChatUsers[indexUser].msgItems.Add(msgItem);
				bool isCurrUser = false;
				if (_idCurrentUserItem != -1)
					if (_userListItems[_idCurrentUserItem].UserName == fromUser)
						isCurrUser = true;

				if (isCurrUser)
				{
					this.msgFlowPanel.Controls.Add(msgItem);
					this.msgFlowPanel.AutoScrollPosition = new Point(msgItem.Left, msgItem.Top);
				}
				else
				{
					_allChatUsers.ToArray()[indexUser].haveMsg = true;
					for (int k = 0; k < _userListItems.Count; ++k)
					{
						if (_userListItems[k].UserName == fromUser)
						{
							_userListItems[k].HaveMsgImage = Resources.haveMsg;
							break;
						}
					}
				}
			}
		}

		public void ConnectUserCallback(string userName)
		{
			if (userName == _userName)
				return;

			bool isNewUser = true;
			for (int i = 0; i < _allChatUsers.Count; ++i)
			{
				if (_allChatUsers.ToArray()[i].userName == userName)
				{
					ChatUser newCU = new ChatUser();
					newCU = _allChatUsers.ToArray()[i];
					newCU.isConnected = true;
					_allChatUsers.Remove(_allChatUsers[i]);
					_allChatUsers.Insert(i, newCU);

					isNewUser = false;
				}
			}

			if (isNewUser)
			{
				ChatUser cu = new ChatUser
				{
					userName = userName,
					isConnected = true,
					haveMsg = false,
					msgItems = new List<MessageItem>()
				};
				_allChatUsers.Add(cu);
				UserListItem item = new UserListItem(this);

				item.UserName = userName;
				item.ConnectedImage = Resources.Circle_Green;
				item.HaveMsgImage = Resources.Tick;
				_userListItems.Add(item);
				this.PanelListUsers.Controls.Add(item);
			}
			else
			{
				for (int i = 0; i < _userListItems.Count; ++i)
					if (_userListItems[i].UserName == userName)
						_userListItems[i].ConnectedImage = Resources.Circle_Green;
			}
		}

		public void DisconnectUserCallback(string userName)
		{
			if (userName == _userName)
				return;

			for (int i = 0; i < _allChatUsers.Count; ++i)
			{
				if (_allChatUsers[i].userName == userName)
				{
					ChatUser newCU = new ChatUser();
					newCU = _allChatUsers.ToArray()[i];
					newCU.isConnected = false;
					_allChatUsers.Remove(_allChatUsers[i]);
					_allChatUsers.Insert(i, newCU);
				}
				if (_userListItems[i].UserName == userName)
					_userListItems[i].ConnectedImage = Resources.Circle_Red;
			}
		}

		// --------- get / set -------------

		public string GetUserName()
		{
			return _userName;
		}

		public List<MessageItem> GetMsgChatUsers(string userName)
		{
			List<MessageItem> mi = new List<MessageItem>();
			foreach (ChatUser cu in _allChatUsers)
			{
				if (cu.userName == userName)
				{
					mi = cu.msgItems;
					break;
				}
			}

			return mi;
		}

		public bool ThisUserIsConnect(string username)
		{
			bool isConnect = false;
			for (int i = 0; i < _allChatUsers.Count; ++i)
			{
				if (_allChatUsers[i].userName == username)
				{
					isConnect = _allChatUsers[i].isConnected;
					break;
				}
			}

			return isConnect;
		}

		public void SetIdCurrentUserItem(int id)
		{
			_idCurrentUserItem = id;
		}

		// ---------- logic design ---------

		private void UserWindow_Load(object sender, EventArgs e)
		{

			_client = new ServiceClient(new System.ServiceModel.InstanceContext(this));
			string[] allUserArr = allUserArr = _client.Connect(_userName);

			for (int i = 0; i < allUserArr.Length; ++i)
			{
				string word = allUserArr[i];
				string un = word;
				un = un.Substring(0, un.Length - 2);

				if (_userName != un)
				{
					ChatUser newCU = new ChatUser();
					newCU.userName = un;
					newCU.isConnected = ('1' == word[word.Length - 2]) ? true : false;
					newCU.haveMsg = ('1' == word[word.Length - 1]) ? true : false;
					newCU.msgItems = new List<MessageItem>();
					_allChatUsers.Add(newCU);
				}
			}

			PopulateInemsUser();
		}

		public void ClickUserItem(UserListItem item)
		{
			СhangeCurrentUserItem(item);

			for (int i = 0; i < _allChatUsers.Count; ++i)
			{
				if (_allChatUsers[i].userName == item.UserName)
				{
					string[] msgs = _client.GetUnsentMsg(item.UserName, _userName); 
					for (int h = 0; h < msgs.Length; ++h)
						MsgCallback(item.UserName, _userName, msgs[h]);

					this.msgFlowPanel.Controls.Clear();

					for (int k = 0; k < _allChatUsers[i].msgItems.Count; ++k)
					{
						this.msgFlowPanel.Controls.Add(_allChatUsers[i].msgItems[k]);
					}
					break;
				}
			}

		}

		private void SedMsfFromMe(string textMsg)
		{
			char[] charsToTrim = { ' ', '\t', '\n', '\r' };
			textMsg = textMsg.Trim(charsToTrim);
			if (textMsg == "" | textMsg == "\n" | _idCurrentUserItem == -1)
				return;

			string date = DateTime.Now.ToString();

			MessageItem msg = new MessageItem(
				textMsg,
				date,
				_userName + _userListItems[_idCurrentUserItem].UserName + date,
				_userListItems[_idCurrentUserItem].UserName,
				true
			);

			this.msgFlowPanel.Controls.Add(msg);
			this.msgFlowPanel.AutoScrollPosition = new Point(msg.Left, msg.Top);
			for (int i = 0; i < _allChatUsers.Count; ++i)
			{
				if (_allChatUsers[i].userName == _userListItems[_idCurrentUserItem].UserName)
				{
					_allChatUsers[i].msgItems.Add(msg);
					break;
				}
			}

			_client.SendMsg(_userName, _userListItems[_idCurrentUserItem].UserName, textMsg + " " + date);
		}

		private void PopulateInemsUser()
		{
			this.PanelListUsers.Controls.Clear();

			_userListItems.Clear();

			for (int i = 0; i < _allChatUsers.Count; ++i)
			{
				UserListItem item = new UserListItem(this);
				item.UserName = _allChatUsers[i].userName;

				if (_allChatUsers[i].isConnected)
					item.ConnectedImage = Resources.Circle_Green;
				else
					item.ConnectedImage = Resources.Circle_Red;


				if (_allChatUsers[i].haveMsg)
					item.HaveMsgImage = Resources.haveMsg;
				else
					item.HaveMsgImage = Resources.Tick;

				_userListItems.Add(item);
				this.PanelListUsers.Controls.Add(item);
			}
		}

		public void СhangeCurrentUserItem(UserListItem item)
		{
			if (_idCurrentUserItem != -1)
			{
				_userListItems[_idCurrentUserItem].SetBackColor(Color.White);
				_userListItems[_idCurrentUserItem].clickAtThis = false;
			}
			
			_idCurrentUserItem = _userListItems.IndexOf(item);
			item.SetBackColor(Color.FromArgb(132, 133, 235));
			item.HaveMsgImage = Resources.Tick;
		}


		//--------- design winforms ----------

		private void topblokAuth_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.Left += e.X - _lastPoint.X;
				this.Top += e.Y - _lastPoint.Y;
			}
		}

		private void topblokAuth_MouseDown(object sender, MouseEventArgs e)
		{
			_lastPoint = new Point(e.X, e.Y);
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			this.Close();
			_client.Disconnect(_userName);
			_singInWindow.Close();
		}

		private void closeButton_MouseEnter(object sender, EventArgs e)
		{
			this.closeButton.BackColor = Color.Red;
		}

		private void closeButton_MouseLeave(object sender, EventArgs e)
		{
			this.closeButton.BackColor = Color.FromArgb(62, 128, 182);
		}

		private void buttonMinimized_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		private void buttonMinimized_MouseEnter(object sender, EventArgs e)
		{
			this.buttonMinimized.BackColor = Color.FromArgb(131, 175, 230);
		}

		private void buttonMinimized_MouseLeave(object sender, EventArgs e)
		{
			this.buttonMinimized.BackColor = Color.FromArgb(62, 128, 182);
		}

		private void buttonLogOut_Click(object sender, EventArgs e)
		{
			this.Close();
			_client.Disconnect(_userName);
			_singInWindow.Show();
		}

		private void msgButton_MouseClick(object sender, MouseEventArgs e)
		{
			string textMsg = this.msgTextBox.Text;
			this.msgTextBox.Text = "";
			SedMsfFromMe(textMsg);
		}

		private void msgTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			MouseEventArgs v = new MouseEventArgs(MouseButtons, 1, 1, 1, 1);
			if (e.KeyData == Keys.Enter)
			{
				string textMsg = this.msgTextBox.Text;
				this.msgTextBox.Text = "";
				SedMsfFromMe(textMsg);
			}
			
		}

	}
}
