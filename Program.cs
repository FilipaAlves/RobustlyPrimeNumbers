using System;
using static ChallengeRobustlyPrimeNumbers.RobustlyPrimeNumbers;

namespace ChallengeRobustlyPrimeNumbers
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***Challenge Robustly Prime Numbers***");
            Console.WriteLine("Write a input number between 1 and 2209 to get the RPN.");
            string input = Console.ReadLine();
            CalculateRTN(input);
        }
    }
}
