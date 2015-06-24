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
        public static SuitType CharToSuit(char input)
        {
            return (SuitType)input;
        }

        public static RankType StringToRank(string input)
        {
            int convertNumber;
            if (int.TryParse(input, out convertNumber))
                return (RankType)convertNumber;
            return RankType.Two;
        }
    }
}
