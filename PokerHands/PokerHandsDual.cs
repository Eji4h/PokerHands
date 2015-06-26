using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Category = PokerHands.Poker.Category;
using ResultDual = PokerHands.Poker.ResultDual;

namespace PokerHands
{
    public class PokerHandsDual
    {
        enum Side
        {
            Black, 
            White
        }

        public static string GetResualDual(List<Card> blackCards, List<Card> whiteCards)
        {
            var resultDual = Poker.ComparePokerHands(blackCards, whiteCards);
            Side winnerSide;
            Category categoryWinner;

            if (resultDual == ResultDual.Draw)
                return "Tie";

            if (resultDual == ResultDual.Win)
            {
                winnerSide = Side.Black;
                categoryWinner = Poker.RecognizeCategory(blackCards);
            }
            else
            {
                winnerSide = Side.White;
                categoryWinner = Poker.RecognizeCategory(whiteCards);
            }

            string output = winnerSide.ToString() + " wins - " + ChangeCategoryForDisplay(categoryWinner);

            if (categoryWinner == Category.HighCard)
            {
                output += ": ";
                if (winnerSide == Side.Black)
                    output += blackCards.Last().Rank.ToString();
                else
                    output += whiteCards.Last().Rank.ToString();
            }
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
