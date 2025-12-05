using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AOC1
{
    public class Day5
    {

        public static void FirstSolution()
        {
            long sumOfGoodFood = 0;
            List<Func<long, bool>> goodFood = new List<Func<long, bool>>();

            int y = 0;
            var lines = File.ReadAllLines("day5.txt");

            bool isBeforeNewLine = true;
            foreach (var line in lines)
            {
                if (line == "")
                {
                    isBeforeNewLine = false;
                    continue;
                }

                if (isBeforeNewLine)
                {
                    var startAndEnd = line.Split('-');
                    var start = long.Parse(startAndEnd[0]);
                    var end = long.Parse(startAndEnd[1]);
                    goodFood.Add(CreateFunction(start, end));
                }
                else
                {
                    foreach (var good in goodFood)
                    {
                        if (good(long.Parse(line)))
                        {
                            sumOfGoodFood++;
                            break;
                        }
                    }

                }
            }


            Console.WriteLine($"First Solution: {sumOfGoodFood}");
        }

        public static Func<long,bool> CreateFunction(long start, long end)
        {
            return (long i) => { return (start <= i && end >= i); };
        }


        public static void SecondSolution()
        {
            long sumOfGoodFood = 0;
            
            List<(long, long)> ranges = new List<(long, long)>();
            HashSet<long> starts = new HashSet<long>();


            int y = 0;
            var lines = File.ReadAllLines("day5.txt");

            foreach (var line in lines)
            {
                if (line == "")
                {
                    break;
                }

                var startAndEnd = line.Split('-');
                var start = long.Parse(startAndEnd[0]);
                var end = long.Parse(startAndEnd[1]);
                ranges.Add((start, end));
                starts.Add(start);
            }

            bool changesFound = true;
            while (changesFound) {
                changesFound = false;
                ranges = ranges.OrderBy(x => x.Item1).ToList();

                for (int i = 0; i < ranges.Count - 1; i++)
                {
                    var range = ranges[i];
                    var nextRange = ranges[i + 1];
                    if (range.Item2 >= nextRange.Item1)
                    {
                        changesFound = true;
                        ranges[i] = (range.Item1, Math.Max(range.Item2, nextRange.Item2));
                        ranges.RemoveAt(i + 1);
                        break;
                    }
                }
            }

            for (int i = 0; i < ranges.Count - 1; i++)
            {
                var range = ranges[i];
                var nextRange = ranges[i + 1];
                if (range.Item1 < nextRange.Item1 && range.Item2 < nextRange.Item1)
                {

                }
                else
                {
                    Console.WriteLine($"somwthing wreonkgd");
                }
            }

            foreach (var range in ranges)
            {
                sumOfGoodFood += (range.Item2 + 1 - range.Item1);
            }

            Console.WriteLine($"Second Solution: {sumOfGoodFood}");
        }


        private static bool HasOnly4OrLessNeighbors2(int y, int x, (bool,bool)[,] grid)
        {
            List<(int, int)> neighbors = new List<(int, int)>();
            neighbors.Add((y - 1, x - 1));
            neighbors.Add((y - 1, x));
            neighbors.Add((y - 1, x + 1));
            neighbors.Add((y, x - 1));
            neighbors.Add((y, x + 1));
            neighbors.Add((y + 1, x - 1));
            neighbors.Add((y + 1, x));
            neighbors.Add((y + 1, x + 1));

            int i = 0;
            foreach (var neighbor in neighbors)
            {
                if (IsValidIndex2(neighbor.Item1, neighbor.Item2, grid) && grid[neighbor.Item1, neighbor.Item2].Item1)
                {
                    i++;
                }
            }
            return (i < 4);
        }

        private static bool IsValidIndex2(int y, int x, (bool,bool)[,] grid)
        {
            return (y >= 0 && x >= 0 && y < grid.GetLength(0) && x < grid.GetLength(1));
        }
    }
}
