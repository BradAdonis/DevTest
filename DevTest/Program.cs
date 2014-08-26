using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WebLibrary;
using WebLibrary.Data;
using WebLibrary.Entities;

namespace DevTest
{
    class Program
    {
        /// <summary>
        /// The main program will instantiate the ServiceHost based on the WebLibrary project.
        /// The configuration for the service may be found under the app.config project file
        /// </summary>
        /// <param name="args">Arguments have not been catered for</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Dev Test Web Service Host");
            Console.WriteLine(".........................");

            using (ServiceHost serviceHost = new ServiceHost(typeof(RateSystem)))
            {
                serviceHost.Open();
                DisplayHostInfo(serviceHost);
                Console.WriteLine("Press q to Quit");

                bool quit = false;

                while (quit == false)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.KeyChar == 'q' || key.Key == ConsoleKey.Escape)
                    {
                        serviceHost.Close();
                        quit = true;
                    }
                }

            }

            //using (var ctx = new RatesDBContext())
            //{
            //    Employee e = new Employee() { EmployeeName = "Test", EmployeeNumber = "123456", EmployeeSurname = "test" };
            //    ctx.Employees.Add(e);
            //    ctx.SaveChanges();
            //}
        }

        private static void DisplayHostInfo(ServiceHost sHost)
        {
            Console.WriteLine("Port: {0}", sHost.BaseAddresses[0].Port);
            Console.WriteLine("Local Path: {0}", sHost.BaseAddresses[0].LocalPath);
            Console.WriteLine("Uri: {0}", sHost.BaseAddresses[0].AbsoluteUri);
            Console.WriteLine("Scheme: {0}", sHost.BaseAddresses[0].Scheme);
            Console.WriteLine("*************************************************");
        }
    }
}
