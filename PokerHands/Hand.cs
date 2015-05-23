using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    public class Hand
    {
        Card[] cards = new Card[5];

        public Card[] GetCards()
        {
            return cards;
        }

        public static void OrderCard(Card[] cardsInput)
        {
            Array.Sort(cardsInput);
        }
    }
}
