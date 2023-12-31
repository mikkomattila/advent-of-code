﻿using AdventOfCode.CLI.Classes;
using AdventOfCode.CLI.Helpers;
using AdventOfCode.CLI.Interfaces;
using System.Text.RegularExpressions;

namespace AdventOfCode.CLI.Solutions2023;

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
        var input = Common.ReadInputLines("1");
        var firstPart = GetFirstPart(input);
        var secondPart = GetSecondPart(input);

        return new DayResult(firstPart, secondPart);
    }

    public static int GetFirstPart(string[] input)
        => ParseCombinedDigits(input).Sum();

    public static int GetSecondPart(string[] input)
        => ParseCombinedDigits(input, true).Sum();

    private static IReadOnlyList<int> ParseCombinedDigits(string[] input, bool includeSpelledNumbers = false)
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
