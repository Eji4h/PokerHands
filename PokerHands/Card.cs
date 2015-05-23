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
            Club,
            Diamond,
            Heart,
            Spade
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
            return this.Rank.CompareTo(other.Rank);
        }
    }
}
