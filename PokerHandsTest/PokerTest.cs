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

        List<Card> onHandCards23456Dummy;
        List<Card> onHandCards34567Dummy;

        List<Card> onHandCards22345Dummy;
        List<Card> onHandCards23345Dummy;


        public PokerTest()
        {
            onHandCards23456Dummy = new List<Card>()
            {
                dummyCardRank2, dummyCardRank3, dummyCardRank4, dummyCardRank5, dummyCardRank6
            };

            onHandCards34567Dummy = new List<Card>()
            {
                dummyCardRank3, dummyCardRank4, dummyCardRank5, dummyCardRank6, dummyCardRank7
            };

            onHandCards22345Dummy = new List<Card>()
            {
                dummyCardRank2, dummyCardRank2,
                dummyCardRank3, dummyCardRank4, dummyCardRank5
            };

            onHandCards23345Dummy = new List<Card>()
            {
                dummyCardRank2, 
                dummyCardRank3, dummyCardRank3,
                dummyCardRank4, dummyCardRank5
            };
        }

        #region RecognizeCatagory
        [Test]
        public void OnHandIs_22345_CategoryShouldBe_Pair()
        {
            Assert.AreEqual(Poker.Category.Pair, Poker.RecognizeCategory(onHandCards22345Dummy));
        }

        [Test]
        public void OnHandIs_23456_CategoryShouldBe_HighCard()
        {
            Assert.AreEqual(Poker.Category.HighCard, Poker.RecognizeCategory(onHandCards23456Dummy));
        }
        #endregion

        #region CompareScoring
        [Test]
        public void CompareScoring_2Vs3_ResultDual_ShouldBe_Lose()
        {
            Assert.AreEqual(ResultDual.Lose, Poker.CompareScoring(dummyCardRank2, dummyCardRank3));
        }

        [Test]
        public void CompareScoring_3Vs2_ResultDual_ShouldBe_Win()
        {
            Assert.AreEqual(ResultDual.Win, Poker.CompareScoring(dummyCardRank3, dummyCardRank2));
        }

        [Test]
        public void CompareScoring_2VsJack_ResultDual_ShouldBe_Lose()
        {
            Assert.AreEqual(ResultDual.Lose, Poker.CompareScoring(dummyCardRank2, dummyCardRankJack));
        }

        [Test]
        public void CompareScoring_2Vs2_ResultDual_ShouldBe_Draw()
        {
            Assert.AreEqual(ResultDual.Draw, Poker.CompareScoring(dummyCardRank2, dummyCardRank2));
        }

        [Test]
        public void CompareScoring_2VsAce_ResultDual_ShouldBe_Lose()
        {
            Assert.AreEqual(ResultDual.Lose, Poker.CompareScoring(dummyCardRank2, dummyCardRankAce));
        }

        [Test]
        public void CompareScoring_AceVs2_ResultDual_ShouldBe_Win()
        {
            Assert.AreEqual(ResultDual.Win, Poker.CompareScoring(dummyCardRankAce, dummyCardRank2));
        }

        [Test]
        public void CompareScoring_AceVsKing_ResultDual_ShouldBe_Win()
        {
            Assert.AreEqual(ResultDual.Win, Poker.CompareScoring(dummyCardRankAce, dummyCardRankKing));
        }

        [Test]
        public void CompareScoring_QueenVsAce_ResultDual_ShouldBe_Lose()
        {
            Assert.AreEqual(ResultDual.Lose, Poker.CompareScoring(dummyCardRankQueen, dummyCardRankAce));
        }

        [Test]
        public void CompareScoring_5VsKing_ResultDual_ShouldBe_Lose()
        {
            Assert.AreEqual(ResultDual.Lose, Poker.CompareScoring(dummyCardRank5, dummyCardRankKing));
        }

        [Test]
        public void CompareScoring_KingVs5_ResultDual_ShouldBe_Win()
        {
            Assert.AreEqual(ResultDual.Win, Poker.CompareScoring(dummyCardRankKing, dummyCardRank5));
        }
        #endregion

        #region CompareHighCard
        [Test]
        public void CompareHighCard_HandOneIs_23456_And_HandTwoIs_34567_ShouldBe_Lose()
        {
            Assert.AreEqual(ResultDual.Lose, 
                Poker.CompareHighCard(onHandCards23456Dummy, onHandCards34567Dummy));
        }

        [Test]
        public void CompareHighCard_HandOneIs_A23K5_And_HandTwoIs_10J6K7_ShouldBe_Win()
        {
            List<Card> onHandCards1 = new List<Card>()
            {
                dummyCardRankAce, dummyCardRank2, dummyCardRank3, dummyCardRankKing, dummyCardRank5
            };

            List<Card> onHandCards2 = new List<Card>()
            {
                dummyCardRank10, dummyCardRankJack, dummyCardRank6, dummyCardRankKing, dummyCardRank7
            };

            Assert.AreEqual(ResultDual.Win, Poker.CompareHighCard(onHandCards1, onHandCards2));
        }

        [Test]
        public void CompareHighCard_HandOneIs_AKQJT_And_HandTwoIs_AQJT9_ShouldBe_Win()
        {
            List<Card> onHandCards1 = new List<Card>()
            {
                dummyCardRankAce, dummyCardRankKing, dummyCardRankQueen, dummyCardRankJack, dummyCardRank10
            };

            List<Card> onHandCards2 = new List<Card>()
            {
                dummyCardRankAce, dummyCardRankQueen, dummyCardRankJack, dummyCardRank10, dummyCardRank9
            };

            Assert.AreEqual(ResultDual.Win, Poker.CompareHighCard(onHandCards1, onHandCards2));
        }

        [Test]
        public void CompareHighCard_HandOneIs_AKQJ9_And_HandTwoIs_AKQJT_ShouldBe_Lose()
        {
            List<Card> onHandCards1 = new List<Card>()
            {
                dummyCardRankAce, dummyCardRankKing, dummyCardRankQueen, dummyCardRankJack, dummyCardRank9
            };

            List<Card> onHandCards2 = new List<Card>()
            {
                dummyCardRankAce, dummyCardRankKing, dummyCardRankQueen, dummyCardRankJack, dummyCardRank10
            };

            Assert.AreEqual(ResultDual.Lose, Poker.CompareHighCard(onHandCards1, onHandCards2));
        }

        [Test]
        public void CompareHighCard_HandOneIs_AKQJT_And_HandTwoIs_AKQJT_ShouldBe_Draw()
        {
            List<Card> onHandCards1 = new List<Card>()
            {
                dummyCardRankAce, dummyCardRankKing, dummyCardRankQueen, dummyCardRankJack, dummyCardRank10
            };

            List<Card> onHandCards2 = new List<Card>()
            {
                dummyCardRankAce, dummyCardRankKing, dummyCardRankQueen, dummyCardRankJack, dummyCardRank10
            };

            Assert.AreEqual(ResultDual.Draw, Poker.CompareHighCard(onHandCards1, onHandCards2));
        }
        #endregion

        #region Pair
        [Test]
        public void ComparePairValue_HandOneIs_22345_And_HandTwoIs_23345_ResultShouldBe_Lose()
        {
            Assert.AreEqual(ResultDual.Lose, 
                Poker.ComparePair(onHandCards22345Dummy, onHandCards23345Dummy));
        }

        [Test]
        public void ComparePairValue_HandOneIs_23345_And_HandTwoIs_22345_ResultShouldBe_Win()
        {
            Assert.AreEqual(ResultDual.Win, 
                Poker.ComparePair(onHandCards23345Dummy, onHandCards22345Dummy));
        }

        [Test]
        public void ComparePairValue_HandOneIs_22356_And_HandTwoIs_22456_ResultShouldBe_Lose()
        {
            var onHand22356 = new List<Card>()
            {
                dummyCardRank2, dummyCardRank2,
                dummyCardRank3, dummyCardRank5, dummyCardRank6
            };

            var onHand22456 = new List<Card>()
            {
                dummyCardRank2, dummyCardRank2,
                dummyCardRank4, dummyCardRank5, dummyCardRank6
            };

            Assert.AreEqual(ResultDual.Lose, Poker.ComparePair(onHand22356, onHand22456));
        }
        #endregion
    }
}
