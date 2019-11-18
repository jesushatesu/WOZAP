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
        DataBase.DataBase dataBase;
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

        public string Connect(string userName)
        {
            dataBase.AddUser(userName);
            string messages = "";

            for (int i = 0; i < users.LongCount(); i++)
            {
                User usr = users[i];
                usr.opCont.GetCallbackChannel<IServerChatCallback>().ConnectUserCallback(usr.name);

                if (usr.name == userName)
                {
                    messages = dataBase.GetMsg(userName);
                    usr.isConnected = true;
                }
            }
            
            /*foreach (User usr in users)
            {
                listUsers.Add(new User { name = usr.name, isConnected = usr.isConnected});
            }*/

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
					// исправил немного: мне удобней, когда имя отправителя отдельным параметром (и код читабельней)
                    string message = DateTime.Now.ToShortTimeString() + "/n";

                    message += msg;

                    user.opCont.GetCallbackChannel<IServerChatCallback>().MsgCallback(fromUserName, message);

                    break;
                }
            }
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