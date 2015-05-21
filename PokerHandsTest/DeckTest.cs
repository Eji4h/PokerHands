using NUnit.Framework;
using PokerHands;

namespace PokerHandsTest
{
    [TestFixture]
    class DeckTest
    {
        [Test]
        public void TestPokerDeckContains_52_Cards()
        {
            Assert.AreEqual(52, new Deck().Amount());
        }
    }
}
