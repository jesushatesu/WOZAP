using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using WOZAP;
using MainWindow.Properties;

namespace MainWindow
{

	public partial class UserWindow : Form, IServerChatCallback
	{
		private SingInWindow _singInWindow;
		private string _userName;
		private List<ChatUser> _allUsers = new List<ChatUser> { };
		private WOZAP.IService _service;
		private Point _lastPoint;
		private UserListItem _currentUserItem;

		public UserWindow(string userName, SingInWindow singInWindow)
		{
			InitializeComponent();
			_currentUserItem = new UserListItem(this);
			_userName = userName;
			_singInWindow = singInWindow;
			this.userName.Text = userName;
			List<User> allUsers = new List<User> { };
			MessageItem m1 = new MessageItem("bbb", "ve", "user3qwee", "user3qwee");

			// Это для визуального тестиования
			ChatUser u1 = new ChatUser { userName = "user1kmv", isConnected = true, haveMsg = true, msgItems = new List<MessageItem>() };
			ChatUser u2 = new ChatUser { userName = "user2d", isConnected = false, haveMsg = false, msgItems = new List<MessageItem>() };
			ChatUser u3 = new ChatUser { userName = "user36e", isConnected = true, haveMsg = true, msgItems = new List<MessageItem>() };
			ChatUser u4 = new ChatUser { userName = "user1sd", isConnected = true, haveMsg = true, msgItems = new List<MessageItem>() };
			ChatUser u5 = new ChatUser { userName = "user2ld", isConnected = false, haveMsg = false, msgItems = new List<MessageItem>() };
			ChatUser u6 = new ChatUser { userName = "user3qwee", isConnected = true, haveMsg = true, msgItems = new List<MessageItem>() };
			ChatUser u7 = new ChatUser { userName = "usec1", isConnected = true, haveMsg = true, msgItems = new List<MessageItem>() };
			ChatUser u8 = new ChatUser { userName = "IIser2", isConnected = false, haveMsg = false, msgItems = new List<MessageItem>() };
			ChatUser u9 = new ChatUser { userName = "cokser3", isConnected = true, haveMsg = true, msgItems = new List<MessageItem>() };
			_allUsers.Add(u1);
			_allUsers.Add(u2);
			_allUsers.Add(u3);
			_allUsers.Add(u4);
			_allUsers.Add(u5);
			_allUsers.Add(u6);
			_allUsers.Add(u7);
			_allUsers.Add(u8);
			_allUsers.Add(u9);
		}

		public void MsgCallback(string fromUser, string msg)
		{
			
		}

		public void ConnectUserCallback(string userName)
		{
			bool flag = true;
			_allUsers.ForEach(user =>
			{
				if (user.userName == userName)
				{
					user.isConnected = true;
					flag = false;
				}
			});

			if (flag)
			{
				_allUsers.Add(new ChatUser { userName = userName, isConnected = true, haveMsg = false });
				UserListItem userItem = new UserListItem(this);
				userItem.ConnectedImage = Resources.Circle_Green;
				userItem.UserName = userName;
				userItem.HaveMsgImage = Resources.Tick;
				this.PanelListUsers.Controls.Add(userItem);
			}
			else
			{
				// Отобразим, что теперь онлайн
				// Только как!?
			}
		}

		public void DisconnectUserCallback(string userName)
		{
			_allUsers.ForEach(user =>
			{
				if (user.userName == userName)
				{
					user.isConnected = false;
				}
			});

			// Нужно отобразаить, что теперь не онлайн!
			// Только как не знаю!!
		}

		//--------------------------------
		// ----------- get ---------------
		//--------------------------------

		public string GetUserName()
		{
			return _userName;
		}

		public List<string> GetAllUsersName()
		{
			List<string> usersName = new List<string> { };
			foreach (ChatUser cu in _allUsers)
			{
				usersName.Add(cu.userName);
			}

			return usersName;
		}

		public bool ThisUserIsConnect(string username)
		{
			bool isConnect = false;
			for (int i = 0; i < _allUsers.Count; ++i)
			{
				if (_allUsers[i].userName == username)
				{
					isConnect = _allUsers[i].isConnected;
					break;
				}
			}

			return isConnect;
		}

		//--------------------------------
		// ---------- chat logic ---------
		//--------------------------------

		public void ClickUserItem(UserListItem item)
		{
			СhangeCurrentUserItem(item);

			for (int i = 0; i < _allUsers.Count; ++i)
			{
				if (_allUsers[i].userName == item.UserName)
				{
					DrowMsg(_allUsers[i]);
					break;
				}
			}
		}



		//--------------------------------
		//----------- design -------------
		//--------------------------------

		private void UserWindow_Load(object sender, EventArgs e)
		{
			// создание списка Itens
			PopulateInemsUser();
			Label newLabel = new Label { };
			newLabel.Text = "cqnknk";
			newLabel.AutoSize = true;
			this.msgPanel.Controls.Add(newLabel);
		}

		// Отрисовка списка всех пользователей
		private void PopulateInemsUser()
		{
			UserListItem[] userListItems = new UserListItem[_allUsers.Count];
			for (int i = 0; i < userListItems.Length; ++i)
			{
				userListItems[i] = new UserListItem(this);
				userListItems[i].UserName = _allUsers[i].userName;
				if (_allUsers[i].isConnected)
				{
					userListItems[i].ConnectedImage = Resources.Circle_Green;
				}
				else
				{
					userListItems[i].ConnectedImage = Resources.Circle_Red;
				}

				if (_allUsers[i].haveMsg)
				{
					userListItems[i].HaveMsgImage = Resources.haveMsg;
				}
				else
					userListItems[i].HaveMsgImage = Resources.Tick;

				this.PanelListUsers.Controls.Add(userListItems[i]);
			}
		}

		private void DrowMsg(ChatUser cu)
		{
			this.msgFlowPanel.Controls.Clear();
			for (int i = 0; i < cu.msgItems.Count; ++i)
			{
				this.msgFlowPanel.Controls.Add(cu.msgItems[i]);
			}
		}

		private void СhangeCurrentUserItem(UserListItem item)
		{
			_currentUserItem.SetBackColor(Color.White);
			_currentUserItem.clickAtThis = false;
			_currentUserItem = item;
			item.SetBackColor(Color.FromArgb(132, 133, 235));
			item.HaveMsgImage = Resources.Tick;
		}

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
			_singInWindow.Show();
		}

		private void msgButton_MouseClick(object sender, MouseEventArgs e)
		{
			if (this.msgTextBox.Text == "")
				return;

			string date = DateTime.Now.ToString();
			
			MessageItem msg = new MessageItem(
				this.msgTextBox.Text,
				date,
				_userName + _currentUserItem.UserName + date,
				_currentUserItem.UserName
			);

			this.msgFlowPanel.Controls.Add(msg);

			for (int i = 0; i < _allUsers.Count; ++i)
			{
				if (_allUsers[i].userName == _currentUserItem.UserName)
				{
					_allUsers[i].msgItems.Add(msg);
					break;
				}
			}

			this.msgTextBox.Text = "";
		}
	}
}
