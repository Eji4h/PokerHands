﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueType = PokerHands.Card.ValueType;

namespace PokerHands
{
    public static class Poker
    {
        public enum ResultDual
        {
            Win,
            Lose,
            Draw
        }

        public static ResultDual CompareScoring(Card card1, Card card2)
        {
            if (card1.Value == card2.Value)
                return ResultDual.Draw;
            if (card1.Value == ValueType.Ace)
                return ResultDual.Win;
            if (card2.Value == ValueType.Ace)
                return ResultDual.Lose;
            if (card1.Value > card2.Value)
                return ResultDual.Win;
            return ResultDual.Lose;
        }
    }
}
