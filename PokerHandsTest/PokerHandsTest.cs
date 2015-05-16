﻿using System;
using NUnit.Framework;
using PokerHands;

namespace PokerHandsTest
{
    [TestFixture]
    public class PokerHandsTest
    {
        [Test]
        public void TestPokerDeckContains_52_Cards()
        {
            Assert.AreEqual(52, new Deck().Amount());
        }
    }
}
