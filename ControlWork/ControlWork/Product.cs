using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ControlWork
{
   public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Category category { get; set; }
        public DateTime DateOfCreate { get; set; }

        public Product() {
            Name = "";
            Price = 0;
            category = Category.none;
            DateOfCreate = (DateTime.Now);
        }

        public string ShowCategory(Category category)
        {
            switch (category)
            {
                case Category.electronic:
                    return "Електроника";
                case Category.food:
                    return "Еда";                    
                case Category.furniture:
                    return "Мебель";
                case Category.toys:
                    return "Игрушки";
                case Category.weapons:
                    return "Оружие";
                default:return "Нет Категории";
            }
        }

        public void ShowInfo()
        {
            WriteLine("\n\nИмя: " + Name);
            WriteLine("Цена: " + Price + " тенге");
            WriteLine("Категория: " + ShowCategory(category));
            WriteLine("Дата выставки на продажу: " + DateOfCreate);
        }

    }
}
