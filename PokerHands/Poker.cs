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

        public static ResultDual ComparePair(List<Card> cardsOnHand1, List<Card> cardsOnHand2)
        {
            var cardPairOfHand1 = GetNextPairCard(cardsOnHand1);
            var cardPairOfHand2 = GetNextPairCard(cardsOnHand2);

            var resultCompareScoring = CompareScoring(cardPairOfHand1, cardPairOfHand2);

            if (resultCompareScoring == ResultDual.Draw)
            {
                var cardsOnHand1NotPairCards = GetOtherCardsOnHand(cardsOnHand1, cardPairOfHand1);
                var cardsOnHand2NotPairCards = GetOtherCardsOnHand(cardsOnHand2, cardPairOfHand2);

                resultCompareScoring = CompareHighCard(cardsOnHand1NotPairCards, cardsOnHand2NotPairCards);
            }
            return resultCompareScoring;
        }

        private static List<Card> GetOtherCardsOnHand(List<Card> onHandCards, Card cardPairOfHand)
        {
            return onHandCards.Where(card => card.Rank != cardPairOfHand.Rank).ToList();
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

        public static ResultDual CompareTwoPair(List<Card> cardsOnHand1, List<Card> cardsOnHand2)
        {
            var cardPairOfHand1 = GetNextPairCard(cardsOnHand1);
            var cardPairOfHand2 = GetNextPairCard(cardsOnHand2);

            var resultCompareScoring = CompareScoring(cardPairOfHand1, cardPairOfHand2);

            if(resultCompareScoring == ResultDual.Draw)
            {
                var remainCardsOnHand1 = GetOtherCardsOnHand(cardsOnHand1, cardPairOfHand1);
                var remainCardsOnHand2 = GetOtherCardsOnHand(cardsOnHand2, cardPairOfHand2);

                var secondPairCardOfHand1 = GetNextPairCard(remainCardsOnHand1);
                var secondPairCardOfHand2 = GetNextPairCard(remainCardsOnHand2);

                resultCompareScoring = CompareScoring(secondPairCardOfHand1, secondPairCardOfHand2);
            }
            return resultCompareScoring;
        }
    }
}
