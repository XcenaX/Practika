using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ControlWork
{
    
    public class User : IPerson
    {
        public string FIO { get; set; }
        public int Age { get; set; }
        public Account account { get; set; }

        public User()
        {
            FIO = "";
            Age = 0;
            account = new Account();
        }


        

    }
}
