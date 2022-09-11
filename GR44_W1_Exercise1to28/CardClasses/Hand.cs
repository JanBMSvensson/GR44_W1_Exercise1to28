using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR44_W1_Exercise1to28.CardClasses
{
    internal class Hand : CardCollection
    {
        public Hand(CardinalDirection direction)
        {
            CardinalDirection = direction;
        }

        public CardinalDirection CardinalDirection { get; } 


        public SuitCollection Spades
        {
            get { return GetSuit(CardSuit.Spades); }
        }
        public SuitCollection Harts
        {
            get { return GetSuit(CardSuit.Harts); }
        }
        public SuitCollection Diamonds
        {
            get { return GetSuit(CardSuit.Diamonds); }
        }
        public SuitCollection Clubs
        {
            get { return GetSuit(CardSuit.Clubs); }
        }

        public int Htp(GameSuit trumph) 
        {
            int htp = HP;
            if (trumph != GameSuit.Spades)
                htp += Spades.TP;
            if(trumph != GameSuit.Harts)
                htp += Harts.TP;
            if (trumph != GameSuit.Diamonds)
                htp += Diamonds.TP;
            if (trumph != GameSuit.Clubs)
                htp += Clubs.TP;
            
            return htp;
        }

        public string Distribution
        {
            get
            {
                List<int> list = new(new int[] { Spades.Count, Harts.Count, Diamonds.Count, Clubs.Count });
                list.Sort();
                string ut = "";
                for (int i = list.Count - 1; i >= 0; i--)
                    ut += ToChar(list[i]);

                return ut;

                char ToChar(int i) {
                    if (i < 10)
                        return i.ToString()[0];
                    else
                        return "x"[0];
                }
            }
        }

        public string DistributionType
        {
            get
            {
                switch (Distribution) 
                {
                    case "4333":
                    case "4432":
                    case "5332":
                        return "Even";
                    case "4443":
                        return "Marmic";
                    default:
                        return "Uneven";
                }
            }
        }

        private SuitCollection GetSuit(CardSuit suit)
        {
            SortedDictionary<int, Card> sorted = new();
            foreach(Card card in this)
                if (card.Suit == suit)
                    sorted.Add(card.Value, card);

            SuitCollection output = new(suit);
            foreach(var card in sorted)
                output.Add(card.Value);

            return output;
        }
    }
}
