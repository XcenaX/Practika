using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace homework_9
{
   public class House
    {
        public Roof roof { get; set; }
        private Window[] windows;
        private Door[] doors;
        private Wall[] walls;
        public Basemet basemet { get; set; }
        public bool IsBuilded { get; set; }
        

        public House()
        {
            roof = new Roof();
            windows = new Window[0];
            doors = new Door[0];
            walls = new Wall[0];
            basemet = new Basemet();
            IsBuilded = false;
        }

        public void ShowInfoAboutHouse()
        {
            WriteLine("\n\t\tФундент:");
            basemet.ShowInfo();

            WriteLine("\n\t\tКрыша:");
            roof.ShowInfo();

            WriteLine("\n\t\tОкна:");
            ShowInfoWindows();

            WriteLine("\n\t\tДвери:");
            ShowInfoDoors();

            WriteLine("\n\t\tСтены:");
            ShowInfoWalls();            

        }

       

        public Window[] GetWindows()
        {
            return windows;
        }

        public Wall[] GetWall()
        {
            return walls;
        }

        public Door[] GetDoor()
        {
            return doors;
        }

        public void ShowInfoWindows()
        {
            if(windows.Length == 0)
            {
                WriteLine("\nОкон пока нет!");
                return;
            }
            windows[0].ShowInfo();
            WriteLine("Кол-во окон: " + windows.Length);
        }

        public void ShowInfoWalls()
        {
            if (walls.Length == 0)
            {
                WriteLine("\nСтен пока нет!");
                return;
            }
            walls[0].ShowInfo();
            WriteLine("Кол-во стен: " + walls.Length);
        }

        public void ShowInfoDoors()
        {
            if (doors.Length == 0)
            {
                WriteLine("\nДверей пока нет!");
                return;
            }
            doors[0].ShowInfo();
            WriteLine("Кол-во дверей: " + doors.Length);
        }

        public void AddRoof(string material, string color, double width, double height)
        {
            roof = new Roof
            {
                Color = color,
                Material = material
            };
        }

        public void AddBasement(string material, string color)
        {
            basemet = new Basemet
            {
                Material = material,
                Color = color
            };
        }

        public void AddDoor(string color, double width, double height, string material)
        {
            Array.Resize(ref doors, doors.Length+1);
            doors[doors.Length - 1] = new Door
            {
                Color = color,
                Width = width,
                Height = height,
                Material = material
            };
        }

        public void AddWindow(double width, double height, string material, string color)
        {
            Array.Resize(ref windows, windows.Length+1);
            windows[windows.Length - 1] = new Window
            {
                Width = width,
                Height = height,
                Material = material,
                Color = color
            };
        }

        public void AddWall(string color, double width, double height, string material)
        {
            Array.Resize(ref walls, walls.Length + 1);
            walls[walls.Length - 1] = new Wall
            {
                Color = color,
                Width = width,
                Height = height,
                Material = material
            };
        }

        public void DeleteRoof()
        {
            roof = new Roof();
        }

        public void DeleteWindwow(int index)
        {
            for(int i = index; i< windows.Length - 1; i++)
            {
                windows[i] = windows[i + 1];
            }
            Array.Resize(ref windows, windows.Length-1);
        }

        public void DeleteWall(int index)
        {
            for (int i = index; i < walls.Length - 1; i++)
            {
                walls[i] = walls[i + 1];
            }
            Array.Resize(ref walls, walls.Length - 1);
        }

        public void DeleteBasement()
        {
            basemet = new Basemet();
        }

        public void DeleteDoor(int index)
        {
            for (int i = index; i < doors.Length - 1; i++)
            {
                doors[i] = doors[i + 1];
            }
            Array.Resize(ref doors, doors.Length - 1);
        }


        public void InputInfoWalls()
        {
            double height = 0, width = 0;
            int wall = 0;
            string colorOfWalls = "", materialOfWalls = "";

            bool check = false;
            while (!check)
            {
                Write("Сколько в доме будет стен? ");
                string toParse = ReadLine();

                if (!int.TryParse(toParse, out wall))
                {
                    check = true;
                    Clear();
                    WriteLine("Некорректно введены данные!");
                }

                if (!check)
                {
                    Clear();
                    while (!check)
                    {
                        Write("Введите ширину стен: ");
                        toParse = ReadLine();

                        if (!double.TryParse(toParse, out width))
                        {
                            check = true;
                            Clear();
                            WriteLine("Некорректно введены данные!");
                        }

                        if (!check)
                        {
                            Clear();
                            while (!check)
                            {
                                check = true;
                                Write("Введите высоту стен: ");
                                toParse = ReadLine();

                                if (!double.TryParse(toParse, out height))
                                {
                                    check = false;
                                    Clear();
                                    WriteLine("Некорректно введены данные!");
                                }
                            }
                            Clear();

                            Write("Введите цвет стен: ");
                            colorOfWalls = ReadLine();

                            Clear();

                            Write("Введите материал стен: ");
                            materialOfWalls = ReadLine();
                            break;
                        }

                        check = false;
                    }
                    break;
                }

                check = false;
            }
            for(int i = 0;i < wall; i++)
            {
                AddWall(colorOfWalls, width,height,materialOfWalls);
            }

        }


        public void InputInfoWindows()
        {
            double height = 0, width = 0;
            int window = 0;
            string colorOfWindow = "", materialOfWindow = "";

            bool check = false;
            while (!check)
            {
                Write("Сколько в доме будет окон? ");
                string toParse = ReadLine();

                if (!int.TryParse(toParse, out window))
                {
                    check = true;
                    Clear();
                    WriteLine("Некорректно введены данные!");
                }

                if (!check)
                {
                    Clear();
                    while (!check)
                    {
                        Write("Введите ширину окон: ");
                        toParse = ReadLine();

                        if (!double.TryParse(toParse, out width))
                        {
                            check = true;
                            Clear();
                            WriteLine("Некорректно введены данные!");
                        }

                        if (!check)
                        {
                            Clear();
                            while (!check)
                            {
                                check = true;
                                Write("Введите высоту окон: ");
                                toParse = ReadLine();

                                if (!double.TryParse(toParse, out height))
                                {
                                    check = false;
                                    Clear();
                                    WriteLine("Некорректно введены данные!");
                                }
                            }
                            Clear();

                            Write("Введите цвет окон: ");
                            colorOfWindow = ReadLine();

                            Clear();

                            Write("Введите материал окон: ");
                            materialOfWindow = ReadLine();
                            break;
                        }

                        check = false;
                    }
                    break;
                }

                check = false;
            }
            for (int i = 0; i < walls.Length; i++)
            {
                AddWindow(width,height,materialOfWindow,colorOfWindow);
            }
        }


        public void InputInfoDoors()
        {
            double height = 0, width = 0;
            int door = 0;
            string colorOfDoor = "", materialOfDoor = "";

            bool check = false;
            while (!check)
            {
                Write("Сколько в доме будет дверей? ");
                string toParse = ReadLine();

                if (!int.TryParse(toParse, out door))
                {
                    check = true;
                    Clear();
                    WriteLine("Некорректно введены данные!");
                }

                if (!check)
                {
                    Clear();
                    while (!check)
                    {
                        Write("Введите ширину дверей: ");
                        toParse = ReadLine();

                        if (!double.TryParse(toParse, out width))
                        {
                            check = true;
                            Clear();
                            WriteLine("Некорректно введены данные!");
                        }

                        if (!check)
                        {
                            Clear();
                            while (!check)
                            {
                                check = true;
                                Write("Введите высоту дверей: ");
                                toParse = ReadLine();

                                if (!double.TryParse(toParse, out height))
                                {
                                    check = false;
                                    Clear();
                                    WriteLine("Некорректно введены данные!");
                                }
                            }
                            Clear();

                            Write("Введите цвет дверей: ");
                            colorOfDoor = ReadLine();

                            Clear();

                            Write("Введите материал дверей: ");
                            materialOfDoor = ReadLine();
                            break;
                        }

                        check = false;
                    }
                    break;
                }

                check = false;
            }
            for (int i = 0; i < walls.Length; i++)
            {
                AddDoor(colorOfDoor,width, height, materialOfDoor);
            }
        }

    }
}
