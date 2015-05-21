using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    public class Card
    {
        public enum SuitType
        {
            Club,
            Diamond,
            Heart,
            Spade
        }

        public enum ValueType
        {
            Ace = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13
        }

        SuitType suit;
        ValueType value;

        public SuitType Suit
        {
            get { return suit; }
        }

        public ValueType Value
        {
            get { return this.value; }
        }

        public Card(SuitType suit, ValueType value)
        {
            this.suit = suit;
            this.value = value;
        }
    }
}
