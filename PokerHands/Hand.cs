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

        public static Card[] OrderCard(Card[] cardsInput)
        {
            Array.Sort(cardsInput, delegate(Card card1, Card card2)
            {
                return card1.Rank.CompareTo(card2.Rank);
            });
            return cardsInput;
        }
    }
}
