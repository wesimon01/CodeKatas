using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greed
{
    [TestFixture]
    public class GreedScoreTester
    {
        [TestCase(1, 1, 1, 2, 3, 1000)]
        [TestCase(1, 1, 1, 1, 5, 1150)]
        [TestCase(1, 1, 1, 1, 1, 1200)]
        [TestCase(2, 3, 4, 6, 2, 0)]
        [TestCase(3, 4, 5, 3, 3, 350)]
        [TestCase(1, 5, 1, 2, 4, 250)]
        public void GameScore(int die1, int die2, int die3, int die4, int die5, int expectedScore)
        {
            var values = new int[] { die1, die2, die3, die4, die5 };
            var greed = new Greed();
            int score = greed.Score(values);
            Assert.That(score == expectedScore);
        }

        [TestCase(new int[] { 2, 2, 2, 2, 2, 2 }, 1600)]
        [TestCase(new int[] { 1, 1, 1, 1, 5 }, 2050)]
        [TestCase(new int[] { 1, 1, 1, 1, 1 }, 4000)]
        [TestCase(new int[] { 2, 2, 3, 3, 4, 4 }, 800)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 1200)]
        [TestCase(new int[] { 1, 2, 3, 6 }, 100)]
        public void GameScore2(int[] values, int expectedScore)
        {     
            var greed = new Greed();
            int score = greed.Score2(values);
            Assert.That(score == expectedScore);
        }
    }
}
