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

            Assert.False(DeckIsSameCardsOrder(originalDeck, shuffleDeck));
        }

        bool CardIsEqual(Card firstCard, Card secondCard)
        {
            return firstCard.Suit == secondCard.Suit &&
                    firstCard.Rank == secondCard.Rank;
        }

        bool DeckIsSameCardsOrder(Deck firstDeck, Deck secondDeck)
        {
            for (int i = 0; i < firstDeck.Cards.Count; i++)
            {
                var cardFromOriginalDeck = firstDeck.Cards[i];
                var cardFromShuffleDeck = secondDeck.Cards[i];

                if (!CardIsEqual(cardFromOriginalDeck, cardFromShuffleDeck))
                    return false;
            }
            return true;
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
