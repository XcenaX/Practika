using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HomeWork14
{
    public struct Employer
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public int[] Marks { get; set; }
       public Vacancies Vacancy { get; set; }
        public int Salary { get; set; }
        public int[] DateOfStartOfWork { get; set; }

        public bool IsBoss { get; set; }

        public Employer(int i)
        {
            Marks = new int[0];
            Name = "";
            DateOfStartOfWork = new int[3]{ 0,0,0};
            IsBoss = false;
            Salary = 0;
            Vacancy = Vacancies.None;
            Group = "";
        }

        public Employer(string name, char selectVacancy, int salary, string dateOfStartWork, string group, char form, char gender)
        {
            Name = name;
            Salary = salary;
            DateOfStartOfWork = new int[3] { 0,0,0};
            Group = group;
            Marks = new int[0];


            string[] date = new string[3];
            date = (dateOfStartWork.Split('.'));
            for (int i = 0; i < DateOfStartOfWork.Length; i++)
            {
                DateOfStartOfWork[i] = Convert.ToInt32(date[i]);
            }

            switch (selectVacancy)
            {
                case '1':
                    Vacancy = Vacancies.Boss;
                    IsBoss = true;
                    break;
                case '2':
                    Vacancy = Vacancies.Clerk;
                    IsBoss = false;
                    break;
                case '3':
                    Vacancy = Vacancies.Manager;
                    IsBoss = false;
                    break;
                case '4':
                    Vacancy = Vacancies.Saleman;
                    IsBoss = false;
                    break;
                default:
                    throw new Exception();
            }

          


        }

        public void InputData(ref bool isBoss)
        {
            Write("Введите имя сотрудника: ");
            Name = ReadLine();


            while (true) { 
            Clear();
                Write("Введите зарплату сотрудника в тенге: ");
            string toParse = ReadLine();
            int salary;

            if (int.TryParse(toParse, out salary))
            {
                    Salary = salary;
                    break;
            }
                        }

            bool check = false;
            while (!check)
            {                
                WriteLine("Выберите кем работает сотрудник:");
                WriteLine("1) Босс");
                WriteLine("2) Клерк");
                WriteLine("3) Менеджер ");
                WriteLine("4) Салеман ");

                char select = ReadKey().KeyChar;

                switch (select)
                {
                    case '1':
                        if (!isBoss)
                        {
                            Vacancy = Vacancies.Boss;
                            check = true;
                            IsBoss = true;
                            isBoss = true;
                        }
                        else
                        {
                            Clear();
                            WriteLine("В компании уже есть босс!");
                            IsBoss = false;
                        }
                        break;
                    case '2':
                        Vacancy = Vacancies.Clerk;
                        check = true;
                        IsBoss = false;
                        break;
                    case '3':
                        Vacancy = Vacancies.Manager;
                        check = true;
                        IsBoss = false;
                        break;
                    case '4':
                        Vacancy = Vacancies.Saleman;
                        check = true;
                        IsBoss = false;
                        break;
                    default:
                        Clear();
                        WriteLine("Неверно нажата клавиша!\n");
                        break;
                }
            }
            Clear();
            while (check)
            {
                check = false;               
                WriteLine("Введите дату начала работы сотрудника\nПример: 10.03.2007\n");
                string toParse = ReadLine();

                string[] dateString = new string[3];
                int[] date= new int[3];

                dateString = toParse.Split('.');
                for(int i = 0; i < dateString.Length; i++)
                {
                    if(!int.TryParse(dateString[i], out date[i]))
                    {
                        check = true;
                        Clear();
                        WriteLine("Некорректно введены данные!\n");
                        break;
                    }
                }

                if(date[0] < 0 || date[0] > 31 || date[1] < 0 || date[1] > 12 || date[2] < 0 || date[2] > 2018)
                {
                    check = true;
                    Clear();
                    WriteLine("Некорректно введены данные!\n");
                }
                else
                {
                    for(int i = 0; i < DateOfStartOfWork.Length; i++)
                    {
                        DateOfStartOfWork[i] = date[i];
                    }
                }

            }

        }


        public string GetProfession()
        {
            switch (Vacancy)
            {
                case Vacancies.Manager:
                    return "Менеджер";                    
                case Vacancies.Clerk:
                    return "Клэрк";                   
                case Vacancies.Boss:
                    return "Босс";                    
                case Vacancies.Saleman:
                    return "Салеман";                    
            }
            return "";
        }

        public void PrintInfo()
        {
            WriteLine("\nИмя: " + Name);
            WriteLine("Зарплата(в тенге): " + Salary);            
            WriteLine("Профессия: " + GetProfession());
            Write("Дата поступления на работу: ");
            for (int i = 0; i < DateOfStartOfWork.Length; i++)
            {
                Write(DateOfStartOfWork[i] + ".");
            }
        }
        

    }

    public enum Vacancies
    {
        Manager,
        Boss,
        Clerk,
        Saleman,
        None
    }
}
