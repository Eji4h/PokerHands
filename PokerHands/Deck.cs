﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    public class Deck
    {
        Card[] cards = new Card[52];

        public int Amount()
        {
            return cards.Length;
        }
    }
}
