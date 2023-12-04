using AdventOfCode.Classes;
using AdventOfCode.Interfaces;

namespace AdventOfCode.Solutions2023;

/// <summary>
/// Solution for day 2 of 2023.
/// Instructions: https://adventofcode.com/2023/day/2.
/// </summary>
public class Day2 : IDay
{
    public record Game(int Id, IReadOnlyList<Colors> Colors);

    public record Colors(int Red, int Green, int Blue);

    public DayResult GetResultForDay()
    {
        var input = Helper.ReadInputLines("2");
        var games = ParseGamesFromStringInput(input);

        var firstAnswer = GetFirstAnswer(games);
        var secondAnswer = GetSecondAnswer(games);

        return new DayResult(firstAnswer, secondAnswer);
    }

    public static IReadOnlyList<Game> ParseGamesFromStringInput(string[] input)
        => input.Select(x =>
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
                       Red: colors.FirstOrDefault(r => r.Color is "red").Count,
                       Green: colors.FirstOrDefault(r => r.Color is "green").Count,
                       Blue: colors.FirstOrDefault(r => r.Color is "blue").Count
                   );
               }).ToList()
            );
        }
    ).ToList();

    public static int GetFirstAnswer(IEnumerable<Game> games)
        => games
            .Where(g => g.Colors.All(c => c is { Red: <= 12, Green: <= 13, Blue: <= 14 }))
            .Sum(r => r.Id);

    public static int GetSecondAnswer(IEnumerable<Game> games)
        => games
            .Select(x =>
                    new Colors(
                        Red: x.Colors.MaxBy(c => c.Red)?.Red ?? 0,
                        Green: x.Colors.MaxBy(c => c.Green)?.Green ?? 0,
                        Blue: x.Colors.MaxBy(c => c.Blue)?.Blue ?? 0
                    )
            )
            .Select(result =>
            {
                return result.Red * result.Green * result.Blue;
            }
        ).Sum();
}

