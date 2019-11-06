using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WOZAP
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service : IService
    {
        IDataBase dataBase;
        static List<User> users;

        Service()
        {
            dataBase = new DataBase.DataBase();
            users = GetUsersList();
        }

        public string Connect(string userName, out List<User> listUsers)
        {
            dataBase.AddUser(userName);
            string messages = "";

            for (int i = 0; i < users.LongCount(); i++)
            {
                User usr = users[i];
                usr.opCont.GetCallbackChannel<IServerChatCallback>().DisconnectUserCallback(usr.name);

                if (usr.name == userName)
                {
                    messages = dataBase.GetMsg(userName);
                    usr.isConnected = false;
                }
            }

            listUsers = new List<User>();
            foreach (User usr in users)
            {
                listUsers.Add(new User { name = usr.name, isConnected = usr.isConnected});
            }

            return messages;
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
                    string message = fromUserName;
                    message += " " + DateTime.Now.ToShortTimeString() + "/n";

                    message += msg;

                    user.opCont.GetCallbackChannel<IServerChatCallback>().MsgCallback(message);

                    break;
                }
            }
        }
        
        public List<User> GetUsersList()
        {
            List<User> users = new List<User> { };
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
