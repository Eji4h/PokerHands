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
        public static SuitType ToSuit(char suit)
        {
            return (SuitType)suit;
        }

        public static RankType ToRank(string rank)
        {
            int convertNumber;
            if (int.TryParse(rank, out convertNumber))
                return (RankType)convertNumber;

            return ConvertNotNumberToRank(rank);
        }

        private static RankType ConvertNotNumberToRank(string rank)
        {
            switch(rank)
            {
                case "J":
                    return RankType.Jack;
                case "Q":
                    return RankType.Queen;
                case "K":
                    return RankType.King;
                case "A":
                    return RankType.Ace;
                default:
                    return RankType.Ten;
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
