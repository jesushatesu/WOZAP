using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;

namespace Sevice.TEST
{
	public class MockDataBase : IDataBase
	{
		public List<string> users;

		public MockDataBase()
		{
			users.Add("vadik");
			users.Add("iluxa");
			users.Add("tema");
			users.Add("roma");
			users.Add("solyzra");
			users.Add("ridux");
			users.Add("dima");
			users.Add("maks");
		}

		public void AddMsg(string from, string to, string msgg)
		{
			throw new NotImplementedException();
		}

		public void AddUser(string user)
		{
			throw new NotImplementedException();
		}

		public void DeleteMsg(string fromUser, string toUser)
		{
			throw new NotImplementedException();
		}

		public int GetId(string username)
		{
			throw new NotImplementedException();
		}

		public string[] GetMsg(string userNameFrom, string userNameTo)
		{
			throw new NotImplementedException();
		}

		public string[] GetUsers()
		{
			throw new NotImplementedException();
		}

		public bool HaveMsg(string fromUser, string toUser)
		{
			throw new NotImplementedException();
		}
	}
}
