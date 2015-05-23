using NUnit.Framework;
using PokerHands;

namespace PokerHandsTest
{
    [TestFixture]
    class HandTest
    {
        [Test]
        public void NumberCardOnHandIs5()
        {
            Assert.AreEqual(5, new Hand().GetCards().Length);
        }
    }
}
