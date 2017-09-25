namespace Project2
{
    using System.Collections.Generic;
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            var outputs = new List<long>();

            for (int a0 = 0; a0 < t; a0++)
            {
                long n = Convert.ToInt64(Console.ReadLine());
                outputs.Add(GetSumOfEvenFibonacciNumbersUntilN(n));
            }

            foreach (var output in outputs)
            {
                Console.WriteLine(output);
            }
        }

        private static long GetSumOfEvenFibonacciNumbersUntilN(long n)
        {
            long sum = 2;
            long leftNumber = 1;
            long rightNumber = 2;

            while (true)
            {
                var number = leftNumber + rightNumber;

                if (number <= n)
                {
                    leftNumber = rightNumber;
                    rightNumber = number;
                    if (IsItEvenOrNot(number))
                    {
                        sum += number;
                    }
                }
                else
                {
                    break;
                }
            }

            return sum;
        }

        private static bool IsItEvenOrNot(long n)
        {
            return n % 2 == 0;
        }
    }
}
