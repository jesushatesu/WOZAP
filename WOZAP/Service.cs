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
			Console.WriteLine("Connect started");
            
			dataBase.AddUser(userName);
            for (int i = 0; i < users.Count(); i++)
                Console.WriteLine(users.ToArray()[i].name + " ---- " + users.ToArray()[i].isConnected.ToString());

            bool flag = false;
            for (int i = 0; i < users.Count(); i++)
            {
                if (users.ToArray()[i].name == userName)
                {
                    users.ToArray()[i].opCont = OperationContext.Current;
                    users.ToArray()[i].isConnected = true;
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
                users.Add(newUser);
            }

			Console.WriteLine("Connect connected with DB");
			string[] userStruct = new string[users.Count()];

			Console.WriteLine("users.Count() = " + users.Count().ToString());
			for (int i = 0; i < users.Count(); i++)
            {
				if (users.ToArray()[i].isConnected & users.ToArray()[i].name != userName)
				{
					Console.WriteLine("before Callback on iteration " + i.ToString());
                    users.ToArray()[i].opCont.GetCallbackChannel<IServerChatCallback>().ConnectUserCallback(users.ToArray()[i].name);
					Console.WriteLine("after Callback on iteration " + i.ToString());
				}

                userStruct[i] = users.ToArray()[i].name + "&" + ((users.ToArray()[i].isConnected)?"1":"0") + ((dataBase.HaveMsg(userName)) ? "1" : "0");
				//userNameConnectHaveMsg.ToArray()[i].haveMsg = dataBase.HaveMsg(userName);
			}
			Console.WriteLine("Connect finished");

			return userStruct;
        }

        public void Disconnect(string userName)
        {
            for (int i = 0; i < users.Count(); i++)
            {
				if (users.ToArray()[i].isConnected & users.ToArray()[i].name != userName)
                    users.ToArray()[i].opCont.GetCallbackChannel<IServerChatCallback>().DisconnectUserCallback(users.ToArray()[i].name);

                if (users.ToArray()[i].name == userName)
                    users.ToArray()[i].isConnected = false;
            }
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