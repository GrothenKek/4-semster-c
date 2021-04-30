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

            Console.WriteLine("enter your guess");
            string guess = Console.ReadLine();
            string res = client.GetData(int.Parse(guess));
            Console.WriteLine(res);


            // Step 4: Close service connection and application.
            client.Close();
            Console.WriteLine("Enter any key to exit.");
            Console.ReadKey();
        }
    }
}
