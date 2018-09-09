using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Practice_ULTRA
{
   public abstract class Storage
    {
        public string Name { get; set; }
        public string Model { get; set; }

        public abstract double GetMemory();

        public abstract void CopyMemory(Computer computer);

        public abstract double GetFreeMemory();

        public abstract void ShowInfo();
        
    }
}
