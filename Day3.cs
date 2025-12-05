using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AOC1
{
    public class Day3
    {
        public static void FirstSolution()
        {
            long sumOfJoltage = 0;
            foreach (var line in File.ReadAllLines("day3.txt"))
            {
                char[] batteries = line.ToCharArray();
                var biggestNumber = batteries.SkipLast(1).OrderByDescending(x => x).First();
                var almostBiggestNumber = batteries.Skip(line.IndexOf(biggestNumber)+1).OrderByDescending(x => x).First();
                sumOfJoltage += long.Parse(biggestNumber +""+ almostBiggestNumber);
            }
            Console.WriteLine($"First Solution: {sumOfJoltage}");
        }

        public static void SecondSolution()
        {
            long sumOfJoltage = 0;
            foreach (var line in File.ReadAllLines("day3.txt"))
            {
                string biggestNumber = "";
                int startIndex = 0;
                while (biggestNumber.Length < 12) {
                    int biggest = 0;
                    int biggestIndex = 0;
                    for (int i = startIndex; i < line.Length - (11 - biggestNumber.Length); i++)
                    {
                        int value = int.Parse(""+ line[i]);
                        if (biggest < value)
                        {
                            biggest = value;
                            biggestIndex = i;
                        }
                    }
                    biggestNumber += biggest.ToString();
                    startIndex = biggestIndex+1;
                }
                sumOfJoltage += long.Parse(biggestNumber);
            }


            Console.WriteLine($"Second Solution: {sumOfJoltage}");
        }

    }
}
