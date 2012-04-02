using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApplication1.Azure;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var queueClient = new QueueClient();
            while (true)
            {
                var message = queueClient.GetMessage();
                if (message != null)
                    Console.WriteLine(message);
                else
                    Thread.Sleep(5000);
            }
        }
    }
}
