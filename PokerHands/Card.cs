using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    public class Card : IComparable<Card>
    {
        public enum SuitType
        {
            Club = 'C',
            Diamond = 'D',
            Heart = 'H',
            Spade = 'S'
        }

        public enum RankType
        {
            Ace = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13
        }

        SuitType suit;
        RankType rank;

        public SuitType Suit
        {
            get { return suit; }
        }

        public RankType Rank
        {
            get { return this.rank; }
        }

        public Card(SuitType suit, RankType rank)
        {
            this.suit = suit;
            this.rank = rank;
        }

        public int CompareTo(Card other)
        {
            if (this.Rank == other.Rank)
                return this.Suit.CompareTo(other.Suit);
            return this.Rank.CompareTo(other.Rank);
        }

        public static bool IsEquals(Card card1, Card card2)
        {
            if (card1.Suit != card2.Suit)
                return false;
            if (card1.Rank != card2.Rank)
                return false;
            return true;
        }
    }
}
