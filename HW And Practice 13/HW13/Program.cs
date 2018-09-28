using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13
{
    class Program
    {

        static void DeleteNechetNumbers(List<int> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                if(!((list[i] % 2 )== 0))
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
        }

        static int ShowElementsWhichBiggerThanAverage(List<int> list)
        {
            int sum = 0;
            for (int i = 0; i < list.Count; i++){
                sum += list[i];
            }
            sum /= list.Capacity;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > sum) Console.WriteLine(list[i] + "  ");
            }
            return sum;
        }

        static void GetRandom(List<int> list)
        {
            Random random = new Random();
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = random.Next(0,100);
            }
        }

        static void ShowPositionAndValueOfSecondMaxElement(List<int> list)
        {
            int secondMaxElement = list[0], maxElement = list[0];
            int position = 0;
            for (int i = 0; i < list.Count;i++)
            {
                if (list[i] > maxElement) maxElement = list[i];
               
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > secondMaxElement && maxElement > list[i]) { secondMaxElement = list[i]; position = i; }
            }
            Console.WriteLine("Позиция второго наибольшего элемента : " + position);
            Console.WriteLine("Значение второго наибольшего элемента : " + secondMaxElement);
        }

        static void Main(string[] args)
        {

          
            List<int> list = new List<int> { 0,0,0,0,0,0,0,0,0,0,0,0},
            list2 = new List<int> { 0,0,0,0,0,0,0,0,0,0,0,0};

            GetRandom(list);
            GetRandom(list2);


            Console.WriteLine("\n\nПервый массив:");
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nПервый массив без нечетных чисел:");
            DeleteNechetNumbers(list);
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n\n\n\nВторой массив:");
            foreach (var item in list2)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n\nВторой массив с числами больше чем среднее:");
           int sum = ShowElementsWhichBiggerThanAverage(list2);
            Console.WriteLine("\nСреднее арифметичесское : " + sum);

            Console.Write("Нажмите любую кнопку...");
            Console.ReadKey();
            Console.Clear();

            List<int> list3 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            GetRandom(list3);


            Console.WriteLine("\n\n\n\nМассив:");
            foreach (var item in list3)
            {
                Console.Write(item + " ");
            }

            ShowPositionAndValueOfSecondMaxElement(list3);

        }
    }
}
