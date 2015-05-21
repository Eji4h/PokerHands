using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static ResultDual Compare(Card card1, Card card2)
        {
            if (card1.Value == card2.Value)
                return ResultDual.Draw;
            if (card1.Value > card2.Value)
                return ResultDual.Win;
            return ResultDual.Lose;
        }
    }
}
