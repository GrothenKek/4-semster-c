using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst.viewModels
{
    public class ValidateCustomer
    {
        public static bool IsCustomerValid()
        {
            HttpContext ctx = HttpContext.Current;
            if (ctx.Session["email"] != null)
            {
                return true;
            }
            else return false;
        }
    }
}