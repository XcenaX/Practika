using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace homework_9
{
    public class Roof : IPart
    {
        public string Material { get; set; }
        public string Color { get; set; }
        public bool IsBuilded { get; set; }

        public Roof()
        {
            Material = "";
            Color = "";
            IsBuilded = false;
        }

        public void ShowInfo()
        {
            if (IsBuilded)
            {
                WriteLine("\nЦвет крыши: " + Color);
                WriteLine("Материал крыши: " + Material);
            }
            else
            {
                WriteLine("\nКрыша пока не посроенa!");
            }
        }

        public void InputInfo()
        {
            WriteLine("\nВведите цвет крыши: ");
            string color = ReadLine();

            WriteLine("\nВведите материал крыши: ");
            string material = ReadLine();

            Color = color;
            Material = material;

            IsBuilded = true;
        }

    }
}
