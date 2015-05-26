using NUnit.Framework;
using PokerHands;
using RankType = PokerHands.Card.RankType;
using SuitType = PokerHands.Card.SuitType;

namespace PokerHandsTest
{
    [TestFixture]
    class DeckTest
    {
        Deck deck = new Deck();

        [Test]
        public void DeckContains_52_Cards()
        {
            Assert.AreEqual(52, deck.Cards.Count);
        }

        [Test]
        public void DeckOrderShouldBeChange_WhenAfterCallShuffleMethod()
        {
            var originalDeck = new Deck();
            var shuffleDeck = new Deck();

            bool deckIsEqual = true;
            shuffleDeck.Shuffle();

            for(int i = 0; i < originalDeck.Cards.Count; i++)
            {
                var cardFromOriginalDeck = originalDeck.Cards[i];
                var cardFromShuffleDeck = shuffleDeck.Cards[i];

                bool cardIsEqual = 
                    cardFromOriginalDeck.Suit == cardFromShuffleDeck.Suit &&
                    cardFromOriginalDeck.Rank == cardFromShuffleDeck.Rank;

                if(!cardIsEqual)
                {
                    deckIsEqual = false;
                    break;
                }
            }
            Assert.False(deckIsEqual);
        }
    }
}
