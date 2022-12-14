using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR44_W1_Exercise1to28.CardClasses
{
    internal class Card
    {

        public Card(int cardIndex)
        {
            Index = cardIndex - 1;
            if (Index % 13 == 0) Index+= 13;

            if (cardIndex < 1)
                throw new ArgumentException("CardID too low");
            else if (cardIndex <= 13)
            {
                Suit = CardSuit.Clubs;
                Value = cardIndex;
            }
            else if (cardIndex <= 26)
            {
                Suit = CardSuit.Diamonds;
                Value = cardIndex - 13;
            }
            else if (cardIndex <= 39)
            {
                Suit = CardSuit.Harts;
                Value = cardIndex - 26;
            }
            else if (cardIndex <= 52)
            {
                Suit = CardSuit.Spades;
                Value = cardIndex - 39;
            }
            else
                throw new ArgumentException("CardID too high");

            if (Value == 1)
                Value = 14; // High aces

            if (Value > 10)
                HP = Value - 10;

            ID = Suit.ToString().Substring(0, 1) + Value.ToString();
        }

        public string ID { get; }
        public int Index { get; }

        public int HP { get; } = 0;

        public int Value { get; }

        public string ShortLabel
        {
            get { return SuitLabel + ValueLabel; }
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
        public string ValueLabel
        {
            get
            {
                return Value switch
                {
                    2 => "2",
                    3 => "3",
                    4 => "4",
                    5 => "5",
                    6 => "6",
                    7 => "7",
                    8 => "8",
                    9 => "9",
                    10 => "T",
                    11 => "J",
                    12 => "Q",
                    13 => "K",
                    14 => "A",
                    _ => throw new NotImplementedException()
                };
            }
        }

        public string Name
        {
            get
            {
                if (Value >= 2 && Value <= 10)
                    return $"{Value} of {Suit.ToString()}";
                else if (Value == 11)
                    return $"Jack of {Suit.ToString()}";
                else if (Value == 12)
                    return $"Queen of {Suit.ToString()}";
                else if (Value == 13)
                    return $"King of {Suit.ToString()}";
                else if (Value == 14)
                    return $"Ace of {Suit.ToString()}";
                else
                    throw new Exception("38947658347");
            }
        }

        public CardSuit Suit { get; }

        public CardColor Color
        {
            get
            {
                if (Suit == CardSuit.Clubs | Suit == CardSuit.Spades)
                    return CardColor.Black;
                else
                    return CardColor.Red;
            }
        }

        public bool IsRoyalCard
        {
            get { return Value >= 11; }
        }

        public bool IsTopRoyalCard
        {
            get { return Value >= 12; }
        }

        public bool IsFaceCard
        {
            get { return Value >= 11 && Value <= 13; }

        }
    }
}
