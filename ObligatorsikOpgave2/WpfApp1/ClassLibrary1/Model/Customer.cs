using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Model
{
    public class Customer
    {
        [Key]
        public String Email { get; set; }


        public String Name { get; set; }

        public String Password { get; set; }


        public ICollection<Reservation> Reservations { get; set; }


     

    }
}
