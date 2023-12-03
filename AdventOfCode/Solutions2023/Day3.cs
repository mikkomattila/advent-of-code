
using AdventOfCode.Classes;
using AdventOfCode.Interfaces;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions2023;

/// <summary>
/// Solution for day 3 of 2023.
/// Instructions: https://adventofcode.com/2023/day/3.
/// </summary>
public class Day3 : IDay
{
    public DayResult GetResultForDay()
    {
        var input = Helper.ReadInputLines("Day3Input.txt");
        var numericValues = ParseNumericValues(input);
        var firstAnswer = numericValues.Sum();

        return new DayResult(firstAnswer, 0);
    }

    public static List<int> ParseNumericValues(string[] input)
        => input.Select((x, index) =>
            {
                var previousString = (index > 0)
                    ? input[index - 1]
                    : null;

                var nextString = (index < input.Length - 1)
                    ? input[index + 1]
                    : null;

                var specialCharacters = !string.IsNullOrEmpty(x)
                    ? GetSpecialCharactersString(x)
                    : string.Empty;

                var previousSpecialCharacters = !string.IsNullOrEmpty(previousString)
                    ? GetSpecialCharactersString(previousString)
                    : string.Empty;

                var nextSpecialCharacters = !string.IsNullOrEmpty(nextString)
                    ? GetSpecialCharactersString(nextString)
                    : string.Empty;

                List<int> previousIndices = new();
                List<int> nextIndices = new();

                if (!string.IsNullOrEmpty(previousString) && !string.IsNullOrEmpty(previousSpecialCharacters))
                    previousIndices = GetIndices(previousString, previousSpecialCharacters);

                if (!string.IsNullOrEmpty(nextString) && !string.IsNullOrEmpty(nextSpecialCharacters))
                    nextIndices = GetIndices(nextString, nextSpecialCharacters);

                var numbers = new List<int>();
                var separators = new string[] { ".", "=", "*", "&", "$", "/", "+", "-", "@", "%" };
                var parts = x.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                foreach (var part in parts)
                {
                    var firstIndex = x.IndexOf(part);
                    var lastIndex = firstIndex + part.Length - 1;
                    var shouldAdd = true;

                    foreach (var p in previousIndices)
                        shouldAdd = ShouldAddIfContained(p, firstIndex, lastIndex);

                    if (shouldAdd)
                        foreach (var n in nextIndices)
                            shouldAdd = ShouldAddIfContained(n, firstIndex, lastIndex);

                    if (shouldAdd && int.TryParse(part, out int result))
                        numbers.Add(result);
                }

                return numbers.Sum();

                static bool ShouldAddIfContained(int index, int firstIndex, int lastIndex)
                {
                    if (index < firstIndex && index > lastIndex)
                        return false;

                    return true;
                }

                static List<int> GetIndices(string stringInput, string lookFor)
                {
                    var result = new List<int>();

                    foreach (var c in lookFor) 
                        result.Add(stringInput.IndexOf(c));
                        
                    return result.Distinct().ToList();
                }

                static string GetSpecialCharactersString(string stringInput) => new(
                    stringInput.Where(z =>
                        !char.IsLetterOrDigit(z) && z != '.'
                    ).ToArray()
                );
            }).ToList();
}
