using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WOZAP
{
    [ServiceContract(CallbackContract = typeof(IServerChatCallback))]   
    public interface IService
    {
        [OperationContract]
        string Connect(string userName);

        [OperationContract]
        void Disconnect(string userName);

		[OperationContract(IsOneWay = true)]
        void SendMsg(string fromUserName, string toUserName, string msg);
    }

    public interface IServerChatCallback
    {
        [OperationContract(IsOneWay = true)]
        void MsgCallback(string fromUser, string msg);

        [OperationContract(IsOneWay = true)]
        void ConnectUserCallback(string userName);

        [OperationContract(IsOneWay = true)]
        void DisconnectUserCallback(string userName);
    }
}
