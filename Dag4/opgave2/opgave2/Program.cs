using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opgave2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(powerOf(2, 2));
            Console.ReadLine();
            Console.WriteLine(4.powerOf(4));
            Console.ReadLine();
        }

        public static double powerOf(int n, int p)
        {
            if (p == 0)
            {
                return 1;
            }
            if (p == 1)
            {
                return n;
            }
            return n * powerOf(n, p - 1);


        }


    }
    public static class PowerExtension
    {
        public static double powerOf(this int n, int p)
        {
            if (p == 0)
            {
                return 1;
            }
            if (p == 1)
            {
                return n;
            }
            return n * n.powerOf(p-1);

        }
    }
    
}
