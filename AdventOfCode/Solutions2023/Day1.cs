using AdventOfCode.Classes;
using AdventOfCode.Interfaces;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions2023;

/// <summary>
/// Solution for day 1 of 2023.
/// Instructions: https://adventofcode.com/2023/day/1.
/// </summary>
public class Day1 : IDay
{
    private static readonly Dictionary<string, string> _numericMapping = new() 
    {
        { "one", "1" },
        { "two", "2" },
        { "three", "3" },
        { "four", "4" },
        { "five", "5" },
        { "six", "6" },
        { "seven", "7" },
        { "eight", "8" },
        { "nine", "9" },
        { "1", "1" },
        { "2", "2" },
        { "3", "3" },
        { "4", "4" },
        { "5", "5" },
        { "6", "6" },
        { "7", "7" },
        { "8", "8" },
        { "9", "9" },
    };

    public DayResult GetResultForDay()
    {
        var input = Helper.ReadInputLines("Day1Input.txt");
        var combinedDigits = ParseCombinedDigits(input);
        var combinedDigitsIncludeWords = ParseCombinedDigits(input, true);

        return new DayResult(combinedDigits.Sum(), combinedDigitsIncludeWords.Sum());
    }
    
    public static IReadOnlyList<int> ParseCombinedDigits(string[] input, bool includeSpelledNumbers = false)
        => input.Select(i =>
            {
                var numbersAggregate = AggregateNumbers(i, includeSpelledNumbers);
                var firstDigit = numbersAggregate.Substring(0, 1);
                var secondDigit = numbersAggregate.Substring(numbersAggregate.Length - 1, 1);

                return int.Parse(firstDigit) * 10 + int.Parse(secondDigit); ;
            }
        ).ToList() 
        ?? new List<int>();

    private static string AggregateNumbers(string input, bool includeSpelledNumbers)
    {
        var pattern = includeSpelledNumbers
            ? @"(?=(one|two|three|four|five|six|seven|eight|nine|\d{1}))"
            : @"(\d{1})";

        return Regex.Matches(input, pattern)
            .Aggregate(
                string.Empty,
                (output, next) => output + _numericMapping[next.Groups[1].Value]
            );
    }
}
