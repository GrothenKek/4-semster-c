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
            Console.WriteLine("press any number");
            String s = Console.ReadLine();
            Console.WriteLine(factorial_Recursion(Int32.Parse(s)));
            Console.WriteLine("press any Key to exit");
            Console.ReadLine();
            Console.WriteLine(  4.factorial());
            Console.ReadLine();

        }



        public static double factorial_Recursion(int number)
        {
            if (number == 1)
                return 1;
            else
                return number * factorial_Recursion(number - 1);

        }
    }


    public static class MyMathExtension
    {
        public static int factorial(this int x)
        {
            if (x <= 1) return 1;
            if (x == 2) return 2;
            else
                return x * factorial(x - 1);
        }
    }
}
