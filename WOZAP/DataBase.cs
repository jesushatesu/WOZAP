using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOZAP 
{
    public interface IDataBase
    {
        void AddUser(string user);

        void AddMsg(string Msg);

        string GetMsg(string UserName);

        string[] GetUsers();

        string ModificationMsgDB(int idMsg, string newMsg);

    }

    public class DataBase : IDataBase
    {
        private static string[] UnsentMsg;
        public void AddUser(string user)
        {

        }
        public void AddMsg(string Msg)
        {

        }
        public string GetMsg(string UserName)
        {
            return UserName;
        }
        public string[] GetUsers()
        {
            return null;
        }
        public string ModificationMsgDB(int idMsg, string newMsg)
        {
            return null;
        }
    }
}
