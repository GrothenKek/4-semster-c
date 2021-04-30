using System;
using WcfServiceAndClientTest;
using System.Web.Script.Serialization;

namespace WcfClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Step 1: Create an instance of the WCF proxy.
            Service1Client client = new Service1Client();

            // Step 2: Call the service operations.
            int intParameter = 3;
            string stringResult = client.GetData(intParameter);
            Console.WriteLine("client.GetData({0}) = {1}", intParameter, stringResult);

            // Step 3: Call the service operations.
            var json = new JavaScriptSerializer();
            CompositeType compositeParameter = new CompositeType() { BoolValue = true, StringValue = "Hello World!!!"};
            CompositeType compositeResult = client.GetDataUsingDataContract(compositeParameter);
            Console.WriteLine("client.GetData({0}) = {1}", json.Serialize(compositeParameter), json.Serialize(compositeResult));

            // Step 4: Close service connection and application.
            client.Close();
            Console.WriteLine("Enter any key to exit.");
            Console.ReadKey();
        }
    }
}
