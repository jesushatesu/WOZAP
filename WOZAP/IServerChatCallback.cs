using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WOZAP
{
    public interface IServerChatCallback
    {
        [OperationContract]
        void MsgCallback(string msg);

        [OperationContract]
        void ConnectUserCallback(string userName);

        [OperationContract]
        void DisconnectUserCallback(string userName);

        [OperationContract]
        void ModificationMsgCallback(string msg);
    }
}
