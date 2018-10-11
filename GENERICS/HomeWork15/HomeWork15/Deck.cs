using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork15
{
    public class Deck
    {
        private Karta[] kartas;
        public Karta this[int index]
        {
            get { return kartas[index]; }
            set { kartas[index] = value; }
        }

        public int GetSizeOfDeck()
        {
            return kartas.Length;
        }

      

        public Deck()
        {
            kartas = new Karta[36];
            int i = 0;

            for(; i < 36; i++)
            {
                kartas[i] = new Karta();
            }

            i = 0;

            for(; i < 4; i++)
            {
                kartas[i].lear = Lear.six;
            }

            for (; i < 8; i++)
            {
                kartas[i].lear = Lear.seven;
            }

            for (; i < 12; i++)
            {
                kartas[i].lear = Lear.eight;
            }

            for (; i < 16; i++)
            {
                kartas[i].lear = Lear.nine;
            }

            for (; i < 20; i++)
            {
                kartas[i].lear = Lear.ten;
            }

            for (; i < 24; i++)
            {
                kartas[i].lear = Lear.man;
            }

            for (; i < 28; i++)
            {
                kartas[i].lear = Lear.woman;
            }

            for (; i < 32; i++)
            {
                kartas[i].lear = Lear.king;
            }

            for (; i < 36; i++)
            {
                kartas[i].lear = Lear.ace;
            }

        }

        public void MixDeck()
        {
            Karta[] kartas2 = new Karta[kartas.Length];
            Random rand = new Random();
            for (int i = 0; i < kartas2.Length; i++)
            {
                int randomNumber = rand.Next(0, kartas.Length-1);
                kartas2[i] = kartas[randomNumber];
                var copy = kartas.ToList();
                copy.RemoveAt(randomNumber);
                kartas = copy.ToArray();
            }
            kartas = kartas2;
        }

        public Karta GiveKart()
        {
            if (GetSizeOfDeck() > 0)
            {
                var kart = kartas[kartas.Length - 1];
                Array.Resize(ref kartas, kartas.Length - 1);
                return kart;
            }
            return new Karta(-1);
        }

    }
}
