using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    public class Hand
    {
        List<Card> cards = new List<Card>(5);

        public List<Card> GetCards()
        {
            return cards;
        }

        public static void OrderCard(List<Card> cardsInput)
        {
            cardsInput.Sort();

            var queueAce = new Queue<Card>();

            for (int i = 0; i < cardsInput.Count; i++)
            {
                if (cardsInput[i].Rank == Card.RankType.Ace)
                {
                    var card = cardsInput[i];
                    cardsInput.Remove(card);
                    queueAce.Enqueue(card);
                    i--;
                }
            }
            cardsInput.AddRange(queueAce);
        }
    }
}
