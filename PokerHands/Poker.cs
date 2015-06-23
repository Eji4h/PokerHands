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
            Three_Of_A_Kind,
            Straight,
            Flush
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

        #region RecognizeCatagory

        public static Category RecognizeCategory(List<Card> onHandCards)
        {
            if (OnHandIsFlush(onHandCards))
                return Category.Flush;
            if (OnHandIsStraight(onHandCards))
                return Category.Straight;
            if (OnHandIsThree_Of_A_Kind(onHandCards))
                return Category.Three_Of_A_Kind;
            if (OnHandIsTwoPairs(onHandCards))
                return Category.TwoPairs;
            if (OnHandIsPair(onHandCards))
                return Category.Pair;
            return Category.HighCard;
        }

        public static bool OnHandIsHighCard(List<Card> onHandCards)
        {
            var onHandCardsCatagory = RecognizeCategory(onHandCards);

            return onHandCardsCatagory == Category.HighCard;
        }

        public static bool OnHandIsPair(List<Card> onHandCards)
        {
            return OnHandHaveASameCardsCount(onHandCards, 2);
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

        public static bool OnHandIsThree_Of_A_Kind(List<Card> onHandCards)
        {
            return OnHandHaveASameCardsCount(onHandCards, 3);
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
            return OnHandIsPair(onHandCards) && OnHandIsThree_Of_A_Kind(onHandCards);
        }

        public static bool OnHandIsFour_Of_A_Kind(List<Card> onHandCards)
        {
            return OnHandHaveASameCardsCount(onHandCards, 4);
        }
        #endregion

        #region SameCard
        private static bool OnHandHaveASameCardsCount(List<Card> onHandCards, int numberOfSameCardToCheck)
        {
            var rankCardGroupsCount = GetRankCardGroupsCount(onHandCards);

            foreach (var rankCardGroupCount in rankCardGroupsCount.Values)
                if (rankCardGroupCount == numberOfSameCardToCheck)
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

        public static ResultDual CompareThree_Of_A_Kind(List<Card> cardsOnHand1, List<Card> cardsOnHand2)
        {
            Hand.OrderCard(cardsOnHand1);
            Hand.OrderCard(cardsOnHand2);

            var three_Of_A_Kind_CardOnHand1 = GetThree_Of_A_KindCardOnHand(cardsOnHand1);
            var three_Of_A_Kind_CardOnHand2 = GetThree_Of_A_KindCardOnHand(cardsOnHand2);

            var resultDual = CompareScoring(three_Of_A_Kind_CardOnHand1, three_Of_A_Kind_CardOnHand2);

            if (resultDual == ResultDual.Draw)
                resultDual = CompareHighCard(cardsOnHand1, cardsOnHand2);
            return resultDual;
        }

        private static Card GetThree_Of_A_KindCardOnHand(List<Card> onHandCards)
        {
            return (from card in onHandCards
                    group card by card.Rank into rankGroupCard
                    where rankGroupCard.Count() == 3
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
            return CompareThree_Of_A_Kind(cardsOnHand1, cardsOnHand2);
        }

        public static ResultDual CompareFour_Of_A_Kind(List<Card> cardsOnHand1, List<Card> cardsOnHand2)
        {
            Hand.OrderCard(cardsOnHand1);
            Hand.OrderCard(cardsOnHand2);

            var four_Of_A_Kind_CardOnHand1 = GetFour_Of_A_KindCardOnHand(cardsOnHand1);
            var four_Of_A_Kind_CardOnHand2 = GetFour_Of_A_KindCardOnHand(cardsOnHand2);

            var resultDual = CompareScoring(four_Of_A_Kind_CardOnHand1, four_Of_A_Kind_CardOnHand2);

            if (resultDual == ResultDual.Draw)
                resultDual = CompareHighCard(cardsOnHand1, cardsOnHand2);
            return resultDual;
        }

        private static Card GetFour_Of_A_KindCardOnHand(List<Card> onHandCards)
        {
            return (from card in onHandCards
                    group card by card.Rank into rankGroupCard
                    where rankGroupCard.Count() == 4
                    select rankGroupCard).First().First();
        }
    }
}
