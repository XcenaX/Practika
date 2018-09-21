using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Practice_9
{
    public class Student : IStudent
    {
       public string Name { get; set; }
        public string FullName { get; set; }

        private int[] Grades;
        public int this[int index]
        {
            get { return Grades[index]; }
            set { Grades[index] = value; }
        }

        public String GetName()
        {
            return Name;
        }
        public String GetFullName()
        {
            return FullName;
        }
        public Double GetAvgGrade()
        {
            int sum = 0;
            for (int i = 0; i < Grades.Length; i++)
            {
                sum += Grades[i];
            }
            return sum / Grades.Length;
        }

        public void ShowGrades()
        {
            for(int i = 0; i< Grades.Length; i++)
            {
                Write(Grades[i] + " ");
            }
        }

        public Student()
        {
            Name = "";
            FullName = "";
            Grades = new int[0];        
        }

        public void AddGrade(int grade)
        {
            Array.Resize(ref Grades, Grades.Length+1);
            Grades[Grades.Length - 1] = new int();
            Grades[Grades.Length - 1] = grade;
        }

        public void DeleteGrade(int index)
        {
            for(int i = index; i < Grades.Length - 1; i++)
            {
                Grades[i] = Grades[i + 1];
            }
            Array.Resize(ref Grades, Grades.Length - 1);
        }

        public void ShowInfo()
        {
            WriteLine("Имя: " + Name);
            WriteLine("Полное Имя: " + FullName);
            WriteLine("Оценки: "); ShowGrades();
            WriteLine("Средний бал: " + GetAvgGrade());
        }

    }
}
