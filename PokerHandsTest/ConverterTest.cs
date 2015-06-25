using NUnit.Framework;
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
    }
}
