using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Model
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
