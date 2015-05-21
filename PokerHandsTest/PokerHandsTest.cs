using System;
using NUnit.Framework;
using PokerHands;
using SuitType = PokerHands.Card.SuitType;

namespace PokerHandsTest
{
    [TestFixture]
    public class PokerHandsTest
    {
        SuitType dummyCardSuit = SuitType.Club;
        string dummyCardValue = "2";

        //[Test]
        //public void CompareScoring_2Vs3_2IsLose()
        //{
        //    Card card1 = new Card(dummyCardSuit, "2");
        //    Card card2 = new Card(dummyCardSuit, "3");
        //    Assert.AreEqual("Lose", Poker.Compare(card1, card2));
        //}
    }
}
