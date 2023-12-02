using AdventOfCode.Interfaces;

namespace AdventOfCode.Solutions2023.Day2;

// 2023-2 https://adventofcode.com/2023/day/2
public class Day2 : IDay
{
    private readonly string _inputFileName = "Day2Input.txt";

    private const int _red = 12;
    private const int _green = 13;
    private const int _blue = 14;

    record Game(int Id, IReadOnlyList<Colors> Colors);
    record Colors(int Red, int Green, int Blue);

    public void Run()
    {
        var input = Helpers.ReadInputLines(_inputFileName);
        var games = input.Select(x =>
        {
            var gameAndColors = x.Split(":");
            return new Game(
               Id: int.Parse(gameAndColors[0].Split(" ")[1]),
               Colors: gameAndColors[1].Split(";").Select(c =>
               {
                   var colors = c.Split(",")
                        .Select(s =>
                        {
                            var colorCount = s.Split(" ");
                            return (Color: colorCount[2], Count: int.Parse(colorCount[1]));
                        }
                   ).ToList();

                   return new Colors(
                       Red: colors.FirstOrDefault(r => r.Color == "red").Count,
                       Green: colors.FirstOrDefault(r => r.Color == "green").Count,
                       Blue: colors.FirstOrDefault(r => r.Color == "blue").Count
                   );
               }).ToList()
            );
        });

        var answer1 = games
            .Where(g => g.Colors.All(c => c is { Red: <= _red, Green: <= _green, Blue: <= _blue }))
            .Sum(r => r.Id);

        var answer2 = games
            .Select(x => 
                    new Colors(
                        Red: x.Colors.MaxBy(c => c.Red)?.Red ?? 0,
                        Green: x.Colors.MaxBy(c => c.Green)?.Green ?? 0,
                        Blue: x.Colors.MaxBy(c => c.Blue)?.Blue ?? 0
                    )
            )
            .Select(result =>
            {
                var power = result.Red * result.Green * result.Blue;
                return power;
            }
        ).Sum();

        Console.WriteLine($"DAY2 answer 1: {answer1}\n" +
            $"DAY2 answer 2: {answer2}");
    }
}

