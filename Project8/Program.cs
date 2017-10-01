namespace Project8
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(String[] args)
        {
            var numberOfTestCase = Convert.ToInt32(Console.ReadLine());
            for (var a0 = 0; a0 < numberOfTestCase; a0++)
            {
                var tokensN = Console.ReadLine().Split(' ');
                var n = Convert.ToInt32(tokensN[0]);
                var k = Convert.ToInt32(tokensN[1]);
                var num = Console.ReadLine();
                Console.WriteLine(GetLargestProduct(n,k,num));
            }
        }

        private static long GetLargestProduct(int length, int consecutive, string number)
        {
            var maxProductStartIndex = 0;

            for (var i = consecutive; i < length; i++)
            {
                if (number.ElementAt(i) == '0')
                {
                    i += consecutive -1;
                    continue;
                }
                if (IsGreater(i, maxProductStartIndex, number, consecutive))
                {
                    maxProductStartIndex = i - consecutive + 1;
                }
            }

            long largestProduct = 1;

            for (var i = 0; i < consecutive; i++)
            {
                largestProduct *= (long)char.GetNumericValue(number.ElementAt(maxProductStartIndex + i));
            }

            return largestProduct;
        }

        private static bool IsGreater(int iterator, int maxIndex, string number, int consecutive)
        {
            var numberOfElementMustBeChecked = GetNumberOfElementsMustBeChecked(iterator, maxIndex, consecutive);
            long oldProduct = 1;
            long newProduct = 1;

            for (var i = 0; i < numberOfElementMustBeChecked; i++)
            {
                oldProduct *= (long) char.GetNumericValue(number.ElementAt(maxIndex + i));
                newProduct *= (long) char.GetNumericValue(number.ElementAt(iterator - i));
            }

            return newProduct > oldProduct;
        }

        private static int GetNumberOfElementsMustBeChecked(int iterator, int maxIndex, int consecutive)
        {
            var numberOfElementMustBeChecked = iterator - maxIndex - consecutive + 1;

            return numberOfElementMustBeChecked > consecutive ? consecutive : numberOfElementMustBeChecked;
        }
    }
}
