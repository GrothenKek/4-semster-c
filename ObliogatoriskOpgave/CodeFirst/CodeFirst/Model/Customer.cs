using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Model
{

  
    public class Customer
    {



        [Key]
        public String Email { get; set; }


        public String Name { get; set; }
       
        public String Password { get; set; }
        
        
        public ICollection<Reservation> Reservations { get; set; }


       public void AddRes (Reservation r)
        {
            Reservations.Add(r);
            
        }


    }
}
