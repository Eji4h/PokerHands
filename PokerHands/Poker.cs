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
            Lose
        }

        public static ResultDual Compare(Card card1, Card card2)
        {
            return ResultDual.Lose;
        }
    }
}
