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

        Card dummyCardSuitClub = new Card(SuitType.Club, RankType.Seven);
        Card dummyCardSuitDiamond = new Card(SuitType.Diamond, RankType.Seven);
        Card dummyCardSuitHeart = new Card(SuitType.Heart, RankType.Seven);
        Card dummyCardSuitSpade = new Card(SuitType.Spade, RankType.Seven);

        Card dummyCardRankAceSuitClub = new Card(SuitType.Club, RankType.Ace);
        Card dummyCardRankAceSuitDiamond = new Card(SuitType.Diamond, RankType.Ace);
        Card dummyCardRankAceSuitHeart = new Card(SuitType.Heart, RankType.Ace);
        Card dummyCardRankAceSuitSpade = new Card(SuitType.Spade, RankType.Ace);

        [Test]
        public void NumberCardOnHandIs5()
        {
            Assert.AreEqual(5, new Hand().GetCards().Capacity);
        }

        [Test]
        public void OrderCardOnHandByRank_65432_ShouldBe_23456()
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
        public void OrderCardOnHandByRank_AceJackKingQueen10_ShouldBe_10JackQueenKingAce()
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

        [Test]
        public void OrderCardOnHandBySuit_HeartDiamondSpadeClub_ShouldBe_ClubDiamondHeartSpade()
        {
            List<Card> cardsShouldBeOrder = new List<Card>(4)
            {
                dummyCardSuitClub, dummyCardSuitDiamond, dummyCardSuitHeart, dummyCardSuitSpade
            };

            List<Card> cardsInput = new List<Card>(4)
            {
                dummyCardSuitHeart, dummyCardSuitDiamond, dummyCardSuitSpade, dummyCardSuitClub
            };

            Hand.OrderCard(cardsInput);
            CollectionAssert.AreEqual(cardsShouldBeOrder, cardsInput);
        }

        [Test]
        public void OrderCardOnHandAceBySuit_HeartDiamondSpadeClub_ShouldBe_ClubDiamondHeartSpade()
        {
            List<Card> cardsShouldBeOrder = new List<Card>(4)
            {
                dummyCardRankAceSuitClub, dummyCardRankAceSuitDiamond, 
                dummyCardRankAceSuitHeart, dummyCardRankAceSuitSpade
            };

            List<Card> cardsInput = new List<Card>(4)
            {
                dummyCardRankAceSuitHeart, dummyCardRankAceSuitDiamond, 
                dummyCardRankAceSuitSpade, dummyCardRankAceSuitClub
            };

            Hand.OrderCard(cardsInput);
            CollectionAssert.AreEqual(cardsShouldBeOrder, cardsInput);
        }

    }
}
