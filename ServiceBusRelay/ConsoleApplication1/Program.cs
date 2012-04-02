using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Service;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(ProductsService));

            host.Open();

            Console.WriteLine("Press ENTER to close");
            Console.ReadLine();
            
            host.Close();
        }
    }
}
