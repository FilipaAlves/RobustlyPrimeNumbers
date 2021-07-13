using System;
using System.Linq;

namespace ChallengeRobustlyPrimeNumbers
{
    public class RobustlyPrimeNumbers
    {
        public static void CalculateRTN(string input)
        {            
            if (ValidateInput(input))
            {
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();

                int finalPrimeNumber = ProcessChalleng(Convert.ToInt32(input));
                watch.Stop();
                Output(input, finalPrimeNumber, watch);                
            }
            else
            {
                HandlerError(input);
                CalculateRTN(Console.ReadLine());
            }
        }

        public static bool ValidateInput(string input)
        {
            int resultTryParse = 0;
            
            if (!int.TryParse(input, out resultTryParse))
            {
                return false;
            }
            else
            {
                var userInput = Convert.ToInt32(input);
                if (userInput < 1 || userInput > 2209)
                {
                    return false;
                }
                else
                    return true;
            }
        }

        public static int ProcessChalleng(int userInput)
        {
            int count = 1, finalPrimeNumber = 0;
            bool isPartialNumbersPrime = true;
            if(userInput == 1)
            {
                return 2;
            }
            else
            {
                for (int i = 3; count < userInput; i+=2)
                {
                    isPartialNumbersPrime = true;
                    var iString = i.ToString(); 
                    if (!iString.Contains('0'))
                    {
                        if (IsPrime(i))
                        {
                            if (i > 10)
                            {
                                for (int k = 1; k < iString.Length; k++)
                                {
                                    if (!IsPrime(Convert.ToInt32(iString.Substring(k))))
                                    {
                                        isPartialNumbersPrime = false;
                                        break;
                                    }
                                }
                                if (isPartialNumbersPrime)
                                {
                                    finalPrimeNumber = i;
                                    count++;
                                }
                            }
                            else
                            {
                                finalPrimeNumber = i;
                                count++;
                            }
                        }
                    }
                }
                return finalPrimeNumber;
            }
        }
        public static bool IsPrime(int num)
        {
            if (num == 1) return false;
            if (num == 2 || num == 3 || num == 5) return true;
            if (num % 2 == 0 || num % 3 == 0 || num % 5 == 0) return false;

            int i = 6;
            while (i <= (int)Math.Floor(Math.Sqrt(num)))
            {
                if (num % (i + 1) == 0 || num % (i + 5) == 0)
                    return false;
                i += 6;
            }
            return true;
        }
    
        static void HandlerError(string userInput)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"ERROR, the input you entered: '{userInput}' is incorrect. Need to put a input between 1 and 2209");
            Console.ResetColor();
            Console.WriteLine("Write a input number between 1 and 2209 to get the RPN.");
        }

        public static void Output(string userInput, int finalPrimeNumber, System.Diagnostics.Stopwatch watch)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"input '{userInput}' should give output {finalPrimeNumber} ");
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds/1000} s");
            Console.WriteLine("Key ENTER to close...");
            Console.ReadLine();
        }
    }
}
