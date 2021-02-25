using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.Net.Http;
using System.Net.Http.Headers;

namespace WcfServiceLibraryOpapLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

                

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        

        public double Add(double n1, double n2)
        {
            throw new NotImplementedException();
        }

        public string GetOpapData(string data) {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/sotos");
            // Add an Accept header for JSON format.    
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // List all Names.    
          /*  HttpResponseMessage response = client.GetAsync("https://api.opap.gr/draws/v3.0/5104/last/50").Result;*/  // Blocking call!   
            HttpResponseMessage response = client.GetAsync("http://www.contoso.com/").Result;
            if (response.IsSuccessStatusCode)
            {
                string products = response.Content.ReadAsStringAsync().Result;
                return products.Substring(0,1000);
                Console.WriteLine("response success");
            }
            else
            {
                 Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                Console.WriteLine("response fails");
                return "false";
            }
        }


        HttpClient client = new HttpClient();

       public async void Connection()
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
               // HttpResponseMessage response = await client.GetAsync("http://www.contoso.com/");
              //  response.EnsureSuccessStatusCode();
               // string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                 string responseBody = await client.GetStringAsync("http://www.contoso.com/");
                Console.WriteLine("It works");
                Console.WriteLine(responseBody.ToString());
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

        }


    }
}
