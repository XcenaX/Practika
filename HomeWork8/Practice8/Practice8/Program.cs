using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Practice8
{
    class Program
    {
        static void Main(string[] args)
        {
            Human human1 = new Human("Мужик", 34, "Таджик");
            Human human2 = new Human("Мужик", 34, "Таджик");

            if (human1 == human2) WriteLine("Два одинаковых человека!!");
            human1.ShowInfo();
            human2.ShowInfo();

            ReadKey();
            Clear();
        }
    }
}
