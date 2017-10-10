namespace Project12
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            var numberOfTestCases = Convert.ToInt32(Console.ReadLine());

            for (var i = 0; i < numberOfTestCases; i++)
            {
                var n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(GetFirstTriangleNumbleHaveOverNDivisors(n));
            }
        }

        private static long GetFirstTriangleNumbleHaveOverNDivisors(int n)
        {
            long count = 2;
            while (true)
            {
                var number = count * (count + 1) / 2;
                var factorizationDictionary = GetFactorizationOfNumber(number);
                if (GetDivisorNumber(factorizationDictionary) > n)
                {
                    return number;
                }
                count++;
            }

        }

        private static int GetDivisorNumber(Dictionary<int, int> dictionary)
        {
            var numberOfDivisor = 1;

            foreach (var dict in dictionary)
            {
                numberOfDivisor *= dict.Value + 1;
            }

            return numberOfDivisor;
        }

        private static Dictionary<int, int> GetFactorizationOfNumber(long number)
        {
            var dictionary = new Dictionary<int, int>{};

            if (number % 2 == 0)
            {
                dictionary.Add(2,1);
                number /= 2;
            }

            while (number % 2 == 0)
            {
                dictionary[2]++;
                number /= 2;
            }

            for (var i = 3; i <= Math.Sqrt(number); i = i + 2)
            {
                if (number % i == 0)
                {
                    dictionary.Add(i, 1);
                    number /= i;
                }

                while (number % i == 0)
                {
                    dictionary[i]++;
                    number = number / i;
                }
            }

            if (number != 1)
            {
                if (!dictionary.ContainsKey((int)number))
                {
                    dictionary.Add((int)number, 1);
                }
                else
                {
                    dictionary[(int)number]++;
                }

            }

            return dictionary;
        }
    }
}
