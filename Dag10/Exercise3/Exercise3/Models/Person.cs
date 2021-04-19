using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Exercise3.Models {
    public class Person {

        public Person(string data) {
            // Id, Name, Age, Weight, Score, Accepted
            var L = data.Split(';');

            Id = int.Parse(L[0]);
            Name = L[1];
            Age = int.Parse(L[2]);
            Weight = int.Parse(L[3]);
            Score = int.Parse(L[4]);
            Accepted = bool.Parse(L[5]);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public int Score { get; set; }
        public bool Accepted { get; set; }

        public override string ToString() {
            return String.Format("ID = {0,-10}, Name = {1,-10} : {2,4} points, {3,4} years, {4,4} kg, {5,10}Accepted",
                Id, Name, Score, Age, Weight,Accepted?"":"NOT ");
        }

        public static List<Person> ReadCSVFile(string filename) {
            List<Person> list = new List<Person>();
            using (var file = new StreamReader(filename)) {
                string line;
                while ((line = file.ReadLine()) != null) {
                    var p = new Person(line);
                    list.Add(p);
                    //Console.WriteLine(p);
                }
            }
            return list;
        }

        public class SortByAge : IComparer<Person> {
            public int Compare(Person x, Person y) {
                return x.Age.CompareTo(y.Age);
            }
        }
        public class SortByScore : IComparer<Person> {
            public int Compare(Person x, Person y) {
                return x.Score.CompareTo(y.Score);
            }
        }
        public class SortByWeight : IComparer<Person> {
            public int Compare(Person x, Person y) {
                return x.Weight.CompareTo(y.Weight);
            }
        }
        public class SortByName : IComparer<Person> {
            public int Compare(Person x, Person y) {
                return x.Name.CompareTo(y.Name);
            }
        }
        public class SortByAgeDistance : IComparer<Person> {
            private double age;
            public SortByAgeDistance(double age) {
                this.age = age;
            }
            public int Compare(Person x, Person y) {
                double xdist = Math.Abs(x.Age - age);
                double ydist = Math.Abs(y.Age - age);
                return xdist.CompareTo(ydist);
            }
        }
        public class SortByWeightAgeLength : IComparer<Person> {
            public int Compare(Person x, Person y) {
                double xval = Math.Sqrt(x.Weight * x.Weight + x.Age * x.Age);
                double yval = Math.Sqrt(y.Weight * y.Weight + y.Age * y.Age);
                return xval.CompareTo(yval);
            }
        }
    }


}