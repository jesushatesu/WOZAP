using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MainWindow;

namespace WOZAP
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service : IService
    {
        private DataBase.IDataBase dataBase { get; set; }
        private List<User> users { get; set; }

        public Service()
        {
            dataBase = new DataBase.DataBase();
            
            users = GetUsersList();
        }

        public Service(DataBase.IDataBase db)
        {
            dataBase = db;

            users = GetUsersList();
        }

        public List<User> GetUsr()
        {
            return users;
        }

        public string[] Connect(string userName)
		{
            bool isNewUser = true;
			
            for (int i = 0; i < users.Count(); i++)
            {
                if (users[i].name == userName)
				{
					users.Remove(users[i]);
					isNewUser = false;
				}
            }

            if (isNewUser)
				dataBase.AddUser(userName); // Не добавляет у меня, возможно нужны временные файлы БД!!!!!!!!!!

			User newUser = new User()
			{
				name = userName,
				isConnected = true,
				opCont = OperationContext.Current
			};

			users.Insert(0, newUser);

			Console.WriteLine("[" + userName + "] => Connect = " + newUser.isConnected.ToString());

			return SayOnlineAndGetInfoAboutOtherUsers(userName);
        }

		private string[] SayOnlineAndGetInfoAboutOtherUsers(string toUserName)
		{
			string[] userStruct = new string[users.Count()];

			for (int i = 0; i < users.Count(); i++)
			{
				if (users[i].isConnected & users[i].name != toUserName)
					users[i].opCont.GetCallbackChannel<IServerChatCallback>().ConnectUserCallback(toUserName);

				userStruct[i] = users[i].name
					+ ((users[i].isConnected) ? "1" : "0")
					+ ((dataBase.HaveMsg(/*user[i],*/ toUserName)) ? "1" : "0"); // Нужно так !!! HaveMsg(string fromUser, toUser)
			}

			return userStruct;
		}

        public void Disconnect(string userName)
		{
			int indexDisconUser = -1;

			for (int i = 0; i < users.Count(); i++)
            {
				if (users[i].isConnected & users[i].name != userName)
					users[i].opCont.GetCallbackChannel<IServerChatCallback>().DisconnectUserCallback(userName);

				if (users.ToArray()[i].name == userName)
					indexDisconUser = i;
			}

			if (indexDisconUser != -1)
			{
				User newUser = users[indexDisconUser];
				newUser.ChangeCon(false);
				users.Remove(users[indexDisconUser]);
				users.Add(newUser);

				Console.WriteLine("[" + userName + "] => Connect = " + newUser.isConnected.ToString());
			}
			else
			{
				Console.WriteLine("Error: [" + userName + "] can't disconnect: can't find [" + userName + "] in all users");
			}

		}

        public void SendMsg(string fromUserName, string toUserName, string msg)
        {
			bool sendMsg = false;
            foreach(User user in users)
            {
                if (user.name == toUserName)
                {
					Console.WriteLine("Waiting send msg [" + fromUserName + "] to [" + toUserName + "]");
					if (user.isConnected)
                        user.opCont.GetCallbackChannel<IServerChatCallback>().MsgCallback(fromUserName, toUserName, msg);
                    else
                        dataBase.AddMsg(fromUserName, toUserName, msg);

					sendMsg = true;
					break;
                }
            }
			if (!sendMsg)
			{
				Console.WriteLine("Error: Can't sendMsg from [" + fromUserName + "] to [" + toUserName + "]");
			}
			else
				Console.WriteLine("sendMsg from [" + fromUserName + "] to [" + toUserName + "]");

		}

        public string[] GetUnsentMsg(string userNameFrom, string userNameTo)
        {
			Console.WriteLine("GetUnsentMsg for [" + userNameFrom + "] to [" + userNameTo + "]");
            string[] str = dataBase.GetMsg(userNameFrom, userNameTo);

            return str;
        }
        
        List<User> GetUsersList()
        {
            string[] allUsers = dataBase.GetUsers();

            foreach (string usr in allUsers)
            {
                User user = new User { name = usr, isConnected = false };
				users.Add(user);
            }


            return users;
        }
    }
}