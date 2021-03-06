﻿using System;
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
            ThreeOfA_Kind,
            Straight,
            Flush,
            FullHouse,
            FourOfA_Kind,
            StraightFlush,
            RoyalStraightFlush
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

        private static ResultDual CompareSuit(List<Card> cardsOnHand1, List<Card> cardsOnHand2)
        {
            var suitOnHand1 = cardsOnHand1.First().Suit;
            var suitOnHand2 = cardsOnHand2.First().Suit;

            if (suitOnHand1 == suitOnHand2)
                return ResultDual.Draw;
            if (suitOnHand1 > suitOnHand2)
                return ResultDual.Win;
            return ResultDual.Lose;
        }

        #region RecognizeCategory

        public static Category RecognizeCategory(List<Card> onHandCards)
        {
            if (OnHandIsRoyalStraightFlush(onHandCards))
                return Category.RoyalStraightFlush;
            if (OnHandIsStraightFlush(onHandCards))
                return Category.StraightFlush;
            if (OnHandIsFourOfA_Kind(onHandCards))
                return Category.FourOfA_Kind;
            if (OnHandIsFullHouse(onHandCards))
                return Category.FullHouse;
            if (OnHandIsFlush(onHandCards))
                return Category.Flush;
            if (OnHandIsStraight(onHandCards))
                return Category.Straight;
            if (OnHandIsThreeOfA_Kind(onHandCards))
                return Category.ThreeOfA_Kind;
            if (OnHandIsTwoPairs(onHandCards))
                return Category.TwoPairs;
            if (OnHandIsPair(onHandCards))
                return Category.Pair;
            return Category.HighCard;
        }

        public static bool OnHandIsHighCard(List<Card> onHandCards)
        {
            var onHandCardsCategory = RecognizeCategory(onHandCards);

            return onHandCardsCategory == Category.HighCard;
        }

        public static bool OnHandIsPair(List<Card> onHandCards)
        {
            return OnHandHaveASameKindCardsCount(onHandCards, 2);
        }

        public static bool OnHandIsTwoPairs(List<Card> onHandCards)
        {
            int pairCount = 0;
            var rankCardGroupsCount = GetRankCardGroupsCount(onHandCards);

            foreach (var rankCardGroupCount in rankCardGroupsCount.Values)
                if (rankCardGroupCount == 2)
                    pairCount++;

            return pairCount == 2;
        }

        public static bool OnHandIsThreeOfA_Kind(List<Card> onHandCards)
        {
            return OnHandHaveASameKindCardsCount(onHandCards, 3);
        }

        public static bool OnHandIsStraight(List<Card> onHandCards)
        {
            bool isStraight = IsStraight(onHandCards);
            Hand.OrderCard(onHandCards);

            return isStraight;
        }

        public static bool OnHandIsFlush(List<Card> onHandCards)
        {
            var firstCardSuit = onHandCards.First().Suit;
            for (int i = 1; i < onHandCards.Count; i++)
            {
                if (onHandCards[i].Suit != firstCardSuit)
                    return false;
            }
            return true;
        }

        public static bool OnHandIsFullHouse(List<Card> onHandCards)
        {
            return OnHandIsPair(onHandCards) && OnHandIsThreeOfA_Kind(onHandCards);
        }

        public static bool OnHandIsFourOfA_Kind(List<Card> onHandCards)
        {
            return OnHandHaveASameKindCardsCount(onHandCards, 4);
        }

        public static bool OnHandIsStraightFlush(List<Card> onHandCards)
        {
            return OnHandIsStraight(onHandCards) && OnHandIsFlush(onHandCards);
        }

        public static bool OnHandIsRoyalStraightFlush(List<Card> onHandCards)
        {
            bool isStraightFlush = OnHandIsStraightFlush(onHandCards);

            OrderCardsForCheckIsStraight(onHandCards);
            bool isRoyal = onHandCards.Last().Rank == RankType.Ace;

            Hand.OrderCard(onHandCards);
            return isStraightFlush && isRoyal;
        }
        #endregion

        #region ComparePokerHands
        public static ResultDual ComparePokerHands(List<Card> cardsOnHand1, List<Card> cardsOnHand2)
        {
            var categoryOfHand1 = RecognizeCategory(cardsOnHand1);
            var categoryOfHand2 = RecognizeCategory(cardsOnHand2);

            if (categoryOfHand1 == categoryOfHand2)
                return ComparePokerHandsSameCategory(cardsOnHand1, cardsOnHand2);
            if (categoryOfHand1 > categoryOfHand2)
                return ResultDual.Win;
            return ResultDual.Lose;
        }

        private static ResultDual ComparePokerHandsSameCategory(List<Card> cardsOnHand1, List<Card> cardsOnHand2)
        {
            var categoryOfHand1 = RecognizeCategory(cardsOnHand1);

            switch (categoryOfHand1)
            {
                case Category.RoyalStraightFlush:
                    return CompareRoyalStraightFlush(cardsOnHand1, cardsOnHand2);
                case Category.StraightFlush:
                    return CompareStraightFlush(cardsOnHand1, cardsOnHand2);
                case Category.FourOfA_Kind:
                    return CompareFourOfA_Kind(cardsOnHand1, cardsOnHand2);
                case Category.FullHouse:
                    return CompareFullHouse(cardsOnHand1, cardsOnHand2);
                case Category.Flush:
                    return CompareFlush(cardsOnHand1, cardsOnHand2);
                case Category.Straight:
                    return CompareStraight(cardsOnHand1, cardsOnHand2);
                case Category.ThreeOfA_Kind:
                    return CompareThreeOfA_Kind(cardsOnHand1, cardsOnHand2);
                case Category.TwoPairs:
                    return CompareTwoPairs(cardsOnHand1, cardsOnHand2);
                case Category.Pair:
                    return ComparePair(cardsOnHand1, cardsOnHand2);
                default:
                    return CompareHighCard(cardsOnHand1, cardsOnHand2);
            }
        }
        #endregion

        #region SameKindCard
        private static bool OnHandHaveASameKindCardsCount(List<Card> onHandCards, int numberOfSameKindCardToCheck)
        {
            var rankCardGroupsCount = GetRankCardGroupsCount(onHandCards);

            foreach (var rankCardGroupCount in rankCardGroupsCount.Values)
                if (rankCardGroupCount == numberOfSameKindCardToCheck)
                    return true;
            return false;
        }

        static Dictionary<RankType, int> GetRankCardGroupsCount(List<Card> onHandCards)
        {
            return onHandCards.GroupBy(card => card.Rank).
                ToDictionary(g => g.Key, g => g.Count());
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

            if (resultCompare == ResultDual.Draw)
            {
                var remainCardsOnHand1 = RemoveHighestPairCardsOnHand(cardsOnHand1);
                var remainCardsOnHand2 = RemoveHighestPairCardsOnHand(cardsOnHand2);

                resultCompare = ComparePair(remainCardsOnHand1, remainCardsOnHand2);
            }
            return resultCompare;
        }

        public static ResultDual CompareThreeOfA_Kind(List<Card> cardsOnHand1, List<Card> cardsOnHand2)
        {
            return CompareKindCard(cardsOnHand1, cardsOnHand2, 3);
        }

        public static ResultDual CompareFourOfA_Kind(List<Card> cardsOnHand1, List<Card> cardsOnHand2)
        {
            return CompareKindCard(cardsOnHand1, cardsOnHand2, 4);
        }

        private static ResultDual CompareKindCard(List<Card> cardsOnHand1, List<Card> cardsOnHand2, 
            int numberOfSameKindCardToGet)
        {
            Hand.OrderCard(cardsOnHand1);
            Hand.OrderCard(cardsOnHand2);

            var kindCardOnHand1 = GetSameKindCardOnHand(cardsOnHand1, numberOfSameKindCardToGet);
            var kindCardOnHand2 = GetSameKindCardOnHand(cardsOnHand2, numberOfSameKindCardToGet);

            var resultDual = CompareScoring(kindCardOnHand1, kindCardOnHand2);

            if (resultDual == ResultDual.Draw)
                resultDual = CompareHighCard(cardsOnHand1, cardsOnHand2);
            return resultDual;
        }

        static Card GetSameKindCardOnHand(List<Card> onHandCards, int numberOfSameKindCardToGet)
        {
            return (from card in onHandCards
                    group card by card.Rank into rankGroupCard
                    where rankGroupCard.Count() == numberOfSameKindCardToGet
                    select rankGroupCard).First().First();
        }
        #endregion

        #region Straight
        private static bool IsStraight(List<Card> onHandCards)
        {
            OrderCardsForCheckIsStraight(onHandCards);

            var nextRankToCheck = onHandCards.First().Rank;
            var onHandCardsRank = new RankType[onHandCards.Count];

            SetOnHandCardsRankForCheckOnHandIsStraight(onHandCards, onHandCardsRank);

            for (int i = 0; i < onHandCardsRank.Length; i++)
            {
                if (onHandCardsRank[i] != nextRankToCheck++)
                    return false;
            }
            return true;
        }

        private static void OrderCardsForCheckIsStraight(List<Card> onHandCards)
        {
            Hand.OrderCard(onHandCards);
            var firstCardOnHand = onHandCards.First();
            var lastCardOnHand = onHandCards.Last();

            if (lastCardOnHand.Rank == RankType.Ace)
            {
                if (firstCardOnHand.Rank == RankType.Two)
                {
                    onHandCards.Remove(lastCardOnHand);
                    onHandCards.Insert(0, lastCardOnHand);
                }
            }
        }

        private static void SetOnHandCardsRankForCheckOnHandIsStraight(List<Card> onHandCards,
            RankType[] onHandCardsRank)
        {
            for (int i = 0; i < onHandCardsRank.Length; i++)
                onHandCardsRank[i] = onHandCards[i].Rank;

            var lastCardOnHand = onHandCards.Last();
            if (lastCardOnHand.Rank == RankType.Ace)
                onHandCardsRank[onHandCardsRank.Length - 1] = RankType.King + 1;
        }

        public static ResultDual CompareStraight(List<Card> cardsOnHand1, List<Card> cardsOnHand2)
        {
            OrderCardsForCheckIsStraight(cardsOnHand1);
            OrderCardsForCheckIsStraight(cardsOnHand2);

            var lastCardOnHand1 = cardsOnHand1.Last();
            var lastCardOnHand2 = cardsOnHand2.Last();

            Hand.OrderCard(cardsOnHand1);
            Hand.OrderCard(cardsOnHand2);

            return CompareScoring(lastCardOnHand1, lastCardOnHand2);
        }
        #endregion

        public static ResultDual CompareHighCard(List<Card> cardsOnHand1, List<Card> cardsOnHand2)
        {
            Hand.OrderCard(cardsOnHand1);
            Hand.OrderCard(cardsOnHand2);

            for (int i = cardsOnHand1.Count - 1; i >= 0; i--)
            {
                var resultDual = CompareScoring(cardsOnHand1[i], cardsOnHand2[i]);
                if (resultDual != ResultDual.Draw)
                    return resultDual;
            }
            return ResultDual.Draw;
        }

        public static ResultDual CompareFlush(List<Card> cardsOnHand1, List<Card> cardsOnHand2)
        {
            return CompareHighCard(cardsOnHand1, cardsOnHand2);
        }

        public static ResultDual CompareFullHouse(List<Card> cardsOnHand1, List<Card> cardsOnHand2)
        {
            return CompareThreeOfA_Kind(cardsOnHand1, cardsOnHand2);
        }

        public static ResultDual CompareStraightFlush(List<Card> cardsOnHand1, List<Card> cardsOnHand2)
        {
            return CompareStraight(cardsOnHand1, cardsOnHand2);
        }

        public static ResultDual CompareRoyalStraightFlush(List<Card> cardsOnHand1, List<Card> cardsOnHand2)
        {
            return CompareSuit(cardsOnHand1, cardsOnHand2);
        }
    }
}
