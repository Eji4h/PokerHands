using NUnit.Framework;
using PokerHands;
using SuitType = PokerHands.Card.SuitType;
using RankType = PokerHands.Card.RankType;

namespace PokerHandsTest
{
    [TestFixture]
    class HandTest
    {
        [Test]
        public void NumberCardOnHandIs5()
        {
            Assert.AreEqual(5, new Hand().GetCards().Length);
        }

        [Test]
        public void OrderCardOnHand_65432_ShouldBe_23456()
        {
            Card cardRank2 = new Card(SuitType.Club, RankType.Two);
            Card cardRank3 = new Card(SuitType.Club, RankType.Three);
            Card cardRank4 = new Card(SuitType.Club, RankType.Four);
            Card cardRank5 = new Card(SuitType.Club, RankType.Five);
            Card cardRank6 = new Card(SuitType.Club, RankType.Six);

            Card[] cardsShouldBeOrder = new Card[5]
            {
                cardRank2, cardRank3, cardRank4, cardRank5, cardRank6
            };

            Card[] cardsInput = new Card[5]
            {
                cardRank6, cardRank5, cardRank4, cardRank3, cardRank2
            };

            CollectionAssert.AreEqual(cardsShouldBeOrder, Hand.OrderCard(cardsInput));
        }
    }
}
