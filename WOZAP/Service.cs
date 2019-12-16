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
        private DataBase.IDataBase _dataBase { get; set; }
        private List<User> _users { get; set; }

        public Service()
        {
            _dataBase = new DataBase.DataBase();
            
            GetUsersList();
        }

        public Service(DataBase.IDataBase db)
        {
            _dataBase = db;

            GetUsersList();
        }

        public List<User> GetUsr()
        {
            return _users;
        }

        public string[] Connect(string userName)
        {
            Console.WriteLine();
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
				_dataBase.AddUser(userName);

			User newUser = new User()
			{
				name = userName,
				isConnected = true,
				opCont = OperationContext.Current
			};

			_users.Insert(0, newUser);

			Console.WriteLine("[" + userName + "] => Connect = " + newUser.isConnected.ToString());


            Console.WriteLine();
            return SayOnlineAndGetInfoAboutOtherUsers(userName);
        }

		private string[] SayOnlineAndGetInfoAboutOtherUsers(string toUserName)
		{
			string[] userStruct = new string[_users.Count()];
            
            for (int i = 0; i < _users.Count(); i++)
			{
				if (_users[i].isConnected & _users[i].name != toUserName)
					_users[i].opCont.GetCallbackChannel<IServerChatCallback>().ConnectUserCallback(toUserName);

                
                userStruct[i] = _users[i].name
					+ ((_users[i].isConnected) ? "1" : "0")
					+ ((_dataBase.HaveMsg(_users[i].name, toUserName)) ? "1" : "0");
            }

			return userStruct;
		}

        public void Disconnect(string userName)
        {
            Console.WriteLine();

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
				User newUser = new User(){name = userName, isConnected = false};
				_users.Remove(_users[indexDisconUser]);
				_users.Add(newUser);

				Console.WriteLine("[" + userName + "] => Connect = " + newUser.isConnected.ToString());
			}
			else
			{
				Console.WriteLine("Error: [" + userName + "] can't disconnect: can't find [" + userName + "] in all users");
			}

            Console.WriteLine();

            foreach (var usr in _users)
            {
                Console.WriteLine(usr.name);
            }
        }

        public void SendMsg(string fromUserName, string toUserName, string msg)
        {
            Console.WriteLine();

            bool sendMsg = false;
            foreach(User user in _users)
            {
                if (user.name == toUserName)
                {
					Console.WriteLine("Waiting send msg [" + fromUserName + "] to [" + toUserName + "]");
					if (user.isConnected)
                        user.opCont.GetCallbackChannel<IServerChatCallback>().MsgCallback(fromUserName, toUserName, msg);
                    else
                        _dataBase.AddMsg(fromUserName, toUserName, msg);

					sendMsg = true;
					break;
                }
            }
			if (!sendMsg)
			{
				Console.WriteLine("Error: Can't sendMsg from [" + fromUserName + "] to [" + toUserName + "]");
			}
			else
				Console.WriteLine("sendMsg from [" + fromUserName + "] to [" + toUserName + "]");

            Console.WriteLine();
        }

        public string[] GetUnsentMsg(string userNameFrom, string userNameTo)
        {
            Console.WriteLine();

            Console.WriteLine("GetUnsentMsg for [" + userNameFrom + "] to [" + userNameTo + "]");
            string[] str = _dataBase.GetMsg(userNameFrom, userNameTo);

            Console.WriteLine();

            return str;
        }
        
        void GetUsersList()
        {
            string[] allUsers = _dataBase.GetUsers();

            _users = new List<User>();
            foreach (string usr in allUsers)
            {
                User user = new User { name = usr, isConnected = false };
				_users.Add(user);
            }
        }
    }
}