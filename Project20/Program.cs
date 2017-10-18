namespace Project20
{
    using System;
    using System.Numerics;

    public class Program
    {
        public static BigInteger[] container = new BigInteger[1001];
        public static int index = 0;

        public static void Main(string[] args)
        {
            var numberOfTestCases = Convert.ToInt32(Console.ReadLine());
            container[0] = 1;

            for (var i = 0; i < numberOfTestCases; i++)
            {
                var number = Convert.ToInt32(Console.ReadLine());
                var factorial = GetFactorialOfNumber(number);
                Console.WriteLine(GetDigitSum(factorial));
            }
        }

        private static int GetDigitSum(BigInteger number)
        {
            var sum = 0;

            while (number > 0)
            {
                sum += (int)(number % 10);
                number /= 10;
            }

            return sum;
        }

        private static BigInteger GetFactorialOfNumber(int number)
        {
            if (index >= number)
            {
                return container[number];
            }

            for (var i = index + 1; i <= number; i++)
            {
                container[i] = container[i - 1] * i;
                index++;
            }

            return container[number];
        }
    }
}
