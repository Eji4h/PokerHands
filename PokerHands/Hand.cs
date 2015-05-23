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

            for (int i = 0; i < cardsInput.Count; i++)
            {
                if (cardsInput[i].Rank == Card.RankType.Ace)
                {
                    if (i == cardsInput.Count - 1)
                        break;
                    var card = cardsInput[i];
                    cardsInput.Remove(card);
                    cardsInput.Add(card);
                }
            }
        }
    }
}
