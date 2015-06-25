using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RankType = PokerHands.Card.RankType;
using ResultDual = PokerHands.Poker.ResultDual;
using SuitType = PokerHands.Card.SuitType;
using Category = PokerHands.Poker.Category;

namespace PokerHands
{
    public class PokerHandsDual
    {
        public static string GetResualDual(List<Card> blackCards, List<Card> whiteCards)
        {
            var resultDual = Poker.ComparePokerHands(blackCards, whiteCards);
            string winnerSide;
            Category categoryWinner;

            if (resultDual == ResultDual.Win)
            {
                winnerSide = "Black";
                categoryWinner = Poker.RecognizeCategory(blackCards);
            }
            else
            {
                winnerSide = "White";
                categoryWinner = Poker.RecognizeCategory(whiteCards);
            }

            string output = winnerSide + " wins - " + ChangeCategoryForDisplay(categoryWinner);
            return output;
        }

        public static string ChangeCategoryForDisplay(Category category)
        {
            if (category == Category.HighCard)
                return "high card";
            if (category == Category.Pair)
                return "pair";
            if (category == Category.TwoPairs)
                return "two pairs";
            if (category == Category.ThreeOfA_Kind)
                return "three of a kind";
            if (category == Category.Straight)
                return "straight";
            if (category == Category.Flush)
                return "flush";
            if(category == Category.FullHouse)
                return "full house";
            if (category == Category.FourOfA_Kind)
                return "four of a kind";
            return "";
        }
    }
}
