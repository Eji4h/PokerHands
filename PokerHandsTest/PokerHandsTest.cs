using System;
using NUnit.Framework;
using PokerHands;

namespace PokerHandsTest
{
    [TestFixture]
    public class PokerHandsTest
    {
        Card.SuitType dummyCardSuit = Card.SuitType.C;
        char dummyCardValue = '2';

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
            Assert.AreEqual('2', new Card(dummyCardSuit, '2').GetValue());
        }

        [Test]
        public void TestCardValueIsT()
        {
            Assert.AreEqual('T', new Card(dummyCardSuit, 'T').GetValue());
        }

        [Test]
        public void TestCardValueIsJ()
        {
            Assert.AreEqual('J', new Card(dummyCardSuit, 'J').GetValue());
        }

        [Test]
        public void CompareScoring_2Vs3_2IsLose()
        {
            Card card1 = new Card(dummyCardSuit, '2');
            Card card2 = new Card(dummyCardSuit, '3');
            Assert.AreEqual("Lose", Card.Compare(card1, card2));
        }
    }
}
