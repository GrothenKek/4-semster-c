using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace øvelse3_palidrom
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsPaldidrom("abba"));
            Console.ReadLine();
            Console.WriteLine("16061".IsPaldidrom());
            Console.ReadLine();

        }


        public static bool IsPaldidrom(String text)
        {
            if (text.Length <= 1)
                return true;

            else
            {
                if (text[0] != text[text.Length - 1])
                    return false;

                else return IsPaldidrom(text.Substring(1, text.Length - 2));
            }
        }


    }
    public static class palidromextension {
        public static bool IsPaldidrom(this String text)
        {
            if (text.Length <= 1)
                return true;

            else
            {
                if (text[0] != text[text.Length - 1])
                    return false;

                else return text.Substring(1, text.Length - 2).IsPaldidrom();

            }





        }
    }
    
}
