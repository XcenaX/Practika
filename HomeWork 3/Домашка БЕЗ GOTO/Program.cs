using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication5
{
    class Program
    {
        static void PrintNumbersInLine(double Number1, double Number2, double Number3){
            Console.WriteLine(Number1 + "  " + Number2 + "  " + Number3 );
        }


        static void PrintNumbersDown(double Number1, double Number2, double Number3)
        {
            Console.WriteLine(Number1 + "\n" + Number2 + "\n" + Number3);
        }


        static void MetersInSantimeters(int Santimeters)
        { //число полных метров в сантиметрах
            const int Thousand = 1000;
            Console.WriteLine("Это " + (Santimeters / Thousand) + " метров");
        }


        static void ConvertDaysToWeeks(int Days)
        {//переводит дни в недели
            const int Days_in_Week = 7;
            Console.WriteLine("Это " + (Days / Days_in_Week) + " недель");
        }


        static void InfoAboutMultiValuedDigitNumber(int MultiDigitNumber)
        {
            const int Dozen = 10; // десяток
            int CountOfUnits = 0; // кол-во едениц
            int CopyOfTwoDigitNumber = MultiDigitNumber; // Копия входящего числа чтобы не изменять это число
            int AmountOfNumbers = 0;
            int CompositionOfNumbers = 1;
            while (CopyOfTwoDigitNumber > 0)
            {
                if (CopyOfTwoDigitNumber % Dozen == 1) { CountOfUnits++; }
                CompositionOfNumbers *= CopyOfTwoDigitNumber % Dozen;
                AmountOfNumbers += CopyOfTwoDigitNumber % Dozen;
                CopyOfTwoDigitNumber /= 10;
            }
            Console.WriteLine("\nЧисло Десятков в этом числе : " + (MultiDigitNumber / Dozen));
            Console.WriteLine("Число едениц в этом числе :" + CountOfUnits);
            Console.WriteLine("Сумма его цифр : " + AmountOfNumbers);
            Console.WriteLine("Произведение его цифр : " + CompositionOfNumbers);
        }


        static void AreaComparsion(double Radius, double SideOfSquare){
            const double PI_NUMBER = 3.14;
            double AreaOfCircle = (PI_NUMBER * Radius * Radius);
            double AreaOfSquare = (SideOfSquare * SideOfSquare);
            if (AreaOfCircle > AreaOfSquare) {Console.WriteLine("Площадь Круга больше!");}
            else{Console.WriteLine("Площадь Квадрата больше!");}
                Console.WriteLine("Площадь Квадрата : " + AreaOfSquare + "\nПлощадь Круга : " + AreaOfCircle);
        }

        static void ComparsionOfDensities(double Amount1, double Weight1, double Amount2, double Weight2){
            double Density1 = Amount1 / Weight1;
            double Density2 = Amount2 / Weight2;
            if (Density1 > Density2) Console.WriteLine("Плотность Первого Тела Больше!");
            else Console.WriteLine("Плотность Второго Тела Больше!");
            Console.WriteLine("Плотность Первого Тела : " + Density1 + "\nПлотность Второго Тела : " + Density2);
        }

        static void PrintInfo(int b, int a){
            Console.WriteLine("Все числа от 20 до 35");
            for (int i = 20; i <= 35; i++ )Console.WriteLine(i);
            Console.WriteLine("\nКвадраты Чисел от 10 до " + b);
            for (int i = 10; i <= b; i++) Console.WriteLine(i*i);
            Console.WriteLine("\nТретьи Степени Чисел от " + a + " до " + 50);
            for (int i = a; i <= 50; i++) Console.WriteLine(i * i * i);
            Console.WriteLine("\nЧисла от " + a + " до " + b);
            for (int i = a; i <= b; i++) Console.WriteLine(i * i * i);
        }




        static void Main(string[] args){
            
            double Number1=0, Number2=0, Number3=0;
            bool checkError = false;

            while (!checkError)
            {
                Console.WriteLine("Введите Три Числа : ");

                Console.Write("1) ");
                string toParse = Console.ReadLine();

                if ((double.TryParse(toParse, out Number1)) == false)
                {
                   checkError = true;
                    Console.Clear();
                    Console.WriteLine("Вы ввели не число!");
                }
                
                if(!checkError){
                Console.Write("2) ");
                toParse = Console.ReadLine();

                if ((double.TryParse(toParse, out Number2)) == false)
                {
                    checkError = true;
                    Console.Clear();
                    Console.WriteLine("Вы ввели не число!");
                }
                }

                if (!checkError)
                {
                    Console.Write("3) ");
                    toParse = Console.ReadLine();

                    if ((double.TryParse(toParse, out Number3)) == false)
                    {
                        checkError = true;
                        Console.Clear();
                        Console.WriteLine("Вы ввели не число!");
                    }
                }


                if (!checkError)
                {
                    PrintNumbersInLine(Number1, Number2, Number3);
                    break;
                }

                checkError = false;              
            }

            Console.Write("Нажмите любую кнопку .  .  .");
            Console.ReadKey();
            Console.Clear();


            double Radius=0, SideOfSquare=0;
            checkError = false;
            
            while(!checkError){
            
            Console.Write("Введите радиус окружности : ");
            string toParse = Console.ReadLine();
   
                if ((double.TryParse(toParse, out Radius)) == false)
                    {
                        checkError = true;
                        Console.Clear();
                        Console.WriteLine("Вы ввели не число!");
                    }

                if(!checkError){
                Console.Write("\nВведите Сторону Квадрата : ");
                toParse = Console.ReadLine();

                    if ((double.TryParse(toParse, out SideOfSquare)) == false)
                    {
                        checkError = true;
                        Console.Clear();
                        Console.WriteLine("Вы ввели не число!");
                    }
                }

                if (!checkError)
                {
                    AreaComparsion(Radius, SideOfSquare);
                    break;
                }

                checkError = false;
            }

            Console.Write("Нажмите любую кнопку .  .  .");
            Console.ReadKey();
            Console.Clear();


            Console.WriteLine("Программа по выводу чисел 5, 10, 21 столбиком\n");
            PrintNumbersDown(5,10,21);
            Console.Write("Нажмите любую кнопку .  .  .");
            Console.ReadKey();
            Console.Clear();


        
            int Santimeters = 0;
            checkError = false;

            while (!checkError)
            {
            Console.WriteLine("Введите расстояние в сантиметрах : ");
            string toParse = Console.ReadLine();

            if ((int.TryParse(toParse, out Santimeters)) == false)
                {
                checkError = false;
                Console.Clear();
                Console.WriteLine("Вы ввели не число!");
                }
                else{
                    checkError = true;
                MetersInSantimeters(Santimeters);
                }

            }

            Console.Write("Нажмите любую кнопку .  .  .");
            Console.ReadKey();
            Console.Clear();



            int Days;
        checkError = false;

        while (!checkError)
        {
            Console.WriteLine("Введите кол-во дней : ");
            string toParse = Console.ReadLine();

            if ((int.TryParse(toParse, out Days)) == false)
            {
                checkError = false;
                Console.Clear();
            Console.WriteLine("Вы ввели не число!");
            }

            else
            {
                checkError = true;
            ConvertDaysToWeeks(Days);
            }
        }

            Console.Write("Нажмите любую кнопку .  .  .");
            Console.ReadKey();
            Console.Clear();



            int Number = 0;
            checkError = false;

            while (!checkError)
            {
                Console.WriteLine("Введите целое число : ");
                string toParse = Console.ReadLine();

                if ((int.TryParse(toParse, out Number)) == false)
                {
                    checkError = false;
                Console.Clear();
                Console.WriteLine("Вы ввели не число!");
                }

                else{
                InfoAboutMultiValuedDigitNumber(Number);
                break;
                }
            }

            Console.Write("Нажмите любую кнопку .  .  .");
            Console.ReadKey();
            Console.Clear();


            double Amount1 = 0,Amount2 = 0,Weight1 = 0,Weight2 = 0;
            checkError = false;

            while (!checkError)
            {
                Console.Write("Введите объём первого тела : ");
                string toParse = Console.ReadLine();

                if ((double.TryParse(toParse, out Amount1)) == false)
                {
                    checkError = true;
                     Console.Clear();
                Console.WriteLine("Вы ввели не число!");
                }

                if (!checkError)
                {
                    Console.Write("\nВведите массу первого тела : ");
                    toParse = Console.ReadLine();

                    if ((double.TryParse(toParse, out Weight1)) == false)
                    {
                        checkError = true;
                        Console.Clear();
                        Console.WriteLine("Вы ввели не число!");
                    }
                }
               
                if (!checkError)
                {
                    Console.Write("Введите объём второго тела : ");
                    toParse = Console.ReadLine();

                    if ((double.TryParse(toParse, out Amount2)) == false)
                    {
                        checkError = true;
                        Console.Clear();
                        Console.WriteLine("Вы ввели не число!");
                    }
                }
                
                if (!checkError)
                {
                    Console.Write("\nВведите массу второго тела : ");
                    toParse = Console.ReadLine();

                    if ((double.TryParse(toParse, out Weight2)) == false)
                    {
                        checkError = true;
                        Console.Clear();
                        Console.WriteLine("Вы ввели не число!");
                    }
                }

                if (!checkError)
                {
                ComparsionOfDensities(Amount1, Weight1, Amount2, Weight2);
                break;
                }

                checkError = false;
            }

            Console.Write("Нажмите любую кнопку .  .  .");
            Console.ReadKey();
            Console.Clear();


            int a = 0,b = 0;
            checkError = false;

            while (!checkError)
            {
                Console.WriteLine(" a<b ; b>10 ; a<50 ");

                Console.Write("Введите целое число а : ");
                string toParse = Console.ReadLine();

                if ((int.TryParse(toParse, out a)) == false || a >= 50)
                {
                    checkError = true;
                    Console.Clear();
                    Console.WriteLine("Некорректно Введены данные!");
                }

                if (!checkError)
                {
                    Console.Write("\nВведите целое число b : ");
                    toParse = Console.ReadLine();

                    if ((int.TryParse(toParse, out b)) == false || b <= 10 || b < a)
                    {
                        checkError = true;
                        Console.Clear();
                        Console.WriteLine("Некорректно Введены данные!");
                    }
                }
                    
                if (!checkError)
                {
                PrintInfo(b, a);
                break;
                }
                checkError = false;
            }

            Console.Write("Нажмите любую кнопку .  .  .");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
