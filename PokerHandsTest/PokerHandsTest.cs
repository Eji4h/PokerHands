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
        public void CompareScoring_2Vs3_ResultDualIsLose()
        {
            Card card1 = new Card(dummyCardSuit, ValueType.Two);
            Card card2 = new Card(dummyCardSuit, ValueType.Three);
            Assert.AreEqual(ResultDual.Lose, Poker.Compare(card1, card2));
        }

        [Test]
        public void CompareScoring_3Vs2_ResultDualIsWin()
        {
            Card card1 = new Card(dummyCardSuit, ValueType.Three);
            Card card2 = new Card(dummyCardSuit, ValueType.Two);
            Assert.AreEqual(ResultDual.Win, Poker.Compare(card1, card2));
        }

        [Test]
        public void CompareScoring_2VsJack_ResultDualIsLose()
        {
            Card card1 = new Card(dummyCardSuit, ValueType.Two);
            Card card2 = new Card(dummyCardSuit, ValueType.Jack);
            Assert.AreEqual(ResultDual.Lose, Poker.Compare(card1, card2));
        }

        [Test]
        public void CompareScoring_2Vs2_ResultDualIsDraw()
        {
            Card card1 = new Card(dummyCardSuit, ValueType.Two);
            Card card2 = new Card(dummyCardSuit, ValueType.Two);
            Assert.AreEqual(ResultDual.Draw, Poker.Compare(card1, card2));
        }

        [Test]
        public void CompareScoring_2VsAce_ResultDualIsLose()
        {
            Card card1 = new Card(dummyCardSuit, ValueType.Two);
            Card card2 = new Card(dummyCardSuit, ValueType.Ace);
            Assert.AreEqual(ResultDual.Lose, Poker.Compare(card1, card2));
        }

        [Test]
        public void CompareScoring_AceVs2_ResultDualIsWin()
        {
            Card card1 = new Card(dummyCardSuit, ValueType.Ace);
            Card card2 = new Card(dummyCardSuit, ValueType.Two);
            Assert.AreEqual(ResultDual.Win, Poker.Compare(card1, card2));
        }
    }
}
