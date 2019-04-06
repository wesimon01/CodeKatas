using System;

namespace Greed
{
    class Program
    {
        private static readonly Random getRandom = new Random();
        static void Main(string[] args)
        {
            int[] result = new int[5];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = GetRandomNumber(1, 7);
            }
            foreach (int i in result)
            {

            }
            
        }

        private static int GetRandomNumber(int min, int max)
        {
            lock (getRandom)
            {
                return getRandom.Next(min, max);
            }
        }
    }
}
