﻿using System;
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
            if (input == 'C')
                return SuitType.Club;
            if (input == 'D')
                return SuitType.Diamond;
            if (input == 'H')
                return SuitType.Heart;
            return SuitType.Spade;
        }
    }
}
