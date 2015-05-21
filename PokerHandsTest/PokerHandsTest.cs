using System;
using NUnit.Framework;
using PokerHands;
using SuitType = PokerHands.Card.SuitType;
using ValueType = PokerHands.Card.ValueType;
using ResultDual = PokerHands.Poker.ResultDual;

namespace PokerHandsTest
{
    [TestFixture]
    public class PokerHandsTest
    {
        SuitType dummyCardSuit = SuitType.Club;
        ValueType dummyCardValue = ValueType.Two;

        [Test]
        public void CompareScoring_2Vs3_2IsLose()
        {
            Card card1 = new Card(dummyCardSuit, ValueType.Two);
            Card card2 = new Card(dummyCardSuit, ValueType.Three);
            Assert.AreEqual(ResultDual.Lose, Poker.Compare(card1, card2));
        }
    }
}
