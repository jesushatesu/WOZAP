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
        DataBase.DataBase dataBase;
        List<User> users = new List<User>();

        public List<User> GetUsr()
        {
            return users;
        }

        public Service()
        {
            dataBase = new DataBase.DataBase();

            users = GetUsersList();
        }

        /*public Service(DataBase.IDataBase db)
        {
            dataBase = db;

			users = GetUsersList();
        }*/

        public string[] Connect(string userName)
        {
			dataBase.AddUser(userName);

            bool flag = false;
			
            for (int i = 0; i < users.Count(); i++)
            {
                if (users.ToArray()[i].name == userName)
				{
					User newUser = new User
					{
						isConnected = true,
						name = userName,
						opCont = OperationContext.Current

					};
					//users.ToArray()[i].opCont = OperationContext.Current;
					//users.ToArray()[i].ChangeCon(true);
					users.Remove(users[i]);
					users.Insert(0, newUser);
                    flag = true;
				}
            }

            if (!flag)
            {
                User newUser = new User()
                {
                    name = userName,
                    isConnected = true,
                    opCont = OperationContext.Current
                };
				users.Insert(0, newUser);
            }

			string[] userStruct = new string[users.Count()];

			for (int i = 0; i < users.Count(); i++)
            {
				if (users.ToArray()[i].isConnected & users.ToArray()[i].name != userName)
				{
                    users.ToArray()[i].opCont.GetCallbackChannel<IServerChatCallback>().ConnectUserCallback(users.ToArray()[i].name);
				}

                userStruct[i] = users.ToArray()[i].name + "&" + ((users.ToArray()[i].isConnected)?"1":"0") + ((dataBase.HaveMsg(userName)) ? "1" : "0");
				//userNameConnectHaveMsg.ToArray()[i].haveMsg = dataBase.HaveMsg(userName);
			}

			Console.WriteLine("-------------------------------------------------------------");
			for (int i = 0; i < users.Count(); i++)
				Console.WriteLine(users.ToArray()[i].name + " ---- " + users.ToArray()[i].isConnected.ToString());

			return userStruct;
        }

        public void Disconnect(string userName)
		{
			for (int i = 0; i < users.Count(); i++)
            {
				if (users.ToArray()[i].isConnected & users.ToArray()[i].name != userName)
                    users.ToArray()[i].opCont.GetCallbackChannel<IServerChatCallback>().DisconnectUserCallback(users.ToArray()[i].name);


				if (users.ToArray()[i].name == userName)
				{
					User newUser = new User
					{
						isConnected = false,
						name = userName
					};
					users.Remove(users[i]);
					users.Add(newUser);
					//users.ToArray()[i].ChangeCon(false);
				}
			}

			Console.WriteLine("-------------------------------------------------------------");
			for (int i = 0; i < users.Count(); i++)
				Console.WriteLine(users.ToArray()[i].name + " ---- " + users.ToArray()[i].isConnected.ToString());
		}

        public void SendMsg(string fromUserName, string toUserName, string msg)
        {
            foreach(User user in users)
            {
                if (user.name == toUserName)
                {
                    // исправил немного: мне удобней, когда имя отправителя отдельным параметром (и код читабельней)
                    //string message = DateTime.Now.ToShortTimeString() + "/n";

                    if (user.isConnected)
                        user.opCont.GetCallbackChannel<IServerChatCallback>().MsgCallback(fromUserName, toUserName, msg);
                    else
                        dataBase.AddMsg(fromUserName, toUserName, msg);

                    break;
                }
            }
        }

        public string[] GetUnsentMsg(string userNameFrom, string userNameTo)
        {
            string[] str = dataBase.GetMsg(userNameFrom, userNameTo);

            return str;
        }
        
        List<User> GetUsersList()
        {
            string[] allUsers = new string[10];
            allUsers = dataBase.GetUsers();

            foreach (string usr in allUsers)
            {
					User user = new User { name = usr, isConnected = false };
				users.Add(user);
            }

            return users;
        }
    }
}