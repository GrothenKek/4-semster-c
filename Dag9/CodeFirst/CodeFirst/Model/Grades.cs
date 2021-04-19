using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Model
{
    public class Grades
    {
        public int GradeId { get; set; }
        public int Grade { get; set; }
        public String Course { get; set; }
        public Students Student { get; set; }
    }
}
