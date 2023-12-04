using AdventOfCode.Classes;
using AdventOfCode.Interfaces;

namespace AdventOfCode.CLI.Solutions2023;

/// <summary>
/// Solution for day 5 of 2023.
/// Instructions: https://adventofcode.com/2023/day/5.
/// </summary>
public class Day5 : IDay
{ 
    public DayResult GetResultForDay()
    {
        var input = Helper.ReadInputLines("5");
        var firstAnswer = GetFirstAnswer(input);
        var secondAnswer = GetSecondAnswer(input);

        return new DayResult($"{firstAnswer}", $"{secondAnswer}");
    }

    public static int GetFirstAnswer(string[] input)
    {


        return 0;
    }

    public static int GetSecondAnswer(string[] input)
    {


        return 0;
    }
}
