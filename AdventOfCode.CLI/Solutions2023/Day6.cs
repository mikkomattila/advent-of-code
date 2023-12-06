using AdventOfCode.Classes;
using AdventOfCode.Interfaces;

namespace AdventOfCode.Solutions2023;

/// <summary>
/// Solution for day 6 of 2023.
/// Instructions: https://adventofcode.com/2023/day/6.
/// </summary>
public class Day6 : IDay
{
    public record Race(int Time, int Distance);

    public DayResult GetResultForDay()
    {
        var input = Helper.ReadInputLines("6");
        var races = ParseRaceInput(input);

        var firstAnswer = GetFirstAnswer(races);
        //var secondAnswer = GetSecondAnswer(races);

        return new DayResult($"{firstAnswer}", $"0");
    }

    public static int GetFirstAnswer(List<Race> races)
    {
        List<int> numberOfWays = new();
        foreach(var race in races)
        {
            var count = 0;
            for (int buttonHoldTime = 0; buttonHoldTime <= race.Time; buttonHoldTime++) 
            {
                var raceTimeLeft = race.Time - buttonHoldTime;
                var distance = buttonHoldTime * raceTimeLeft;
                if (distance > race.Distance) count++;
            }
            numberOfWays.Add(count);
        }
        var result = numberOfWays
            .Aggregate((acc, x) => acc * x);

        return result;
    }

    public static List<Race> ParseRaceInput(string[] input)
    {
        var timeInput = input[0]
            .Split(":")[1]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var distanceInput = input[1]
            .Split(":")[1]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        List<Race> races = new();

        foreach (var (timeStr, i) in timeInput.Select((value, i) => (value, i)))
        {
            races.Add(
                new Race(
                    int.Parse(timeStr),
                    int.Parse(distanceInput[i]))
                );
        }

        return races;
    }
}
