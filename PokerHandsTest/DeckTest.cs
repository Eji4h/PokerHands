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

            shuffleDeck.Shuffle();

            CollectionAssert.AreNotEqual(originalDeck.Cards, shuffleDeck.Cards);
        }
    }
}
