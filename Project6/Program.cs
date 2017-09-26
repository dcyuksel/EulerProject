using System;
using System.Collections.Generic;

namespace Project6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var t = Convert.ToInt32(Console.ReadLine());
            var outputs = new List<long>();

            for (var a0 = 0; a0 < t; a0++)
            {
                var n = Convert.ToInt32(Console.ReadLine());
                outputs.Add(GetSumSquareDifference(n));
            }

            foreach (var output in outputs)
            {
                Console.WriteLine(output);
            }
        }

        private static long GetSumSquareDifference(int number)
        {
            return GetSquareOfTheSum(number) - GetSumOfSquares(number);
        }

        private static long GetSumOfSquares(int number)
        {
            var numberLongVersion = (long) number;

            return (numberLongVersion * (numberLongVersion + 1) * ((2 * numberLongVersion) + 1)) / 6;
        }

        private static long GetSquareOfTheSum(int number)
        {
            var numberLongVersion = (long)number;
            var sum = (numberLongVersion * (numberLongVersion + 1)) / 2;
            return sum * sum;
        }
    }
}
