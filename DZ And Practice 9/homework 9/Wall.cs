using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace homework_9
{
    public class Wall : IPart
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public string Material { get; set; }
        public string Color { get; set; }
        public bool IsBuilded { get; set; }

        public Wall()
        {
            Width = 0;
            Height = 0;
            Material = "";
            Color = "";
            IsBuilded = false;
        }
       

        public void ShowInfo()
        {
            WriteLine("\nЦвет стен: " + Color);
            WriteLine("Ширина стен: " + Width);
            WriteLine("Высота стен: " + Height);
            WriteLine("Материал стен: " + Material);
        }

    }
}
