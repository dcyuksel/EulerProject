namespace Project11
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(String[] args)
        {
            var grid = new int[20][];
            for (var row = 0; row < 20; row++)
            {
                var grid_temp = Console.ReadLine().Split(' ');
                grid[row] = Array.ConvertAll(grid_temp, Int32.Parse);
            }

            Console.WriteLine(GetLargestProductInAGrid(grid));
        }

        private static long GetLargestProductInAGrid(int[][] grid)
        {
            long largest = 0;

            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid.ElementAt(i).Length; j++)
                {
                    if (j<17)
                    {
                        var product = grid.ElementAt(i).ElementAt(j) *
                                      grid.ElementAt(i).ElementAt(j+1) *
                                      grid.ElementAt(i).ElementAt(j+2) *
                                      grid.ElementAt(i).ElementAt(j+3);

                        if (product > largest)
                        {
                            largest = product;
                        }
                    }
                    if (i < 17)
                    {
                        var product = grid.ElementAt(i).ElementAt(j) *
                                      grid.ElementAt(i + 1).ElementAt(j) *
                                      grid.ElementAt(i + 2).ElementAt(j) *
                                      grid.ElementAt(i + 3).ElementAt(j);

                        if (product > largest)
                        {
                            largest = product;
                        }
                    }
                    if (j>=3 && i<17)
                    {
                        var product = grid.ElementAt(i).ElementAt(j) *
                                      grid.ElementAt(i + 1).ElementAt(j - 1) *
                                      grid.ElementAt(i + 2).ElementAt(j - 2) *
                                      grid.ElementAt(i + 3).ElementAt(j - 3);

                        if (product > largest)
                        {
                            largest = product;
                        }
                    }
                    if (j < 17 && i < 17)
                    {
                        var product = grid.ElementAt(i).ElementAt(j) *
                                      grid.ElementAt(i + 1).ElementAt(j + 1) *
                                      grid.ElementAt(i + 2).ElementAt(j + 2) *
                                      grid.ElementAt(i + 3).ElementAt(j + 3);

                        if (product > largest)
                        {
                            largest = product;
                        }
                    }
                }
            }

            return largest;
        }

    }
}
