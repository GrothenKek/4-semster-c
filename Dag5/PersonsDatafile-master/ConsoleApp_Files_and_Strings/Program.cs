using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp_Files_and_Strings
{

    public delegate int ComparePeopleDelegate(Person p1, Person p2);
    public delegate bool Predicate<in Person>(Person obj);
    public delegate UpdatePeople Func<in T, out UpdatePeople>(T arg);

    public class Person {
        public Person(string name, int age, double weight,int score) {
            Name = name;
            Age = age;
            Weight = weight;
            Score = score;
            Accepted = true;

        }
        public string Name { get; set; }
        public int    Age { get; set; }
        public double Weight { get; set; }
        public int Score { get; set; }
        public bool Accepted { get; set; }

        public override string ToString() {
            return $"{Name};{Age};{Weight};{Score}";
        }
    }
    public class ComparePeople : IComparer<Person> {

        private ComparePeopleDelegate comparisonMethod;

        public ComparePeople(ComparePeopleDelegate comparer)
        {
            comparisonMethod = comparer;
        }

        public int Compare(Person x, Person y) {
            return comparisonMethod(x,y);
        }
    }


    
    
    


    class Program {

       static bool Below2(Person x)
        {
            if (x.Score < 2)
            {
                return true;
            }
            else return false;
        }

        static bool evenSteven(Person x)
        {
            if (x.Score %2 == 0)
            {
                return true;
            }
            else return false;
        }


        static bool WnS(Person x)
        {
            if (x.Score % 2 == 0 && x.Weight > 60)
            {
                return true;
            }
            else return false;
        }

        static bool u3(Person x)
        {
            if (x.Score == 4)
            {
                return true;
            }
            else return false;
        }

        public static List<string> ReadFileLines(string filename) {
            List<string> result = new List<string>();
            using (var file = new StreamReader(filename)) {
                string line;
                while ((line = file.ReadLine()) != null) {
                    result.Add(line);
                }
            }
            return result;
        }
        public static List<Person> ReadCSVFile(string filename)
        {
            List<Person> personList = new List<Person>();
            List<string> fileLines = ReadFileLines(filename);
            foreach (string line in fileLines)
            {
                string[] fieldValues = line.Split(';');
                string name = fieldValues[0];
                int age = int.Parse(fieldValues[1]);
                int weight = int.Parse(fieldValues[2]);
                int score = int.Parse(fieldValues[3]);
                personList.Add(new Person(name, age, weight,score));
            }

            return personList;
        }



        




        static void Main(string[] args) {
            // Read all people from file
            List<Person> people = ReadCSVFile("../../data.csv");
           
            // Sort using lambda expression
            ComparePeople comparerObj = new ComparePeople((Person a, Person b) => a.Name.CompareTo(b.Name));
            people.Sort(comparerObj);





            var s= from p in people
                    where p.Accepted
                    orderby p.Score
                    select p.Name;

            Console.WriteLine(s.ToString());

               




             //people = people.FindAll(Below2);
             //people = people.FindAll(evenSteven);
             //people = people.FindAll(WnS);

            Console.WriteLine(people.FindIndex(u3));
            
            

            // Output result
          //  foreach (var p in people)
          //  {
          //      Console.WriteLine(p);
          //  }
          //  Console.WriteLine("Number of people in data file : " + people.Count);
            Console.ReadKey();
        }
    }
}
