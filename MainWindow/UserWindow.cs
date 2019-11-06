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

namespace MainWindow
{

	public partial class UserWindow : Form, IServerChatCallback
	{
		private SingInWindow _singInWindow;
		private string _userName;
        private List<User> _allUsers;
        WOZAP.IService service; // ---------
         
		public UserWindow(string userName, SingInWindow singInWindow)
		{
            InitializeComponent();
			_userName = userName;
			_singInWindow = singInWindow;
            this.userName.Text = userName;
			
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

		public void MsgCallback(string msg)
		{
			
		}

		public void ConnectUserCallback(string userName)
		{
			
		}

		public void DisconnectUserCallback(string userName)
		{
			
		}

		public void ModificationMsgCallback(string msg)
		{
			
		}

    
	}
}
