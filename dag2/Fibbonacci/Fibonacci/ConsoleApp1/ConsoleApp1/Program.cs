using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class calculator
    {
        public static void Fibonacci(int uLimit)    
        {
            int n1 = 0, n2 = 1, n3, i;
            for (i = 2; i < uLimit; i++)
            {
                n3 = n1 + n2;
                Console.WriteLine(n3);
                n1 = n2;
                n2 = n3;
            }
            


        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            Console.WriteLine("Fibbonacci in C#\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                String limit = "";
                int res = 0;
                
                Console.Write("Enter the upper limit: ");
                limit = Console.ReadLine();
                if (limit  == "0") endApp = true;


                int cleanLimit = 0;
                while (!int.TryParse(limit, out cleanLimit))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    limit = Console.ReadLine();
                }
               
                try
                {
                    int Ulimit = int.Parse(limit);
                    calculator.Fibonacci(Ulimit);
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("exception \n - Details: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                Console.Write("Press '0' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "0") endApp = true;

                Console.WriteLine("\n"); // Friendly linespacing.

            }
            return;


        }
    }
}
