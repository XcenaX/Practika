using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassAccount;
using ClassBanc;
using static System.Console;

namespace ClassClient
{
    public class Client
    {
        public string FitstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public Account account { get; set; }

        public Client()
        {
            FitstName = "";
            MiddleName = "";
            LastName = "";
            PhoneNumber = "";
        }
    }
}
