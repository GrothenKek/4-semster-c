using ConsoleApp1.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            CalculatorSoapClient csc = new CalculatorSoapClient();


            int sum = csc.Add(1, 3);
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
