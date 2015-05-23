using NUnit.Framework;
using PokerHands;
using SuitType = PokerHands.Card.SuitType;
using RankType = PokerHands.Card.RankType;

namespace PokerHandsTest
{
    [TestFixture]
    class HandTest
    {
        Card dummyCardRank2 = new Card(SuitType.Club, RankType.Two);
        Card dummyCardRank3 = new Card(SuitType.Club, RankType.Three);
        Card dummyCardRank4 = new Card(SuitType.Club, RankType.Four);
        Card dummyCardRank5 = new Card(SuitType.Club, RankType.Five);
        Card dummyCardRank6 = new Card(SuitType.Club, RankType.Six);


        [Test]
        public void NumberCardOnHandIs5()
        {
            Assert.AreEqual(5, new Hand().GetCards().Length);
        }

        [Test]
        public void OrderCardOnHand_65432_ShouldBe_23456()
        {
            Card[] cardsShouldBeOrder = new Card[5]
            {
                dummyCardRank2, dummyCardRank3, dummyCardRank4, dummyCardRank5, dummyCardRank6
            };

            Card[] cardsInput = new Card[5]
            {
                dummyCardRank6, dummyCardRank5, dummyCardRank4, dummyCardRank3, dummyCardRank2
            };
            Hand.OrderCard(cardsInput);
            CollectionAssert.AreEqual(cardsShouldBeOrder, cardsInput);
        }
    }
}
