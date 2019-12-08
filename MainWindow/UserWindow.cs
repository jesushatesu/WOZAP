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
		private UserListItem _currentUserItem;
		private List<UserListItem> _userListItems;
		private ServiceClient _client;

		public UserWindow(string userName, SingInWindow singInWindow)
		{
			InitializeComponent();
			
			_currentUserItem = new UserListItem(this);
			_userName = userName;
			_singInWindow = singInWindow;
			this.userName.Text = userName;
			_allChatUsers = new List<ChatUser>();
			_userListItems = new List<UserListItem>();
		}


        public void MsgCallback(string fromUser, string toUser, string msg)
		{
			if (toUser != _userName)
				return;
			string[] words = msg.Split(new char[] { ' ' });
			words[words.Length - 1] = "";
			string msgWithoutDate = String.Join(" ", words);
			for (int i = 0; i < _allChatUsers.Count; ++i)
			{
				if (_allChatUsers[i].userName == fromUser)
				{
					MessageItem msgItem = new MessageItem(msgWithoutDate, DateTime.Now.ToString(),
							_userName + fromUser + DateTime.Now.ToString(), fromUser);
					_allChatUsers[i].msgItems.Add(msgItem);

					if (_currentUserItem.UserName == fromUser)
					{
						this.msgFlowPanel.Controls.Add(msgItem);
					}
					else
					{
						_allChatUsers.ToArray()[i].haveMsg = true; // ------ Сомнительная вещь
						for (int k = 0; k < _userListItems.Count; ++k)
						{
							if (_userListItems[k].UserName == fromUser)
							{
								_userListItems[k].HaveMsgImage = Resources.haveMsg; //-работает изменение элемента LIST!!!
								break;
							}
						}
					}
					break;
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
					break;
				}
			}

			if (isNewUser)
			{
				ChatUser cu = new ChatUser { userName = userName, 
						isConnected = true, haveMsg = false , msgItems = new List<MessageItem>()};
				_allChatUsers.Add(cu);
			}
			else if (_currentUserItem.UserName == userName)
				_currentUserItem.ConnectedImage = Resources.Circle_Green;

			PopulateInemsUser();
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
					break;
				}
			}

			if (_currentUserItem.UserName == userName)
				_currentUserItem.ConnectedImage = Resources.Circle_Red;

			PopulateInemsUser();
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
			foreach (ChatUser cu in _allChatUsers)
			{
				usersName.Add(cu.userName);
			}

			return usersName;
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

		//--------------------------------
		// ---------- chat logic ---------
		//--------------------------------

		public void ClickUserItem(UserListItem item)
		{
			СhangeCurrentUserItem(item);

			for (int i = 0; i < _allChatUsers.Count; ++i)
			{
				if (_allChatUsers[i].userName == item.UserName)
				{
					// Взять сообщения с сервиса и отобразить их(сохранить как items)
					this.msgFlowPanel.Controls.Clear();

					for (int k = 0; k < _allChatUsers[i].msgItems.Count; ++k)
					{
						this.msgFlowPanel.Controls.Add(_allChatUsers[i].msgItems[k]);
					}
					break;
				}
			}
		}



		//--------------------------------
		//----------- design -------------
		//--------------------------------

		private void UserWindow_Load(object sender, EventArgs e)
		{

			_client = new ServiceClient(new System.ServiceModel.InstanceContext(this));
			string[] allUserArr = allUserArr = _client.Connect(_userName);

			for (int i = 0; i < allUserArr.Length; ++i)
			{
				string[] words = allUserArr[i].Split(new char[] { '&' });
				if (_userName != words[0])
				{
					ChatUser newCU = new ChatUser();
					newCU.userName = words[0];
					newCU.isConnected = ('1' == words[1][0]) ? true : false;
					newCU.haveMsg = ('1' == words[1][1]) ? true : false;
					newCU.msgItems = new List<MessageItem>();
					_allChatUsers.Add(newCU);
				}
			}

			PopulateInemsUser();
		}

		// Отрисовка списка всех пользователей
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

				if (item == _currentUserItem)
				{
					СhangeCurrentUserItem(item);
				}

				_userListItems.Add(item);
				this.PanelListUsers.Controls.Add(item);
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
			if (this.msgTextBox.Text == "")
				return;

			if (_currentUserItem == null)
				return;

			string date = DateTime.Now.ToString();
			
			MessageItem msg = new MessageItem(
				this.msgTextBox.Text,
				date,
				_userName + _currentUserItem.UserName + date,
				_currentUserItem.UserName
			);

			this.msgFlowPanel.Controls.Add(msg);

			for (int i = 0; i < _allChatUsers.Count; ++i)
			{
				if (_allChatUsers[i].userName == _currentUserItem.UserName)
				{
					_allChatUsers[i].msgItems.Add(msg);
					break;
				}
			}

			_client.SendMsg(_userName, _currentUserItem.UserName, this.msgTextBox.Text + " " + date);
			this.msgTextBox.Text = "";
		}
	}
}
