using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace ControlWork
{
    class Program
    {

        public static string PasswordGenerate(int length)
        {
            Random _random = new Random(Environment.TickCount);

            string chars = "0123456789abcdefghijklmnopqrstuvwxyz";
            StringBuilder builder = new StringBuilder(length);

            for (int i = 0; i < length; ++i)
                builder.Append(chars[_random.Next(chars.Length)]);

            return builder.ToString();
        }

        public static bool SendMessage(string phone, ref string password, bool checkContent)
        {
            // Find your Account Sid and Token at twilio.com/console
            const string accountSid = "AC66f30d814454e464a8777365b4cb7170";
            const string authToken = "cbf88a0c476adcdb73995db45cc9fdc5";

            password = PasswordGenerate(6);

            TwilioClient.Init(accountSid, authToken);
            try
            {
                if (checkContent)
                {
                    var message = MessageResource.Create(
                        body: "Код для подтверждения : " + password,
                        from: new Twilio.Types.PhoneNumber("+18654019192"),
                        to: new Twilio.Types.PhoneNumber(phone)
                    );
                }
                else
                {
                    var message = MessageResource.Create(
                                           body: "Ваш аккаунт был удален! TRIGGERED",
                                           from: new Twilio.Types.PhoneNumber("+18654019192"),
                                           to: new Twilio.Types.PhoneNumber(phone)
                                       );
                }
            }
            catch (Twilio.Exceptions.ApiException)
            {
                Clear();
                WriteLine("Такого телефона не найдено!");
                ReadKey();
                return false;
            }
            return true;
        }

        public static void CreateAccount(Market market)
        {
            User user = new User();

            Write("Введите ваше Ф.И.О: ");
            user.FIO = ReadLine();

            while (true)
            {
                Clear();
                Write("Введите ваш возраст: ");

                int age;
                string toParse = ReadLine();

                if (int.TryParse(toParse, out age))
                {
                    user.Age = age;
                    break;
                }
            }

            string login;
            while (true)
            {
                Write("Введите ваш логин: ");
                login = ReadLine();
                bool check = market.CheckSameLogin(login, market.GetUsers());
                if (!check) break;
                else
                {
                    Clear();
                    WriteLine("Такой логин уже существует!");
                }
            }

            user.account.Login = login;

            Write("Введите ваш пароль: ");
            user.account.Password = ReadLine();

            string yourcode = "";
            string phone;

            while (true)
            {
                Write("Введите ваш телефон: ");
                phone = ReadLine();
                Clear();

                bool check = SendMessage(phone, ref yourcode, true);
                if (check) break;
            }

            Clear();

            while (true)
            {
                Write("Введите код, который пришел на ваш телефон: ");
                string code = ReadLine();

                if (code == yourcode)
                {
                    Clear();
                    WriteLine("Телефон успешно подтвержден!");
                    user.account.Phone = phone;
                    ReadKey();
                    break;
                }
                else
                {
                    Clear();
                    WriteLine("Неверно введен код!");
                }
            }                        
            market.AddUser(user);
        }

        public static void PrintMenu()
        {
            WriteLine("1) Просмотреть товары по категориям");
            WriteLine("2) Просмотреть все товары");
            WriteLine("3) Положить товар в корзину");
            WriteLine("4) Приобрести все что находится в корзине");
            WriteLine("5) Искать товары по имени");
            WriteLine("6) Просмотреть корзину");
            WriteLine("7) Выход");
        }

        static void Main(string[] args)
        {
            Market market = new Market();

            Category category1 = Category.electronic;
            Category category2 = Category.food;
            Category category3 = Category.furniture;
            Category category4 = Category.toys;
            Category category5 = Category.weapons;

            
            market.AddProduct("Лишайник", 5000, category2);
            market.AddProduct("Холодильник", 50000, category1);
            market.AddProduct("Чайник", 23000, category1);
            market.AddProduct("Котлеты", 500, category2);
            market.AddProduct("Мишка", 10000, category4);
            market.AddProduct("Пулемет", 55000, category5);
            market.AddProduct("Пистолет", 50000, category5);
            market.AddProduct("Диван", 500000, category3);
            market.AddProduct("Стул", 5000, category3);


            WriteLine("Здравствуйте! Это инетрнет-магазин arbuz.kz!\nДля начала вам нужно зарегестрироваться!\n\nНажмите любую кнопку...");
            ReadKey();
            Clear();

            CreateAccount(market);

            bool check = false;

            while (!check)
            {
                Clear();
                WriteLine("У вас на счету: " + market.GetUsers()[0].account.Money + " тенге\n");
                PrintMenu();
                char select = ReadKey().KeyChar;
                Clear();
                switch (select)
                {
                    case '1':
                        bool checkWhile = false;
                        while (!checkWhile)
                        {
                            WriteLine("Выберите категорию: ");
                            WriteLine("1) Електроника \n2)Еда \n3)Оружие \n4)Игрушки \n5) Мебель");

                            char choose = ReadKey().KeyChar;
                            Clear();


                            switch (choose)
                            {
                                case '1':
                                    market.SearchWithCategory(Category.electronic);
                                    checkWhile = true;
                                    break;
                                case '2':
                                    market.SearchWithCategory(Category.food);
                                    checkWhile = true;
                                    break;
                                case '3':
                                    market.SearchWithCategory(Category.weapons);
                                    checkWhile = true;
                                    break;
                                case '4':
                                    market.SearchWithCategory(Category.toys);
                                    checkWhile = true;
                                    break;
                                case '5':
                                    market.SearchWithCategory(Category.furniture);
                                    checkWhile = true;
                                    break;
                                default:Clear(); checkWhile = false; break;
                            }
                        }
                        ReadKey();
                        break;
                    case '2':
                        for(int i = 0 ; i < market.GetProducts().Length; i++)
                        {
                            market.GetProducts()[i].ShowInfo();
                        }                        
                        ReadKey();
                        break;
                    case '3':
                        WriteLine("Введите имя товара");
                        string name = ReadLine();
                        market.AddProductToBasketByName(name);
                        ReadKey();
                        break;
                    case '4':
                        market.BuyAll();
                        ReadKey();
                        break;
                    case '6':
                        market.basket.ShowContent();
                        ReadKey();
                        break;
                    case '5':
                        WriteLine("Введите имя товара: ");
                        string nameProduct = ReadLine();
                        market.SearchByName(nameProduct);
                        ReadKey();
                        break;
                    case '7':
                        return;
                    default:Clear();break;

                }
            }
        }
    }
}
