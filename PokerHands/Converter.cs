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
        public static SuitType ToSuit(char input)
        {
            return (SuitType)input;
        }

        public static RankType ToRank(string input)
        {
            int convertNumber;
            if (int.TryParse(input, out convertNumber))
                return (RankType)convertNumber;

            return ConvertCourtToRank(input);
        }

        private static RankType ConvertCourtToRank(string input)
        {
            switch(input)
            {
                case "J":
                    return RankType.Jack;
                case "Q":
                    return RankType.Queen;
                case "K":
                    return RankType.King;
                default:
                    return RankType.Jack;
            }
        }
    }
}
