using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HomeWork15
{
   public class Karta
    {
        public Lear lear { get; set; }

        public Karta()
        {
            lear = Lear.none;
        }

        public Karta(int number)
        {
            if (number <= 0)
            {
                lear = Lear.error;
            }
            else
            {
                lear = Lear.none;
            }
        }
        public string ShowLear()
        {
            switch (lear)
            {
                case Lear.six:
                    return "Шесть";
                case Lear.seven:
                    return "Семь";
                case Lear.eight:
                    return "Восемь";
                case Lear.nine:
                    return "Девять";
                case Lear.ten:
                    return "Десять";
                case Lear.man:
                    return "Валет";
                case Lear.woman:
                    return "Дама";
                case Lear.king:
                    return "Король";
                case Lear.ace:
                    return "Туз";
                default: return "";
            }
        }
        public void ShowInfo()
        {
            Write("Значение карты: "+ShowLear());   
        }
    }

    public enum Lear
    {
        six = 0,
        seven,
        eight,
        nine,
        ten,
        man,
        woman,
        king,
        ace,
        none,
        error
    }
}
