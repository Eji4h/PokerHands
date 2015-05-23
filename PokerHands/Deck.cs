using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RankType = PokerHands.Card.RankType;
using SuitType = PokerHands.Card.SuitType;

namespace PokerHands
{
    public class Deck
    {
        Card[] cards = new Card[52];

        public Card[] Cards
        {
            get { return cards; }
        }

        public Deck()
        {
            int suitCount = 4;
            int rankCount = 13;
            int cardIndex = 0;

            for(int i = 0; i < suitCount; i++)
                for(int j = 1; j <= rankCount; j++)
                {
                    cards[cardIndex] = new Card((SuitType)i, (RankType)j);
                    cardIndex++;
                }
        }
    }
}
