using DatabaseFirst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DBFirst");

            using (var ctx = new StudentsGradesEntities())
            {

              var students =  ctx.Students.ToList();
                foreach(Students s in students)
                {
                    Console.WriteLine();
                    Console.WriteLine(s.Name);
                    var grades = s.Grades.ToList();
                    foreach(Grades g in grades)
                    {
                        Console.WriteLine($"{g.Course} : {g.Grade}");
                    }

                }

            }



            Console.ReadKey();

        }
    }
}
