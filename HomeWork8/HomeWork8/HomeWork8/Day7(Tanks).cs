using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace HomeWork8
{
    public class Day7Tanks
    {

        public static void ShowInfoTwoTanks(Tank tank1, Tank tank2)
        {
            WriteLine("\t\tБоеКомплект танка 'T-34': " + tank1.Ammunition + "\tБоеКомплект танка 'Pantera': " + tank2.Ammunition);
            WriteLine("\t\tМаневренность танка 'T-34': " + tank1.Mobility + "\tМаневренность танка 'Pantera': " + tank2.Mobility);
            WriteLine("\t\tБроня танка 'T-34': " + tank1.Armor + "\t\tБроня танка 'Pantera': " + tank2.Armor);
        }

        static void Main(string[] args)
        {

            Tank[] tank = new Tank[10];
            for(int index = 0; index < tank.Length/2; index++)
            {
                tank[index] = new Tank("T-34", index);
            }
            for(int index = tank.Length/2; index < tank.Length; index++)
            {
                tank[index] = new Tank("Pantera",index);
            }

            WriteLine("\t\tИ Всем привет и вы попали на мировой чемпионат по World Of Tanks!!!");
            WriteLine("\t\tСегодня вы увидите битву 5 на 5 между танками 'T-34' и 'Pantera'!!!");

            Write("\n\n\n\n\nНажмите любую кнопку...");
            ReadKey();
            Clear();

            WriteLine("\n\n\t\t\tИнформация об участниках 'T-34'");
            for (int index = 0; index < tank.Length / 2; index++)
            {
                tank[index].ShowInfo();
                WriteLine();
            }

            Write("\n\n\n\n\nНажмите любую кнопку...");
            ReadKey();
            Clear();

            WriteLine("\n\n\t\t\tИнформация об участниках 'Pantera'");
            for (int index = tank.Length/2; index < tank.Length; index++)
            {
                tank[index].ShowInfo();
                WriteLine();
            }

            Write("\n\n\n\n\nНажмите любую кнопку...");
            ReadKey();
            Clear();

            WriteLine("\t\tКак видите потенциал у каждой команды неплохой!");
            WriteLine("\t\tЧтоже, давайте начнем!!!\n\n");

            int i = 0;
            while (i < tank.Length / 2)
            {
                WriteLine("\t\t\tБой №" + (i+1));
                ShowInfoTwoTanks(tank[i], tank[tank.Length/2 + i]);

                i++;

                Write("\n\n\n\n\nНажмите любую кнопку...");
                ReadKey();
                Clear();
                WriteLine("\n\n\t\t\tЕСТЬ ПРОБИТИЕ!!!");
                WriteLine("\t\tПобедил танк " + (tank[i]*tank[tank.Length/2-1+i]).Name);

                Write("\n\n\n\n\nНажмите любую кнопку...");
                ReadKey();
                Clear();
            }

            Clear();
            WriteLine("Это была блистательная игра, всем удачи, всем пока!!!");
            ReadKey();

        }
    }
}
