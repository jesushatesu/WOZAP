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
        public string name { get; set; }
        public bool isConnected { get; set; }
        public OperationContext opCont { get; set; }

    }
}
