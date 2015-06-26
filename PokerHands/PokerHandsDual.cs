using System.Collections.Generic;
using System.Text.RegularExpressions;
using Category = PokerHands.Poker.Category;
using ResultDual = PokerHands.Poker.ResultDual;

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
            string outputCategory = category.ToString();

            outputCategory = Regex.Replace(outputCategory, @"\B\p{Lu}", m => " " + m.ToString().ToLower());
            outputCategory = outputCategory.Replace("_", "");

            return outputCategory.ToLower();
        }
    }
}
