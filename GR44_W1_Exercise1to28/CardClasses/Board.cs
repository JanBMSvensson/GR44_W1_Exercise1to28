using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR44_W1_Exercise1to28.CardClasses
{
    internal class Board
    {


        public Hands Hands { get; } = new();
        public Vulnerable Vulnerable { get; set; }
        public CardinalDirection Dealer { get; } 

        public Board(CardinalDirection dealer)
        {
            Dealer = dealer;
        }

        public void DealCards(Deck deck)
        {
            // Deck deck = new();

            Random rnd = new();
            
            Vulnerable = (Vulnerable)(rnd.Next(9999) % 4);

            foreach (var item in Enum.GetValues<CardinalDirection>())
                Hands.Hand(item).Clear();

            int dealIndex = (int)Dealer;
            foreach (Card card in deck)
            {
                if (dealIndex > 3)
                    dealIndex = 0;

                Hands.Hand((CardinalDirection)dealIndex).Add(card);
                dealIndex++;
            }

            deck.Clear();
        }
    }
}
