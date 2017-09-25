namespace Project4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            var outputs = new List<int>();

            for (int a0 = 0; a0 < t; a0++)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                outputs.Add(GetMaxPalindrome(n));
            }

            foreach (var output in outputs)
            {
                Console.WriteLine(output);
            }
        }

        private static int GetMaxPalindrome(int number)
        {
            var maxPalindrome = 101101;

            for (var i = 101; i < 1000; i++)
            {
                if (i % 10 == 0)
                {
                    continue;
                }

                var lowerBound = maxPalindrome / i;

                for (var j = lowerBound; j < 1000; j++)
                {
                    if (j % 10 == 0)
                    {
                        continue;
                    }

                    var generatedNumber = i * j;

                    if (generatedNumber % 10 == 0 || generatedNumber < maxPalindrome)
                    {
                        continue;
                    }

                    if (generatedNumber >= number)
                    {
                        break;
                    }

                    if (IsItPalindrome(generatedNumber.ToString()))
                    {
                        maxPalindrome = generatedNumber;
                    }
                }
            }

            return maxPalindrome;
        }

        private static bool IsItPalindrome(string number)
        {
            for (var i = 0; i < 3; i++)
            {
                if (number.ElementAt(i) != number.ElementAt(5 - i))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
