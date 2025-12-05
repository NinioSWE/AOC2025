using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC1
{
    public class Day1
    {
        public static void FirstSolution()
        {
            int dial = 50;
            int numberOfTimesAtZero = 0;

            foreach (var line in File.ReadAllLines("day1.txt"))
            {
                string type = line.Substring(0, 1);
                int numberOfTurns = int.Parse(line.Substring(1));

                if (type == "L")
                {
                    numberOfTurns *= -1;
                }

                dial = (dial + numberOfTurns) % 100;

                if (dial < 0)
                {
                    dial += 100;
                }
                if (dial == 0)
                {
                    numberOfTimesAtZero++;
                }
            }
            Console.WriteLine($"First Solution: {numberOfTimesAtZero}");
        }
        public static void SecondSolution()
        {
            int dial = 50;
            int numberOfTimesAtZero = 0;

            foreach (var line in File.ReadAllLines("day1.txt"))
            {
                string type = line.Substring(0, 1);
                int numberOfTurns = int.Parse(line.Substring(1));

                int dialBefore = dial;

                if (type == "L")
                {
                    numberOfTurns *= -1;
                }

                while (numberOfTurns > 100)
                {
                    numberOfTurns -= 100;
                    numberOfTimesAtZero++;
                }

                while (numberOfTurns < -100)
                {
                    numberOfTurns += 100;
                    numberOfTimesAtZero++;
                }

                dial = (dial + numberOfTurns) % 100;

                if (dial < 0)
                {
                    dial += 100;
                }

                if (dial == 0)
                {
                    numberOfTimesAtZero++;
                }
                else if (dialBefore < dial && type == "L" && dialBefore != 0)
                {
                    numberOfTimesAtZero++;
                }
                else if (dial < dialBefore && type == "R" && dialBefore != 0)
                {
                    numberOfTimesAtZero++;
                }


            }

            Console.WriteLine($"Second Solution: {numberOfTimesAtZero}");
        }
    }
}
