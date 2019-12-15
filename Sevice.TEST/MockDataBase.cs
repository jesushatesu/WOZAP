using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;

namespace Sevice.TEST
{
    public class MockDataBase : IDataBase
    {
        public List<string> users;

        public MockDataBase()
        {
            users.Add("vadik");
            users.Add("iluxa");
            users.Add("tema");
            users.Add("roma");
            users.Add("solyzra");
            users.Add("ridux");
            users.Add("dima");
            users.Add("maks");
        }

        public void AddMsg(string Msg)
        {
            return;
        }

        public void AddUser(string userName)
        {
            users.Insert(0, userName);
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

        public string[] GetMsg(string userNameFrom, string userNameTo)
        {
            throw new NotImplementedException();
        }

        public int GetId(string username)
        {
            throw new NotImplementedException();
        }

        public void AddMsg(string from, string to, string msgg)
        {
            throw new NotImplementedException();
        }

        public bool HaveMsg(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
