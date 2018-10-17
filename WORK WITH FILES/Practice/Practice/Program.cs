using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using  System.IO;

namespace Practice
{
    class Program
    {

        public static void PrintCountOfAllSimvolsInFile()
        {

            bool check = false;
            string path;

            while (!check)
            {
                Write("Введите путь файла в для подсчета всех символов: ");
                path = ReadLine();

                try
                {
                    using (StreamReader file = new StreamReader(path))
                    {
                        char[] buf = new char[file.BaseStream.Length];
                        file.Read(buf, 0, Convert.ToInt32(file.BaseStream.Length));

                        List<string> array = new List<string>();

                        for (int i = 0; i < buf.Length; i++)
                        {
                            bool IsThere = false;

                            for (int j = 0; j < array.Count; j++)
                            {
                                if (array[j].First() == buf[i])
                                {
                                    array[j] += buf[i];
                                    IsThere = true;
                                    break;
                                }
                            }

                            if (!IsThere)
                            {
                                array.Add(buf[i].ToString());
                            }

                        }

                        Clear();

                        WriteLine("Символ\tКол-во");
                        for (int i = 0; i < array.Count; i++)
                        {
                            WriteLine(array[i].First() + "\t" + array[i].Length);
                        }
                    }
                    check = true;
                }
                catch (FileNotFoundException ex)
                {
                    Clear();
                    WriteLine(ex.Message);
                    check = false;
                }
                catch (Exception ex)
                {
                    WriteLine(ex.Message);
                }
            }            
        }

        public static void WriteYourDataInFile()
        {

            bool check = false;
            string path;

            while (!check)
            {
                Write("Введите путь файла в для подсчета всех символов: ");
                path = ReadLine();

                try
                {
                    using (StreamWriter file = new StreamWriter(path))
                    {
                        WriteLine("Введите ваше Имя: ");
                        string name = ReadLine();

                        WriteLine("Введите вашу Фамилию: ");
                        string lastName = ReadLine();

                        int age;
                        while (true)
                        {
                            WriteLine("Введите ваш Возраст: ");
                            string toParse = ReadLine();

                            if (!int.TryParse(toParse, out age))
                            {
                                Clear();
                                WriteLine("Вы ввели не число!");
                            }
                            else break;
                        }

                        file.WriteLine(name);
                        file.WriteLine(lastName);
                        file.WriteLine(age);

                    }
                    check = true;
                }
                catch (FileNotFoundException ex)
                {
                    Clear();
                    WriteLine(ex.Message);
                    check = false;
                }
                catch (Exception ex)
                {
                    WriteLine(ex.Message);
                }
            }
        }

        static void Main(string[] args)
        {

            PrintCountOfAllSimvolsInFile();

            WriteLine("\nНажмите любую кнопку . . .");
            ReadKey();
            Clear();

            WriteYourDataInFile();

            WriteLine("\nНажмите любую кнопку . . .");
            ReadKey();
            Clear();
        }
    }
}

