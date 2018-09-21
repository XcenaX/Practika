using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace homework_9
{


    public class Program
    {
     
        public static void PrintMenu()
        {
            WriteLine("Это программа по постройке дома!\nВы можете использовать действия, которые нписаны ниже!\n");
            WriteLine("1) Пустить нового бригадира работать");
            WriteLine("2) Приказать лидеру составить отчет о постройке");
            WriteLine("3) Вывести информации о запланированном доме");
        }

        public static bool Choose(char select, Team team, House futureHouse)
        {
            switch (select)
            {
                case '1':
                    Clear();
                    team.worker.Build(team.house, futureHouse);
                    ReadKey();
                    Clear();
                    break;
                case '2':
                    Clear();
                    if(!team.house.IsBuilded)
                    {
                    team.house.ShowInfoAboutHouse();
                    Write("\n\nНажмите любую кнопку...");
                    }
                    else
                    {
                        WriteLine("Постройка дома завершена! Ураааа! С вас 1 000 000 рублей");
                        WriteLine("Нажмите любую кнопку чтобы сбежать и не платить ...");
                        ReadKey();
                        return false;
                    }
                    ReadKey();
                    Clear();
                    break;
                case '3':
                    Clear();
                    futureHouse.ShowInfoAboutHouse();
                    Write("\n\nНажмите любую кнопку...");
                    ReadKey();
                    Clear();
                    break;
                default:
                    Clear();
                    break;
            }
            return true;
        }

        static void Main(string[] args)
        {
            Team team = new Team();
            House futureHouse = new House(), house = new House();

            //ввод данных
            futureHouse.InputInfoWalls();
            Clear();
            futureHouse.InputInfoDoors();
            Clear();
            futureHouse.InputInfoWindows();
            Clear();
            futureHouse.roof.InputInfo();
            Clear();
            futureHouse.basemet.InputInfo();
            Clear();

            bool checkEnd = false;

            while (true)
            {
                PrintMenu();
                char select = ReadKey().KeyChar;
               checkEnd = Choose(select, team, futureHouse);
                if (!checkEnd) break; 
                Clear();
            }
            
        }
    }
}
