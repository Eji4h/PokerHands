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
        public void OutputShouldBe_Black_wins_full_house_WhenBlackCardsIs_2H_4S_4C_2D_4H_And_WhiteCardsIs_2S_8S_AS_QS_3S()
        {
            string expected = "Black wins - full house";

            var blackCards = Converter.ToCardsList("2H 4S 4C 2D 4H");
            var whiteCards = Converter.ToCardsList("2S 8S AS QS 3S");

            Assert.AreEqual(expected, PokerHandsDual.GetResualDual(blackCards, whiteCards));
        }

        [Test]
        public void ChangeCategoryForDisplay_ShouldBe_high_card_WhenInputIs_HighCard()
        {
            Assert.AreEqual("high card", PokerHandsDual.ChangeCategoryForDisplay(Category.HighCard));
        }
    }
}
