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
        DataBase.IDataBase dataBase;
        List<User> users = new List<User>();

        public List<User> GetUsr()
        {
            /*List<User> listUsers = new List<User>();
            foreach (User usr in users)
            {
                listUsers.Add(new User { name = usr.name, isConnected = usr.isConnected });
            }

            return listUsers;*/
            return users;
        }

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

        public void Connect(string userName, ref List<ChatUser> userNameConnectHaveMsg)
        {
            dataBase.AddUser(userName);

            for (int i = 0; i < users.LongCount(); i++)
            {
                User usr = users[i];
                usr.opCont.GetCallbackChannel<IServerChatCallback>().ConnectUserCallback(usr.name);

                if (usr.name == userName)
                {
                    usr.isConnected = true;
                }

                userNameConnectHaveMsg.ToArray()[i].isConnected = usr.isConnected;
                userNameConnectHaveMsg.ToArray()[i].userName = usr.name;
                //userNameConnectHaveMsg.ToArray()[i].haveMsg = dataBase.HaveMsg(userName);
            }
            
        }

        public void Disconnect(string userName)
        {
            for (int i = 0; i < users.LongCount(); i++)
            {
                User usr = users[i];
                usr.opCont.GetCallbackChannel<IServerChatCallback>().DisconnectUserCallback(usr.name);

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

                    string message = msg;

                    user.opCont.GetCallbackChannel<IServerChatCallback>().MsgCallback(fromUserName, message);

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