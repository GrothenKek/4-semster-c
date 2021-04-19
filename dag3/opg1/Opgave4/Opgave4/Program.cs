using System;

namespace Opgave4
{
    class Program
    {
        



        static void Main(string[] args)
        {
            Time t1, t2;
            t1 = new Time("01:23:20");
            Console.WriteLine(t1.SFM());
            t2 = t1;
            t2.Hour = t2.Hour + 2;
            Console.WriteLine(t1.ToString());
            Console.WriteLine(t2.ToString());


        }

        struct Time
        {
            public int Hour;
            public int minute;
            public int seconds;

             public int SFM()
            {
                return (Hour * 60 * 60) + (minute * 60) + seconds;
            }

            public Time(string tid)
            {
                
                    this.Hour = Int32.Parse(tid.Substring(0, 2));
                    this.minute = Int32.Parse(tid.Substring(3, 2));
                    this.seconds = Int32.Parse(tid.Substring(6, 2));
            }

            public Time(int hour, int minute, int seconds)
            {
                this.Hour = hour;
                this.minute = minute;
                this.seconds = seconds;

            }
            public override string ToString() {
               

               string test = Hour.ToString()+":"+minute.ToString()+":"+seconds.ToString();


                return test;
            }







        }
    }
}
