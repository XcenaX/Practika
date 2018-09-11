using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HomeWork7
{
    class Program
    {
        static void Main(string[] args)
        {
            RangeOfArray rangeOfArray = new RangeOfArray();
            rangeOfArray.Input();
            rangeOfArray.ForProgram();

            Clear();
            WriteLine("Вот ваш массив:");
            rangeOfArray.PrintArray();

            ReadKey();
        }
    }
}
