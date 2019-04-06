using System;

namespace BowlingGame
{
    class Program
    {
        static void Main()
        {
            int[] rolls = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            var g = new Game();

            foreach (int pins in rolls)
            {
                g.Roll(pins);
            }
            g.Score();

            Console.WriteLine($"Final Score: {g.GameScore}");
            Console.ReadLine();
        }
    }
}
