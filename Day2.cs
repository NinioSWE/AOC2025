using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AOC1
{
    public class Day2
    {
        public static void FirstSolution()
        {
            long numberOfInvalidIDs = 0;
            foreach (var line in File.ReadAllLines("day2.txt"))
            {
                string[] ids = line.Split(",");
                foreach (var id in ids)
                {
                    var productIds = id.Split("-");

                    long startIndex = long.Parse(productIds[0]);
                    long endIndex = long.Parse(productIds[1]);

                    for (long i = startIndex; i <= endIndex; i++)
                    {
                        if (!ValidateNumber(i))
                        {
                            numberOfInvalidIDs+= i;
                        }
                    }

                }

            }
            Console.WriteLine($"First Solution: {numberOfInvalidIDs}");
        }

        private static bool ValidateNumber(long number)
        {
            string numberAsString = number.ToString();
            if (numberAsString.Length % 2 == 0)
            {
                string first = numberAsString.Substring(0, numberAsString.Length / 2);
                string second = numberAsString.Substring(numberAsString.Length / 2);
                if (first == second)
                {
                    return false;
                }
            }
            return true;
        }

        public static void SecondSolution()
        {
            long numberOfInvalidIDs = 0;
            foreach (var line in File.ReadAllLines("day2.txt"))
            {
                string[] ids = line.Split(",");
                foreach (var id in ids)
                {
                    var productIds = id.Split("-");

                    long startIndex = long.Parse(productIds[0]);
                    long endIndex = long.Parse(productIds[1]);

                    for (long i = startIndex; i <= endIndex; i++)
                    {
                        if (!ValidateNumber2(i))
                        {
                            numberOfInvalidIDs += i;
                        }
                    }

                }

            }

            Console.WriteLine($"Second Solution: {numberOfInvalidIDs}");
        }

        private static bool ValidateNumber2(long number)
        {
            string numberAsString = number.ToString();
            for (int i = 1; i <= numberAsString.Length; i++)
            {
                if (numberAsString.Length % i == 0)
                {
                    bool isRepeated = true;
                    string temp = numberAsString.Substring(0, i);
                    for (int y = i; y < numberAsString.Length; y+= i)
                    {
                        if (temp != numberAsString.Substring(y, i))
                        {
                            isRepeated = false;
                            break;
                        }
                        temp = numberAsString.Substring(y, i);
                    }
                    if (isRepeated && i < numberAsString.Length)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
