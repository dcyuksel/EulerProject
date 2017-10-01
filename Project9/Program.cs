namespace Project9
{
    using System;
    
    public class Program
    {
        public static void Main(String[] args)
        {
            var t = Convert.ToInt32(Console.ReadLine());
            for (var a0 = 0; a0 < t; a0++)
            {
                var n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(GetTripletMultiplication(n));
            }
        }

        private static long GetTripletMultiplication(int number)
        {
            long maxMultiple = -1;

            for (var c = 5; c < number/2; c++)
            {
                var aPlusb = number - c;
                var squareOfaPlusb = aPlusb * aPlusb;
                var squareOfaPlusSquareOfb = c * c;
                var aTimesbTimes2 = squareOfaPlusb - squareOfaPlusSquareOfb;
                var aMinusb = Math.Sqrt(squareOfaPlusSquareOfb - aTimesbTimes2);

                if (!IsItInteger(aMinusb)) continue;
                var a = (aPlusb + aMinusb) / 2;

                if (!IsItInteger(a)) continue;
                var b = aPlusb - (int)a;

                if (!CheckTriplet((int) a, b, c)) continue;
                var multiple = (long)a * b * c;

                if (multiple > maxMultiple)
                {
                    maxMultiple = multiple;
                }
            }

            return maxMultiple;
        }

        private static bool CheckTriplet(int a, int b, int c)
        {
            return a * a + b * b == c * c;
        }

        private static bool IsItInteger(double number)
        {
            return number % 1 == 0;
        }
    }
}
