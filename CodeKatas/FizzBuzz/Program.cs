using System;

namespace FizzBuzz
{
    class Program
    {
        private const int numberCeiling = 100;
        private const string sMult3and5 = "FizzBuzz";
        private const string sMult3 = "Fizz";
        private const string sMult5 = "Buzz";
        
        static void Main()
        {
            for (int i = 1; i < numberCeiling + 1; i++)
            {
                bool foundMatch = LookForDigitMatches(i);             
                if (foundMatch) continue;

                DetermineMultiples(i);                
            }
            Console.ReadLine();
        }

        private static bool LookForDigitMatches(int number)
        {
            bool matchFound = false;
            if (number.ToString().Contains("5"))
            {
                if (number.ToString().Contains("3"))
                {
                    ConsoleColorWriteLine($"{number} FizzBuzz", ConsoleColor.Cyan);
                    matchFound = true;
                }
                else
                {
                    ConsoleColorWriteLine($"{number} Buzz", ConsoleColor.Green);
                    matchFound = true;
                }
            }
            else if (number.ToString().Contains("3"))
            {
                ConsoleColorWriteLine($"{number} Fizz", ConsoleColor.Yellow);
                matchFound = true;
            }
            return matchFound;
        }

        private static void DetermineMultiples(int number)
        {
            if (number % 5 == 0)
            {
                if (number % 3 == 0)
                    ConsoleColorWriteLine(number + " " + sMult3and5, ConsoleColor.Cyan);
                else
                    ConsoleColorWriteLine(number + " " + sMult5, ConsoleColor.Green);

            }
            else if (number % 3 == 0)
                ConsoleColorWriteLine(number + " " + sMult3, ConsoleColor.Yellow);
            else
                ConsoleColorWriteLine(number.ToString(), ConsoleColor.White);
        }

        private static void ConsoleColorWriteLine(string message, ConsoleColor consoleColor)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = consoleColor;
            if (message != null)
                Console.WriteLine(message);
            Console.ForegroundColor = originalColor;
        }
    }
}
