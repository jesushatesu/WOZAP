using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MainWindow;

namespace WOZAP
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service : IService
    {
        DataBase.DataBase _dataBase;
        List<User> _users = new List<User>();

        public List<User> GetUsr()
        {
            return _users;
        }

        public Service()
        {
            _dataBase = new DataBase.DataBase();

            _users = GetUsersList();
        }

        /*public Service(DataBase.IDataBase db)
        {
            dataBase = db;

			users = GetUsersList();
        }*/

        public string[] Connect(string userName)
		{
            bool isNewUser = true;
			
            for (int i = 0; i < _users.Count(); i++)
            {
                if (_users[i].name == userName)
				{
					_users.Remove(_users[i]);
					isNewUser = false;
				}
            }

            if (isNewUser)
				_dataBase.AddUser(userName); // Не добавляет у меня, возможно нужны временные файлы БД!!!!!!!!!!

			User newUser = new User()
			{
				name = userName,
				isConnected = true,
				opCont = OperationContext.Current
			};

			_users.Insert(0, newUser);

			Console.WriteLine("-------------------------------------------------------------");
			for (int i = 0; i < _users.Count(); i++)
				Console.WriteLine(_users[i].name + " ---- " + _users[i].isConnected.ToString());

			return SayOnlineAndGetInfoAboutOtherUsers(userName);
        }

		private string[] SayOnlineAndGetInfoAboutOtherUsers(string toUserName)
		{
			string[] userStruct = new string[_users.Count()];

			for (int i = 0; i < _users.Count(); i++)
			{
				if (_users[i].isConnected & _users[i].name != toUserName)
					_users[i].opCont.GetCallbackChannel<IServerChatCallback>().ConnectUserCallback(toUserName);

				userStruct[i] = _users[i].name + "&"
					+ ((_users[i].isConnected) ? "1" : "0")
					+ ((_dataBase.HaveMsg(toUserName)) ? "1" : "0"); // Нужно так !!! HaveMsg(string fromUser, toUser)
			}

			return userStruct;
		}

        public void Disconnect(string userName)
		{
			int indexDisconUser = -1;

			for (int i = 0; i < _users.Count(); i++)
            {
				if (_users[i].isConnected & _users[i].name != userName)
					_users[i].opCont.GetCallbackChannel<IServerChatCallback>().DisconnectUserCallback(userName);

				if (_users.ToArray()[i].name == userName)
					indexDisconUser = i;
			}

			if (indexDisconUser != -1)
			{
				User newUser = _users[indexDisconUser];
				newUser.ChangeCon(false);
				_users.Remove(_users[indexDisconUser]);
				_users.Add(newUser);
			}

			Console.WriteLine("-------------------------------------------------------------");
			for (int i = 0; i < _users.Count(); i++)
				Console.WriteLine(_users[i].name + " ---- " + _users[i].isConnected.ToString());
		}

        public void SendMsg(string fromUserName, string toUserName, string msg)
        {
            foreach(User user in _users)
            {
                if (user.name == toUserName)
                {
                    if (user.isConnected)
                        user.opCont.GetCallbackChannel<IServerChatCallback>().MsgCallback(fromUserName, toUserName, msg);
                    else
                        _dataBase.AddMsg(fromUserName, toUserName, msg);  // Не работает !!!!!
                    break;
                }
            }
        }

        public string[] GetUnsentMsg(string userNameFrom, string userNameTo)
        {
            string[] str = _dataBase.GetMsg(userNameFrom, userNameTo);

            return str;
        }
        
        List<User> GetUsersList()
        {
            string[] allUsers = new string[10];
            allUsers = _dataBase.GetUsers();

            foreach (string usr in allUsers)
            {
				User user = new User { name = usr, isConnected = false };
				_users.Add(user);
            }

            return _users;
        }
    }
}