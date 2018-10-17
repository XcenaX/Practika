using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

namespace HomeWork
{
    class Program
    {

        public static bool CheckBuffer(string[] buffer)
        {
            var copy = buffer;
            int simvol;
             
            for (int i = 0; i < buffer.Length; i++)
            {
                if(!int.TryParse(buffer[i], out simvol))
                {
                    return false;
                }
            }
            return true;
        } 

        public static bool AppendFebonachiNumbersToEndOfFile(string path)
        {
            try
            {
                string data;
                string[] numbers;
                using (StreamReader file = new StreamReader(path))
                {
                    data = file.ReadToEnd();
                }
                     numbers = data.Split(' ');
                
                    if (!CheckBuffer(numbers))
                    {
                        Clear();
                        WriteLine("Ошибка : В вашем файле присутствуют не только цифры!");
                        return false;
                    }

                    int oldLength = numbers.Length;

                    Array.Resize(ref numbers, numbers.Length*2);
                    
                    for(int i =oldLength; i < numbers.Length; i++)
                    {
                        var sumStr = Convert.ToInt32(numbers[i - 1]) + Convert.ToInt32(numbers[i - 2]);
                        numbers[i] = sumStr.ToString();
                    }

                    using (StreamWriter writer = new StreamWriter(path))
                    {
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            writer.Write(numbers[i] + " ");

                        }
                    }
                    

                    return true;
                
            }
            catch (FileNotFoundException ex)
            {
                WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
            return false;
        }

        static void Main(string[] args)
        {
            Write("Введите путь файла с числами Фебоначи: ");
            string path = ReadLine();

            AppendFebonachiNumbersToEndOfFile(path);

        }
    }
}
