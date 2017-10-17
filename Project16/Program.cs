namespace Project16
{
    using System;
    using System.Numerics;

    public class Program
    {
        private static readonly BigInteger[] Container = new BigInteger[10001];
        private static int index = 0;

        public static void Main(string[] args)
        {
            var numberOfTestCases = Convert.ToInt32(Console.ReadLine());
            Container[0] = (1);

            for (var i = 0; i < numberOfTestCases; i++)
            {
                var input = Convert.ToInt32(Console.ReadLine());
                var number = GetPowerDigit(input);
                PrintDigitSum(number);
            }
        }

        private static void PrintDigitSum(BigInteger number)
        {
            var sum = 0;

            while (number != 0)
            {
                sum += (int)(number % 10);
                number /= 10;
            }

            Console.WriteLine(sum);
        }

        private static BigInteger GetPowerDigit(int input)
        {
            if (index >= input)
            {
                return Container[input];
            }

            index++;
            Container[index] = Container[index - 1] * 2;
            return GetPowerDigit(input);
        }
    }
}
