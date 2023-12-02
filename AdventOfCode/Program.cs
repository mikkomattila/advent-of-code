using AdventOfCode.Interfaces;
using AdventOfCode.Solutions2023;

Console.WriteLine("Advent of Code\n");

IDay day;

// TODO: Provide day as an argument
day = new Day1();
var result = day.GetResultForDay();

Console.WriteLine(
    $"Answer 1: {result.FirstAnswer}\n" +
    $"Answer 2: {result.SecondAnswer}"
);

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();
