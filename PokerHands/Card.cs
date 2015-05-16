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

        public SuitType Suit
        {
            get { return suit; }
        }

        public Card(SuitType suit)
        {
            this.suit = suit;
        }

        public int GetValue()
        {
            return 2;
        }
    }
}
