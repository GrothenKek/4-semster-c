using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Model
{
   public class Status
    {
        StatusEnum StatusE { get; set; }


        public enum StatusEnum
        {
            available,
            NotAvailable

        }
    }
}
