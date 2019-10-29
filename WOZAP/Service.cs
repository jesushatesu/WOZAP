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
		//qwer
        IDataBase dataBase;
        static List<User> users;

        Service()
        {
            users = GetUsers();
        }

        public string Connect(string userName, out List<User> listUsers)
        {
            dataBase.AddUser(userName);
            string messages = "";

            foreach (User user in users)
            {
                if (user.name == userName)
                {
                    messages = dataBase.GetMsg(userName);
                    user.isConnected = true;
                }
            }
            
            listUsers = users;
            return messages;
        }

        public void Disconnect(string userName)
        {
            foreach (User user in users)
            {
                if (user.name == userName)
                    user.isConnected = false;
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

        public List<User> GetUsers()
        {
            return dataBase.GetUsers();
        }
    }
}
