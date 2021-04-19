using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Model
{
   public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ResStatus StorageStatus { get; set; }



        public int ToolId { get; set; }
        public virtual Tool Tool { get; set; }

        public int Price { get; set; }
        public string CustomerId { get; set; }
        public virtual Customer Customer { get; set; }



    }

    public enum ResStatus
    {
        Reserved,
        Consigned,
        Returned

    }
}

