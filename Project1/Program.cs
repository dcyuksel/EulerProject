namespace Project1
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private const long Divider = 2;

        public static void Main(string[] args)
        {
            var t = Convert.ToInt32(Console.ReadLine());
            var outputs = new List<long>();

            for (var a0 = 0; a0 < t; a0++)
            {
                var n = Convert.ToInt64(Console.ReadLine());
                outputs.Add(GetSum(n));
            }

            foreach (var output in outputs)
            {
                Console.WriteLine(output);
            }
        }

        private static long GetSum(long n)
        {
            return GetSumForDivisorThree(n) + GetSumForDivisorFive(n) - GetSumForDivisorFifteen(n);
        }

        private static long GetSumForDivisorThree(long n)
        {
            var maximumDivisorOfThree = GetMaxDivisor(n, 3);

            return ((maximumDivisorOfThree * (maximumDivisorOfThree + 1)) / Divider) * 3;
        }

        private static long GetSumForDivisorFive(long n)
        {
            var maximumDivisorOfFive = GetMaxDivisor(n, 5);

            return ((maximumDivisorOfFive * (maximumDivisorOfFive + 1)) / Divider) * 5;
        }

        private static long GetSumForDivisorFifteen(long n)
        {
            var maximumDivisorOfFifTeen = GetMaxDivisor(n, 15);

            return ((maximumDivisorOfFifTeen * (maximumDivisorOfFifTeen + 1)) / Divider) * 15;
        }

        private static long GetMaxDivisor(long n, long number)
        {
            var a = (n - 1) % number;
            a = n - 1 - a;
            return a / number;
        }
    }
}