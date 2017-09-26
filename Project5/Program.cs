using System;
using System.Collections.Generic;
using System.Linq;

namespace Project5
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
                outputs.Add(GetSmalllestMultiple(n));
            }

            foreach (var output in outputs)
            {
                Console.WriteLine(output);
            }
        }

        private static long GetSmalllestMultiple(int number)
        {
            if (number == 1)
            {
                return 1;
            }
            if (number == 2)
            {
                return 2;
            }

            var primes = GetPrimesLessThenAGivenNumber(number);
            var gcd = GetCommonDevisorOfPrimes(primes.ToList());

            var iterator = 1;

            while (true)
            {
                var smallestMultiple = gcd * iterator;

                if (CheckIsNumberDivisibleByAll(smallestMultiple, number))
                {
                    return smallestMultiple;
                }

                iterator++;
            }
        }

        private static bool CheckIsNumberDivisibleByAll(long smallestMultiple, int number)
        {
            for (var i = 3; i < number + 1; i++)
            {
                if (smallestMultiple % i != 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static long GetCommonDevisorOfPrimes(IList<int> primes)
        {
            long gcd = 1;

            for (var i = 0; i < primes.Count(); i++)
            {
                gcd *= primes.ElementAt(i);
            }

            return gcd;
        }

        private static IEnumerable<int> GetPrimesLessThenAGivenNumber(int number)
        {
            if (number == 3 || number == 4)
            {
                return new List<int> { 2, 3 };
            }
            if (number == 5)
            {
                return new List<int> { 2 , 3, 5};
            }

            var primes = new List<int>{2, 3, 5};

            for (var i = 6; i < number + 1; i++)
            {
                if (i % 2 != 0 && i % 3 != 0 && i % 5 != 0)
                {
                    primes.Add(i);
                }
            }

            return primes;
        }
    }
}
