using System.Linq;

namespace Project10
{
    using System.Collections.Generic;
    using System;

    public class Program
    {
        public static void Main(String[] args)
        {
            var t = Convert.ToInt32(Console.ReadLine());
            var processParameters = new ProcessParameters
            {
                IteratorNumber = 9,
                NecessaryPrimesForChecking = new List<int> { 2, 3, 5 },
                UpperBound = 15,
                Primes = new List<int> { 2, 3, 5, 7 }
            };

            for (var a0 = 0; a0 < t; a0++)
            {
                var n = Convert.ToInt32(Console.ReadLine());

                if (n > processParameters.Primes.Last())
                {
                    processParameters = GetProcessParametersForN(processParameters, n);
                    Console.WriteLine(GetSumOfPrimesUntilN(n, processParameters.Primes));
                }
                else
                {
                    Console.WriteLine(GetSumOfPrimesUntilN(n, processParameters.Primes));
                }
            }
        }

        private static ProcessParameters GetProcessParametersForN(ProcessParameters processParameters, int n)
        {
            var primes = processParameters.Primes;
            var necessaryPrimesForChecking = processParameters.NecessaryPrimesForChecking;
            var upperBound = processParameters.UpperBound;
            var iteratorNumber = processParameters.IteratorNumber;

            while (iteratorNumber <= n)
            {
                if (iteratorNumber == upperBound)
                {
                    var lengthOfNecessaryPrimesForChecking = necessaryPrimesForChecking.Count;
                    upperBound = primes.ElementAt(lengthOfNecessaryPrimesForChecking) *
                                 primes.ElementAt(lengthOfNecessaryPrimesForChecking - 1);

                    necessaryPrimesForChecking.Add(primes.ElementAt(necessaryPrimesForChecking.Count));
                }
                else
                {
                    if (IsPrime(iteratorNumber, necessaryPrimesForChecking))
                    {
                        primes.Add(iteratorNumber);
                    }
                }

                iteratorNumber += 2;
            }

            return new ProcessParameters
            {
                IteratorNumber = iteratorNumber,
                NecessaryPrimesForChecking = necessaryPrimesForChecking,
                UpperBound = upperBound,
                Primes = primes
            };
        }

        private static bool IsPrime(int number, List<int> primes)
        {
            return primes.All(prime => number % prime != 0);
        }

        private static long GetSumOfPrimesUntilN(int n, List<int> primes)
        {
            var count = 0;
            var length = primes.Count;
            long sum = 0;

            while (count < length && primes.ElementAt(count) <= n)
            {
                sum += primes.ElementAt(count);
                count++;
            }

            return sum;
        }
    }
}
