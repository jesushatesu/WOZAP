using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
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

        public DataBase()
        {
            UnsentMsg = new string[3] { " ", " ", " " };
        }

        static void Main(string[] args)
        {

        }

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
            //Исправить, сделал для того, чтобы компилировалось
            string[] users = new string[10];
            for (int i = 0; i < 10; i++)
            {
                users[i] = " ";
            }
            return users;
        }

        public string ModificationMsgDB(int idMsg, string newMsg)
        {
            return null;
        }
    }
}
