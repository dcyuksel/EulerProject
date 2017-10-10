namespace Project13
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    public class Program
    {
        public static void Main(String[] args)
        {
            var inputNumber = Convert.ToInt32(Console.ReadLine());
            var numbers = new List<BigInteger>();

            for (var i = 0; i < inputNumber; i++)
            {
                var number = BigInteger.Parse(Console.ReadLine());
                numbers.Add(number);
            }
            
            Console.WriteLine(GetFirstTenIntegersOfSum(numbers));
        }

        private static string GetFirstTenIntegersOfSum(List<BigInteger> numbers)
        {
            BigInteger sum = numbers.Aggregate<BigInteger, BigInteger>(0, (current, number) => BigInteger.Add(current, number));
            var stringFormOfSum = sum.ToString();
            return new string(stringFormOfSum.Take(10).ToArray());
        }
    }
}
