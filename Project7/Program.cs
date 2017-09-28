namespace Project7
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(String[] args)
        {
            var t = Convert.ToInt32(Console.ReadLine());
            var outputs = new List<long>();
            var processParameters = new ProcessParameters
                                        {
                                            IteratorNumber = 9,
                                            NecessaryPrimesForChecking = new List<long> { 2, 3, 5 },
                                            UpperBound = 15,
                                            Primes = new List<long> { 2, 3, 5, 7 }
                                        };

            for (var a0 = 0; a0 < t; a0++)
            {
                var n = Convert.ToInt32(Console.ReadLine());

                if (n > processParameters.Primes.Count)
                {
                    processParameters = GetProcessParametersForNthPrime(processParameters, n);
                }
                
                outputs.Add(processParameters.Primes.ElementAt(n - 1));
            }

            foreach (var output in outputs)
            {
                Console.WriteLine(output);
            }
        }

        private static ProcessParameters GetProcessParametersForNthPrime(
            ProcessParameters processParameters,
            int number)
        {
            var primes = processParameters.Primes;
            var necessaryPrimesForChecking = processParameters.NecessaryPrimesForChecking;
            long upperBound = processParameters.UpperBound;
            var iteratorNumber = processParameters.IteratorNumber;

            while (primes.Count != number)
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

                iteratorNumber = iteratorNumber + 2;
            }

            return new ProcessParameters
                            {
                                IteratorNumber = iteratorNumber,
                                NecessaryPrimesForChecking = necessaryPrimesForChecking,
                                UpperBound = upperBound,
                                Primes = primes
            };
        }

        private static bool IsPrime(long number, List<long> primes)
        {
            return primes.All(prime => number % prime != 0);
        }
    }
}
