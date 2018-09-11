using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace HomeWork6
{
    public class Program
    {        

        static void Main(string[] args)
        {
            Classes.Person person = new Person();
            Company company = new Company();

            person.Input("Санек", 22, "Мужик");
            Console.WriteLine(Classes.Company.ShowPerson(person));


        }
    }
}
