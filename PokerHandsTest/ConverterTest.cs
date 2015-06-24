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
    }
}
