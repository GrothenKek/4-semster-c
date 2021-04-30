using System;
using System.Threading;

namespace Øvelse1
{
    public class Worker
    {

        public void work()

        {

            for (int i = 1; i <= 40; i++)

            {

                // udskriv en linje
                /* lock (this)
                 {
                     Console.Write("Output from");


                     Console.Write(Thread.CurrentThread.Name);

                     Console.Write(": " + i);

                     Console.WriteLine();
                 }
                */

                Monitor.Enter(this);
                try
                {
                    
                        Console.Write("Output from");


                        Console.Write(Thread.CurrentThread.Name);

                        Console.Write(": " + i);

                        Console.WriteLine();
                    
                }
                finally
                {
                    Monitor.Exit(this);
                }

                


            }

        }

    }
}