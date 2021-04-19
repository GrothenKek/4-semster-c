using System;

namespace Opgave6
{
    class Program
    {
        class MyClass {
            private int arg;

            public MyClass(int x)

            {
                this.arg = x;
            }

            public int Arg{
                set { arg = value; { Console.WriteLine(" was set to " + value); } }
                get { return arg; }
                }

            public override String ToString()
            {

                return arg.ToString();
            }
                
            }

        static void Main(string[] args)
        {
            var mc = new MyClass(56);
            mc.Arg = 65;
            Console.WriteLine(mc);
        }
    }
}
