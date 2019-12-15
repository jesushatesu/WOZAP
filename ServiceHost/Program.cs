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
            var service = new Service();
            string uri = "localhost:8080";
            using (var host = new ServiceHost(service, new Uri(uri)))
            {
                host.Open();
                Console.WriteLine("host started!");
                Console.ReadLine();
                System.Console.Read();
            }
        }
    }
}