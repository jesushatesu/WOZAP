using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainWindow;
using System.Collections.Generic;

namespace Tests_MainWindow
{
	[TestClass]
	public class Tests_UserWindow
	{
		private SingInWindow _sw;
		private const string _testNameUser = "testNameUser";
		private const string _newNameUser = "newNameUser";
		private UserWindow _testUW;
		private UserWindow _newUser;

		private void InitializationsTest()
		{
			_sw = new SingInWindow();
			_testUW = new UserWindow(_testNameUser, _sw);
			_newUser = new UserWindow(_newNameUser, _sw);
		}

		[TestMethod]
		public void DesignerUserWindow()
		{
			InitializationsTest();

			string userName = _testUW.GetUserName();

			Assert.AreEqual(_testNameUser, userName);
		}

		[TestMethod]
		public void ConnectUserCallback()
		{
			InitializationsTest();

			_testUW.ConnectUserCallback(_newNameUser);

			Assert.IsTrue(_testUW.ThisUserIsConnect(_newNameUser));
		}


		[TestMethod]
		public void DisconnectUserCallback()
		{
			InitializationsTest();

			_testUW.ConnectUserCallback(_newNameUser);

			_testUW.DisconnectUserCallback(_newNameUser);

			Assert.IsFalse(_testUW.ThisUserIsConnect(_newNameUser));
		}
	}
}
