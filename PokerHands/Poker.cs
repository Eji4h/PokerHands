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
            HighCard,
            Pair,
            TwoPair
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

        public static Category RecognizeCategory(List<Card> onHandCards)
        {
            if (OnHandIsTwoPair(onHandCards))
                return Category.TwoPair;
            if (OnHandIsPair(onHandCards))
                return Category.Pair;
            return Category.HighCard;
        }

        public static bool OnHandIsPair(List<Card> onHandCards)
        {
            int pairCount = GetPairCount(onHandCards);
            return pairCount == 1;
        }

        public static bool OnHandIsTwoPair(List<Card> onHandCards)
        {
            int pairCount = GetPairCount(onHandCards);
            return pairCount == 2;
        }

        private static int GetPairCount(List<Card> onHandCards)
        {
            Hand.OrderCard(onHandCards);

            int pairCount = 0;

            for (int i = 1; i < onHandCards.Count; i++)
            {
                var oldCard = onHandCards[i - 1];
                var card = onHandCards[i];

                if (oldCard.Rank == card.Rank)
                {
                    pairCount++;
                    i++;
                }
            }
            return pairCount;
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

        public static ResultDual ComparePair(List<Card> onHandCards1, List<Card> onHandCards2)
        {
            var cardPairOfHand1 = GetPairCard(onHandCards1);
            var cardPairOfHand2 = GetPairCard(onHandCards2);

            var resultCompareScoring = CompareScoring(cardPairOfHand1, cardPairOfHand2);

            if (resultCompareScoring == ResultDual.Draw)
            {
                var onHand1NotPairCards = GetOnHandNotPairCards(onHandCards1, cardPairOfHand1);
                var onHand2NotPairCards = GetOnHandNotPairCards(onHandCards2, cardPairOfHand2);

                resultCompareScoring = CompareHighCard(onHand1NotPairCards, onHand2NotPairCards);
            }
            return resultCompareScoring;
        }

        private static List<Card> GetOnHandNotPairCards(List<Card> onHandCards, Card cardPairOfHand)
        {
            return onHandCards.Where(card => card.Rank != cardPairOfHand.Rank).ToList();
        }

        static Card GetPairCard(List<Card> onHandCards)
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

        public static ResultDual CompareTwoPair(List<Card> onHandCards1, List<Card> onHandCards2)
        {
            return ResultDual.Lose;
        }
    }
}
