using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Linq;
using System.Configuration;

namespace DataBase
{
	public interface IDataBase
	{
		int GetId(string username);
		void AddUser(string user);

		void AddMsg(string from, string to, string msgg);

		string[] GetMsg(string userNameFrom, string userNameTo);

		string[] GetUsers();

		string ModificationMsgDB(int idMsg, string newMsg);

		bool HaveMsg(string fromUser,string toUser);

	}

	public class DataBase : IDataBase
	{
		private static string[] UnsentMsg;

		public int GetId(string username)
		{
			int iden = 0;
			string name = username;
			string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\5 сем\ТИМП\WOZAP\DataBase\Database1.mdf';Integrated Security=True";
			DataClasses1DataContext db = new DataClasses1DataContext(connectionString);

			foreach (var user in db.GetTable<User>().OrderByDescending(u => u.Id))
			{
				if (user.name == name)
				{
					iden = user.Id;
				}
			}
			return iden;
		}

		// Нужно так  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		// public bool HaveMsg(string fromUser, toUser)
		public bool HaveMsg(string fromUser, string toUser)
		{
			int b = GetId(toUser);
			int a = GetId(fromUser);
			string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\5 сем\ТИМП\WOZAP\DataBase\Database1.mdf';Integrated Security=True";
			DataClasses1DataContext db2 = new DataClasses1DataContext(connectionString);
			foreach (var user in db2.GetTable<Message>().OrderByDescending(u => u.Id2))
			{
				if (user.Id2 == b && user.Id1==a)
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
			string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\5 сем\ТИМП\WOZAP\DataBase\Database1.mdf';Integrated Security=True";
			DataClasses1DataContext db = new DataClasses1DataContext(connectionString);
			User user1 = new User { name = user };
			// добавляем его в таблицу Users
			db.GetTable<User>().InsertOnSubmit(user1);
			db.SubmitChanges();
		}

		public void AddMsg(string from, string to, string msgg)
		{
			string a = from; string b = to;
			string msg = msgg;
			string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\5 сем\ТИМП\WOZAP\DataBase\Database1.mdf';Integrated Security=True";
			DataClasses1DataContext db2 = new DataClasses1DataContext(connectionString);

			int ida = GetId(a);
			int idb = GetId(b);
            //Console.WriteLine("До добавления");
            //foreach (var user in db2.GetTable<Message>().OrderByDescending(u => u.Id1).Take(5))
            //{
            //	Console.WriteLine("{0} \t{1} \t{2}", user.Id1, user.Id2, user.Msg);
            //}
            //Console.WriteLine();
            Message user12 = new Message { Id1 = ida, Id2 = idb, Msg = msg };
			// добавляем его в таблицу Message
			db2.GetTable<Message>().InsertOnSubmit(user12);

            db2.SubmitChanges();
            //Console.WriteLine("После добавления");
            //foreach (var user in db2.GetTable<Message>())
            //{
            //	Console.WriteLine("{0} \t{1} \t{2}", user.Id1, user.Id2, user.Msg);
            //}
        }

		public string[] GetMsg(string userNameFrom, string userNameTo)
		{
			//DataBase db = new DataBase();
			int a;
			int b;
			a = GetId(userNameFrom);
			b = GetId(userNameTo);
			string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\5 сем\ТИМП\WOZAP\DataBase\Database1.mdf';Integrated Security=True";
			DataClasses1DataContext db2 = new DataClasses1DataContext(connectionString);
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
				}
			}

			return str;
		}

		public string[] GetUsers()
		{
			string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\JesusHatesU\Desktop\WOZAP\DataBase\Database1.mdf';Integrated Security=True";
			DataClasses1DataContext db = new DataClasses1DataContext(connectionString);

			// Получаем таблицу пользователей
			Table<User> users = db.GetTable<User>();
			int max_id = 1;
			int i = 0;
			string[] str = new string[max_id];
			foreach (var user in users)
			{
				if (i >= max_id)
				{
					string[] new_str = new string[max_id + 1];

					for (int j = 0; j < max_id; j++)
						new_str[j] = str[j];

					max_id += 1;
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
    }

	class Program
	{
		static void Main(string[] args)
		{
			//string fromUser = "ilya";
			//string touser = "tema";
			DataBase db = new DataBase();
			bool a= db.HaveMsg("ilya", "vadik");
			Console.WriteLine(a);
			//int a = db.GetId(fromUser);
			//int b = db.GetId(touser);
			//string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\5 сем\ТИМП\WOZAP\DataBase\Database1.mdf';Integrated Security=True";
			//DataClasses1DataContext db2 = new DataClasses1DataContext(connectionString);
			//foreach (var user in db2.GetTable<Message>())
			//{
			//	if (user.Id2 == b && user.Id1 == a)
			//	{
			//		return true;
			//	}
			//}


		}
	}
}

