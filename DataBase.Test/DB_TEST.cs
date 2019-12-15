using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataBase;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.ComponentModel;


namespace DataBase.Test
{
	[TestClass]
	public class DB_TEST
	{
		[TestMethod]
		public void get_id()
		{
			DataBase db = new DataBase();
			int b = db.GetId("vadik");
			Assert.AreEqual(b,7);
		}

		[TestMethod]
		public void add_user()
		{
			DataBase db = new DataBase();
			db.AddUser("vadim");
			int b = db.GetId("vadik");
			int c = db.GetId("vadim");
			Assert.AreEqual(b+1,c);
		}

		[TestMethod]
		public void Have_mess()
		{
			DataBase db = new DataBase();
			bool b = db.HaveMsg("123", "sada");
			Assert.AreEqual(b,true);
		}

		[TestMethod]
		public void Add_mes ()
		{
			DataBase db = new DataBase();
			string[] a = db.GetMsg("sss","ddd");
			string[] b = {"aaa"};
			foreach (var usr in a)
			{
				Assert.AreEqual(usr, b[0]);
			}
		}
}
}
