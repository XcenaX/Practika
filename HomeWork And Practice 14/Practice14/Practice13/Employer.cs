using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice13
{
    public struct Employer
    {
        public string Name { get; set; }
        Vacancies vacancy { get; set; }
        public int Salary { get; set; }
        private int[] DateOfStartOfWork;
      
        public Employer(string name, char selectVacancy, int salary, string dateOfStartWork)
        {
            Name = name;
            Salary = salary;
            DateOfStartOfWork = new int[3];

            string[] date = new string[3];
            date = (dateOfStartWork.Split('.'));
            for(int i=0; i < DateOfStartOfWork.Length; i++)
            {
                DateOfStartOfWork[i] = Convert.ToInt32(date[i]);
            }

            switch (selectVacancy)
            {
                case '1':
                    vacancy = Vacancies.Boss;
                    break;
                case '2':
                    vacancy = Vacancies.Clerk;
                    break;
                case '3':
                    vacancy = Vacancies.Manager;
                    break;
                case '4':
                    vacancy = Vacancies.Saleman;
                    break;
                default:
                    throw new Exception();                    
            }
        }

    }

    public enum Vacancies
    {
        Manager,
        Boss,
        Clerk,
        Saleman
    }
}
