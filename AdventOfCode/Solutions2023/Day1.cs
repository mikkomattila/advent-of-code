using AdventOfCode.Interfaces;

namespace AdventOfCode.Solutions2023;

/// <summary>
/// 2023-1
/// https://adventofcode.com/2023/day/1
/// </summary>
public class Day1 : IDay
{
    private static readonly string _inputFolder = "Solutions2023";
    private static readonly string _inputFileName = "Day1Input.txt";

    public void Run()
    {
        var input = Helper.ReadInputLines(_inputFolder, _inputFileName);
        var digits = ParseCombinedDigits(input);

        Console.WriteLine(
            $"2023-01 answer 1: {GetFirstAnswer(digits)}"
        );
    }

    public static List<int> ParseCombinedDigits(string[] input)
        => input.Select(x =>
            {
                int firstDigit = 0, secondDigit = 0;

                var numeric = new string(x.Where(char.IsDigit).ToArray());
                if (!string.IsNullOrEmpty(numeric))
                {
                    firstDigit = int.Parse($"{numeric[0]}");

                    var secondIndex = numeric.Length - 1;
                    secondIndex = secondIndex > 0 ? secondIndex : 0;

                    secondDigit = int.Parse($"{numeric[secondIndex]}");
                }
                return firstDigit * 10 + secondDigit;
            }
        ).ToList() 
        ?? new List<int>();

    public static int GetFirstAnswer(List<int> combinedNumber)
        => combinedNumber.Sum();
}
