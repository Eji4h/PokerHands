using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RankType = PokerHands.Card.RankType;

namespace PokerHands
{
    public static class Poker
    {
        public enum ResultDual
        {
            Win,
            Lose,
            Draw
        }

        public enum Category
        {
            Pair,
            HighCard
        }

        public static ResultDual CompareScoring(Card card1, Card card2)
        {
            if (card1.Rank == card2.Rank)
                return ResultDual.Draw;
            if (card1.Rank == RankType.Ace)
                return ResultDual.Win;
            if (card2.Rank == RankType.Ace)
                return ResultDual.Lose;
            if (card1.Rank > card2.Rank)
                return ResultDual.Win;
            return ResultDual.Lose;
        }

        public static ResultDual CompareHighCard(List<Card> cardsOnHand1, List<Card> cardsOnHand2)
        {
            Hand.OrderCard(cardsOnHand1);
            Hand.OrderCard(cardsOnHand2);

            for (int i = cardsOnHand1.Count - 1; i >= 0; i--)
            {
                var nextHighestCardFromHand1 = cardsOnHand1[i];
                var nextHighestCardFromHand2 = cardsOnHand2[i];

                var nextIndexResultDual = CompareScoring(nextHighestCardFromHand1, nextHighestCardFromHand2);
                if (nextIndexResultDual != ResultDual.Draw)
                    return nextIndexResultDual;
            }
            return ResultDual.Draw;
        }

        public static bool OnHandIsPair(List<Card> onHandCards)
        {
            var rankOfOldCard = onHandCards.First().Rank;
            for (int i = 1; i < onHandCards.Count; i++)
            {
                if (onHandCards[i].Rank == rankOfOldCard)
                    return true;
                rankOfOldCard = onHandCards[i].Rank;
            }
            return false;
        }

        public static Category RecognizeCategory(List<Card> onHandCards)
        {
            if (OnHandIsPair(onHandCards))
                return Category.Pair;
            return Category.HighCard;
        }

        public static ResultDual ComparePair(List<Card> onHandCards1, List<Card> onHandCards2)
        {
            Card cardPairOfHand1 = CardPair(onHandCards1);
            Card cardPairOfHand2 = CardPair(onHandCards2);

            ResultDual resultCompareScoring = CompareScoring(cardPairOfHand1, cardPairOfHand2);

            if(resultCompareScoring == ResultDual.Draw)
            {
                List<Card> onHand1NotPairCards = 
                    onHandCards1.Where(card => card.Rank != cardPairOfHand1.Rank).ToList();

                List<Card> onHand2NotPairCards =
                    onHandCards2.Where(card => card.Rank != cardPairOfHand2.Rank).ToList();

                resultCompareScoring = CompareHighCard(onHand1NotPairCards, onHand2NotPairCards);
            }

            return resultCompareScoring;
        }

        public static Card CardPair(List<Card> onHandCards)
        {
            var rankOfOldCard = onHandCards.First().Rank;
            for (int i = 1; i < onHandCards.Count; i++)
            {
                if (onHandCards[i].Rank == rankOfOldCard)
                    return onHandCards[i];
                rankOfOldCard = onHandCards[i].Rank;
            }
            return null;
        }
    }
}
