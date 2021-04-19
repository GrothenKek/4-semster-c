using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestConsoleApp
{
    class FractionCalculator
    {

        public class Fraction{
            int Numerator;
            int Denominator;


            

           public Fraction(int numerator, int denominator)
            {
                if(denominator== 0)
                {
                    throw new ArgumentException();
                }
                else
                {
                    Numerator = numerator;
                    Denominator = denominator;
                }

            }

            public int Denominator1 { get => Denominator; set => Denominator = value; }
            public int Numerator1 { get => Numerator; set => Numerator = value; }
        }






        public Fraction Add(Fraction a, Fraction b)
        {
            int A = a.Numerator1;
            int B = a.Denominator1;
            int C = b.Numerator1;
            int D = b.Denominator1;
            int Num = (A * D) + (B * C);
            int Denum = (B * D);
            return  new Fraction(Num,Denum);
        }

        public Fraction substract(Fraction a, Fraction b)
        {
            int A = a.Numerator1;
            int B = a.Denominator1;
            int C = b.Numerator1;
            int D = b.Denominator1;
            int Num = ((A * D) - (B * C));
            int Denum = (B * D);
            return new Fraction(Num, Denum);
        }

        public Fraction div(Fraction a, Fraction b)
        {
            int A = a.Numerator1;
            int B = a.Denominator1;
            int C = b.Numerator1;
            int D = b.Denominator1;
            int Num = (A * C) ;
            int Denum = (B * D);
            return new Fraction(Num, Denum);
        }

        public Fraction mul(Fraction a, Fraction b)
        {
            int A = a.Numerator1;
            int B = a.Denominator1;
            int C = b.Numerator1;
            int D = b.Denominator1;
            int Num = (A * D);
            int Denum = (B * C);
            return new Fraction(Num, Denum);
        }



    }
}
