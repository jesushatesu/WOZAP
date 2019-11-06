using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataBase;

namespace WOZAP
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service : IService
    {
        IDataBase dataBase;
        static List<User> users;

        Service()
        {
            //users = this.GetUsers();
            //dataBase = new DataBase.IDataBase();
        }

        public string Connect(string userName, out List<User> listUsers)
        {
            dataBase.AddUser(userName);
            string messages = "";

            foreach (User user in users)
            {
                user.opCont.GetCallbackChannel<IServerChatCallback>().ConnectUserCallback(user.name);

                if (user.name == userName)
                {
                    messages = dataBase.GetMsg(userName);
                    //user.isConnected = true;
                }
            }
            
            listUsers = users;
            return messages;
        }

        public void Disconnect(string userName)
        {
            foreach (User user in users)
            {
                user.opCont.GetCallbackChannel<IServerChatCallback>().DisconnectUserCallback(user.name);
                //if (user.name == userName)
                    //user.isConnected = false;
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

        [OperationContract]
        public List<User> GetUsers()
        {
            List<User> users = new List<User> { };
            string[] allUsers = dataBase.GetUsers();

            foreach (string usr in allUsers)
            {
                User user = new User { name = usr, isConnected = false};
                users.Add(user);
            }

            return users;
        }
    }
}
