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
            Assert.AreEqual(52, deck.Cards.Length);
        }

        [Test]
        public void FirstCardOfDeck_ShouldBe_AceClub()
        {
            Card aceClubCard = new Card(SuitType.Club, RankType.Ace);
            Card firstCardOfDeck = deck.Cards[0];
            Assert.AreEqual(aceClubCard.Suit, firstCardOfDeck.Suit);
            Assert.AreEqual(aceClubCard.Rank, firstCardOfDeck.Rank);
        }

        [Test]
        public void LastCardOfDeck_ShouldBe_KingSpade()
        {
            Card kingSpadeCard = new Card(SuitType.Spade, RankType.King);
            Card lastCardOfDeck = deck.Cards[deck.Cards.Length - 1];
            Assert.AreEqual(kingSpadeCard.Suit, lastCardOfDeck.Suit);
            Assert.AreEqual(kingSpadeCard.Rank, lastCardOfDeck.Rank);
        }
    }
}
