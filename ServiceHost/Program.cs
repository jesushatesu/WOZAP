using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WOZAP
{
    class Program
    {
        static void Main()
        {
            using (var host = new ServiceHost(typeof(WOZAP.Service)))
            {
                host.Open();
                Console.WriteLine("host started!");
                Console.ReadLine();
                System.Console.Read();
            }
        }
    }
}