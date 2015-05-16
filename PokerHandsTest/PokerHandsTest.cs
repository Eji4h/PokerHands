using System;
using NUnit.Framework;
using PokerHands;

namespace PokerHandsTest
{
    [TestFixture]
    public class PokerHandsTest
    {
        int dummyCardValue = 2;

        [Test]
        public void TestPokerDeckContains_52_Cards()
        {
            Assert.AreEqual(52, new Deck().Amount());
        }

        [Test]
        public void TestCardSuitIsClub()
        {
            Assert.AreEqual(Card.SuitType.C, new Card(Card.SuitType.C, dummyCardValue).Suit);
        }

        [Test]
        public void TestCardSuitIsDiamond()
        {
            Assert.AreEqual(Card.SuitType.D, new Card(Card.SuitType.D, dummyCardValue).Suit);
        }

        [Test]
        public void TestCardSuitIsHeart()
        {
            Assert.AreEqual(Card.SuitType.H, new Card(Card.SuitType.H, dummyCardValue).Suit);
        }

        [Test]
        public void TestCardSuitIsSpades()
        {
            Assert.AreEqual(Card.SuitType.S, new Card(Card.SuitType.S, dummyCardValue).Suit);
        }

        [Test]
        public void TestCardValueIs2()
        {
            Assert.AreEqual(2, new Card(Card.SuitType.C, 2).GetValue());
        }
    }
}
