using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.ViewModel
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }


        public LoginModel( string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
        public LoginModel()
        {

        }
    }
}
