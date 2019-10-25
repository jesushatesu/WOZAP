using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ChatWindow;

namespace WOZAP
{
    [ServiceContract(CallbackContract = typeof(IServerChatCallback))]   
    public interface IService
    {
        [OperationContract]
        int Connect(string userName);

        [OperationContract]
        void Disconnect(string userName);

        [OperationContract(IsOneWay = true)]
        void SendMsg(string userName, string msg);
    }
}
