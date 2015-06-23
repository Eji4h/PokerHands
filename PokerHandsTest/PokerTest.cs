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

        Card dummyCardSuitClub = new Card(SuitType.Club, RankType.Ace);
        Card dummyCardSuitDiamond = new Card(SuitType.Diamond, RankType.Three);
        Card dummyCardSuitHeart = new Card(SuitType.Heart, RankType.Five);
        Card dummyCardSuitSpade = new Card(SuitType.Spade, RankType.Seven);

        #region RecognizeCatagory
        [Test]
        public void OnHandIs_QQQKA_CategoryShouldBe_Three_Of_A_Kind()
        {
            var onHandCards = new List<Card>()
            {
                dummyCardRankQueen, dummyCardRankQueen, dummyCardRankQueen,
                dummyCardRankKing, dummyCardRankAce
            };

            Assert.AreEqual(Poker.Category.Three_Of_A_Kind, Poker.RecognizeCategory(onHandCards));
        }

        [Test]
        public void OnHandIs_77QQA_CategoryShouldBe_TwoPairs()
        {
            var onHandCards = new List<Card>()
            {
                dummyCardRank7, dummyCardRank7, 
                dummyCardRankQueen, dummyCardRankQueen,
                dummyCardRankAce
            };

            Assert.AreEqual(Poker.Category.TwoPairs, Poker.RecognizeCategory(onHandCards));
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

        #region HighCard
        [Test]
        public void OnHandIs_22445_HighCard_ShouldBe_False()
        {
            var onHandCards = new List<Card>()
            {
                dummyCardRank2, dummyCardRank2,
                dummyCardRank4, dummyCardRank4,
                dummyCardRank5
            };

            Assert.False(Poker.OnHandIsHighCard(onHandCards));
        }

        [Test]
        public void OnHandIs_2468T_HighCard_ShouldBe_True()
        {
            var onHandCards = new List<Card>()
            {
                dummyCardRank2, dummyCardRank4, dummyCardRank6, 
                dummyCardRank8, dummyCardRank10
            };

            Assert.True(Poker.OnHandIsHighCard(onHandCards));
        }

        [Test]
        public void CompareHighCard_HandOneIs_2468T_And_HandTwoIs_3579J_ResultDual_ShouldBe_Lose()
        {
            var cardsOnHand1 = new List<Card>()
            {
                dummyCardRank2, dummyCardRank4, dummyCardRank6, 
                dummyCardRank8, dummyCardRank10
            };

            var cardsOnHand2 = new List<Card>()
            {
                dummyCardRank3, dummyCardRank5, dummyCardRank7, 
                dummyCardRank9, dummyCardRankJack
            };

            Assert.True(Poker.OnHandIsHighCard(cardsOnHand1));
            Assert.True(Poker.OnHandIsHighCard(cardsOnHand2));

            Assert.AreEqual(ResultDual.Lose,
                Poker.CompareHighCard(cardsOnHand1, cardsOnHand2));
        }

        [Test]
        public void CompareHighCard_HandOneIs_A23K5_And_HandTwoIs_TJ6K7_ResultDual_ShouldBe_Win()
        {
            var cardsOnHand1 = new List<Card>()
            {
                dummyCardRankAce, dummyCardRank2, dummyCardRank3, 
                dummyCardRankKing, dummyCardRank5
            };

            var cardsOnHand2 = new List<Card>()
            {
                dummyCardRank10, dummyCardRankJack, dummyCardRank6, 
                dummyCardRankKing, dummyCardRank7
            };

            Assert.True(Poker.OnHandIsHighCard(cardsOnHand1));
            Assert.True(Poker.OnHandIsHighCard(cardsOnHand2));

            Assert.AreEqual(ResultDual.Win, Poker.CompareHighCard(cardsOnHand1, cardsOnHand2));
        }

        [Test]
        public void CompareHighCard_HandOneIs_AQJT9_And_HandTwoIs_AQJT8_ResultDual_ShouldBe_Win()
        {
            var cardsOnHand1 = new List<Card>()
            {
                dummyCardRankAce, dummyCardRankQueen, dummyCardRankJack, 
                dummyCardRank10, dummyCardRank9
            };

            var cardsOnHand2 = new List<Card>()
            {
                dummyCardRankAce, dummyCardRankQueen, dummyCardRankJack, 
                dummyCardRank10, dummyCardRank8
            };

            Assert.True(Poker.OnHandIsHighCard(cardsOnHand1));
            Assert.True(Poker.OnHandIsHighCard(cardsOnHand2));

            Assert.AreEqual(ResultDual.Win, Poker.CompareHighCard(cardsOnHand1, cardsOnHand2));
        }

        [Test]
        public void CompareHighCard_HandOneIs_AKQJ8_And_HandTwoIs_AKQJ9_ResultDual_ShouldBe_Lose()
        {
            var cardsOnHand1 = new List<Card>()
            {
                dummyCardRankAce, dummyCardRankKing, dummyCardRankQueen, 
                dummyCardRankJack, dummyCardRank8
            };

            var cardsOnHand2 = new List<Card>()
            {
                dummyCardRankAce, dummyCardRankKing, dummyCardRankQueen, 
                dummyCardRankJack, dummyCardRank9
            };

            Assert.True(Poker.OnHandIsHighCard(cardsOnHand1));
            Assert.True(Poker.OnHandIsHighCard(cardsOnHand2));

            Assert.AreEqual(ResultDual.Lose, Poker.CompareHighCard(cardsOnHand1, cardsOnHand2));
        }

        [Test]
        public void CompareHighCard_HandOneIs_AKQJ9_And_HandTwoIs_AKQJ9_ResultDual_ShouldBe_Draw()
        {
            var cardsOnHand1 = new List<Card>()
            {
                dummyCardRankAce, dummyCardRankKing, dummyCardRankQueen, 
                dummyCardRankJack, dummyCardRank9
            };

            var cardsOnHand2 = new List<Card>()
            {
                dummyCardRankAce, dummyCardRankKing, dummyCardRankQueen, 
                dummyCardRankJack, dummyCardRank9
            };

            Assert.True(Poker.OnHandIsHighCard(cardsOnHand1));
            Assert.True(Poker.OnHandIsHighCard(cardsOnHand2));

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
        public void ComparePair_HandOneIs_22345_And_HandTwoIs_23345_ResultDual_ShouldBe_Lose()
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

            Assert.True(Poker.OnHandIsPair(cardsOnHand1));
            Assert.True(Poker.OnHandIsPair(cardsOnHand2));

            Assert.AreEqual(ResultDual.Lose,
                Poker.ComparePair(cardsOnHand1, cardsOnHand2));
        }

        [Test]
        public void ComparePair_HandOneIs_23345_And_HandTwoIs_22345_ResultDual_ShouldBe_Win()
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

            Assert.True(Poker.OnHandIsPair(cardsOnHand1));
            Assert.True(Poker.OnHandIsPair(cardsOnHand2));

            Assert.AreEqual(ResultDual.Win,
                Poker.ComparePair(cardsOnHand1, cardsOnHand2));
        }

        [Test]
        public void ComparePair_HandOneIs_22356_And_HandTwoIs_22456_ResultDual_ShouldBe_Lose()
        {
            var cardsOnHand1 = new List<Card>()
            {
                dummyCardRank2, dummyCardRank2,
                dummyCardRank3, dummyCardRank5, dummyCardRank6
            };

            var cardsOnHand2 = new List<Card>()
            {
                dummyCardRank2, dummyCardRank2,
                dummyCardRank4, dummyCardRank5, dummyCardRank6
            };

            Assert.True(Poker.OnHandIsPair(cardsOnHand1));
            Assert.True(Poker.OnHandIsPair(cardsOnHand2));

            Assert.AreEqual(ResultDual.Lose, Poker.ComparePair(cardsOnHand1, cardsOnHand2));
        }
        #endregion

        #region TwoPairs
        [Test]
        public void OnHandIs_24A2A_TwoPairs_ShouldBe_True()
        {
            var onHandCards = new List<Card>()
            {
                dummyCardRank2, dummyCardRank4, dummyCardRankAce, 
                dummyCardRank2, dummyCardRankAce
            };

            Assert.True(Poker.OnHandIsTwoPairs(onHandCards));
        }

        [Test]
        public void OnHandIs_22345_TwoPairs_ShouldBe_False()
        {
            var onHandCards = new List<Card>()
            {
                dummyCardRank2, dummyCardRank2,
                dummyCardRank3, dummyCardRank4, dummyCardRank5
            };

            Assert.False(Poker.OnHandIsTwoPairs(onHandCards));
        }

        [Test]
        public void CompareTwoPairs_HandOneIs_5577J_And_HandTwoIs_77QQA_ResultShouldBe_Lose()
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

            Assert.True(Poker.OnHandIsTwoPairs(cardsOnHand1));
            Assert.True(Poker.OnHandIsTwoPairs(cardsOnHand2));

            Assert.AreEqual(ResultDual.Lose, Poker.CompareTwoPairs(cardsOnHand1, cardsOnHand2));
        }

        [Test]
        public void CompareTwoPairs_HandOneIs_6688T_And_HandTwoIs_3355K_ResultDualShouldBe_Win()
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

            Assert.True(Poker.OnHandIsTwoPairs(cardsOnHand1));
            Assert.True(Poker.OnHandIsTwoPairs(cardsOnHand2));

            Assert.AreEqual(ResultDual.Win, Poker.CompareTwoPairs(cardsOnHand1, cardsOnHand2));
        }

        [Test]
        public void CompareTwoPairs_HandOneIs_TTKAA_And_HandTwoIs_JJQAA_ResultDualShouldBe_Lose()
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

            Assert.True(Poker.OnHandIsTwoPairs(cardsOnHand1));
            Assert.True(Poker.OnHandIsTwoPairs(cardsOnHand2));

            Assert.AreEqual(ResultDual.Lose, Poker.CompareTwoPairs(cardsOnHand1, cardsOnHand2));
        }

        [Test]
        public void CompareTwoPairs_HandOneIs_JJKAA_And_HandTwoIs_JJQAA_ResultDualShouldBe_Win()
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

            Assert.True(Poker.OnHandIsTwoPairs(cardsOnHand1));
            Assert.True(Poker.OnHandIsTwoPairs(cardsOnHand2));

            Assert.AreEqual(ResultDual.Win, Poker.CompareTwoPairs(cardsOnHand1, cardsOnHand2));
        }
        #endregion

        #region Three_Of_A_Kind
        [Test]
        public void OnHandIs_22JJK_Three_Of_A_Kind_ShouldBe_False()
        {
            var onHandCards = new List<Card>()
            {
                dummyCardRank2, dummyCardRank2, 
                dummyCardRankJack, dummyCardRankJack,
                dummyCardRankKing
            };

            Assert.False(Poker.OnHandIsThree_Of_A_Kind(onHandCards));
        }

        [Test]
        public void OnHandIs_222JK_Three_Of_A_Kind_ShouldBe_True()
        {
            var onHandCards = new List<Card>()
            {
                dummyCardRank2, dummyCardRank2, dummyCardRank2,
                dummyCardRankJack, dummyCardRankKing
            };

            Assert.True(Poker.OnHandIsThree_Of_A_Kind(onHandCards));
        }

        [Test]
        public void CompareThree_Of_A_Kind_HandOneIs_222JK_And_HandTwoIs_333JK_ResultShouldBe_Lose()
        {
            var cardsOnHand1 = new List<Card>()
            {
                dummyCardRank2, dummyCardRank2, dummyCardRank2,
                dummyCardRankJack, dummyCardRankKing
            };

            var cardsOnHand2 = new List<Card>()
            {
                dummyCardRank3, dummyCardRank3, dummyCardRank3,
                dummyCardRankJack, dummyCardRankKing
            };

            Assert.True(Poker.OnHandIsThree_Of_A_Kind(cardsOnHand1));
            Assert.True(Poker.OnHandIsThree_Of_A_Kind(cardsOnHand2));

            Assert.AreEqual(ResultDual.Lose, Poker.CompareThree_Of_A_Kind(cardsOnHand1, cardsOnHand2));
        }

        [Test]
        public void CompareThree_Of_A_Kind_HandOneIs_QKKKA_And_HandTwoIs_8889T_ResultShouldBe_Win()
        {
            var cardsOnHand1 = new List<Card>()
            {
                dummyCardRankQueen, 
                dummyCardRankKing, dummyCardRankKing, dummyCardRankKing,
                dummyCardRankAce
            };

            var cardsOnHand2 = new List<Card>()
            {
                dummyCardRank8, dummyCardRank8, dummyCardRank8,
                dummyCardRank9, dummyCardRank10
            };

            Assert.True(Poker.OnHandIsThree_Of_A_Kind(cardsOnHand1));
            Assert.True(Poker.OnHandIsThree_Of_A_Kind(cardsOnHand2));

            Assert.AreEqual(ResultDual.Win, Poker.CompareThree_Of_A_Kind(cardsOnHand1, cardsOnHand2));
        }

        [Test]
        public void CompareThree_Of_A_Kind_HandOneIs_JKKKA_And_HandTwoIs_QKKKA_ResultShouldBe_Lose()
        {
            var cardsOnHand1 = new List<Card>()
            {
                dummyCardRankJack, 
                dummyCardRankKing, dummyCardRankKing, dummyCardRankKing,
                dummyCardRankAce
            };

            var cardsOnHand2 = new List<Card>()
            {
                dummyCardRankQueen, 
                dummyCardRankKing, dummyCardRankKing, dummyCardRankKing,
                dummyCardRankAce
            };

            Assert.True(Poker.OnHandIsThree_Of_A_Kind(cardsOnHand1));
            Assert.True(Poker.OnHandIsThree_Of_A_Kind(cardsOnHand2));

            Assert.AreEqual(ResultDual.Lose, Poker.CompareThree_Of_A_Kind(cardsOnHand1, cardsOnHand2));
        }

        [Test]
        public void CompareThree_Of_A_Kind_HandOneIs_QKKKA_And_HandTwoIs_JKKKA_ResultShouldBe_Win()
        {
            var cardsOnHand1 = new List<Card>()
            {
                dummyCardRankQueen, 
                dummyCardRankKing, dummyCardRankKing, dummyCardRankKing,
                dummyCardRankAce
            };

            var cardsOnHand2 = new List<Card>()
            {
                dummyCardRankJack, 
                dummyCardRankKing, dummyCardRankKing, dummyCardRankKing,
                dummyCardRankAce
            };

            Assert.True(Poker.OnHandIsThree_Of_A_Kind(cardsOnHand1));
            Assert.True(Poker.OnHandIsThree_Of_A_Kind(cardsOnHand2));

            Assert.AreEqual(ResultDual.Win, Poker.CompareThree_Of_A_Kind(cardsOnHand1, cardsOnHand2));
        }
        #endregion

        #region Straight
        [Test]
        public void OnHandIs_22234_Straight_ShouldBe_False()
        {
            var onHandCards = new List<Card>()
            {
                dummyCardRank2, dummyCardRank2, dummyCardRank2,
                dummyCardRank3, dummyCardRank4
            };

            Assert.False(Poker.OnHandIsStraight(onHandCards));
        }

        [Test]
        public void OnHandIs_23456_Straight_ShouldBe_True()
        {
            var onHandCards = new List<Card>()
            {
                dummyCardRank2, dummyCardRank3, dummyCardRank4, 
                dummyCardRank5, dummyCardRank6
            };

            Assert.True(Poker.OnHandIsStraight(onHandCards));
        }

        [Test]
        public void OnHandIs_12345_Straight_ShouldBe_True()
        {
            var onHandCards = new List<Card>()
            {
                dummyCardRankAce, dummyCardRank2, dummyCardRank3, 
                dummyCardRank4, dummyCardRank5
            };

            Assert.True(Poker.OnHandIsStraight(onHandCards));
        }

        [Test]
        public void OnHandIs_TJQKA_Straight_ShouldBe_True()
        {
            var onHandCards = new List<Card>()
            {
                dummyCardRank10, dummyCardRankJack, dummyCardRankQueen,
                dummyCardRankKing, dummyCardRankAce
            };

            Assert.True(Poker.OnHandIsStraight(onHandCards));
        }

        [Test]
        public void OnHandIs_9TJQA_Straight_ShouldBe_False()
        {
            var onHandCards = new List<Card>()
            {
                dummyCardRank9, dummyCardRank10, dummyCardRankJack, 
                dummyCardRankQueen, dummyCardRankAce
            };

            Assert.False(Poker.OnHandIsStraight(onHandCards));
        }

        [Test]
        public void CompareStraight_HandOneIs_23456_And_HandTwoIs_34567_ResultShouldBe_Lose()
        {
            var cardsOnHand1 = new List<Card>()
            {
                dummyCardRank2, dummyCardRank3, dummyCardRank4,
                dummyCardRank5, dummyCardRank6
            };

            var cardsOnHand2 = new List<Card>()
            {
                dummyCardRank3, dummyCardRank4, dummyCardRank5,
                dummyCardRank6, dummyCardRank7
            };

            Assert.True(Poker.OnHandIsStraight(cardsOnHand1));
            Assert.True(Poker.OnHandIsStraight(cardsOnHand2));

            Assert.AreEqual(ResultDual.Lose, Poker.CompareStraight(cardsOnHand1, cardsOnHand2));
        }

        [Test]
        public void CompareStraight_HandOneIs_9TJQK_And_HandTwoIs_34567_ResultShouldBe_Win()
        {
            var cardsOnHand1 = new List<Card>()
            {
                dummyCardRank9, dummyCardRank10, 
                dummyCardRankJack, dummyCardRankQueen, dummyCardRankKing
            };

            var cardsOnHand2 = new List<Card>()
            {
                dummyCardRank3, dummyCardRank4, dummyCardRank5,
                dummyCardRank6, dummyCardRank7
            };

            Assert.True(Poker.OnHandIsStraight(cardsOnHand1));
            Assert.True(Poker.OnHandIsStraight(cardsOnHand2));

            Assert.AreEqual(ResultDual.Win, Poker.CompareStraight(cardsOnHand1, cardsOnHand2));
        }

        [Test]
        public void CompareStraight_HandOneIs_12345_And_HandTwoIs_34567_ResultShouldBe_Lose()
        {
            var cardsOnHand1 = new List<Card>()
            {
                dummyCardRankAce, dummyCardRank2, dummyCardRank3,
                dummyCardRank4, dummyCardRank5
            };

            var cardsOnHand2 = new List<Card>()
            {
                dummyCardRank3, dummyCardRank4, dummyCardRank5,
                dummyCardRank6, dummyCardRank7
            };

            Assert.True(Poker.OnHandIsStraight(cardsOnHand1));
            Assert.True(Poker.OnHandIsStraight(cardsOnHand2));

            Assert.AreEqual(ResultDual.Lose, Poker.CompareStraight(cardsOnHand1, cardsOnHand2));
        }

        [Test]
        public void CompareStraight_HandOneIs_34567_And_HandTwoIs_12345_ResultShouldBe_Win()
        {
            var cardsOnHand1 = new List<Card>()
            {
                dummyCardRank3, dummyCardRank4, dummyCardRank5,
                dummyCardRank6, dummyCardRank7
            };

            var cardsOnHand2 = new List<Card>()
            {
                dummyCardRankAce, dummyCardRank2, dummyCardRank3,
                dummyCardRank4, dummyCardRank5
            };

            Assert.True(Poker.OnHandIsStraight(cardsOnHand1));
            Assert.True(Poker.OnHandIsStraight(cardsOnHand2));

            Assert.AreEqual(ResultDual.Win, Poker.CompareStraight(cardsOnHand1, cardsOnHand2));
        }

        [Test]
        public void CompareStraight_HandOneIs_34567_And_HandTwoIs_TJQKA_ResultShouldBe_Lose()
        {
            var cardsOnHand1 = new List<Card>()
            {
                dummyCardRank3, dummyCardRank4, dummyCardRank5,
                dummyCardRank6, dummyCardRank7
            };

            var cardsOnHand2 = new List<Card>()
            {
                dummyCardRank10, dummyCardRankJack, dummyCardRankQueen,
                dummyCardRankKing, dummyCardRankAce
            };

            Assert.True(Poker.OnHandIsStraight(cardsOnHand1));
            Assert.True(Poker.OnHandIsStraight(cardsOnHand2));

            Assert.AreEqual(ResultDual.Lose, Poker.CompareStraight(cardsOnHand1, cardsOnHand2));
        }
        #endregion

        #region Flush
        [Test]
        public void OnHandIs_CDHSS_Flush_ShouldBe_False()
        {
            var onHandCards = new List<Card>()
            {
                dummyCardSuitClub, dummyCardSuitDiamond, dummyCardSuitHeart, 
                dummyCardSuitSpade, dummyCardSuitSpade
            };

            Assert.False(Poker.OnHandIsFlush(onHandCards));
        }

        [Test]
        public void OnHandIs_CCCCC_Flush_ShouldBe_True()
        {
            var onHandCards = new List<Card>()
            {
                dummyCardSuitClub, dummyCardSuitClub, dummyCardSuitClub, 
                dummyCardSuitClub, dummyCardSuitClub
            };

            Assert.True(Poker.OnHandIsFlush(onHandCards));
        }

        [Test]
        public void CompareFlush_HandOneIs_2468TClub_And_HandTwoIs_79JQKClub_ResultShouldBe_Lose()
        {
            var cardsOnHand1 = new List<Card>()
            {
                dummyCardRank2, dummyCardRank4, dummyCardRank6, 
                dummyCardRank8, dummyCardRank10
            };

            var cardsOnHand2 = new List<Card>()
            {
                dummyCardRank7, dummyCardRank9,
                dummyCardRankJack, dummyCardRankQueen, dummyCardRankKing
            };

            Assert.True(Poker.OnHandIsFlush(cardsOnHand1));
            Assert.True(Poker.OnHandIsFlush(cardsOnHand2));

            Assert.AreEqual(ResultDual.Lose, Poker.CompareFlush(cardsOnHand1, cardsOnHand2));
        }
        #endregion
    }
}
