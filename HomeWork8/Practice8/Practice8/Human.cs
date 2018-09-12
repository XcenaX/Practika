using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Practice8
{
    class Human
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string LastName { get; set; }

        public Human(string Name, int Age, string LastName)
        {
            this.Age = Age;
            this.LastName = LastName;
            this.Name = Name;
        }

        public static bool operator ==(Human human1, Human human2)
        {
            if (human1.Age == human2.Age && human1.LastName == human2.LastName && human1.Name == human2.Name) return true;
            return false;
        }
        public static bool operator !=(Human human1, Human human2)
        {
            if (human2 == human1) return false;
            return true;
        }

        public void ShowInfo()
        {
            Write("Имя: " + Name);
            WriteLine(" Фамилия: " + LastName);
            WriteLine("Возраст: " + Age);
        }
    }
}
