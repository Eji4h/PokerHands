using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    public class Hand
    {
        Deck deck;
        List<Card> cards = new List<Card>(5);

        public List<Card> GetCards()
        {
            return cards;
        }

        public Hand(Deck deck)
        {
            this.deck = deck;
        }

        public static void OrderCard(List<Card> cardsInput)
        {
            cardsInput.Sort();

            var aceQueue = GetAceQueue(cardsInput);
            cardsInput.AddRange(aceQueue);
        }

        static Queue<Card> GetAceQueue(List<Card> cardsInput)
        {
            var aceQueue = new Queue<Card>();
            for (int i = 0; i < cardsInput.Count; i++)
            {
                var card = cardsInput[i];
                bool cardRankIsAce = card.Rank == Card.RankType.Ace;
                if (cardRankIsAce)
                {
                    cardsInput.Remove(card);
                    aceQueue.Enqueue(card);
                    i--;
                }
            }
            return aceQueue;
        }

        public void DealCardsFromDeck(int amountOfCards)
        {
            cards.AddRange(deck.DealCards(amountOfCards));
        }
    }
}
