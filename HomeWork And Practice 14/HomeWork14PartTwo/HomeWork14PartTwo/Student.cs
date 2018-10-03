using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HomeWork14PartTwo
{
    class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public int[] Marks { get; set; }
       
        public int Salary { get; set; }
        
        public Gender Gender { get; set; }

        public FormOfStudy Form { get; set; }


        public Student()
        {
            Gender = Gender.none;
            Marks = new int[0];
            Name = "";            
            Salary = 0;           
            Group = "";
            Form = FormOfStudy.none;
        }
       
        public void InputData()
        {
            Write("Введите ФИО студента: ");
            Name = ReadLine();

            while (true)
            {
                Clear();
                Write("Введите зарплату студента в тенге: ");
                string toParse = ReadLine();
                int salary;

                if (int.TryParse(toParse, out salary))
                {
                    Salary = salary;
                    break;
                }
            }

            Clear();
            bool check = false;
            while (!check)
            {
                WriteLine("Пол студента: ");
                WriteLine("1) Мужской \n2) Женский");
                char gender = ReadKey().KeyChar;

                switch (gender)
                {
                    case '1':
                        Gender = Gender.man;
                        check = true;
                        break;
                    case '2':
                        Gender = Gender.woman;
                        check = true;
                        break;
                    default:
                        Clear();
                        check = false;
                        break;
                }                
            }

            Clear();
            check = false;
            while (!check)
            {
                WriteLine("Форма обучения студента: ");
                WriteLine("1) Заочная \n2) Очная \n3) Очно-заочная \n4) Дистанционная");
                char form = ReadKey().KeyChar;

                switch (form)
                {
                    case '1':
                        Form = FormOfStudy.correspondence;
                        check = true;
                        break;
                    case '2':
                        Form = FormOfStudy.fullTime;
                        check = true;
                        break;
                    case '3':
                        Form = FormOfStudy.partTime;
                        check = true;
                        break;
                    case '4':
                        Form = FormOfStudy.remote;
                        check = true;
                        break;
                    default:
                        Clear();
                        check = false;
                        break;
                }
            }
            Clear();
            WriteLine("Группа студента: ");
            Group = ReadLine();

            int marks;
            while (true)
            {
                Clear();
                Write("Сколько оценок у студента: ");
                string toParse = ReadLine();
                

                if (int.TryParse(toParse, out marks))
                {
                    break;
                }
            }

            Marks = new int[marks];
            Clear();
            WriteLine("Введите " + marks + " оценок:");
            for(int i = 0; i< marks;i++)
            {
                Write((i+1)+ ") ");
                string toParse = ReadLine();
                int mark;
                if(int.TryParse(toParse, out mark) && mark > 0 && mark < 13)
                {
                    Marks[i] = mark;
                }
                else
                {
                    i--;
                    Clear();
                }
            }

        }


        public string GetGender()
        {
            switch (Gender)
            {
                case Gender.man:
                    return "Мужчина";
                case Gender.woman:
                    return "Женщина";
                default:return "";
            }
        }

        public string GetForm()
        {
            switch (Form)
            {
                case FormOfStudy.correspondence:
                    return "Заочная";
                case FormOfStudy.fullTime:
                    return "Очная";
                case FormOfStudy.partTime:
                    return "Очно-Заочная";
                case FormOfStudy.remote:
                    return "Дистанционная";
                default: return "";
            }
        }

        public void PrintInfo()
        {
            double avarage = 0;
            WriteLine("\nФИО: " + Name);
            WriteLine("Зарплата(в тенге): " + Salary);
            WriteLine("Пол: " + GetGender());
            WriteLine("Форма обучения: " + GetForm());
            WriteLine("Группа: " + Group);
            Write("Оценки: ");
            for(int i = 0; i< Marks.Length; i++)
            {
                Write(Marks[i] + ", ");
                avarage += Marks[i];
            }
            WriteLine("\nСредний бал: " + avarage/Marks.Length);
        }


    }

    public enum FormOfStudy
    {
        fullTime,
        correspondence,
        partTime,
        remote,
        none
    }

    public enum Gender
    {
        man,
        woman,
        none
    }

}

