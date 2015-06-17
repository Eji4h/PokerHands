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

        #region RecognizeCatagory
        [Test]
        public void OnHandIs_77QQA_CategoryShouldBe_TwoPair()
        {
            var onHandCards = new List<Card>()
            {
                dummyCardRank7, dummyCardRank7, 
                dummyCardRankQueen, dummyCardRankQueen,
                dummyCardRankAce
            };

            Assert.AreEqual(Poker.Category.TwoPair, Poker.RecognizeCategory(onHandCards));
        }

        [Test]
        public void OnHandIs_22345_CategoryShouldBe_Pair()
        {
            var onHandCards = new List<Card>()
            {
                dummyCardRank2, dummyCardRank2,
                dummyCardRank3, dummyCardRank4, dummyCardRank5
            };

            Assert.AreEqual(Poker.Category.Pair, Poker.RecognizeCategory(onHandCards));
        }

        [Test]
        public void OnHandIs_23456_CategoryShouldBe_HighCard()
        {
            var onHandCards = new List<Card>()
            {
                dummyCardRank2, dummyCardRank3, dummyCardRank4, dummyCardRank5, dummyCardRank6
            };

            Assert.AreEqual(Poker.Category.HighCard, Poker.RecognizeCategory(onHandCards));
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
        public void CompareHighCard_HandOneIs_23456_And_HandTwoIs_34567_ResultDual_ShouldBe_Lose()
        {
            var cardsOnHand1 = new List<Card>()
            {
                dummyCardRank2, dummyCardRank3, dummyCardRank4, dummyCardRank5, dummyCardRank6
            };

            var cardsOnHand2 = new List<Card>()
            {
                dummyCardRank3, dummyCardRank4, dummyCardRank5, dummyCardRank6, dummyCardRank7
            };

            Assert.AreEqual(ResultDual.Lose, 
                Poker.CompareHighCard(cardsOnHand1, cardsOnHand2));
        }

        [Test]
        public void CompareHighCard_HandOneIs_A23K5_And_HandTwoIs_10J6K7_ResultDual_ShouldBe_Win()
        {
            var cardsOnHand1 = new List<Card>()
            {
                dummyCardRankAce, dummyCardRank2, dummyCardRank3, dummyCardRankKing, dummyCardRank5
            };

            var cardsOnHand2 = new List<Card>()
            {
                dummyCardRank10, dummyCardRankJack, dummyCardRank6, dummyCardRankKing, dummyCardRank7
            };

            Assert.AreEqual(ResultDual.Win, Poker.CompareHighCard(cardsOnHand1, cardsOnHand2));
        }

        [Test]
        public void CompareHighCard_HandOneIs_AKQJT_And_HandTwoIs_AQJT9_ResultDual_ShouldBe_Win()
        {
            var cardsOnHand1 = new List<Card>()
            {
                dummyCardRankAce, dummyCardRankKing, dummyCardRankQueen, dummyCardRankJack, dummyCardRank10
            };

            var cardsOnHand2 = new List<Card>()
            {
                dummyCardRankAce, dummyCardRankQueen, dummyCardRankJack, dummyCardRank10, dummyCardRank9
            };

            Assert.AreEqual(ResultDual.Win, Poker.CompareHighCard(cardsOnHand1, cardsOnHand2));
        }

        [Test]
        public void CompareHighCard_HandOneIs_AKQJ9_And_HandTwoIs_AKQJT_ResultDual_ShouldBe_Lose()
        {
            var cardsOnHand1 = new List<Card>()
            {
                dummyCardRankAce, dummyCardRankKing, dummyCardRankQueen, dummyCardRankJack, dummyCardRank9
            };

            var cardsOnHand2 = new List<Card>()
            {
                dummyCardRankAce, dummyCardRankKing, dummyCardRankQueen, dummyCardRankJack, dummyCardRank10
            };

            Assert.AreEqual(ResultDual.Lose, Poker.CompareHighCard(cardsOnHand1, cardsOnHand2));
        }

        [Test]
        public void CompareHighCard_HandOneIs_AKQJT_And_HandTwoIs_AKQJT_ResultDual_ShouldBe_Draw()
        {
            var cardsOnHand1 = new List<Card>()
            {
                dummyCardRankAce, dummyCardRankKing, dummyCardRankQueen, dummyCardRankJack, dummyCardRank10
            };

            var cardsOnHand2 = new List<Card>()
            {
                dummyCardRankAce, dummyCardRankKing, dummyCardRankQueen, dummyCardRankJack, dummyCardRank10
            };

            Assert.AreEqual(ResultDual.Draw, Poker.CompareHighCard(cardsOnHand1, cardsOnHand2));
        }
        #endregion

        #region Pair
        [Test]
        public void OnHandIs_22345_Pair_ShouldBe_True()
        {
            var onHandCards = new List<Card>()
            {
                dummyCardRank2, dummyCardRank2,
                dummyCardRank3, dummyCardRank4, dummyCardRank5
            };

            Assert.True(Poker.OnHandIsPair(onHandCards));
        }

        [Test]
        public void OnHandIs_23456_Pair_ShouldBe_False()
        {
            var onHandCards = new List<Card>()
            {
                dummyCardRank2, dummyCardRank3, dummyCardRank4, dummyCardRank5, dummyCardRank6
            };

            Assert.False(Poker.OnHandIsPair(onHandCards));
        }

        [Test]
        public void ComparePairValue_HandOneIs_22345_And_HandTwoIs_23345_ResultDual_ShouldBe_Lose()
        {
            var cardsOnHand1 = new List<Card>()
            {
                dummyCardRank2, dummyCardRank2,
                dummyCardRank3, dummyCardRank4, dummyCardRank5
            };

            var cardsOnHand2 = new List<Card>()
            {
                dummyCardRank2, 
                dummyCardRank3, dummyCardRank3,
                dummyCardRank4, dummyCardRank5
            };

            Assert.AreEqual(ResultDual.Lose, 
                Poker.ComparePair(cardsOnHand1, cardsOnHand2));
        }

        [Test]
        public void ComparePairValue_HandOneIs_23345_And_HandTwoIs_22345_ResultDual_ShouldBe_Win()
        {
            var cardsOnHand1 = new List<Card>()
            {
                dummyCardRank2, 
                dummyCardRank3, dummyCardRank3,
                dummyCardRank4, dummyCardRank5
            };

            var cardsOnHand2 = new List<Card>()
            {
                dummyCardRank2, dummyCardRank2,
                dummyCardRank3, dummyCardRank4, dummyCardRank5
            };

            Assert.AreEqual(ResultDual.Win, 
                Poker.ComparePair(cardsOnHand1, cardsOnHand2));
        }

        [Test]
        public void ComparePairValue_HandOneIs_22356_And_HandTwoIs_22456_ResultDual_ShouldBe_Lose()
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

        #region TwoPair
        [Test]
        public void OnHandIs_24A2A_TwoPair_ShouldBe_True()
        {
            var onHandCards = new List<Card>()
            {
                dummyCardRank2, dummyCardRank4, dummyCardRankAce, 
                dummyCardRank2, dummyCardRankAce
            };

            Assert.True(Poker.OnHandIsTwoPair(onHandCards));
        }

        [Test]
        public void OnHandIs_22345_TwoPair_ShouldBe_False()
        {
            var onHandCards = new List<Card>()
            {
                dummyCardRank2, dummyCardRank2,
                dummyCardRank3, dummyCardRank4, dummyCardRank5
            };

            Assert.False(Poker.OnHandIsTwoPair(onHandCards));
        }

        [Test]
        public void CompareTwoPairValue_HandOneIs_5577J_And_HandTwoIs_77QQA_ResultShouldBe_Lose()
        {
            var cardsOnHand1 = new List<Card>()
            {
                dummyCardRank5, dummyCardRank5,
                dummyCardRank7, dummyCardRank7,
                dummyCardRankJack
            };

            var cardsOnHand2 = new List<Card>()
            {
                dummyCardRank7, dummyCardRank7,
                dummyCardRankQueen, dummyCardRankQueen,
                dummyCardRankAce
            };

            Assert.AreEqual(ResultDual.Lose, Poker.CompareTwoPair(cardsOnHand1, cardsOnHand2));
        }

        [Test]
        public void CompareTwoPairValue_HandOneIs_6688T_And_HandTwoIs_3355K_ResultDualShouldBe_Win()
        {
            var cardsOnHand1 = new List<Card>()
            {
                dummyCardRank6, dummyCardRank6,
                dummyCardRank8, dummyCardRank8,
                dummyCardRank10
            };

            var cardsOnHand2 = new List<Card>()
            {
                dummyCardRank3, dummyCardRank3,
                dummyCardRank5, dummyCardRank5,
                dummyCardRankKing
            };

            Assert.AreEqual(ResultDual.Win, Poker.CompareTwoPair(cardsOnHand1, cardsOnHand2));
        }

        [Test]
        public void CompareTwoPairValue_HandOneIs_TTKAA_And_HandTwoIs_JJQAA_ResultDualShouldBe_Lose()
        {
            var cardsOnHand1 = new List<Card>()
            {
                dummyCardRank10, dummyCardRank10,
                dummyCardRankKing,
                dummyCardRankAce, dummyCardRankAce
            };

            var cardsOnHand2 = new List<Card>()
            {
                dummyCardRankJack, dummyCardRankJack,
                dummyCardRankQueen,
                dummyCardRankAce, dummyCardRankAce
            };

            Assert.AreEqual(ResultDual.Lose, Poker.CompareTwoPair(cardsOnHand1, cardsOnHand2));
        }

        [Test]
        public void CompareTwoPairValue_HandOneIs_JJKAA_And_HandTwoIs_JJQAA_ResultDualShouldBe_Win()
        {
            var cardsOnHand1 = new List<Card>()
            {
                dummyCardRankJack, dummyCardRankJack,
                dummyCardRankKing,
                dummyCardRankAce, dummyCardRankAce
            };

            var cardsOnHand2 = new List<Card>()
            {
                dummyCardRankJack, dummyCardRankJack,
                dummyCardRankQueen,
                dummyCardRankAce, dummyCardRankAce
            };

            Assert.AreEqual(ResultDual.Win, Poker.CompareTwoPair(cardsOnHand1, cardsOnHand2));
        }
        #endregion
    }
}
