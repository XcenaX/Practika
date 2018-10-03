using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ControlWork
{
    public class Account
    {
        public string Password { get; set; }
        public string Login { get; set; }
        public string Phone { get; set; }   
        public int Money { get; set; }

        public Account()
        {
            Password = "";
            Login = "";
            Phone = "";
            Money = 100000;
        }

        

    }
}
