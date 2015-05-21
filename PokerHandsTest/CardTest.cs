using NUnit.Framework;
using PokerHands;
using SuitType = PokerHands.Card.SuitType;
using ValueType = PokerHands.Card.ValueType;

namespace PokerHandsTest
{
    [TestFixture]
    class CardTest
    {
        SuitType dummyCardSuit = SuitType.Club;
        ValueType dummyCardValue = (ValueType)2;

        [Test]
        public void TestCardSuitIsClub()
        {
            Card cardSuitClub = new Card(SuitType.Club, dummyCardValue);
            Assert.AreEqual(SuitType.Club, cardSuitClub.Suit);
        }

        [Test]
        public void TestCardSuitIsDiamond()
        {
            Card cardSuitDiamond = new Card(SuitType.Diamond, dummyCardValue);
            Assert.AreEqual(SuitType.Diamond, cardSuitDiamond.Suit);
        }

        [Test]
        public void TestCardSuitIsHeart()
        {
            Card cardSuitHeart = new Card(SuitType.Heart, dummyCardValue);
            Assert.AreEqual(SuitType.Heart, cardSuitHeart.Suit);
        }

        [Test]
        public void TestCardSuitIsSpade()
        {
            Card cardSuitSpade = new Card(SuitType.Spade, dummyCardValue);
            Assert.AreEqual(SuitType.Spade, cardSuitSpade.Suit);
        }

        //[Test]
        //public void TestCardValueIs2()
        //{
        //    Card cardValue2 = new Card(dummyCardSuit, "2");
        //    Assert.AreEqual("2", cardValue2.Value);
        //}

        //[Test]
        //public void TestCardValueIs10()
        //{
        //    Card cardValueT = new Card(dummyCardSuit, "10");
        //    Assert.AreEqual("10", cardValueT.Value);
        //}

        //[Test]
        //public void TestCardValueIsJack()
        //{
        //    Card cardValueJ = new Card(dummyCardSuit, "Jack");
        //    Assert.AreEqual("Jack", cardValueJ.Value);
        //}
    }
}
