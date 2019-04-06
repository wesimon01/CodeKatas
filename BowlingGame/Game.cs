using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame
{
    class Game
    {
        private int[] rolls = new int[21];
        private int currentRoll = 0;
        public int GameScore { get; private set; }
        internal void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        internal void Score()
        {
            int score = 0;
            int frameIndex = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(frame)) {
                    score += 10 + StrikeBonus(frameIndex);
                    frameIndex++;
                }
                else if (IsSpare(frame)) {
                    score += 10 + SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else {
                    score += SumOfBallsInFrame(frameIndex);
                    frameIndex += 2;
                }
            }
            GameScore = score;
        }

        private bool IsStrike(int frameIndex) {
            return rolls[frameIndex] == 10;
        }

        private int SumOfBallsInFrame(int frameIndex) {
            return rolls[frameIndex] + rolls[frameIndex + 1];
        }

        private int SpareBonus(int frameIndex) {
            return rolls[frameIndex + 2];
        }

        private int StrikeBonus(int frameIndex) {
            return rolls[frameIndex + 1] + rolls[frameIndex + 2];
        }

        private bool IsSpare(int frameIndex) {
            return ((rolls[frameIndex] + rolls[frameIndex + 1]) == 10);
        }
    }
}
