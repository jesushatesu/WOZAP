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

		//string[] GetUsers();

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

		}

		public void AddMsg(string Msg)
		{

		}

		public string GetMsg(string UserName)
		{
			return UserName;
		}

		//      public string[] GetUsers()
		//      {
		//	//Исправить, сделал для того, чтобы компилировалось

		//	//using (var context = new DataClasses1DataContext())
		//	//{
		//	//	var users1 = context.GetTable<Table>;
		//	//}
		//	using (DataClasses1DataContext db = new DataClasses1DataContext())
		//	{
		//		var user = db.GetTable.ToString<Table>();
		//	}
		//        return 
		//}

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
			DataClasses1DataContext db = new DataClasses1DataContext(connectionString);

				// Получаем таблицу пользователей
			Table<User> users = db.GetTable<User>();

			foreach (var user in users)
			{
				Console.WriteLine("{0} \t{1} \t{2}", user.id, user.FirstName);
			}

			Console.Read();

		}
	}
}


