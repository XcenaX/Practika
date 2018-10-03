using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ControlWork
{
    public interface IPerson
    {
         string FIO { get; set; }
         int Age { get; set; }         
    }
}
