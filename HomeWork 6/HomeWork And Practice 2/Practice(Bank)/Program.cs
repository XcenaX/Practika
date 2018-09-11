using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using ClassAccount;
using ClassBanc;
using ClassClient;

namespace Bancomat
{
    public class Program
    {

        public static void PrintFirstMenu()
        {
            WriteLine("Здравствуйте! \n" +
                "Это программа 'Банкомат'." +
                " Вы можете завести свой счет в банке,\n" +
                "закидывать и снимать деньги со счета." +
                "\nСписок услуг вы можете увидеть внизу. ");
            WriteLine("\n1) Завести счет");
            WriteLine("2) Войти в свой аккаунт");
            WriteLine("3) Выход из программы");
        }

        public static void PrintSecondMenu()
        {
            WriteLine("1) Посмотреть информацию об аккунте");
            WriteLine("2) Пополнить счет");
            WriteLine("3) Снять деньги со счета");
            WriteLine("4) Выход из аккаунта");
            WriteLine("5) Выход из программы");
        }

        public static string PasswordGenerate(int length)
        {
            Random _random = new Random(Environment.TickCount);

            string chars = "0123456789abcdefghijklmnopqrstuvwxyz";
            StringBuilder builder = new StringBuilder(length);

            for (int i = 0; i < length; ++i)
                builder.Append(chars[_random.Next(chars.Length)]);

            return builder.ToString();
        }

        
        


        static void Main(string[] args)
        {
            bool checkEndOfFirstWhile = false;
            bool checkEndOfSecondWhile = false;
            bool isCorrectChoose = false;
           const int passwordLength = 8;
            bool exit = false;

            Banc banc = new Banc();
            Client client = new Client();

        
            while (!checkEndOfFirstWhile)
            {
                Clear();
                PrintFirstMenu();
                char choose = ReadKey().KeyChar;
                switch (choose)
                {
                    case '1':
                        Clear();

                        banc.CreateAccount(client,passwordLength);
                        WriteLine("Аккаунт успешно добавлен!\nНажмите любую кнопку. . .");

                        ReadKey();
                        Clear();
                        break;
                    case '2':
                        isCorrectChoose = true;
                        bool isLogged = banc.TryToLogIn(client);
                        if (!isLogged) return;
                        break;
                    default:
                        Clear();
                        break;
                    case '3':
                        Clear();
                        WriteLine("До свидания!");
                        ReadKey();
                        return;
                }

                if (isCorrectChoose)
                {
                    checkEndOfSecondWhile = false;

                    while (!checkEndOfSecondWhile)
                    {
                        Clear();
                        PrintSecondMenu();
                        char choose2 = ReadKey().KeyChar;

                        switch (choose2)
                        {
                            case '1':
                                Clear();

                                client.account.ShowInfo(client);

                                ReadKey();
                                Clear();
                                break;
                            case '2':
                                Clear();
                                while (true)
                                {

                                    Write("Введите сумму для пополнения счета: ");
                                    string toParse = ReadLine();
                                    int replenishMoney;

                                    if (int.TryParse(toParse, out replenishMoney))
                                    {
                                        client.account.ReplenishAccount(replenishMoney);
                                        WriteLine("\nВы успешно пополнили баланс!");
                                        break;
                                    }
                                    Clear();
                                    WriteLine("Некорректно введены данные");
                                }
                                ReadKey();
                                Clear();
                                break;
                            case '3':
                                Clear();

                                while (true)
                                {

                                    Write("Введите сумму для списания счета: ");
                                    string toParse = ReadLine();
                                    int takeOffMoney;
                                    bool check = false;

                                    if (int.TryParse(toParse, out takeOffMoney))
                                    {
                                       check = client.account.TakeOffMoney(takeOffMoney);
                                        if (check)
                                        {
                                            WriteLine("\nВы успешно списали " + takeOffMoney + " тенге с баланса!");
                                            break;
                                        }                                      
                                    }
                                    if(!check == false)
                                    {
                                    Clear();
                                    WriteLine("Некорректно введены данные");
                                    }
                                }

                                ReadKey();
                                Clear();
                                break;
                            case '4':
                                isCorrectChoose = false;
                                checkEndOfSecondWhile = true;
                                break;
                            case '5':
                                Clear();
                                WriteLine("До свидания!");
                                ReadKey();
                                return;
                        }
                    }
                }


            }
        }
    }
}
