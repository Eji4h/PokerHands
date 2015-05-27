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
                new Card(dummyCardSuit, RankType.Two),
                new Card(dummyCardSuit, RankType.Three),
                new Card(dummyCardSuit, RankType.Four),
                new Card(dummyCardSuit, RankType.Five),
                new Card(dummyCardSuit, RankType.Six)
            };

            List<Card> cardsOnHand2 = new List<Card>()
            {
                new Card(dummyCardSuit, RankType.Three),
                new Card(dummyCardSuit, RankType.Four),
                new Card(dummyCardSuit, RankType.Five),
                new Card(dummyCardSuit, RankType.Six),
                new Card(dummyCardSuit, RankType.Seven)
            };

            Assert.AreEqual(ResultDual.Lose, Poker.CompareHighCard(cardsOnHand1, cardsOnHand2));
        }
    }
}
