using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork1
{

    class Program
    {
    public static double Dividing(double devident, double devider)
    {
        if(devider == 0)throw new ArgumentNullException();
        if(devident == null || devider == null)throw new ArgumentException();
        return devident / devider;
    }

    public static void GoingBeyondTheArray(int[] mas)
    {
        mas[mas.Length] = 0;
    }

    public static double SumSQRT(double number1,double number2)
    {
        return SQRT(number1) + SQRT(number2);
    }

        public static double SQRT(double number)
        {
            number = -5;
            if (number < 0) throw new System.ArgumentException();
            return Math.Sqrt(number);
        }

        static void Main(string[] args)
        {
           // Домашняя работа//////////////////////////////////////////////////////////
            // 1 задание
            double devident = 0, devider = 0;

            try
            {
                Dividing(devident, devider);
            }
            catch (ArgumentNullException argumentNullException)
            {
                Console.WriteLine("\nНа ноль делить нельзя!");
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine("\nНекорректно введены данные!");
            }
            //////////////////////////////////////////////////////
            Console.ReadKey();
            // 2 задание
            int sizeOfMas = 5;
            int[] mas = new int[sizeOfMas];

            try
            {
                GoingBeyondTheArray(mas);
            }
            catch (IndexOutOfRangeException indexOutOfRangeException)
            {
                Console.WriteLine("\nО нет! Выход за пределы массива! Завершаю программу! Пока!");
            }
            Console.ReadKey();
            // Домашняя работа////////////////////////////////////////////////////////////////////////

            // Практичесская работа///////////////////////////////////////////////////////////////////

            double number1 = 0, number2 = -1;

            try
            {
                SumSQRT(number1, number2);
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine("\nО нет! Нельзя извлечь корень из отрицательного числа! :( . . .");
            }
            // Практичесская работа///////////////////////////////////////////////////////////////////
        }
    }
}
