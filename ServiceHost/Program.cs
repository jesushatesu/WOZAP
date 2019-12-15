using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using DataBase;

namespace WOZAP
{
    class Program
    {
        static void Main()
        {
            var db = new DataBase.DataBase();
            var service = new Service(db);
            using (var host = new ServiceHost(service, new Uri("http://localhost:8080/")))
            {
                host.Open();
                Console.WriteLine("host started!");
                Console.ReadLine();
                System.Console.Read();
            }
        }
    }
}