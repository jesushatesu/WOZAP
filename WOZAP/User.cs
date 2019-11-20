using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WOZAP
{
    public struct User
    {
        public string name { get; set; }
		public bool isConnected;
        public OperationContext opCont { get; set; }

		public void ChangeCon(bool val)
		{
			isConnected = val;
		}
    }
}
