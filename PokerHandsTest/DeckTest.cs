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
        public void DeckContains_ShouldBe_52_Cards()
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

        [Test]
        public void Deal_5_CardsFromDeck_DeckShouldBeRemain_47_Cards()
        {
            var deck = new Deck();
            deck.DealCards(5);

            Assert.AreEqual(47, deck.Cards.Count);
        }
    }
}
