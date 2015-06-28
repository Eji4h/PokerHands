using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RankType = PokerHands.Card.RankType;
using ResultDual = PokerHands.Poker.ResultDual;
using SuitType = PokerHands.Card.SuitType;

namespace PokerHands
{
    public static class Converter
    {
        public static SuitType ToSuit(char suitInput)
        {
            var suit = (SuitType)suitInput;
            ValidateSuitInRange_CDHS(suit);
            return suit;
        }

        private static void ValidateSuitInRange_CDHS(SuitType suit)
        {
            if (!Enum.IsDefined(typeof(SuitType), suit))
                throw new ArgumentOutOfRangeException();
        }

        public static RankType ToRank(string rank)
        {
            int convertNumber;
            if (int.TryParse(rank, out convertNumber))
            {
                ValidateInRangeOneToTen(convertNumber);
                return (RankType)convertNumber;
            }
            return ConvertNotNumberToRank(rank);
        }

        private static void ValidateInRangeOneToTen(int convertNumber)
        {
            if (convertNumber < 1 || convertNumber > 10)
                throw new ArgumentOutOfRangeException();
        }

        private static RankType ConvertNotNumberToRank(string rank)
        {
            switch (rank)
            {
                case "T":
                    return RankType.Ten;
                case "J":
                    return RankType.Jack;
                case "Q":
                    return RankType.Queen;
                case "K":
                    return RankType.King;
                case "A":
                    return RankType.Ace;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static Card ToCard(string card)
        {
            int lastIndexOfInput = card.Length - 1;

            var rankStr = card.Substring(0, lastIndexOfInput);
            var suitChar = card[lastIndexOfInput];

            var rank = ToRank(rankStr);
            var suit = ToSuit(suitChar);

            return new Card(suit, rank);
        }

        public static List<Card> ToCardsList(string cardsList)
        {
            var cards = new List<Card>();
            string[] cardsStr = cardsList.Split(' ');

            foreach (var cardStr in cardsStr)
                cards.Add(ToCard(cardStr));

            Hand.OrderCard(cards);
            return cards;
        }
    }
}
