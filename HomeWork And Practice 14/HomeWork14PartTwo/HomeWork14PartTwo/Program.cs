using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HomeWork14PartTwo
{
    class Program
    {
        public static void AddStudent(ref Student[] students)
        {
            Array.Resize(ref students, students.Length+1);
            students[students.Length - 1] = new Student();
            students[students.Length - 1].InputData();
        }

        public static void Sort(ref Student[] students)
        {
            Student student = new Student();

            for (int i = 0; i < students.Length-1; i++)
            {
                for (int j = 0; j < students.Length-1; j++)
                {
                    if(students[j].Salary < students[j + 1].Salary)
                    {
                        student = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = student;
                    }
                }
            }
        }

        public static void ShowDormitory(Student[] students)
        {
            int minSalary = students[0].Salary;
            for (int i = 0; i < students.Length; i++)
            {
                if (minSalary > students[i].Salary) minSalary = students[i].Salary;
            }

            Sort(ref students);

            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].Salary < minSalary * 2) students[i].PrintInfo();
            }

        }

        static void Main(string[] args)
        {
            Student[] students = new Student[0];
            WriteLine("Здравствуйте! Это программа для получения общежитий!");
            int count;
            while (true)
            {
                Write("Введите кол-во студентов: ");
                string toParse = ReadLine();

                if (int.TryParse(toParse, out count))
                {
                    break;
                }
                else
                {
                    Clear();
                }
            }
            
            for(int i = 0; i < count; i++)
            {
                Clear();
                AddStudent(ref students);
            }

            Clear();
            WriteLine("Вот список студентов, которые получили общежития:");
            ShowDormitory(students);

        }
    }
}
