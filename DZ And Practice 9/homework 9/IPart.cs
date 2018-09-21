using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_9
{
   public interface IPart
    {
        string Color { get; set; }
        string Material { get; set; }
         bool IsBuilded { get; set; }
    }
}
