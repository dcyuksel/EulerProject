namespace Project17
{
    using System;

    public class Program
    {
        private static readonly string[] LowerTwenty = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private static readonly string[] UpperTwenty = { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        public static void Main(string[] args)
        {
            var numberOfTestCases = Convert.ToInt32(Console.ReadLine());

            for (var i = 0; i < numberOfTestCases; i++)
            {
                var input = Convert.ToInt64(Console.ReadLine());
                var output = NumberToWords(input);
                Console.WriteLine(output);
            }
        }

        public static string NumberToWords(long input)
        {
            if (input == 0)
                return "zero";

            var output = string.Empty;

            if (input >= 1000000000)
            {
                output += NumberToWords(input / 1000000000) + " Billion ";
                input %= 1000000000;
            }

            if (input >= 1000000)
            {
                output += NumberToWords(input / 1000000) + " Million ";
                input %= 1000000;
            }

            if (input >= 1000)
            {
                output += NumberToWords(input / 1000) + " Thousand ";
                input %= 1000;
            }

            if (input >= 100)
            {
                output += NumberToWords(input / 100) + " Hundred ";
                input %= 100;
            }

            if (input > 0)
            {
                if (input < 20)
                {
                    output += LowerTwenty[input];
                }
                else
                {
                    output += UpperTwenty[input / 10];
                    if ((input % 10) > 0)
                        output += " " + LowerTwenty[input % 10];
                }
            }

            return output;
        }
    }
}
