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
        char value;

        public SuitType Suit
        {
            get { return suit; }
        }

        public Card(SuitType suit, char value)
        {
            this.suit = suit;
            this.value = value;
        }

        public char GetValue()
        {
            return value;
        }

        public static string Compare(Card card1, Card card2)
        {
            return "Lose";
        }
    }
}
