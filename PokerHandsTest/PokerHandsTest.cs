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
            Assert.AreEqual('C', new Card('C').GetSuit());
        }

        [Test]
        public void TestCardSuitIsDiamond()
        {
            Assert.AreEqual('D', new Card('D').GetSuit());
        }

        [Test]
        public void TestCardSuitIsHeart()
        {
            Assert.AreEqual('H', new Card('H').GetSuit());
        }

        [Test]
        public void TestCardSuitIsSpades()
        {
            Assert.AreEqual('S', new Card('S').GetSuit());
        }
    }
}
