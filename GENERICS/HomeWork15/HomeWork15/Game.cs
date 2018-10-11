using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HomeWork15
{
    public class Game
    {
        public Player[] players { get; set; }
        public Deck deck { get; set; }

        public Game(int countOfPlayers) 
        {
            players = new Player[countOfPlayers];
            deck = new Deck();
            for(int i = 0; i < countOfPlayers; i++)
            {
                players[i] = new Player();
                players[i].Number = i+1;
            }
        }

        public void Distribution()
        {
            for (int i = 0; i < players.Length; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    players[i].TakeOneKart(deck);
                }
            }
        }

        public void SortPlayers(ref List<Player> list)
        {
            for(int i = 0; i < list.Count-1; i++)
            {
                for (int j = 0; j < list.Count-1; j++)
                {
                    if(list[j].GetLear(0) < list[j+1].GetLear(0))
                    {
                        var copy = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = copy;
                    }
                }
            }
        }

        public void RemovePlayerNumber(int number)
        {
            int i = 0;
            for (; i < players.Length-1; i++)
            {
                if (players[i].Number == number) break;
            }
            for(; i < players.Length - 1;i++)
            {
                players[i] = players[i + 1];
            }
            var copy = players.ToList();
            copy.RemoveAt(copy.Count-1);
            players = copy.ToArray();
        }



        public bool Step()
        {
            List<Player> list = new List<Player>();
            WriteLine("Все игроки положили по карте с верха колоды:");
            for (int i = 0; i < players.Length; i++)
            {
                if (!players[i].IsYou) Write("Игрок: " + (players[i].Number) + ") ");
                else Write("Вы(" + (players[i].Number) + ") ");
                list.Add(players[i].ShowYourKart());
                WriteLine("\tКол-во карт игрока на руке: " + (list[i].GetCountOfKarts()-1));
                
            }
            WriteLine("Кол-во карт в колоде: " + deck.GetSizeOfDeck());
                SortPlayers( ref list);
                WriteLine("\nЭтот раунд выиграл игрок под номером " + list[0].Number);

            ReadKey();
            Clear();

            for (int i = 1; i < list.Count; i++)// победивший собирает все карты
            {
                list[0].TakeOneKart(list[i].GetKarta(0));
                list[i].ThrowKart();
                if(list[i].GetCountOfKarts() == 0 && deck.GetSizeOfDeck() == 0)
                {
                    Clear();

                    if (!list[i].IsYou) WriteLine("У игрока " + list[i].Number + " закончились карты, так что он выбывает!");
                    else
                    {
                        WriteLine("Жаль но ты проиграл!\nВы взбесились и решили покнинуть партию!Конец! . . .\n");
                        return true;
                    }
                    RemovePlayerNumber(list[i].Number);
                    list.RemoveAt(i);
                    ReadKey();
                    if(players.Length == 1)
                    {
                        WriteLine("И победителем стал игрок " + players[0].Number);
                        return true;
                    }
                }
            }
            list[0].RemoveFirstKardToLast();

            Clear();

            for (int i = 0; i < players.Length; i++)
            {
                if (!players[i].IsYou) Write("Игрок: " + (players[i].Number) + ") ");
                else Write("Вы(" + (players[i].Number) + ") ");
                WriteLine("\tКол-во карт игрока: " + players[i].GetCountOfKarts());
            }
            WriteLine("Кол-во карт в колоде: " + deck.GetSizeOfDeck());

            WriteLine("\nИгрок " + list[0].Number + ") забирает все карты!");
          

            for(int i = 0; i < players.Length; i++)
            {
                players[i].TakeOneKart(deck);
            }


            ReadKey();
            Clear();

            for (int i = 0; i < players.Length; i++)
            {
                if (!players[i].IsYou) Write("Игрок: " + (players[i].Number) + ") ");
                else Write("Вы(" + (players[i].Number) + ") ");
                WriteLine("\tКол-во карт игрока: " + players[i].GetCountOfKarts());
            }
            WriteLine("Кол-во карт в колоде: " + deck.GetSizeOfDeck());

            WriteLine("\nВсе игроки при необходимости взяли недостающие карты!");


            return false;
        }
    }
}
