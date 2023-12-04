using AdventOfCode.Classes;
using AdventOfCode.Interfaces;

namespace AdventOfCode.Solutions2023;

/// <summary>
/// Solution for day 4 of 2023.
/// Instructions: https://adventofcode.com/2023/day/4.
/// </summary>
public class Day4 : IDay
{
    public DayResult GetResultForDay()
    {
        var input = Helper.ReadInputLines("Day4Input.txt");
        var firstAnswer = GetFirstAnswer(input);

        return new DayResult(firstAnswer.ToString(), string.Empty);
    }

    public static double GetFirstAnswer(string[] cards)
    {
        double totalPoints = 0.0;

        foreach (var card in cards)
        {
            var matchingNumbers = GetMatchingNumbersForCard(card);

            totalPoints += matchingNumbers.Any()
                ? Math.Pow(2, matchingNumbers.Count - 1)
                : 0;
        }

        return totalPoints;
    }

    private static List<int> GetMatchingNumbersForCard(string card)
    {
        var cardParts = card.Split('|');
        var winningNumbers = ParseNumbers(cardParts[0].Split(':')[1]);
        var resultNumbers = ParseNumbers(cardParts[1]);

        return winningNumbers.Intersect(resultNumbers).ToList();
    }

    private static List<int> ParseNumbers(string input)
        => input.Split(' ')
            .Where(x => !string.IsNullOrEmpty(x))
            .Select(int.Parse)
            .ToList();
}
