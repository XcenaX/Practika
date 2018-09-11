using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
   public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; } 

        public Person()
        {
            Name = "";
            Age = 0;
            Gender = "Не задан!";
        }

        public void Input(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

    }

    public class Company
    {
       public  string Name { get; set; }

        public static string ShowPerson(Person person)
        {
            string SomeValues = person.Age + " " + person.Gender + " " + person.Name;
            return SomeValues;
        }

    }

}
