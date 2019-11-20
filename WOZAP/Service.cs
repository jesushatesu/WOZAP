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

			Console.WriteLine(users[0].name);
			dataBase.AddUser(userName);
			Console.WriteLine("Connect connected with DB");
			string[] userStruct = new string[users.Count()];

			Console.WriteLine("users.Count() = " + users.Count().ToString());
			for (int i = 0; i < users.LongCount(); i++)
            {
                User usr = users[i];
				
				if (usr.isConnected)
				{
					Console.WriteLine("before Callback on iteration " + i.ToString());
					usr.opCont.GetCallbackChannel<IServerChatCallback>().ConnectUserCallback(usr.name);
					Console.WriteLine("after Callback on iteration " + i.ToString());
				}
				
				

				if (usr.name == userName)
                {
                    usr.isConnected = true;
                }

                userStruct[i] = usr.name + "&" + ((usr.isConnected)?"1":"0") + ((dataBase.HaveMsg(userName)) ? "1" : "0");
				//userNameConnectHaveMsg.ToArray()[i].haveMsg = dataBase.HaveMsg(userName);
			}
			Console.WriteLine("Connect finished");

			return userStruct;
        }

        public void Disconnect(string userName)
        {
            for (int i = 0; i < users.LongCount(); i++)
            {
                User usr = users[i];
				if (usr.isConnected)
				{
					usr.opCont.GetCallbackChannel<IServerChatCallback>().DisconnectUserCallback(usr.name);
				}

                if (usr.name == userName)
                    usr.isConnected = false;
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
                        user.opCont.GetCallbackChannel<IServerChatCallback>().MsgCallback(fromUserName, msg);
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
                User user = new User { name = usr, isConnected = false};
                users.Add(user);
            }

            return users;
        }
    }
}