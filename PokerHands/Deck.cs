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
        List<Card> cards = new List<Card>(52);

        public List<Card> Cards
        {
            get { return cards; }
        }

        public Deck()
        {
            InitDeck();
        }

        public void InitDeck()
        {
            int suitCount = 4;
            int rankCount = 13;
            int cardIndex = 0;

            for (int i = 0; i < suitCount; i++)
                for (int j = 1; j <= rankCount; j++)
                {
                    cards.Add(new Card((SuitType)i, (RankType)j));
                    cardIndex++;
                }
        }

        public void Shuffle()
        {
            cards = cards.OrderBy(card => Guid.NewGuid()).ToList();
        }

        public List<Card> DealCards(int amountOfCard)
        {
            List<Card> dealCards = new List<Card>(amountOfCard);
            dealCards.AddRange(cards.GetRange(0, amountOfCard));
            cards.RemoveRange(0, amountOfCard);
            return dealCards;
        }
    }
}
