using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR44_W1_Exercise1to28.CardClasses
{
    internal class Hands
    {

        Hand North { get; } = new Hand(CardinalDirection.North);
        Hand South { get; } = new Hand(CardinalDirection.South);
        Hand East { get; } = new Hand(CardinalDirection.East);
        Hand West { get; } = new Hand(CardinalDirection.West);

        public Hand Hand(CardinalDirection direction)
        {
            return direction switch
            {
                CardinalDirection.North => North,
                CardinalDirection.South => South,
                CardinalDirection.East => East,
                CardinalDirection.West => West,
                _ => throw new NotImplementedException()
            };
        }

        void Clear()
        {
            North.Clear();
            South.Clear();
            East.Clear();
            West.Clear();
        }
    }
}
