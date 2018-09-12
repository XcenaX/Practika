using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HomeWork8
{
    public class Tank
    {
        public string Name { get; set; }
        public int Ammunition { get; set; }
        public int Armor { get; set; }
        public int Mobility { get; set; }

        public Tank(string Name, int index)
        {
            Random random = new Random(index);
            this.Name = Name;
            Ammunition = random.Next(100);
            Armor = random.Next(100);
            Mobility = random.Next(100);
        }

        public static Tank operator *(Tank tank1, Tank tank2)
        {
            int counter = 0;
            if (tank1.Armor > tank2.Armor) counter++;
            if (tank1.Mobility > tank2.Mobility) counter++;
            if (tank1.Ammunition > tank2.Ammunition) counter++;
            if (counter >= 2) return tank1;
            return tank2;
        }

        public void ShowInfo()
        {                        
            WriteLine("БоеКомплект танка: " + Ammunition);
            WriteLine("Маневренность танка: " + Mobility);
            WriteLine("Броня танка: " + Armor);
        }

    }
}