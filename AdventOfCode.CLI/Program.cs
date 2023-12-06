using AdventOfCode;

Console.WriteLine("Advent of Code\n");
Console.WriteLine("Get solution for day:");

if (int.TryParse(Console.ReadLine(), out int day))
{
    try
    {
        var result = Helper.GetResultForDay(day);
        Console.WriteLine(
            $"\n2023-{day} Answer 1: {result.FirstPart}\n" +
            $"2023-{day} Answer 2: {result.SecondPart}\n"
        );
    }
    catch
    {
        Console.WriteLine($"Error getting the answer for day: {day}");
    }
}
else
{
    Console.WriteLine("Invalid input. Please enter a valid integer for the day.");
}
