using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;

namespace Sevice.TEST
{
    class MockDataBase : IDataBase
    {
        public string[] users = new string[10];
        public static int next = 0;

        public void AddMsg(string Msg)
        {
            return;
        }

        public void AddUser(string user)
        {
            users[next++] = user;
        }

        public string GetMsg(string UserName)
        {
            string str = " ";
            return str;
        }

        public string[] GetUsers()
        {
            string[] str = new string[] { " ", " " };
            return str;
        }

        public string ModificationMsgDB(int idMsg, string newMsg)
        {
            string str = " ";
            return str;
        }
    }
}
