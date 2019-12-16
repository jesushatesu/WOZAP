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

		bool HaveMsg(string fromUser,string toUser);

		void DeleteMsg(string fromUser, string toUser);
	}

	public class DataBase : IDataBase
	{
		static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\JesusHatesU\Desktop\WOZAP\DataBase\Database1.mdf;Integrated Security=True";

		public int GetId(string username)
		{
			int iden = 0;
			string name = username;
			
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

		public bool HaveMsg(string fromUser, string toUser)
		{
			int b = GetId(toUser);
			int a = GetId(fromUser);
			
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
		}


		public void AddUser(string user)
		{
			DataClasses1DataContext db = new DataClasses1DataContext(connectionString);
			User user1 = new User { name = user };
			
			db.GetTable<User>().InsertOnSubmit(user1);
			db.SubmitChanges();
		}

		public void AddMsg(string from, string to, string msg)
		{
			DataClasses1DataContext db = new DataClasses1DataContext(connectionString);

			int ida = GetId(from);
			int idb = GetId(to);
            Message user12 = new Message { Id1 = ida, Id2 = idb, Msg = msg };
			db.GetTable<Message>().InsertOnSubmit(user12);
            db.SubmitChanges();

            foreach (var user in db.GetTable<Message>().OrderByDescending(u => u.Id2))
            {
                Console.WriteLine("Сообщение: " + user.Msg);
            }

            //Console.WriteLine("Добавилось сообщение " + user12.Msg + " from " + user12.Id1 + " to " + user12.Id2);
        }

		public string[] GetMsg(string userNameFrom, string userNameTo)
		{
			int a = GetId(userNameFrom);
            int b = GetId(userNameTo);
			
			DataClasses1DataContext db2 = new DataClasses1DataContext(connectionString);
			int count = 0;
			foreach (var user in db2.GetTable<Message>().OrderByDescending(u => u.Id2))
			{
				if (user.Id2 == b && user.Id1 == a)
				{
					count++;
                    Console.WriteLine("Сообщение: " + user.Msg);
                }
			}
			string[] str = new string[count];
			int i = 0;
            Console.WriteLine("\n");

            foreach (var user in db2.GetTable<Message>().OrderByDescending(u => u.Id1))
			{
				if (user.Id2 == b && user.Id1 == a)
				{
					if (i >= count)
					{
						string[] new_str = new string[count + 10];

						for (int j = 0; j < count; j++)
							new_str[j] = str[j];

						count += 10;
						str = new_str;
					}
					str[i++] = user.Msg;
				}
			}

            Console.WriteLine("\n");
            DeleteMsg(userNameFrom, userNameTo);

			return str;
		}

		public string[] GetUsers()
		{
			
			DataClasses1DataContext db = new DataClasses1DataContext(connectionString);

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

        public void DeleteMsg(string fromUser, string toUser)
		{
			int a = GetId(fromUser);
			int b = GetId(toUser);
			
			DataClasses1DataContext db2 = new DataClasses1DataContext(connectionString);
			foreach (var user in db2.GetTable<Message>())
			{
				if (user.Id1 == a && user.Id2 == b && user.Msg != null)
					db2.GetTable<Message>().DeleteOnSubmit(user);
				    db2.SubmitChanges();
			}
		}
    }

	class Program
	{
		static void Main(string[] args)
		{
			DataBase db = new DataBase();
			string[] a = db.GetMsg("tema", "ilya");
		}
	}
}

