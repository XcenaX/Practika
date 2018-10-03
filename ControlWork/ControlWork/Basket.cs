using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ControlWork
{
   public class Basket
    {
        private Product[] products;
        public Product this[int index]
        {
            get { return products[index]; }
            set { products[index] = value; }
        }

        public Product[] GetProducts()
        {
            return products;
        }

        public Basket()
        {
            products = new Product[0];
        }

        public void AddProduct(Product product)
        {
            Array.Resize(ref products, products.Length+1);
            products[products.Length - 1] = new Product();
            products[products.Length - 1] = product;
        }

        public int GetAllPrice()
        {
            int allPrice = 0;
            for (int i = 0; i < products.Length; i++)
            {
                allPrice += products[i].Price;
            }
            return allPrice;
        }

        public void ShowContent()
        {
            if(products.Length == 0)
            {
                WriteLine("В корзине пока нет товаров!");
                return;
            }
            int allPrice = 0;
            for(int i = 0; i< products.Length; i++)
            {
                WriteLine((i + 1) + ")");
                products[i].ShowInfo();
                WriteLine("\n");
                allPrice += products[i].Price;
            }
            WriteLine("\nОбщая Стоимость всех товаров: " + allPrice);
        }

    }
}
