namespace Project18
{
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var numberOfTestCases = Convert.ToInt32(Console.ReadLine());

            for (var i = 0; i < numberOfTestCases; i++)
            {
                var numberOfLines = Convert.ToInt32(Console.ReadLine());
                var triangle = new List<List<int>>();
                var counter = 0;

                while (counter < numberOfLines)
                {
                    var line = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                    triangle.Add(line);
                    counter++;
                }

                Console.WriteLine(GetMaxSum(numberOfLines, triangle));
            }
        }

        private static int GetMaxSum(int numberOfLines, List<List<int>> triangle)
        {
            for (var i = numberOfLines - 2; i >= 0; i--)
            {
                for (var j = 0; j <= i; j++)
                {
                    var left = triangle.ElementAt(i + 1).ElementAt(j);
                    var right = triangle.ElementAt(i + 1).ElementAt(j + 1);

                    if (left > right)
                    {
                        triangle[i][j] = triangle.ElementAt(i).ElementAt(j) + left;
                        continue;
                    }

                    triangle[i][j] = triangle.ElementAt(i).ElementAt(j) + right;
                }
            }

            return triangle.ElementAt(0).ElementAt(0);
        }
    }
}
