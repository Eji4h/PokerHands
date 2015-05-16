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
            C,
            D,
            H,
            S
        }

        SuitType suit;
        int value;

        public SuitType Suit
        {
            get { return suit; }
        }

        public Card(SuitType suit, int value)
        {
            this.suit = suit;
            this.value = value;
        }

        public int GetValue()
        {
            return value;
        }
    }
}
