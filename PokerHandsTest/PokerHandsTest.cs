using System;
using NUnit.Framework;
using PokerHands;

namespace PokerHandsTest
{
    [TestFixture]
    public class PokerHandsTest
    {
        [Test]
        public void TestPokerDeckContains_52_Cards()
        {
            Assert.AreEqual(52, new Deck().Amount());
        }

        [Test]
        public void TestCardSuitIsClub()
        {
            Assert.AreEqual(Card.SuitType.C, new Card(Card.SuitType.C).Suit);
        }

        [Test]
        public void TestCardSuitIsDiamond()
        {
            Assert.AreEqual(Card.SuitType.D, new Card(Card.SuitType.D).Suit);
        }

        [Test]
        public void TestCardSuitIsHeart()
        {
            Assert.AreEqual(Card.SuitType.H, new Card(Card.SuitType.H).Suit);
        }

        [Test]
        public void TestCardSuitIsSpades()
        {
            Assert.AreEqual(Card.SuitType.S, new Card(Card.SuitType.S).Suit);
        }
    }
}
