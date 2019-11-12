using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainWindow;
using System.Collections.Generic;

namespace Tests_MainWindow
{
	[TestClass]
	public class Tests_UserWindow
	{
		private SingInWindow sw = new SingInWindow();

		[TestMethod]
		public void DesignerUserWindow()
		{
			string ex = "my user name";
			UserWindow uw = new UserWindow(ex, sw);
			string userName = uw.GetUserName();

			Assert.AreEqual(ex, userName);
		}

		[TestMethod]
		public void ConnectUserCallback()
		{
			UserWindow uw = new UserWindow("user name", sw);
			string newUser = "new user";
			uw.ConnectUserCallback(newUser);
			List<string> allUserName = uw.GetAllUsersName();
			bool addNewUser = false;

			// проверим, есть ли такой пользовватель
			for (int i = 0; i < allUserName.Count; ++i)
			{
				if (allUserName[i] == newUser)
				{
					addNewUser = true;
					break;
				}	
			}
			
			Assert.IsTrue(addNewUser);
			Assert.IsTrue(uw.ThisUserIsConnect(newUser));
		}


		[TestMethod]
		public void DisconnectUserCallback()
		{
			UserWindow uw = new UserWindow("user name", sw);
			string newUser = "new user";
			uw.ConnectUserCallback(newUser);

			uw.DisconnectUserCallback(newUser);

			Assert.IsFalse(uw.ThisUserIsConnect(newUser));
		}
	}
}
