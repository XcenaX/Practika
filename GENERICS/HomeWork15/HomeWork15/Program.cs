using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HomeWork15
{
    class Program
    {
        
        public static void SayHi()
        {
            WriteLine("Приветствую вас! Это карточная игра 'Очко'!");
            WriteLine("1) Начать игру");
            WriteLine("2) Правила игры");
        }      
        
        public static void PrintRules()
        {
            WriteLine("В начале игры всем игрокам раздется по шесть карт");
            WriteLine("После этого игроки разом кладут на стол верхнюю карту с колоды, причем никто не знает какая у кого карта");
            WriteLine("Чья карта больше тот забирает все карты!");
            WriteLine("Чем больше карт, тем больше очков.");
            WriteLine("\nПримечание: чтобы играть просто нажимайте любую кнопку и смотрите какое действие произошло!\n");
            WriteLine("Это все правила, можете приступать и как говорится - береги свое Очко!");
        }

        public static int InputCountPlayers()
        {
            Clear();
                int count;
            while (true)
            {

                WriteLine("Введите кол-во игроков: ");
                string toParse = ReadLine();

                if (int.TryParse(toParse, out count))
                {
                    if (count < 7 && count > 1)
                    {
                        break;
                    }
                    else
                    {
                        Clear();
                        WriteLine("Число игроков не может быть больше 6 и меньше 2!");
                    }
                }
                else
                {
                    Clear();
                    WriteLine("Вы ввели не число!");
                }

            }
            return count;
        }

        public static int InputYourNumber(Game game)
        {
            Clear();
            int count;
            while (true)
            {

                WriteLine("Введите за какой номер вы будете играть: ");
                string toParse = ReadLine();

                if (int.TryParse(toParse, out count))
                {
                    if (count <= game.players.Length && count >= 1)
                    {
                        break;
                    }
                    else
                    {
                        Clear();
                        WriteLine("В игре всего " + game.players.Length + " игроков!");
                    }
                }
                else
                {
                    Clear();
                    WriteLine("Вы ввели не число!");
                }

            }
            return count;
        }

        public static void Choose()
        {
            bool check = false;

            while (!check)
            {
                SayHi();
                char select = ReadKey().KeyChar;
                switch (select)
                {
                    case '1':
                        check = true;
                        break;
                    case '2':
                        Clear();
                        PrintRules();
                        ReadKey();
                        Clear();
                        break;
                    default:
                        Clear();
                        break;
                }
            }
        }


        static void Main(string[] args)
        {
           Choose();          
           Game game = new Game(InputCountPlayers());
            game.players[InputYourNumber(game) - 1].IsYou = true;

            game.deck.MixDeck();
            game.Distribution(); // раздача карт всем игрокам по 6

            Clear();

            bool win = false;
            while (!win)
            {
               win = game.Step();
                
                ReadKey();
                Clear();                     
            }

        }
    }
}
