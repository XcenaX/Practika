using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace homework_9
{
    public class Window : IPart
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public string Material { get; set; }
        public string Color { get; set; }
        public bool IsBuilded { get; set; }

        public Window()
        {
            Width = 0;
            Height = 0;
            Material = "";
            Color = "";
            IsBuilded = false;
        }

        public void ShowInfo()
        {
            WriteLine("\nЦвет окон: " + Color);
            WriteLine("Ширина окон: " + Width);
            WriteLine("Высота окон: " + Height);
            WriteLine("Материал окон: " + Material);
        }
    }
}
