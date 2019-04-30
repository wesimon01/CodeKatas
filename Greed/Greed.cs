using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greed
{
    public class Greed
    {
        private const int tripleOnePoints = 1000;
        private const int threePairsPoints = 800;
        private const int straightPoints = 1200;
        
        public int Score(int[] ints)
        {
            IEnumerable<IGrouping<int, int>> groupedDieRolls = ints.GroupBy(c => c);
            return groupedDieRolls.Sum(g => ScoreSet(g.Key, g.ToList()));
        }
        
        private int ScoreSet(int key, IList<int> values)
        {
            int score = 0;
            int count = values.Count();

            switch (key)
            {
                case 1:
                    if (count >= 3)
                    {
                        score += 1000;
                        int extraOnes = count - 3;
                        score += (100 * extraOnes);
                    }
                    else {
                        score += (count * 100);
                    }
                    break;

                case 5:
                    if (count >= 3)
                    {
                        score += 500;
                        int extraFives = count - 3;
                        score += (extraFives * 50);
                    }
                    else {
                        score += (count * 50);
                    }
                    break;

                default:
                    if (count >= 3) {
                        score += (key * 100);
                    }                    
                    break;
            }
            return score;
        }

        public int Score2(int[] ints)
        {
            if (ints.Count() == 6)
            {
                int[] dieCounts = CountInstanceOfEachRollValue(ints);

                if (FoundStraight(dieCounts))
                    return straightPoints;
                else if (FoundThreePairs(dieCounts))
                    return threePairsPoints;
            }
            IEnumerable<IGrouping<int, int>> groupedDieRolls = ints.GroupBy(c => c);           
            return groupedDieRolls.Sum(g => ScoreSet2(g.Key, g.ToList()));
        }

        private int ScoreSet2(int key, IList<int> values)
        {
            int score = 0;
            int count = values.Count();
            int triplePoints = key * 100;
            
            switch (key)
            {
                case 1:
                    if (count == 3)                    
                        score += tripleOnePoints;                    
                    else if (count == 4)
                        score += 2 * tripleOnePoints;
                    else if (count == 5)
                        score += 4 * tripleOnePoints;
                    else if (count == 6)
                        score += 8 * tripleOnePoints;
                    else                   
                        score += (count * 100);                    
                    break;

                case 5:
                    if (count == 3)                   
                        score += 500;                    
                    else if (count == 4)
                        score += 2 * triplePoints;
                    else if (count == 5)
                        score += 4 * triplePoints;
                    else if (count == 6)
                        score += 8 * triplePoints;
                    else
                        score += (count * 50);                   
                    break;

                default:
                    if (count == 3)                  
                        score += triplePoints;                  
                    else if (count == 4)                   
                        score += 2 * triplePoints;                    
                    else if (count == 5)
                        score += 4 * triplePoints;
                    else if (count == 6)
                        score += 8 * triplePoints;
                    break;
            }
            return score;
        }

        private static int[] CountInstanceOfEachRollValue(int[] values)
        {
            int ones = 0,
                    twos = 0,
                    threes = 0,
                    fours = 0,
                    fives = 0,
                    sixes = 0;
            foreach (int i in values)
            {
                switch (i)
                {
                    case 1:
                        ones++;
                        break;
                    case 2:
                        twos++;
                        break;
                    case 3:
                        threes++;
                        break;
                    case 4:
                        fours++;
                        break;
                    case 5:
                        fives++;
                        break;
                    case 6:
                        sixes++;
                        break;
                    default:
                        throw new ApplicationException();
                }
            }
            return new int[] { ones, twos, threes, fours, fives, sixes };
        }

        private static bool FoundThreePairs(int[] values)
        {
            int pairsCount = 0;
            foreach (var i in values) {
                if (i == 2)
                    pairsCount++;
            }
            if (pairsCount == 3)
                return true;
            else
                return false;
        }
        private static bool FoundStraight(int[] values)
        {
            if (values.Where(i => i == 1).Count() == values.Length)
            {
                return true;
            }
            return false;
        }
       
    }
}