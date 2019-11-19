using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainWindow
{
	public struct ChatUser
	{
		public string userName { get; set; }
		public bool isConnected { get; set; }
		public bool haveMsg { get; set; }
		public List<MessageItem> msgItems { get; set; }
	}
}
