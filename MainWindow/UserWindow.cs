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
		private WOZAP.IService service;
		private Point lastPoint;

		public UserWindow(string userName, SingInWindow singInWindow)
		{
			InitializeComponent();
			_userName = userName;
			_singInWindow = singInWindow;
			this.userName.Text = userName;
			List<User> allUsers = new List<User> { };

			// Это для визуального тестиования
			ChatUser u1 = new ChatUser { name = "user1", isConnected = true, haveMsg = true };
			ChatUser u2 = new ChatUser { name = "user2", isConnected = false, haveMsg = false };
			ChatUser u3 = new ChatUser { name = "user3", isConnected = true, haveMsg = true };
			_allUsers.Add(u1);
			_allUsers.Add(u2);
			_allUsers.Add(u3);
		}

		public void MsgCallback(string fromUser, string msg)
		{

		}

		// Тут может быть вопрос с циклом List.ForEach
		public void ConnectUserCallback(string userName)
		{
			bool flag = true;
			_allUsers.ForEach(user =>
			{
				if (user.name == userName)
				{
					user.isConnected = true;
					flag = false;
				}
			});

			if (flag)
			{
				_allUsers.Add(new ChatUser { name = userName, isConnected = true, haveMsg = false });
			}
		}

		// Тут может быть вопрос с циклом List.ForEach
		public void DisconnectUserCallback(string userName)
		{
			_allUsers.ForEach(user =>
			{
				if (user.name == userName)
				{
					user.isConnected = false;
				}
			});
		}

		// ----------- get --------------

		public string GetUserName()
		{
			return _userName;
		}

		// вернёт список всех имён пользователей
		public List<string> GetAllUsersName()
		{
			List<string> usersName = new List<string> { };
			foreach (ChatUser cu in _allUsers)
			{
				usersName.Add(cu.name);
			}

			return usersName;
		}

		public bool ThisUserIsConnect(string username)
		{
			bool isConnect = false;
			for (int i = 0; i < _allUsers.Count; ++i)
			{
				if (_allUsers[i].name == username)
				{
					isConnect = _allUsers[i].isConnected;
					break;
				}
			}

			return isConnect;
		}
		
		
		//----------- design -------------

		private void UserWindow_Load(object sender, EventArgs e)
		{
			// создание списка Itens
			PopulateItems();
		}

		// Отрисовка списка всех пользователей
		private void PopulateItems()
		{
			UserListItem[] userListItems = new UserListItem[_allUsers.Count];
			//bool flag = true;
			for (int i = 0; i < userListItems.Length; ++i)
			{
				userListItems[i] = new UserListItem();
				userListItems[i].UserName = _allUsers[i].name;
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

				this.PanelListUsers.Controls.Add(userListItems[i]);
				
			}
		}

		private void topblokAuth_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.Left += e.X - lastPoint.X;
				this.Top += e.Y - lastPoint.Y;
			}
		}

		private void topblokAuth_MouseDown(object sender, MouseEventArgs e)
		{
			lastPoint = new Point(e.X, e.Y);
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

	}
}
