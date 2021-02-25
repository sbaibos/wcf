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

        // client.Connection();

          // client.GetOpapData();

            string STR = client.GetOpapData("data");
            Console.WriteLine("The string is: {0}", STR);
            Console.WriteLine("All done!");

           

            Console.ReadKey();

            client.Close();
          
        }
    }
}
