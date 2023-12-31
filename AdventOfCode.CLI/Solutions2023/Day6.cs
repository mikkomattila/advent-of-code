﻿using AdventOfCode.CLI.Classes;
using AdventOfCode.CLI.Helpers;
using AdventOfCode.CLI.Interfaces;

namespace AdventOfCode.CLI.Solutions2023;

public class Day6 : IDay
{
    public record Race(long Time, long Distance);

    public DayResult GetResultForDay()
    {
        var input = Common.ReadInputLines("6");
        var firstPart = GetFirstPart(input);
        var secondPart = GetSecondPart(input);

        return new DayResult(firstPart, secondPart);
    }

    public static long GetFirstPart(string[] input)
    {
        var races = ParseRaceInput(input);
        return GetPossibilities(races);
    }

    public static long GetSecondPart(string[] input)
    {
        var races = ParseRaceInput(input);

        var combinedTime = long.Parse(string.Concat(races.Select(x => x.Time)));
        var combinedDistance = long.Parse(string.Concat(races.Select(x => x.Distance)));
        var combinedRaces = new List<Race> { new Race(combinedTime, combinedDistance) };

        return GetPossibilities(combinedRaces);
    }

    private static long GetPossibilities(IReadOnlyList<Race> races)
    {
        long result = 1;
        foreach (var race in races)
        {
            var count = 0;
            for (int buttonHoldTime = 0; buttonHoldTime <= race.Time; buttonHoldTime++)
            {
                var raceTimeLeft = race.Time - buttonHoldTime;
                var distance = buttonHoldTime * raceTimeLeft;
                if (distance > race.Distance) count++;
            }
            result *= count;
        }
        return result;
    }

    private static List<Race> ParseRaceInput(string[] input)
    {
        List<Race> races = new();

        var timeInput = input[0]
            .Split(":")[1]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var distanceInput = input[1]
            .Split(":")[1]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (var (time, i) in timeInput.Select((value, i) => (value, i)))
            races.Add(new Race(int.Parse(time), int.Parse(distanceInput[i])));

        return races;
    }
}
