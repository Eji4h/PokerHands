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
        public void ConvertCharToSuit_ShouldBe_Club_WhenInputIsC()
        {
            Assert.AreEqual(SuitType.Club, Converter.CharToSuit('C'));
        }

        [Test]
        public void ConvertCharToSuit_ShouldBe_Diamond_WhenInputIsD()
        {
            Assert.AreEqual(SuitType.Diamond, Converter.CharToSuit('D'));
        }

        [Test]
        public void ConvertCharToSuit_ShouldBe_Heart_WhenInputIsH()
        {
            Assert.AreEqual(SuitType.Heart, Converter.CharToSuit('H'));
        }

        [Test]
        public void ConvertCharToSuit_ShouldBe_Spade_WhenInputIsS()
        {
            Assert.AreEqual(SuitType.Spade, Converter.CharToSuit('S'));
        }

        [Test]
        public void ConvertStringToRank_ShouldBe_2_WhenInputIs2()
        {
            Assert.AreEqual(RankType.Two, Converter.StringToRank("2"));
        }
    }
}
