using NUnit.Framework;
using PokerHands;
using System;
using System.Collections.Generic;
using RankType = PokerHands.Card.RankType;
using ResultDual = PokerHands.Poker.ResultDual;
using SuitType = PokerHands.Card.SuitType;
using Category = PokerHands.Poker.Category;

namespace PokerHandsTest
{
    [TestFixture]
    class PokerHandsDualTest
    {
        [Test]
        public void OutputShouldBe_White_wins_straight_flush_WhenBlackCardsIs_1C_2C_3C_4C_5C_And_WhiteCardsIs_7H_8H_9H_10H_JH()
        {
            string expected = "White wins - straight flush";

            var blackCards = Converter.ToCardsList("1C 2C 3C 4C 5C");
            var whiteCards = Converter.ToCardsList("7H 8H 9H 10H JH");

            Assert.AreEqual(expected, PokerHandsDual.GetResultDual(blackCards, whiteCards));
        }

        [Test]
        public void OutputShouldBe_Black_wins_full_house_WhenBlackCardsIs_2H_4S_4C_2D_4H_And_WhiteCardsIs_2S_8S_AS_QS_3S()
        {
            string expected = "Black wins - full house";

            var blackCards = Converter.ToCardsList("2H 4S 4C 2D 4H");
            var whiteCards = Converter.ToCardsList("2S 8S AS QS 3S");

            Assert.AreEqual(expected, PokerHandsDual.GetResultDual(blackCards, whiteCards));
        }

        [Test]
        public void OutputShouldBe_White_wins_high_card_Ace_WhenBlackCardsIs_2H_3D_5S_9C_KD_And_WhiteCardsIs_2C_3H_4S_8C_AH()
        {
            string expected = "White wins - high card: Ace";

            var blackCards = Converter.ToCardsList("2H 3D 5S 9C KD");
            var whiteCards = Converter.ToCardsList("2C 3H 4S 8C AH");

            Assert.AreEqual(expected, PokerHandsDual.GetResultDual(blackCards, whiteCards));
        }

        [Test]
        public void OutputShouldBe_Tie_WhenBlackCardsIs_2H_3D_5S_9C_KD_And_WhiteCardsIs_2H_3D_5S_9C_KD()
        {
            string expected = "Tie";

            var blackCards = Converter.ToCardsList("2H 3D 5S 9C KD");
            var whiteCards = Converter.ToCardsList("2H 3D 5S 9C KD");

            Assert.AreEqual(expected, PokerHandsDual.GetResultDual(blackCards, whiteCards));
        }

        [Test]
        public void ChangeCategoryForDisplay_ShouldBe_high_card_WhenInputIs_HighCard()
        {
            Assert.AreEqual("high card", PokerHandsDual.ChangeCategoryForDisplay(Category.HighCard));
        }

        [Test]
        public void ChangeCategoryForDisplay_ShouldBe_pair_WhenInputIs_Pair()
        {
            Assert.AreEqual("pair", PokerHandsDual.ChangeCategoryForDisplay(Category.Pair));
        }

        [Test]
        public void ChangeCategoryForDisplay_ShouldBe_two_pairs_WhenInputIs_TwoPairs()
        {
            Assert.AreEqual("two pairs", PokerHandsDual.ChangeCategoryForDisplay(Category.TwoPairs));
        }

        [Test]
        public void ChangeCategoryForDisplay_ShouldBe_three_of_a_Kind_WhenInputIs_ThreeOfA_Kind()
        {
            Assert.AreEqual("three of a kind", PokerHandsDual.ChangeCategoryForDisplay(Category.ThreeOfA_Kind));
        }

        [Test]
        public void ChangeCategoryForDisplay_ShouldBe_straight_WhenInputIs_Straight()
        {
            Assert.AreEqual("straight", PokerHandsDual.ChangeCategoryForDisplay(Category.Straight));
        }

        [Test]
        public void ChangeCategoryForDisplay_ShouldBe_flush_WhenInputIs_Flush()
        {
            Assert.AreEqual("flush", PokerHandsDual.ChangeCategoryForDisplay(Category.Flush));
        }

        [Test]
        public void ChangeCategoryForDisplay_ShouldBe_full_house_WhenInputIs_FullHouse()
        {
            Assert.AreEqual("full house", PokerHandsDual.ChangeCategoryForDisplay(Category.FullHouse));
        }

        [Test]
        public void ChangeCategoryForDisplay_ShouldBe_four_of_a_Kind_WhenInputIs_FourOfA_Kind()
        {
            Assert.AreEqual("four of a kind", PokerHandsDual.ChangeCategoryForDisplay(Category.FourOfA_Kind));
        }

        [Test]
        public void ChangeCategoryForDisplay_ShouldBe_straight_flush_WhenInputIs_StraightFlush()
        {
            Assert.AreEqual("straight flush", PokerHandsDual.ChangeCategoryForDisplay(Category.StraightFlush));
        }

        [Test]
        public void ChangeCategoryForDisplay_ShouldBe_royal_straight_flush_WhenInputIs_RoyalStraightFlush()
        {
            Assert.AreEqual("royal straight flush", PokerHandsDual.ChangeCategoryForDisplay(Category.RoyalStraightFlush));
        }
    }
}
