using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR44_W1_Exercise1to28.CardClasses
{
    enum CardColor
    {
        Black = 0,
        Red = 1,
    }

    enum CardSuit
    {
        Clubs = 0,
        Diamonds = 1,
        Harts = 2,
        Spades = 3,
    }

    enum GameSuit
    {
        Clubs = 0,
        Diamonds = 1,
        Harts = 2,
        Spades = 3,
        NT = 4,
    }

    enum CardinalDirection
    {
        //NotSet = -1,
        North = 0,
        East = 1,
        South = 2,
        West = 3,
    }

    enum Vulnerable
    {
        None = 0,
        NorthSouth = 1,
        EastWest = 2,
        Both = 3,
    }
}
