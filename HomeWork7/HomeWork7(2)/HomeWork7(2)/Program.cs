using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HomeWork7_2_
{
    class Program
    {
        static void Main(string[] args)
        {
            Indexator indexator = new Indexator();
            indexator[0] = 5;
            WriteLine(indexator[0]);
        }
    }
}
    

