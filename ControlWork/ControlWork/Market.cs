using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ControlWork
{
    public class Market
    {
        private User[] users;
        public User this[int index]
        {
            get { return users[index]; }
            set { users[index] = value; }
        }
        public Basket basket { get; set; }
        private Product[] products;      


        public Market()
        {
            users = new User[0];
            basket = new Basket();
            products = new Product[0];
        }

        public User[] GetUsers()
        {
            return users;
        }

        public Product[] GetProducts()
        {
            return products;
        }

        public void AddUser(User user)
        {
            Array.Resize(ref users, users.Length + 1);
            users[users.Length - 1] = new User();
            users[users.Length - 1] = user;
        }

        public void AddProduct(Product product)
        {
            Array.Resize(ref products, products.Length + 1);
            products[users.Length - 1] = new Product();
            products[users.Length - 1] = product;
        }

        public void AddProduct(string name, int price, Category category)
        {
            Product product = new Product();
            product.category = category;
            product.Name = name;
            product.Price = price;
            Array.Resize(ref products, products.Length + 1);
            products[products.Length - 1] = new Product();
            products[products.Length - 1] = product;
        }



        public bool CheckSameLogin(string login, User[] users)
        {
            for (int i = 0; i < users.Length; i++)
            {
                if (users[i].account.Login == login) return true;
            }
            return false;
        }

        public void SearchByName(string name)
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].Name.Contains(name))
                {
                    products[i].ShowInfo();
                    WriteLine("\n");
                }
            }
        }

       public void BuyAll()
        {
            if(basket.GetAllPrice() > users[0].account.Money)
            {
                WriteLine("У вас недостаточно средств для покупки товаров!");
                return;
            }
            int sizeBusket = basket.GetProducts().Length;
            for(int i = 0; i < sizeBusket; i++)
            {
                users[0].account.Money -= basket.GetProducts()[i].Price;                
            }
            basket = new Basket();
        }

        public void AddProductToBasketByName(string name)
        {            
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].Name == name)
                {
                    basket.AddProduct(products[i]);
                    return;
                }
            }
            Clear();
            WriteLine("Товара с таким именем не найдено!");
        }

        public void SearchWithCategory(Category category)
        {
            for(int i = 0; i < products.Length; i++)
            {
                if(products[i].category == category)
                {
                    products[i].ShowInfo();
                    WriteLine("\n");
                }
            }
        }


    }
}
