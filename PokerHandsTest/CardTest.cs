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
        public void CardSuitClub_ShouldBe_Club()
        {
            Card cardSuitClub = new Card(SuitType.Club, dummyCardRank);
            Assert.AreEqual(SuitType.Club, cardSuitClub.Suit);
        }

        [Test]
        public void CardSuitDiamond_ShouldBe_Diamond()
        {
            Card cardSuitDiamond = new Card(SuitType.Diamond, dummyCardRank);
            Assert.AreEqual(SuitType.Diamond, cardSuitDiamond.Suit);
        }

        [Test]
        public void CardSuitHeart_ShouldBe_Heart()
        {
            Card cardSuitHeart = new Card(SuitType.Heart, dummyCardRank);
            Assert.AreEqual(SuitType.Heart, cardSuitHeart.Suit);
        }

        [Test]
        public void CardSuitSpade_ShouldBe_Spade()
        {
            Card cardSuitSpade = new Card(SuitType.Spade, dummyCardRank);
            Assert.AreEqual(SuitType.Spade, cardSuitSpade.Suit);
        }

        [Test]
        public void CardRank2_ShouldBe_2()
        {
            Card cardRank2 = new Card(dummyCardSuit, RankType.Two);
            Assert.AreEqual(2, (int)cardRank2.Rank);
        }

        [Test]
        public void CardRank10_ShouldBe_10()
        {
            Card cardRank10 = new Card(dummyCardSuit, RankType.Ten);
            Assert.AreEqual(10, (int)cardRank10.Rank);
        }

        [Test]
        public void CardRankJack_ShouldBe_Jack()
        {
            Card cardRankJ = new Card(dummyCardSuit, RankType.Jack);
            Assert.AreEqual(RankType.Jack, cardRankJ.Rank);
        }

        [Test]
        public void Card_IsEquals_ShouldBe_False_WhenInputIs_AceClub_And_2Spade()
        {
            var card1 = new Card(SuitType.Club, RankType.Ace);
            var card2 = new Card(SuitType.Spade, RankType.Two);

            Assert.False(Card.IsEquals(card1, card2));
        }
    }
}
