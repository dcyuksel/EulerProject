namespace Project19
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var numberOfTestCases = Convert.ToInt16(Console.ReadLine());

            for (var i = 0; i < numberOfTestCases; i++)
            {
                var date1 = Console.ReadLine().Split(' ');
                var date2 = Console.ReadLine().Split(' ');

                var countOfSundays = GetCountOfSundays(
                    Convert.ToInt64(date1[0]), Convert.ToInt32(date1[1]), Convert.ToInt32(date1[2]),
                    Convert.ToInt64(date2[0]), Convert.ToInt32(date2[1]));

                Console.WriteLine(countOfSundays);
            }
        }

        private static int GetCountOfSundays(long year1, int month1, int day1, long year2, int month2)
        {
            if (year2 < year1)
            {
                return 0;
            }

            if (year1 == year2)
            {
                return GetNumberOfSundaysIfSameYear(day1, month1, month2, year1);
            }

            var countOfSundays = GetNumberOfSundaysForFirstYear(day1, month1, year1);
            countOfSundays += GetNumberOfSundaysForLastYear(month2, year2);

            for (var i = year1 + 1; i < year2; i++)
            {
                for (var j = 1; j <= 12; j++)
                {
                    if (IsItSunday(1, j, i))
                    {
                        countOfSundays++;
                    }
                }
            }

            return countOfSundays;
        }

        private static int GetNumberOfSundaysForLastYear(int month2, long year2)
        {
            var countOfSundays = 0;

            for (var i = 1; i <= month2; i++)
            {
                if (IsItSunday(1, i, year2))
                {
                    countOfSundays++;
                }
            }

            return countOfSundays;
        }

        private static int GetNumberOfSundaysForFirstYear(int day1, int month1, long year1)
        {
            var countOfSundays = 0;

            if (day1 == 1 && IsItSunday(1, month1, year1))
            {
                countOfSundays++;
            }

            for (var i = month1 + 1; i <= 12; i++)
            {
                if (IsItSunday(1, i, year1))
                {
                    countOfSundays++;
                }
            }

            return countOfSundays;
        }

        private static int GetNumberOfSundaysIfSameYear(int day1, int month1, int month2, long year)
        {
            var countOfSundays = 0;

            if (day1 == 1 && IsItSunday(1, month1, year))
            {
                countOfSundays++;
            }

            for (var i = month1 + 1; i <= month2; i++)
            {
                if (IsItSunday(1, i, year))
                {
                    countOfSundays++;
                }
            }

            return countOfSundays;
        }
        
        // Used Zeller Congruence
        private static bool IsItSunday(int day, int month, long year)
        {
            if (month == 1)
            {
                month = 13;
                year--;
            }
            if (month == 2)
            {
                month = 14;
                year--;
            }

            var q = day;
            var m = month;
            var k = year % 100;
            var j = year / 100;
            var h = q + 13 * (m + 1) / 5 + k + k / 4 + j / 4 + 5 * j;
            h = h % 7;

            return h == 1;
        }
    }
}
