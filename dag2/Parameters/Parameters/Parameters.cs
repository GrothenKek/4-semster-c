using System;

namespace Parameters
{
    class Parameters
    {
        static void standardParam(int a)
        {
            a += 1;
        }
        static void inParam(in int a)
        {
            // a = a + 1; // <-illegal assignment of readonly variable!
        }
        static void outParam(out int a)
        {
            a = 0;
            // a = a + 1; // <-illegal use of unassigned out!
        }
        static void refParam(ref int a)
        {
            a += 1;
        }
        static void Main(string[] args)
        {
            int xStandard = 12;
            standardParam(xStandard);
            Console.WriteLine(xStandard);

            int xIn = 12; 
            inParam(xIn);
            Console.WriteLine(xIn);

            int xOut = 12;
            outParam(out xOut);
            Console.WriteLine(xOut);

            int xRef = 12;
            refParam(ref xRef);
            Console.WriteLine(xRef);

            Console.ReadKey();
        }
    }
}
