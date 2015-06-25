﻿using NUnit.Framework;
using PokerHands;
using System;
using System.Collections.Generic;
using RankType = PokerHands.Card.RankType;
using ResultDual = PokerHands.Poker.ResultDual;
using SuitType = PokerHands.Card.SuitType;

namespace PokerHandsTest
{
    [TestFixture]
    class ConverterTest
    {
        [Test]
        public void ConvertToSuit_ShouldBe_Club_WhenInputIsC()
        {
            Assert.AreEqual(SuitType.Club, Converter.ToSuit('C'));
        }

        [Test]
        public void ConvertToSuit_ShouldBe_Diamond_WhenInputIsD()
        {
            Assert.AreEqual(SuitType.Diamond, Converter.ToSuit('D'));
        }

        [Test]
        public void ConvertToSuit_ShouldBe_Heart_WhenInputIsH()
        {
            Assert.AreEqual(SuitType.Heart, Converter.ToSuit('H'));
        }

        [Test]
        public void ConvertToSuit_ShouldBe_Spade_WhenInputIsS()
        {
            Assert.AreEqual(SuitType.Spade, Converter.ToSuit('S'));
        }

        [Test]
        public void ConvertToRank_ShouldBe_2_WhenInputIs2()
        {
            Assert.AreEqual(RankType.Two, Converter.ToRank("2"));
        }

        [Test]
        public void ConvertToRank_ShouldBe_10_WhenInputIs10()
        {
            Assert.AreEqual(RankType.Ten, Converter.ToRank("10"));
        }

        [Test]
        public void ConvertToRank_ShouldBe_Jack_WhenInputIsJ()
        {
            Assert.AreEqual(RankType.Jack, Converter.ToRank("J"));
        }

        [Test]
        public void ConvertToRank_ShouldBe_Queen_WhenInputIsQ()
        {
            Assert.AreEqual(RankType.Queen, Converter.ToRank("Q"));
        }

        [Test]
        public void ConvertToRank_ShouldBe_King_WhenInputIsK()
        {
            Assert.AreEqual(RankType.King, Converter.ToRank("K"));
        }

        [Test]
        public void ConvertToRank_ShouldBe_Ace_WhenInputIsA()
        {
            Assert.AreEqual(RankType.Ace, Converter.ToRank("A"));
        }

        [Test]
        public void ConvertToCard_ShouldBe_AceDiamond_WhenInputIs_AD()
        {
            var expectedCard = new Card(SuitType.Diamond, RankType.Ace);
            var actualCard = Converter.ToCard("AD");

            Assert.AreEqual(expectedCard.Suit, actualCard.Suit);
            Assert.AreEqual(expectedCard.Rank, actualCard.Rank);
        }

        [Test]
        public void ConvertToCard_ShouldBe_2Spade_WhenInputIs_2S()
        {
            var expectedCard = new Card(SuitType.Spade, RankType.Two);
            var actualCard = Converter.ToCard("2S");

            Assert.AreEqual(expectedCard.Suit, actualCard.Suit);
            Assert.AreEqual(expectedCard.Rank, actualCard.Rank);
        }

        [Test]
        public void ConvertToCard_ShouldBe_10Club_WhenInputIs_10C()
        {
            var expectedCard = new Card(SuitType.Club, RankType.Ten);
            var actualCard = Converter.ToCard("10C");

            Assert.AreEqual(expectedCard.Suit, actualCard.Suit);
            Assert.AreEqual(expectedCard.Rank, actualCard.Rank);
        }
    }
}
