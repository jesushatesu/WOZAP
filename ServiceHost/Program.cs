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
            using (ServiceHost host = new ServiceHost(service, new Uri("localhost:8080")))
            {
                try
                {
                    host.Open();
                    Console.WriteLine("host started!");
                    Console.ReadLine();

                    host.Close();
                }
                catch (TimeoutException timeProblem)
                {
                    Console.WriteLine(timeProblem.Message);
                    Console.ReadLine();
                }
                catch (CommunicationException commProblem)
                {
                    Console.WriteLine(commProblem.Message);
                    Console.ReadLine();
                }
            }
        }
    }
}