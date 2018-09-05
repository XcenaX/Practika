using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    class Program
    {


        static void Main(string[] args)
        {
            Train train = new Train();
            train.AddVagon(34, 25);
            train.AddVagon(12, 41);
            train.ShowInfoAboutVagons();


            Console.WriteLine("\nПока только один вагон, добавьте еще");
            int number = 0;
            bool checkError = false;
            int countOfPeople = 0;

            while (!checkError)
            {
                Console.WriteLine("Введите кол-во пассажиров: ");
                string toParse = Console.ReadLine();

                if (int.TryParse(toParse, out countOfPeople) == false)
                {
                    checkError = true;
                    Console.Clear();
                    Console.WriteLine("Вы ввели не число!");
                }


                if (!checkError)
                {
                    Console.WriteLine("Введите номер вагона: ");
                    toParse = Console.ReadLine();

                    if (int.TryParse(toParse, out number) == false)
                    {
                        checkError = true;
                        Console.Clear();
                        Console.WriteLine("Вы ввели не число!");
                    }
                }

                if (!checkError)
                {
                    try
                    {
                        train.AddVagon(number, countOfPeople);
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Вагон с таким номером уже существует!");
                        checkError = true;
                    }
                    if (!checkError) break;
                }
                checkError = false;
            }
            Console.Clear();



            int number2 = 0;
            checkError = false;

            while (!checkError)
            {
                train.ShowInfoAboutVagons();
                Console.WriteLine("\nТеперь попробуйте удалить вагон");
                Console.WriteLine("просто введите номер вагона: ");

                string toParse = Console.ReadLine();

                if (int.TryParse(toParse, out number2) == false)
                {
                    checkError = true;
                    Console.Clear();
                    Console.WriteLine("Вы ввели не число!");
                }

                if (!checkError)
                {
                    try { train.DeleteVagon(number2); }
                    catch (Exception)
                    {
                        checkError = true;
                    }
                }

                if (!checkError)
                {
                    Console.Clear();
                    Console.WriteLine("Вагон успешно удален!");
                    train.ShowInfoAboutVagons();
                    break;
                }
                checkError = false;
            }

            Console.WriteLine("\nНажмите любую кнопку !!!");
            Console.ReadKey();
            Console.Clear();


            Console.Write("Введите имя поезда: ");
            train.SetName(Console.ReadLine());

            double speed = 0;
            checkError = false;

            while (!checkError)
            {
                Console.Write("Введите скорость поезда: ");
                string toParse = Console.ReadLine();

                if(double.TryParse(toParse, out speed) == false)
                {
                    checkError = true;
                    Console.Clear();
                    Console.WriteLine("Вы ввели не число!");                
                }

                if (!checkError)
                {
                train.SetSpeed(speed);

                Console.WriteLine("\nИнформация об этом поезде");
                train.ShowInfoAboutTrain();
                train.ShowInfoAboutVagons();

                Console.ReadKey();
                    break;
                }
                checkError = false;
            }
        }
    }
}
