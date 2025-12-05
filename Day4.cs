using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AOC1
{
    public class Day4
    {

        public static void FirstSolution()
        {
            long sumOfRolls = 0;
            bool[,] grid;

            int y = 0;
            var lines = File.ReadAllLines("day4.txt");
            grid = new bool[lines.Length, lines[0].Length];

            foreach (var line in lines)
            {
                int x = 0;
                foreach (var character in line)
                {
                    if (character == '@') {
                        grid[y, x] = true;
                    }
                    x++;
                }
                y++;
            }

            for (int yy = 0; yy < grid.GetLength(0); yy++)
            {
                for (int xx = 0; xx < grid.GetLength(1); xx++)
                {
                    if(grid[yy,xx] && HasOnly4OrLessNeighbors(yy,xx, grid))
                    {
                        sumOfRolls++;
                    }
                }
            }

            Console.WriteLine($"First Solution: {sumOfRolls}");
        }


        private static bool HasOnly4OrLessNeighbors(int y, int x, bool[,] grid)
        {
            List<(int, int)> neighbors = new List<(int, int)>();
            neighbors.Add((y - 1, x-1));
            neighbors.Add((y - 1, x));
            neighbors.Add((y - 1, x+1));
            neighbors.Add((y, x-1));
            neighbors.Add((y, x+1));
            neighbors.Add((y + 1, x - 1));
            neighbors.Add((y + 1, x));
            neighbors.Add((y + 1, x + 1));

            int i = 0;
            foreach (var neighbor in neighbors)
            {
                if (IsValidIndex(neighbor.Item1, neighbor.Item2, grid) && grid[neighbor.Item1, neighbor.Item2])
                {
                    i++;
                }
            }
            return (i < 4);
        }

        private static bool IsValidIndex(int y, int x, bool[,] grid)
        {
            return (y >= 0 && x >= 0 && y < grid.GetLength(0) && x < grid.GetLength(1));
        }

        public static void SecondSolution()
        {
            long sumOfRolls = 0;
            (bool,bool)[,] grid;

            int y = 0;
            var lines = File.ReadAllLines("day4.txt");
            grid = new (bool,bool)[lines.Length, lines[0].Length];

            foreach (var line in lines)
            {
                int x = 0;
                foreach (var character in line)
                {
                    if (character == '@')
                    {
                        grid[y, x] = (true,false);
                    }
                    x++;
                }
                y++;
            }
            bool runAgain = true;
            while (runAgain) {
                runAgain = false;
                for (int yy = 0; yy < grid.GetLength(0); yy++)
                {
                    for (int xx = 0; xx < grid.GetLength(1); xx++)
                    {
                        if (grid[yy, xx].Item1 && HasOnly4OrLessNeighbors2(yy, xx, grid))
                        {
                            sumOfRolls++;
                            grid[yy, xx].Item2 = true;
                        }
                    }
                }

                for (int yy = 0; yy < grid.GetLength(0); yy++)
                {
                    for (int xx = 0; xx < grid.GetLength(1); xx++)
                    {
                        if (grid[yy, xx].Item2)
                        {
                            runAgain = true;
                            grid[yy, xx].Item1 = false;
                            grid[yy, xx].Item2 = false;
                        }
                    }
                }
            }


            Console.WriteLine($"Second Solution: {sumOfRolls}");
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
