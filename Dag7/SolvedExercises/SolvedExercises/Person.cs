using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvedExercises {

    public class Person : INotifyPropertyChanged {

        public Person(string data) {
            // Name, Age, Weight, Score, Accepted
            var L = data.Split(';');

            Name = L[0];
            Age = int.Parse(L[1]);
            Weight = int.Parse(L[2]);
            Score = int.Parse(L[3]);
            Accepted = bool.Parse(L[4]);
        }

        private string name;
        public string Name {
            get { return name; }
            set { name = value; NotifyPropertyChanged(nameof(Name)); }
        }

        private int age;
        public int Age {
            get { return age; }
            set { age = value; NotifyPropertyChanged(nameof(Age)); }
        }

        private int weight;
        public int Weight {
            get { return weight; }
            set { weight = value; NotifyPropertyChanged(nameof(Weight)); }
        }

        private int score;
        public int Score {
            get { return score; }
            set {
                if (value < 0 || value > 10)
                    return;
                score = value; NotifyPropertyChanged(nameof(Score));
            }
        }

        private bool accepted;
        public bool Accepted {
            get { return accepted; }
            set { accepted = value; NotifyPropertyChanged(nameof(Accepted)); }
        }

        public override string ToString() {
            return String.Format("{0,-10} : {1,4} points, {2,4} years, {3,4} kg, {4,4} Accepted", Name, Score, Age, Weight, Accepted ? "" : "NOT");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public static List<Person> ReadCSVFile(string filename) {
            List<Person> list = new List<Person>();
            using (var file = new StreamReader(filename)) {
                string line;
                while ((line = file.ReadLine()) != null) {
                    var p = new Person(line);
                    list.Add(p);
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

        public static ObservableCollection<Person> GetPeople() {
            var list = new ObservableCollection<Person>()
            {
                new Person("Saul;60;63;7;false"),
                new Person("Mel;9;117;5;false"),
                new Person("Preston;50;100;10;false"),
                new Person("Evan;23;28;2;false"),
                new Person("Alison;24;93;4;false"),
                new Person("Nikia;90;110;7;false"),
                new Person("Micheal;15;10;10;false"),
                new Person("Brittany;21;83;8;false"),
                new Person("Ward;18;17;2;false"),
                new Person("Elmo;46;105;5;false"),
                new Person("Bertram;60;88;6;false"),
                new Person("Cristin;31;86;7;false"),
                new Person("Monroe;12;49;2;false"),
                new Person("Aundrea;16;42;3;false"),
                new Person("Ayanna;67;60;10;false"),
                new Person("Lucio;51;102;1;false"),
                new Person("Armando;93;105;3;false"),
                new Person("Audrie;56;42;5;false"),
                new Person("Mirtha;56;45;7;false"),
                new Person("Voncile;20;28;0;false"),
                new Person("Chae;80;13;0;false"),
                new Person("Halina;97;71;7;false"),
                new Person("Alex;13;42;5;false"),
                new Person("Adan;99;100;5;false"),
                new Person("Natashia;18;92;9;false"),
                new Person("Forrest;66;102;2;false"),
                new Person("Taina;9;96;9;false"),
                new Person("Simon;83;75;10;false"),
                new Person("Kory;46;82;8;false"),
                new Person("Tinisha;65;89;9;false"),
                new Person("Denny;38;116;2;false"),
                new Person("Harriette;52;67;9;false"),
                new Person("Conrad;14;114;2;false"),
                new Person("Jeanie;65;72;4;false"),
                new Person("Mose;5;79;4;false"),
                new Person("Stefan;77;47;9;false"),
                new Person("Wade;69;7;7;false"),
                new Person("Andrew;43;77;2;false"),
                new Person("Shameka;35;82;4;false"),
                new Person("Kenna;22;87;3;false"),
                new Person("Columbus;85;101;3;false"),
                new Person("Denna;98;94;4;false"),
                new Person("Stephanie;38;77;9;false"),
                new Person("Rigoberto;78;90;8;false"),
                new Person("Jamila;87;5;9;false"),
                new Person("Seymour;48;58;9;false"),
                new Person("Warner;31;19;2;false"),
                new Person("Tommie;99;104;4;false"),
                new Person("Emma;17;51;8;false"),
                new Person("Tim;70;71;8;false"),
                new Person("Marhta;75;34;5;false"),
                new Person("Joshua;21;13;7;false"),
                new Person("Luigi;9;84;3;false"),
                new Person("Vito;58;14;8;false"),
                new Person("Marquis;59;7;3;false"),
                new Person("Kaci;29;6;6;false"),
                new Person("Necole;18;108;4;false"),
                new Person("Samella;25;69;2;false"),
                new Person("Hang;82;64;9;false"),
                new Person("Asuncion;30;99;0;false"),
                new Person("Enoch;83;119;6;false"),
                new Person("Andreas;90;120;1;false"),
                new Person("Doyle;21;75;7;false"),
                new Person("Loree;66;52;0;false"),
                new Person("Trudie;55;86;6;false"),
                new Person("Jon;52;104;2;false"),
                new Person("Chantay;59;6;9;false"),
                new Person("Gwenda;15;37;5;false"),
                new Person("Piper;50;56;2;false"),
                new Person("Sabine;5;44;4;false"),
                new Person("Saturnina;67;62;1;false"),
                new Person("Dovie;81;35;9;false"),
                new Person("Nick;1;74;7;false"),
                new Person("Roxanne;86;82;3;false"),
                new Person("Francisco;88;23;10;false"),
                new Person("Galina;89;34;3;false"),
                new Person("Shirley;100;81;8;false"),
                new Person("Nada;71;113;2;false"),
                new Person("Jamee;64;66;0;false"),
                new Person("Tona;35;103;5;false"),
                new Person("Valencia;77;30;10;false"),
                new Person("Gavin;63;93;0;false"),
                new Person("Jean;20;120;9;false"),
                new Person("Darrel;28;11;10;false"),
                new Person("Boris;3;94;0;false"),
                new Person("Alverta;85;12;5;false"),
                new Person("Otto;71;24;8;false"),
                new Person("Hermelinda;81;118;0;false"),
                new Person("Jeffrey;78;45;6;false"),
                new Person("Lon;13;120;5;false"),
                new Person("Stuart;73;101;8;false"),
                new Person("Marcel;1;8;4;false"),
                new Person("Zita;100;59;5;false"),
                new Person("Damion;48;40;4;false"),
                new Person("Dona;54;109;4;false"),
                new Person("Elli;57;68;5;false"),
                new Person("Luther;86;76;4;false"),
                new Person("Alica;61;31;2;false"),
                new Person("Aletha;37;63;3;false"),
                new Person("Amina;41;105;7;false"),
            };
            return list;
        }
    }



}
