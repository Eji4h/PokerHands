using NUnit.Framework;
using PokerHands;
using SuitType = PokerHands.Card.SuitType;
using RankType = PokerHands.Card.RankType;

namespace PokerHandsTest
{
    [TestFixture]
    class CardTest
    {
        SuitType dummyCardSuit = SuitType.Club;
        RankType dummyCardRank = RankType.Two;

        [Test]
        public void TestCardSuitIsClub()
        {
            Card cardSuitClub = new Card(SuitType.Club, dummyCardRank);
            Assert.AreEqual(SuitType.Club, cardSuitClub.Suit);
        }

        [Test]
        public void TestCardSuitIsDiamond()
        {
            Card cardSuitDiamond = new Card(SuitType.Diamond, dummyCardRank);
            Assert.AreEqual(SuitType.Diamond, cardSuitDiamond.Suit);
        }

        [Test]
        public void TestCardSuitIsHeart()
        {
            Card cardSuitHeart = new Card(SuitType.Heart, dummyCardRank);
            Assert.AreEqual(SuitType.Heart, cardSuitHeart.Suit);
        }

        [Test]
        public void TestCardSuitIsSpade()
        {
            Card cardSuitSpade = new Card(SuitType.Spade, dummyCardRank);
            Assert.AreEqual(SuitType.Spade, cardSuitSpade.Suit);
        }

        [Test]
        public void TestCardRankIs2()
        {
            Card cardRank2 = new Card(dummyCardSuit, RankType.Two);
            Assert.AreEqual(2, (int)cardRank2.Rank);
        }

        [Test]
        public void TestCardRankIs10()
        {
            Card cardRank10 = new Card(dummyCardSuit, RankType.Ten);
            Assert.AreEqual(10, (int)cardRank10.Rank);
        }

        [Test]
        public void TestCardRankIsJack()
        {
            Card cardRankJ = new Card(dummyCardSuit, RankType.Jack);
            Assert.AreEqual(RankType.Jack, cardRankJ.Rank);
        }
    }
}
