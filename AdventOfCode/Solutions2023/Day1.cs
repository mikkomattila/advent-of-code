using AdventOfCode.Interfaces;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions2023;

/// <summary>
/// 2023-1
/// https://adventofcode.com/2023/day/1
/// </summary>
public class Day1 : IDay
{
    private static readonly string _inputFolder = "Solutions2023";
    private static readonly string _inputFileName = "Day1Input.txt";

    private static readonly Dictionary<string, string> _numericMapping = new() {
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

    public void Run()
    {
        var input = Helper.ReadInputLines(_inputFolder, _inputFileName);
        var firstAnswer = ParseCombinedDigits(input).Sum();
        var secondAnswer = ParseCombinedDigits(input, true).Sum();

        Console.WriteLine(
            $"2023-01 answer 1: {firstAnswer}\n" +
            $"2023-01 answer 2: {secondAnswer}"
        );
    }
    
    public static string AggregateNumbers(string input, bool includeWords)
    {
        var pattern = includeWords 
            ? @"(?i)(one|two|three|four|five|six|seven|eight|nine|\d{1})" 
            : @"(\d{1})";
        
        var matches = Regex.Matches(input, pattern);

        var aggregate = matches
            .Aggregate(string.Empty, (output, next) => output + _numericMapping[next.Groups[1].Value]);

        return aggregate;
    }

    public static List<int> ParseCombinedDigits(string[] input, bool includeWords = false)
        => input.Select(x =>
            {
                var numbersAggregate = AggregateNumbers(x, includeWords);
                var firstDigit = numbersAggregate.Substring(0, 1);
                var secondDigit = numbersAggregate.Substring(numbersAggregate.Length - 1, 1);
                return CombineNumbers(firstDigit, secondDigit);
            }
        ).ToList() 
        ?? new List<int>();

    private static int CombineNumbers(string firstDigit, string secondDigit)
        => int.Parse(firstDigit) * 10 + int.Parse(secondDigit);
}
