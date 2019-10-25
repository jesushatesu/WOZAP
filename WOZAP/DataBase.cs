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

    public static class DataBase : IDataBase
    {
        private static string[] UnsentMsg;
        public static void AddUser(string user)
        {

        }
        public static void AddMsg(string Msg)
        {

        }
        public static string GetMsg(string UserName)
        {
            return UserName;
        }
        public static string[] GetUsers()
        {
            return null;
        }
        public static string ModificationMsgDB(int idMsg, string newMsg)
        {
            return null;
        }
    }
}
