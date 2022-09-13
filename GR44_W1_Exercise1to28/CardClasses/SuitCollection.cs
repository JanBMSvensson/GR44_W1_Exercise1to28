using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR44_W1_Exercise1to28.CardClasses
{
    internal class SuitCollection : CardCollection
    {

        public SuitCollection(CardSuit suit)
        {
            Suit = suit;
        }

        public string SuitLabel
        {
            get
            {
                return Suit switch
                {
                    CardSuit.Spades => "♠",
                    CardSuit.Harts => "♥",
                    CardSuit.Diamonds => "♦",
                    CardSuit.Clubs => "♣",
                    _ => throw new Exception("2938745628973")
                };
            }
        }


        public new string[] CardShortNames()
        {
            List<string> strings = new List<string>();
            if (this.Count > 0)
                strings.Add(SuitLabel);

            foreach (Card card in this)
                strings.Add(card.ValueLabel);

            if (this.Count > 0)
                strings.Add(" ");

            return strings.ToArray();
        }


        public CardSuit Suit { get; }


        public bool IsRenons
        {
            get { return Count == 0; }
        }
        public bool IsSingleton
        {
            get { return Count == 1; }
        }
        public bool IsDoubleton
        {
            get { return Count == 2; }
        }

        public SuitCollection FaceCards
        {
            get
            {
                SuitCollection op = new(Suit);
                foreach (Card item in this)
                    if (item.IsFaceCard)
                        op.Add(item);
                
                return op;
            }
        }

        public int TP
        {
            get
            {
                int sum = 0;

                if (IsRenons) // has no cards of that suit
                    sum = 3;
                else if (IsSingleton && FaceCards.Count == 0) // has a single card of that suit but no face cards (J/Q/K)
                    sum = 2;
                else if (IsDoubleton && FaceCards.Count == 0) // has two cards of that suit and none of them are face cards
                    sum = 1;

                return sum;
            }
        }

    }
}
