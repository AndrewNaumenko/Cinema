using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema
{
    public class registrationclass
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public registrationclass(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public registrationclass()
        { }
    }
}
