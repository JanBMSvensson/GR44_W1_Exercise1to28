using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GR44_W1_Exercise1to28.CardClasses
{
    internal class Deck : CardCollection
    {
        public Deck()
        {
            for (int i = 1; i <= 52; i++)
                Add(new Card(i));
        }

        public void Shuffle(int times = 1000)
        {
            // Don't want to remove - add ... creates a copy
            var temp = new Card[52];
            Items.CopyTo(temp, 0);
            Items.Clear();

            Card card;
            int N1, N2;
            Random rnd = new();

            // Swap two random cards many times ...
            for(int i = 0; i < times * 52; i++)
            {
                N1 = rnd.Next(52);
                N2 = rnd.Next(52);

                card = temp[N1];
                temp[N1] = temp[N2];
                temp[N2] = card;
            }

            // Return the cards to the collection
            foreach (Card item in temp)
                Items.Add(item);
        }
    }
}
