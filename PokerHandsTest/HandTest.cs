using NUnit.Framework;
using PokerHands;
using System.Collections.Generic;
using RankType = PokerHands.Card.RankType;
using SuitType = PokerHands.Card.SuitType;

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
        Card dummyCardRank7 = new Card(SuitType.Club, RankType.Seven);
        Card dummyCardRank8 = new Card(SuitType.Club, RankType.Eight);
        Card dummyCardRank9 = new Card(SuitType.Club, RankType.Nine);
        Card dummyCardRank10 = new Card(SuitType.Club, RankType.Ten);
        Card dummyCardRankJack = new Card(SuitType.Club, RankType.Jack);
        Card dummyCardRankQueen = new Card(SuitType.Club, RankType.Queen);
        Card dummyCardRankKing = new Card(SuitType.Club, RankType.King);
        Card dummyCardRankAce = new Card(SuitType.Club, RankType.Ace);

        [Test]
        public void NumberCardOnHandIs5()
        {
            Assert.AreEqual(5, new Hand().GetCards().Capacity);
        }

        [Test]
        public void OrderCardOnHand_65432_ShouldBe_23456()
        {
            List<Card> cardsShouldBeOrder = new List<Card>(5)
            {
                dummyCardRank2, dummyCardRank3, dummyCardRank4, dummyCardRank5, dummyCardRank6
            };

            List<Card> cardsInput = new List<Card>(5)
            {
                dummyCardRank6, dummyCardRank5, dummyCardRank4, dummyCardRank3, dummyCardRank2
            };

            Hand.OrderCard(cardsInput);
            CollectionAssert.AreEqual(cardsShouldBeOrder, cardsInput);
        }

        [Test]
        public void OrderCardOnHand_AceJackKingQueen10_ShouldBe_10JackQueenKingAce()
        {
            List<Card> cardsShouldBeOrder = new List<Card>(5)
            {
                dummyCardRank10, dummyCardRankJack, dummyCardRankQueen, dummyCardRankKing, dummyCardRankAce
            };

            List<Card> cardsInput = new List<Card>(5)
            {
                dummyCardRankAce, dummyCardRankJack, dummyCardRankKing, dummyCardRankQueen, dummyCardRank10
            };

            Hand.OrderCard(cardsInput);
            CollectionAssert.AreEqual(cardsShouldBeOrder, cardsInput);
        }
    }
}
