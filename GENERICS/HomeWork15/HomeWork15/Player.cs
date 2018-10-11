using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HomeWork15
{
   public class Player
    {
        private Karta[] kartas;
        public int Number { get; set; }

        public bool IsYou { get; set; }

        public Player()
        {
            kartas = new Karta[0];
            Number = 0;
            IsYou = false;
        }

 

        public void TakeOneKart(Deck deck)
        {
            if (kartas.Length < 6)
            {
                var copy = deck.GiveKart();
                if (copy.lear != Lear.error)
                {
                    Array.Resize(ref kartas, kartas.Length + 1);
                    kartas[kartas.Length - 1] = new Karta();
                    kartas[kartas.Length - 1] = copy;
                }
            }
        }

        public Karta GetKarta(int index)
        {
            return kartas[index];
        }

        public void TakeOneKart(Karta karta)
        {
                    Array.Resize(ref kartas, kartas.Length + 1);
                    kartas[kartas.Length - 1] = new Karta();
                    kartas[kartas.Length - 1] = karta;                
            }
        

        public int GetCountOfKarts()
        {
            return kartas.Length;
        }

        public void ThrowKart()
        {
            for(int i = 0; i < kartas.Length - 1; i++)
            {
                kartas[i] = kartas[i + 1];
            }
            Array.Resize(ref kartas, kartas.Length - 1);
        }

        public void RemoveFirstKardToLast()
        {
            var copy = kartas[0];
            for(int i = 0; i < kartas.Length-1; i++)
            {
                kartas[i] = kartas[i + 1];
            }
            kartas[kartas.Length - 1] = copy;
        }
        
        public Lear GetLear(int i)
        {
            if (kartas.Length < 0) return Lear.error;
            return kartas[i].lear;
        }
        public Player ShowYourKart()
        {
            if (kartas.Length > 0)
            {
                kartas[0].ShowInfo();
            }
            return this;
        }
    }
}
