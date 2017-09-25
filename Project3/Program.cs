namespace Project3
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(String[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            var outputs = new List<long>();

            for (int a0 = 0; a0 < t; a0++)
            {
                long n = Convert.ToInt64(Console.ReadLine());
                outputs.Add(GetMaxDivisor(n));
            }

            foreach (var output in outputs)
            {
                Console.WriteLine(output);
            }
        }

        public static long GetMaxDivisor(long number)
        {
            while (number % 2 == 0)
            {
                number = number / 2;
            }

            if (number == 1)
            {
                return 2;
            }

            long counter = 3;
            var possibleMaxValue = GetGreatestPossibleValueOfDivisor(number);
            long maxValue = 1;

            while (counter <= possibleMaxValue)
            {
                if (number % counter == 0)
                {
                    number = number / counter;
                    maxValue = counter;
                }
                else
                {
                    counter = counter + 2;
                }
            }

            if (number > 2)
            {
                return number;
            }

            return maxValue;
        }

        private static long GetGreatestPossibleValueOfDivisor(long number)
        {
            return (long)Math.Floor(Math.Sqrt(number));
        }
    }
}
