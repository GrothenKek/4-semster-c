using System;

namespace ConsoleApp1
{
    class Program
    {
        public class Person
        {
            private String name;
            private String address;

            public Person(String name, String address)
            {
                this.name = name;
                this.address = address;
            }
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public string Address
            {
                get { return address; }
                set { address = value; }
            }
        }

        public class Mekaniker : Person
        {
            public int Svendeprøve;
            public double Timeløn;
            public Mekaniker(int SvendePrøve, String name, String address, double timeLøn) : base(name, address)
            {
                this.Svendeprøve = SvendePrøve;
                this.Timeløn = timeLøn;
            }

            public int SvendePrøve
            {
                get { return SvendePrøve; }
                set { SvendePrøve = value; }
            }


            public double timeLøn
            {
                get { return Timeløn; }
                set { Timeløn = value; }
            }

            public virtual double Ugeløn()
            {
                return Timeløn * 37;
            }

        }

        public class Værkførere : Mekaniker
        {
            private double tillæg;
            public Værkførere(int SvendePrøve, String name, String address, double timeLøn, double tillæg) : base(SvendePrøve, name, address, timeLøn)
            {
                this.tillæg = tillæg;

            }


            public double Tillæg
            {
                get { return tillæg; }
                set { tillæg = value; }
            }

            public override double Ugeløn()
            {
                return tillæg + (timeLøn * 37);
            }


            public class Synsmand : Mekaniker
            {
                private int AntalSyn;
                public Synsmand(int SvendePrøve, String name, String address, double timeLøn, int AntalSyn) : base(SvendePrøve, name, address, timeLøn)
                {
                    this.AntalSyn = AntalSyn;

                }


                public int Syn
                {
                    get { return AntalSyn; }
                    set { AntalSyn = value; }
                }

                public override double Ugeløn()

                {
                    return (AntalSyn * 290);



                }

                static void Main(string[] args)
                {
                    Person p1 = new Person("ole", "Vej1");
                    Console.WriteLine(p1.Name);
                    Mekaniker m1 = new Mekaniker(1997, "jens", "vej2", 200);
                    Console.WriteLine(m1.Name +" "+ m1.Ugeløn();
                    Værkførere v1 = new Værkførere(1997, "kaj", "vej3", 300, 1000);
                    Console.WriteLine(v1.Name+ " "+ v1.Ugeløn());
                    Synsmand s1 = new Synsmand(1997, "bent", "vej4", 900, 2);
                    Console.WriteLine(s1.Name + " " +  s1.Ugeløn());
                }
            }
        }
    }
}
