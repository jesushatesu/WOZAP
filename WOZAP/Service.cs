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

        static string[] users = DataBase.GetUsers();

        public int Connect(string userName)
        {
            return 0;
        }

        public void Disconnect(string userName)
        {

        }

        public void SendMsg(string userName, string msg)
        {

        }

        public static string[] GetUsers()
        {
            return users;
        }
    }
}
