using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Linq;

namespace DataBase
{

	//заебали исправлять база данных не работает теперь 
	public interface IDataBase
	{
		void AddUser(string user);

		void AddMsg(string Msg);

		string GetMsg(string UserName);

		string[] GetUsers();

		string ModificationMsgDB(int idMsg, string newMsg);

	}

	public class DataBase : IDataBase
	{
		private static string[] UnsentMsg;

		public DataBase()
		{
			UnsentMsg = new string[3] { " ", " ", " " };
		}
        

		public void AddUser(string user)
		{
			string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\228\Desktop\WOZAP\DataBase\Database1.mdf;Integrated Security=True";
			DataContext db = new DataContext(connectionString);
			User user1 = new User { name = "asa" };
			// добавляем его в таблицу Users
			db.GetTable<User>().InsertOnSubmit(user1);
			db.SubmitChanges();
		}

		public void AddMsg(string Msg)
		{

		}

		public string GetMsg(string UserName)
		{
			return UserName;
		}

		public string[] GetUsers()
		{
			//string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\228\Desktop\WOZAP\DataBase\Database1.mdf;Integrated Security=True";

			//string[] str = { "123", "123" };
			DataClasses1DataContext db = new DataClasses1DataContext();

			// Получаем таблицу пользователей
			Table<User> users = db.GetTable<User>();
			int max_id = 1;
			int i = 0;
			string[] str = new string[max_id];
			foreach (var user in users)
			{
				//Console.WriteLine("{0} \t{1}", user.Id, user.name);
				if (i >= max_id)
				{
					string[] new_str = new string[max_id + 100];

					for (int j = 0; j < max_id; j++)
						new_str[j] = str[j];

					max_id += 100;
					str = new_str;
				}

				str[i++] = user.name;
				//Console.WriteLine(str[i - 1]);
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
		static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\228\Desktop\WOZAP\DataBase\Database1.mdf;Integrated Security=True";
		static void Main(string[] args) 
		{
			//DataContext db = new DataContext(connectionString);
			//Console.WriteLine("До добавления");
			//foreach (var user in db.GetTable<User>().OrderByDescending(u => u.Id).Take(10))
			//{
			//	Console.WriteLine("{0} \t{1}", user.Id, user.name);
			//}
			//Console.WriteLine();



			//// создаем нового пользователя
			//User user1 = new User { name = "asa" };
			//// добавляем его в таблицу Users
			//db.GetTable<User>().InsertOnSubmit(user1);
			//db.SubmitChanges();

			//Console.WriteLine();
			//Console.WriteLine("После добавления");
			//foreach (var user in db.GetTable<User>().OrderByDescending(u => u.Id).Take(10))
			//{
			//	Console.WriteLine("{0} \t{1}", user.Id, user.name);
			//}
			//Console.WriteLine("До обновления");
			//foreach (var user in db.GetTable<User>().Take(5))
			//{
			//	Console.WriteLine("{0} \t{1}", user.Id, user.name);
			//}
			//Console.WriteLine();

			//// возьмем первого пользователя
			//User user1 = db.GetTable<User>().FirstOrDefault();
			//// и изменим у него возраст
			//user1.Id = 11;
			//// сохраним изменения
			//db.SubmitChanges();

			//Console.WriteLine();
			//Console.WriteLine("После обновления");
			//foreach (var user in db.GetTable<User>().Take(5))
			//{
			//	Console.WriteLine("{0} \t{1}", user.Id, user.name);
			//}

		}
	}
}


