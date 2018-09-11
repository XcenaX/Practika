using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HomeWork7
{
    class RangeOfArray
    {
        public int UpperIndex { get; set; }
        public int LowerIndex { get; set; }
        private int[] array;

        public RangeOfArray()
        {
            UpperIndex = 0;
            LowerIndex = 0;
            array = new int[0];
        }

       public RangeOfArray(int UpperIndex, int LowerIndex)
        {
            if(UpperIndex > LowerIndex)
            {
            this.UpperIndex = UpperIndex;
            this.LowerIndex = LowerIndex;
            }
            else
            {
                this.UpperIndex = LowerIndex;
                this.LowerIndex = UpperIndex;
            }

            array = new int[UpperIndex - LowerIndex];

            int realIndex = 0;
            for (int i = LowerIndex; i < UpperIndex; i++)
            {
                array[realIndex] = 0;
            }

        }

        public int GetData(int index)
        {
            int realIndex = 0;
            for(realIndex = LowerIndex; realIndex < index; realIndex++){}
            return array[realIndex];
        }

        public void SetData(int index, int data)
        {
            int realIndex = 0;
            for (int i = LowerIndex; i < UpperIndex; i++ , realIndex++)
            {
                if (i == index) array[realIndex] = data;
            }
             
        }

        public int GetSize()
        {
            return UpperIndex - LowerIndex;
        }

        public void Input()
        {
            bool check = false;
            int firstIndex, secondIndex;

            while (!check)
            {
                Clear();
                WriteLine("Введите индексный диапозон массива: ");
                Write("Индекс начала: ");
                string toParse = ReadLine();

                if (!int.TryParse(toParse, out firstIndex))
                {
                    check = true;
                }

                if (!check)
                {
                    Write("\nИндекс конца: ");
                    toParse = ReadLine();

                    if (int.TryParse(toParse, out secondIndex))
                    {

                        if (firstIndex > secondIndex)
                        {
                            this.UpperIndex = firstIndex;
                            this.LowerIndex = secondIndex;
                        }
                        else
                        {
                            this.UpperIndex = secondIndex;
                            this.LowerIndex = firstIndex;
                        }

                        array = new int[this.UpperIndex - this.LowerIndex];
                        break;
                    }
                }

                check = false;
            }
        }


        public void ForProgram()
        {
            bool check = false;
            int index;

            while (!check)
            {
                Clear();
                WriteLine("В массиве " + GetSize() + " элементов");
                WriteLine("Границы от " + LowerIndex + " до " + UpperIndex);
                Write("\nВведите цифру из этого диапозона и задайте значение элементу: ");

                string toParse = ReadLine();
                if (!int.TryParse(toParse, out index))
                {
                    WriteLine("\nНекорректно введены данные!");
                    check = true;
                    ReadKey();
                }               
                if(!(!check && index >= LowerIndex && index <= UpperIndex))
                {
                    WriteLine("\nЧисло вне диапозона!");
                    check = true;
                    ReadKey();
                }

                if (!check)
                {
                    while (!check)
                    {
                        Clear();
                        WriteLine("Задайте значение: ");
                        toParse = ReadLine();
                        int data;

                        if (!int.TryParse(toParse, out data))
                        {
                            WriteLine("\nНекорректно введены данные!");
                            check = true;
                            ReadKey();
                        }

                        if (!check)
                        {
                            SetData(index, data);
                            WriteLine("\nЭлемент успешно изменен!");
                            ReadKey();
                            return;
                        }

                    }
                }

                check = false;
            }
        }

        public void PrintArray()
        {
            int realIndex = 0;
            for(int i = LowerIndex; i < UpperIndex; i++)
            {
                WriteLine();
                Write(i +") ");                
                Write(array[realIndex]);
                realIndex++;
            }
        }

    }
}
