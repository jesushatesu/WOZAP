using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Linq;

namespace DataBase
{
	public interface IDataBase
	{
		int GetId(string username);
		void AddUser(string user);

		void AddMsg(string Msg);

		string[] GetMsg(string userNameFrom, string userNameTo);

		string[] GetUsers();

		string ModificationMsgDB(int idMsg, string newMsg);

		bool HaveMsg(string userName);

	}

	public class DataBase : IDataBase
	{
		private static string[] UnsentMsg;

		public int GetId(string username)
		{
			int iden = 0;
			string name = username;
			DataClasses1DataContext db = new DataClasses1DataContext();
	
			foreach (var user in db.GetTable<User>().OrderByDescending(u => u.Id))
			{
				if (user.name == name)
				{
					iden = user.Id;
				}
			}
			return iden;
		}

		public bool HaveMsg(string userName)
		{
			int b = GetId(userName);
			DataClasses1DataContext db2 = new DataClasses1DataContext();
			foreach (var user in db2.GetTable<Message>().OrderByDescending(u => u.Id2))
			{
				if (user.Id2 == b)
				{
					return true;
				}
			}
		    return false;
		}
		public DataBase()
		{
			UnsentMsg = new string[3] { " ", " ", " " };
		}
        

		public void AddUser(string user)
		{
			DataClasses1DataContext db = new DataClasses1DataContext();
			User user1 = new User { name = user};
			// добавляем его в таблицу Users
			db.GetTable<User>().InsertOnSubmit(user1);
			db.SubmitChanges();
		}

		public void AddMsg(string Msg)
		{

		}

<<<<<<< HEAD
        /*string[] GetMsg(string userNameFrom, string userNameTo)
        {

		}*/
=======
		public string[] GetMsg(string userNameFrom, string userNameTo)
		{
			//DataBase db = new DataBase();
			int a;
			int b;
			a = GetId(userNameFrom);
			b = GetId(userNameTo);
			DataClasses1DataContext db2 = new DataClasses1DataContext();
			int count = 0;
			foreach (var user in db2.GetTable<Message>().OrderByDescending(u => u.Id2))
			{
				if (user.Id2 == b && user.Id1 == a)
				{
					count++;
				}
			}
			//Console.WriteLine(count);

			string[] str = new string[count];
			int i = 0;
			foreach (var user in db2.GetTable<Message>().OrderByDescending(u => u.Id1))
			{
				if (user.Id2 == b && user.Id1 == a)
				{
					if (i >= count)
					{
						string[] new_str = new string[count + 100];

						for (int j = 0; j < count; j++)
							new_str[j] = str[j];

						count += 100;
						str = new_str;
					}
					str[i++] = user.Msg;
					//Console.WriteLine(str[i - 1]);
				}
			}
			return str;
		}
>>>>>>> 3ebe067... доделал базу данных

		public string[] GetUsers()
		{
			DataClasses1DataContext db = new DataClasses1DataContext();

			// Получаем таблицу пользователей
			Table<User> users = db.GetTable<User>();
			int max_id = 1;
			int i = 0;
			string[] str = new string[max_id];
			foreach (var user in users)
			{
				if (i >= max_id)
				{
					string[] new_str = new string[max_id + 100];

					for (int j = 0; j < max_id; j++)
						new_str[j] = str[j];

					max_id += 100;
					str = new_str;
				}

				str[i++] = user.name;
			}
			return str;
		}

		public string ModificationMsgDB(int idMsg, string newMsg)
		{
			return null;
		}

        string[] IDataBase.GetMsg(string userNameFrom, string userNameTo)
        {
            throw new NotImplementedException();
        }
    }

	class Program
	{
		static void Main(string[] args) 
		{
			//DataBase db = new DataBase();
			//string from = "vadik";
			//string [] a;
			//string to = "sada";
			//a= db.GetMsg(from, to);

			//for (int i = 0; i <3; i++)
			//{
			//	Console.WriteLine(a[i]);
			//}
		}
	}
}

