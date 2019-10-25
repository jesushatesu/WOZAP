using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WOZAP
{
    class User
    {
        private string name { get; set; }
        private bool isConnected { get; set; }
        private OperationContext opCont { get; set; }

    }
}
