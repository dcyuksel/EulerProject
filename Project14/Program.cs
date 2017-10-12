namespace Project14
{
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public class Program
    {
        private static List<Tuple<long, long, long, long>> Container = new List<Tuple<long, long, long, long>>();
        // Item1 for number 
        // Item2 max chain produced by number n
        // Item3 for max chain 
        // Item4 for chain produced by number 
        
        public static void Main(string[] args)
        {
            var numberOfTestCases = Convert.ToInt32(Console.ReadLine());
            Container.Add(new Tuple<long, long, long, long>(1, 1, 0, 0));
            Container.Add(new Tuple<long, long, long, long>(2, 2, 1, 1));

            for (var i = 0; i < numberOfTestCases; i++)
            {
                var n = Convert.ToInt32(Console.ReadLine());
                GetDictionary(n);
                Console.WriteLine(Container.ElementAt(n - 1).Item2);
            }
        }

        private static void GetDictionary(long number)
        {
            var lastKeyOfDictionary = Container.Last().Item1;

            if (lastKeyOfDictionary < number)
            {
                for (var i = lastKeyOfDictionary + 1; i <= number; i++)
                {
                    var lengthOfChain = GetChainLongForNumber(i);
                    if (Container.Last().Item3 <= lengthOfChain)
                    {
                        Container.Add(new Tuple<long, long, long, long>(i, i, lengthOfChain, lengthOfChain));
                    }
                    else
                    {
                        Container.Add(new Tuple<long, long, long, long>(i, Container.Last().Item2, Container.Last().Item3, lengthOfChain));
                    }
                   
                }
            }
        }

        private static long GetChainLongForNumber(long number)
        {
            var lengthOfChain = 0;
            var containerLastNumber = Container.Last().Item1;

            while (number != 1)
            {
                if (IsNumberEven(number))
                {
                    number /= 2;

                    if (number <= containerLastNumber)
                    {
                        return lengthOfChain + 1 + Container.ElementAt((int)number-1).Item4;
                    }
                }
                else
                {
                    number = (3 * number) + 1;
                }

                lengthOfChain++;
            }

            return lengthOfChain;
        }

        public static bool IsNumberEven(long number)
        {
            return number % 2 == 0;
        }
    }
}
