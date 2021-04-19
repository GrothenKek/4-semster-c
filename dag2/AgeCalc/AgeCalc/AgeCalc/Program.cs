using System;

namespace AgeCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            String year = "";
            Console.WriteLine("Enter your birthyear: ");
            
            year = Console.ReadLine();


            int currentYear = DateTime.Now.Year;

            Console.WriteLine(currentYear - int.Parse(year));


        }
    }
}
