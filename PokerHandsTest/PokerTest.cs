using NUnit.Framework;
using PokerHands;
using System;
using System.Collections.Generic;
using RankType = PokerHands.Card.RankType;
using ResultDual = PokerHands.Poker.ResultDual;
using SuitType = PokerHands.Card.SuitType;

namespace PokerHandsTest
{
    [TestFixture]
    public class PokerTest
    {
        SuitType dummyCardSuit = SuitType.Club;
        RankType dummyCardRank = RankType.Two;

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
        public void CompareScoring_2Vs3_ResultDualIsLose()
        {
            Card card1 = new Card(dummyCardSuit, RankType.Two);
            Card card2 = new Card(dummyCardSuit, RankType.Three);
            Assert.AreEqual(ResultDual.Lose, Poker.CompareScoring(card1, card2));
        }

        [Test]
        public void CompareScoring_3Vs2_ResultDualIsWin()
        {
            Card card1 = new Card(dummyCardSuit, RankType.Three);
            Card card2 = new Card(dummyCardSuit, RankType.Two);
            Assert.AreEqual(ResultDual.Win, Poker.CompareScoring(card1, card2));
        }

        [Test]
        public void CompareScoring_2VsJack_ResultDualIsLose()
        {
            Card card1 = new Card(dummyCardSuit, RankType.Two);
            Card card2 = new Card(dummyCardSuit, RankType.Jack);
            Assert.AreEqual(ResultDual.Lose, Poker.CompareScoring(card1, card2));
        }

        [Test]
        public void CompareScoring_2Vs2_ResultDualIsDraw()
        {
            Card card1 = new Card(dummyCardSuit, RankType.Two);
            Card card2 = new Card(dummyCardSuit, RankType.Two);
            Assert.AreEqual(ResultDual.Draw, Poker.CompareScoring(card1, card2));
        }

        [Test]
        public void CompareScoring_2VsAce_ResultDualIsLose()
        {
            Card card1 = new Card(dummyCardSuit, RankType.Two);
            Card card2 = new Card(dummyCardSuit, RankType.Ace);
            Assert.AreEqual(ResultDual.Lose, Poker.CompareScoring(card1, card2));
        }

        [Test]
        public void CompareScoring_AceVs2_ResultDualIsWin()
        {
            Card card1 = new Card(dummyCardSuit, RankType.Ace);
            Card card2 = new Card(dummyCardSuit, RankType.Two);
            Assert.AreEqual(ResultDual.Win, Poker.CompareScoring(card1, card2));
        }

        [Test]
        public void CompareScoring_AceVsKing_ResultDualIsWin()
        {
            Card card1 = new Card(dummyCardSuit, RankType.Ace);
            Card card2 = new Card(dummyCardSuit, RankType.King);
            Assert.AreEqual(ResultDual.Win, Poker.CompareScoring(card1, card2));
        }

        [Test]
        public void CompareScoring_QueenVsAce_ResultDualIsLose()
        {
            Card card1 = new Card(dummyCardSuit, RankType.Queen);
            Card card2 = new Card(dummyCardSuit, RankType.Ace);
            Assert.AreEqual(ResultDual.Lose, Poker.CompareScoring(card1, card2));
        }

        [Test]
        public void CompareScoring_5VsKing_ResultDualIsLose()
        {
            Card card1 = new Card(dummyCardSuit, RankType.Five);
            Card card2 = new Card(dummyCardSuit, RankType.King);
            Assert.AreEqual(ResultDual.Lose, Poker.CompareScoring(card1, card2));
        }

        [Test]
        public void CompareScoring_KingVs5_ResultDualIsWin()
        {
            Card card1 = new Card(dummyCardSuit, RankType.King);
            Card card2 = new Card(dummyCardSuit, RankType.Five);
            Assert.AreEqual(ResultDual.Win, Poker.CompareScoring(card1, card2));
        }

        [Test]
        public void CompareHighCard_HandOneIs_23456_And_HandTwoIs_34567_ShouldBe_Lose()
        {
            List<Card> cardsOnHand1 = new List<Card>()
            {
                dummyCardRank2, dummyCardRank3, dummyCardRank4, dummyCardRank5, dummyCardRank6
            };

            List<Card> cardsOnHand2 = new List<Card>()
            {
                dummyCardRank3, dummyCardRank4, dummyCardRank5, dummyCardRank6, dummyCardRank7
            };

            Assert.AreEqual(ResultDual.Lose, Poker.CompareHighCard(cardsOnHand1, cardsOnHand2));
        }

        [Test]
        public void CompareHighCard_HandOneIs_A23K5_And_HandTwoIs_10J6K7_ShouldBe_Win()
        {
            List<Card> cardsOnHand1 = new List<Card>()
            {
                dummyCardRankAce, dummyCardRank2, dummyCardRank3, dummyCardRankKing, dummyCardRank5
            };

            List<Card> cardsOnHand2 = new List<Card>()
            {
                dummyCardRank10, dummyCardRankJack, dummyCardRank6, dummyCardRankKing, dummyCardRank7
            };

            Assert.AreEqual(ResultDual.Win, Poker.CompareHighCard(cardsOnHand1, cardsOnHand2));
        }
    }
}
