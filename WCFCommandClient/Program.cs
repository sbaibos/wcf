using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFCommandClient.ServiceReference1;




namespace WCFCommandClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1Client client = new Service1Client();
            Console.WriteLine(client.Endpoint.ToString());
            Console.WriteLine("test");

            Console.ReadKey();
          
        }
    }
}
