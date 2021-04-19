using System;

namespace RandomNum
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            Console.WriteLine("Five random integers between 0 and 100:");
            for (int ctr = 0; ctr <= 4; ctr++)
                Console.Write("{0,8:N0}", rand.Next(101));
            Console.WriteLine();

        }
    }
}
