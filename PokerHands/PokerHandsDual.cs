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

        public static string GetResultDual(List<Card> blackCards, List<Card> whiteCards)
        {
            var resultDual = Poker.ComparePokerHands(blackCards, whiteCards);

            if (resultDual == ResultDual.Draw)
                return "Tie";

            return GetOutputWithWinner(blackCards, whiteCards);
        }

        private static string GetOutputWithWinner(List<Card> blackCards, List<Card> whiteCards)
        {
            Side winnerSide;
            List<Card> winnerCards;

            SetWinnerSide(blackCards, whiteCards, out winnerSide, out winnerCards);

            return GetWinnerOutput(winnerSide, winnerCards);
        }

        private static string GetWinnerOutput(Side winnerSide, List<Card> winnerCards)
        {
            var categoryWinner = Poker.RecognizeCategory(winnerCards);
            string output = winnerSide.ToString() + " wins - " + ChangeCategoryForDisplay(categoryWinner);

            if (categoryWinner == Category.HighCard)
                output += ": " + winnerCards.Last().Rank.ToString();
            return output;
        }

        private static void SetWinnerSide(List<Card> blackCards, List<Card> whiteCards, out Side winnerSide, out List<Card> winnerCards)
        {
            var resultDual = Poker.ComparePokerHands(blackCards, whiteCards);

            if (resultDual == ResultDual.Win)
            {
                winnerSide = Side.Black;
                winnerCards = blackCards;
            }
            else
            {
                winnerSide = Side.White;
                winnerCards = whiteCards;
            }
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
