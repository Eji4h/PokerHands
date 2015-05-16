using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    public class Card
    {
        char suit;

        public Card(char suit)
        {
            this.suit = suit;
        }

        public char GetSuit()
        {
            return suit;
        }
    }
}
