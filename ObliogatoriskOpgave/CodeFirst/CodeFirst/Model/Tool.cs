using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Model
{


    public class Tool
    {


        [Key]
        public int ToolId { get; set; }
        public String Name { get; set; }

        public String Description { get; set; }

        public Status.StatusEnum Status { get; set; }

        public double PricePrDay { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
