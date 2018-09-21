using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace homework_9
{
    public class Worker : IWorker
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Worker()
        {
            Name = "";
            Age = 0;
        }

        public void Build(House house, House futureHouse)
        {
            if (!house.basemet.IsBuilded)
            {
                house.basemet.Material = futureHouse.basemet.Material;
                house.basemet.Color = futureHouse.basemet.Color;
                WriteLine("Строитель построил фундамент!");
                WriteLine("Цвет: " + house.basemet.Color + ", Материал: " + house.basemet.Material);
                house.basemet.IsBuilded = true;
                return;
            }        
            
                if (futureHouse.GetWall().Length > house.GetWall().Length)
                {
                
                house.AddWall(
                    futureHouse.GetWall()[house.GetWall().Length].Color,
                    futureHouse.GetWall()[house.GetWall().Length].Width,
                    futureHouse.GetWall()[house.GetWall().Length].Height,
                    futureHouse.GetWall()[house.GetWall().Length].Material
                    );

                WriteLine("Строитель построил стену!");
                        WriteLine("Цвет: " + house.GetWall()[house.GetWall().Length - 1].Color);
                    WriteLine("Материал: " + house.GetWall()[house.GetWall().Length - 1].Material);
                WriteLine("Высота стены: " + house.GetWall()[house.GetWall().Length - 1].Height);
                WriteLine("Ширина стены: " + house.GetWall()[house.GetWall().Length - 1].Width);

                return;
                }

            if (futureHouse.GetWindows().Length > house.GetWindows().Length)
            {
                house.AddWindow(
                    futureHouse.GetWindows()[house.GetWindows().Length].Width,
                    futureHouse.GetWindows()[house.GetWindows().Length].Height,
                    futureHouse.GetWindows()[house.GetWindows().Length].Material,
                    futureHouse.GetWindows()[house.GetWindows().Length].Color
                    );

                WriteLine("Строитель построил окно!");
                       WriteLine("Цвет: " + house.GetWindows()[house.GetWindows().Length - 1].Color);
                   WriteLine("Материал: " + house.GetWindows()[house.GetWindows().Length - 1].Material);
                WriteLine("Высота окна: " + house.GetWindows()[house.GetWindows().Length - 1].Height);
                WriteLine("Ширина окна: " + house.GetWindows()[house.GetWindows().Length - 1].Width);
                return;
            }

            if (futureHouse.GetDoor().Length > house.GetDoor().Length)
            {
                house.AddDoor(
                    futureHouse.GetDoor()[house.GetDoor().Length ].Color,
                    futureHouse.GetDoor()[house.GetDoor().Length ].Width,
                    futureHouse.GetDoor()[house.GetDoor().Length ].Height,
                    futureHouse.GetDoor()[house.GetDoor().Length ].Material
                    );

                WriteLine("Строитель построил дверь!");
                        WriteLine("Цвет: " + house.GetDoor()[house.GetDoor().Length - 1].Color);
                    WriteLine("Материал: " + house.GetDoor()[house.GetDoor().Length - 1].Material);
                WriteLine("Высота двери: " + house.GetDoor()[house.GetDoor().Length - 1].Height);
                WriteLine("Ширина двери: " + house.GetDoor()[house.GetDoor().Length - 1].Width);
                return;
            }

            if (!house.roof.IsBuilded)
            {
                house.roof.Material = futureHouse.roof.Material;
                house.roof.Color = futureHouse.roof.Color;
                WriteLine("Строитель построил крышу!");
                WriteLine("Цвет: " + house.roof.Color + ", Материал: " + house.roof.Material);
                house.roof.IsBuilded = true;
                house.IsBuilded = true;
                return;
            }

            WriteLine("Здание Уже Построено! :)");
            
        }

    }
}
