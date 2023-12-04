using AdventOfCode.Classes;
using AdventOfCode.Interfaces;

namespace AdventOfCode.Solutions2023;

public  class Day4 : IDay
{
    public DayResult GetResultForDay()
    {
        var input = Helper.ReadInputLines("Day4Input.txt");
        var firstAnswer = GetFirstAnswer(input);

        return new DayResult(firstAnswer.ToString(), "");
    }

    public static double GetFirstAnswer(string[] input)
    {
        var totalPoints = 0.0;

        foreach (var line in input)
        {
            var parts = line.Split('|');
            var winningNumbers = ParseNumbersPart(parts[0].Split(':')[1]);
            var resultNumbers = ParseNumbersPart(parts[1]);

            var matchingNumbers = winningNumbers.Intersect(resultNumbers).ToList();

            var matchingNumbersWithIndex = matchingNumbers
                .Select((value, i) => (value, i));

            var points = matchingNumbers.Count == 0 
                ? 0 
                : Math.Pow(2, matchingNumbers.Count - 1);

            totalPoints += points;
        }

        return totalPoints;

        static List<int> ParseNumbersPart(string part)
        {
            var split = part.Split(' ').Where(x => !string.IsNullOrEmpty(x));
            return split.Select(int.Parse).ToList();
        }
    }
}
