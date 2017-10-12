namespace Project15
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class Program
    {
        private static readonly BigInteger modulo = 1000000007;

        public static void Main(string[] args)
        {
            var numberOfTestCases = Convert.ToInt32(Console.ReadLine());

            for (var i = 0; i < numberOfTestCases; i++)
            {
                var inputArray = Console.ReadLine().Split(' ');
                var n = BigInteger.Parse(inputArray.ElementAt(0));
                var m = BigInteger.Parse(inputArray.ElementAt(1));

                Console.WriteLine((Factorial(n + m) / (Factorial(n) * Factorial(m))) % modulo); 
            }
        }

        public static BigInteger Factorial(BigInteger number)
        {
            if (number == 1)
            {
                return 1;
            }

            return number * Factorial(number - 1);
        }
    }
}
