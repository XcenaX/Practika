using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace homework_9
{
    public class Basemet : IPart
    {
        public string Material { get; set; }
        public string Color { get; set; }
        public bool IsBuilded { get; set; }

        public Basemet()
        {
            Material = "";
            Color = "";
            IsBuilded = false;
        }

        public void ShowInfo()
        {
            if (IsBuilded)
            {
                WriteLine("\nЦвет фундамента: " + Color);
                WriteLine("Материал фундамента: " + Material);
            }
            else
            {
                WriteLine("\nФундамент пока не посроен!");
            }
        }

        public void InputInfo()
        {
            WriteLine("\nВведите цвет фундамента: ");
            string color = ReadLine();

            WriteLine("\nВведите материал фундамента: ");
            string material = ReadLine();

            Color = color;
            Material = material;

            IsBuilded = true;
        }

    }
}
