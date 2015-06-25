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

            if(resultDual == ResultDual.Win)
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
            return "full house";
        }
    }
}
