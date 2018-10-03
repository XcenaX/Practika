using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HomeWork14
{


   public class Program
    {

        public static void Sort(Employer[] employers)
        {
            Employer buf = new Employer();
            for (int i = 0; i< employers.Length-1; i++)
            {
                for(int j = 0; j < employers.Length-1; j++)
                {
                        byte[] firstSimvol1 = Encoding.ASCII.GetBytes(employers[i].Name.Substring(0,1));
                        byte[] firstSimvol2 = Encoding.ASCII.GetBytes(employers[i+1].Name.Substring(0, 1));

                    if (firstSimvol1[0] > firstSimvol2[0])
                    {
                        buf = employers[i];
                        employers[i] = employers[i + 1];
                        employers[i + 1] = buf;
                    }
                }
            }
        }

        public static void SearchManagersWithSalaryMoreThanAvarageSalaryOfClerks(Employer[] employers)
        {
            Employer[] managers = new Employer[0];

            int avarageSalaryOfClerks = 0;
            int countOfClerks = 0;
            for (int i = 0; i < employers.Length; i++)
            {
                if (employers[i].Vacancy == Vacancies.Clerk) {
                    countOfClerks++;
                    avarageSalaryOfClerks += employers[i].Salary;
                }
            }

            if(countOfClerks != 0)avarageSalaryOfClerks /= countOfClerks;

            for (int i = 0;  i < employers.Length; i++)
            {                
                if (employers[i].Vacancy == Vacancies.Manager && employers[i].Salary > avarageSalaryOfClerks)
                {
                    Array.Resize(ref managers, managers.Length+1);
                    managers[managers.Length - 1] = new Employer();
                    managers[managers.Length - 1] = employers[i];
                }
            }
            Sort(managers);
            PrintAll(managers);
        }


        public static bool IsBoss(Employer[] employers)
        {
            for (int i = 0; i < employers.Length; i++)
            {
                if (employers[i].IsBoss) { return true; }
            }
            return false;
        }
     

        public static void EmployersWhichComeAfterBoss(Employer[] employers)
        {
            if (!IsBoss(employers))
            {
                WriteLine("В компании пока нет босса!");
                return;
            }

            Employer boss = new Employer();
            Employer[] employersWhichComeAfterBoss = new Employer[0];

            for(int i = 0; i < employers.Length; i++)
            {
                if (employers[i].IsBoss) { boss = employers[i]; break; }
            }

            for (int i = 0; i < employers.Length; i++)
            {
                if(employers[i].DateOfStartOfWork[2] > boss.DateOfStartOfWork[2])
                {
                    Array.Resize(ref employersWhichComeAfterBoss, employersWhichComeAfterBoss.Length + 1);
                    employersWhichComeAfterBoss[employersWhichComeAfterBoss.Length - 1] = new Employer(0);
                    employersWhichComeAfterBoss[employersWhichComeAfterBoss.Length - 1] = employers[i];
                    break;
                }
                else if(employers[i].DateOfStartOfWork[2] == boss.DateOfStartOfWork[2])
                {
                    if (employers[i].DateOfStartOfWork[1] > boss.DateOfStartOfWork[1])
                    {
                        Array.Resize(ref employersWhichComeAfterBoss, employersWhichComeAfterBoss.Length + 1);
                        employersWhichComeAfterBoss[employersWhichComeAfterBoss.Length - 1] = new Employer(0);
                        employersWhichComeAfterBoss[employersWhichComeAfterBoss.Length - 1] = employers[i];
                    }
                    else if(employers[i].DateOfStartOfWork[1] == boss.DateOfStartOfWork[1])
                    {
                        if (employers[i].DateOfStartOfWork[0] > boss.DateOfStartOfWork[0])
                        {
                            Array.Resize(ref employersWhichComeAfterBoss, employersWhichComeAfterBoss.Length + 1);
                            employersWhichComeAfterBoss[employersWhichComeAfterBoss.Length - 1] = new Employer(0);
                            employersWhichComeAfterBoss[employersWhichComeAfterBoss.Length - 1] = employers[i];
                        }
                    }
                }
                
            }
            Sort(employersWhichComeAfterBoss);
            PrintAll(employersWhichComeAfterBoss);
        }

        public static void PrintAll(Employer[] employers)
        {
            for (int i = 0; i < employers.Length; i++)
            {
                WriteLine((i+1) + ")");
                employers[i].PrintInfo();
                WriteLine("\n");
            }
        }

        public static void PrintMenu()
        {
            WriteLine("Это программа для работы с сотрудниками!\nВнизу вы видите что вы можете сделать, удачи!\n");
            WriteLine("1) Вывести информацию обо всех сорудниках");
            WriteLine("2) Вывести Менеджеров, зарпалата которых больше чем средняя зарпалата Клерков");
            WriteLine("3) Все сотрудники, которые были приняты на работу позже Босса");
        }

        public static bool Switch(char select, Employer[] employers)
        {
            switch (select)
            {
                case '1':
                    Clear();
                    PrintAll(employers);
                    ReadKey();
                    return true;
                case '2':
                    Clear();
                    SearchManagersWithSalaryMoreThanAvarageSalaryOfClerks(employers);
                    ReadKey();
                    return true;
                case '3':
                    Clear();
                    EmployersWhichComeAfterBoss(employers);
                    ReadKey();
                    return true;
                case '5': return false;
                default: Clear(); return true;
            }
        }

        static void Main(string[] args)
        {
            int count;
            while (true)
            {
                Clear();
                Write("Введите кол-во сотрудников: ");
                
                string toParse = ReadLine();

                if (int.TryParse(toParse, out count))
                {
                    break;
                }
            }

            Employer[] employers = new Employer[count];
            for(int i = 0; i < employers.Length; i++)
            {
                employers[i] = new Employer(0);
            }

            Clear();
            WriteLine("Введите информацию о всех сотрудниках:\n");
            bool isBoss = false;
            for(int i= 0; i < employers.Length; i++)
            {
                WriteLine((i+1)+")");
                employers[i].InputData(ref isBoss);
                Clear();
            }

            bool check = false;

            while (!check)
            {
                PrintMenu();
                char select = ReadKey().KeyChar;
                Switch(select, employers);
                Clear();
            }

        }
    }
}
