using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFCommandClient.ServiceReference1;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;

//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;



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

            string STR = client.GetOpapData("https://api.opap.gr/draws/v3.0/5104/last/50");



         

            //4th way
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(CompositeType));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(STR));
            stream.Position = 0;
            CompositeType dataContractDetail = (CompositeType)jsonSerializer.ReadObject(stream);
            Console.WriteLine(string.Concat("Hi ", dataContractDetail.gameId, " " + dataContractDetail.drawId));
            Console.ReadLine();


           // Console.WriteLine("The string is: {0}", STR);
            Console.WriteLine("All done!");

           

            Console.ReadKey();

            client.Close();
          
        }
    }
}
