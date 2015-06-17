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
            TwoPairs,
            Three_Of_A_Kind
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
            if (OnHandIsThree_Of_A_Kind(onHandCards))
                return Category.Three_Of_A_Kind;
            if (OnHandIsTwoPairs(onHandCards))
                return Category.TwoPairs;
            if (OnHandIsPair(onHandCards))
                return Category.Pair;
            return Category.HighCard;
        }

        public static bool OnHandIsPair(List<Card> onHandCards)
        {
            int pairCount = GetPairCount(onHandCards);
            return pairCount == 1;
        }

        public static bool OnHandIsTwoPairs(List<Card> onHandCards)
        {
            int pairCount = GetPairCount(onHandCards);
            return pairCount == 2;
        }

        public static bool OnHandIsThree_Of_A_Kind(List<Card> onHandCards)
        {
            var groupCounts = onHandCards.GroupBy(card => card.Rank).
                ToDictionary(group => group.Key, group => group.Count());

            foreach (var groupCount in groupCounts.Values)
                if (groupCount == 3)
                    return true;
            return false;
        }

        private static int GetPairCount(List<Card> onHandCards)
        {
            Hand.OrderCard(onHandCards);

            int pairCount = 0;

            for (int i = 1; i < onHandCards.Count; i++)
            {
                var oldCard = onHandCards[i - 1];

                if (onHandCards[i].Rank == oldCard.Rank)
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
                var cardFromHand1 = cardsOnHand1[i];
                var cardFromHand2 = cardsOnHand2[i];

                var resultDual = CompareScoring(cardFromHand1, cardFromHand2);
                if (resultDual != ResultDual.Draw)
                    return resultDual;
            }
            return ResultDual.Draw;
        }

        private static List<Card> GetOtherCardsRankOnHand(List<Card> onHandCards, Card cardPairOfHand)
        {
            return onHandCards.Where(card => card.Rank != cardPairOfHand.Rank).ToList();
        }

        private static List<Card> RemoveHighestPairCardsOnHand(List<Card> onHandCards)
        {
            var highestCardPairOfHand = GetNextPairCard(onHandCards);

            return GetOtherCardsRankOnHand(onHandCards, highestCardPairOfHand);
        }

        static Card GetNextPairCard(List<Card> onHandCards)
        {
            var oldCard = onHandCards.Last();

            for (int i = onHandCards.Count - 2; i >= 0; i--)
            {
                var card = onHandCards[i];
                if (card.Rank == oldCard.Rank)
                    return card;
                oldCard = card;
            }
            return null;
        }

        private static ResultDual ComparePairCard(List<Card> cardsOnHand1, List<Card> cardsOnHand2)
        {
            var cardPairOfHand1 = GetNextPairCard(cardsOnHand1);
            var cardPairOfHand2 = GetNextPairCard(cardsOnHand2);

            return CompareScoring(cardPairOfHand1, cardPairOfHand2);
        }

        public static ResultDual ComparePair(List<Card> cardsOnHand1, List<Card> cardsOnHand2)
        {
            Hand.OrderCard(cardsOnHand1);
            Hand.OrderCard(cardsOnHand2);

            var resultCompare = ComparePairCard(cardsOnHand1, cardsOnHand2);

            if (resultCompare == ResultDual.Draw)
                resultCompare = CompareHighCard(cardsOnHand1, cardsOnHand2);
            return resultCompare;
        }

        public static ResultDual CompareTwoPairs(List<Card> cardsOnHand1, List<Card> cardsOnHand2)
        {
            Hand.OrderCard(cardsOnHand1);
            Hand.OrderCard(cardsOnHand2);

            var resultCompare = ComparePairCard(cardsOnHand1, cardsOnHand2);

            if(resultCompare == ResultDual.Draw)
            {
                var remainCardsOnHand1 = RemoveHighestPairCardsOnHand(cardsOnHand1);
                var remainCardsOnHand2 = RemoveHighestPairCardsOnHand(cardsOnHand2);

                resultCompare = ComparePair(remainCardsOnHand1, remainCardsOnHand2);
            }
            return resultCompare;
        }
    }
}
