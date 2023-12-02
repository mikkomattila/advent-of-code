using AdventOfCode.Interfaces;

namespace AdventOfCode.Solutions2023.Day2;

// 2023-2 https://adventofcode.com/2023/day/2
public class Day2 : IDay
{
    private static readonly string _inputFolder = "Solutions2023";
    private static readonly string _inputFileName = "Day2Input.txt";

    private const int _redMax = 12;
    private const int _greenMax = 13;
    private const int _blueMax = 14;

    public record Game(int Id, IReadOnlyList<Colors> Colors);
    public record Colors(int Red, int Green, int Blue);

    public void Run()
    {
        try
        {
            var input = Helper.ReadInputLines(_inputFolder, _inputFileName);
            var games = ParseGamesFromStringInput(input) 
                ?? throw new Exception("Error parsing games during 2023-02.");

            Console.WriteLine(
                $"2023-02 answer 1: {GetFirstAnswer(games)}\n" +
                $"2023-02 answer 2: {GetSecondAnswer(games)}"
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during 2023-02. Ex: {ex}");
        }
    }

    public static List<Game> ParseGamesFromStringInput(string[] input)
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
                       Red: colors.FirstOrDefault(r => r.Color == "red").Count,
                       Green: colors.FirstOrDefault(r => r.Color == "green").Count,
                       Blue: colors.FirstOrDefault(r => r.Color == "blue").Count
                   );
               }).ToList()
            );
        }
    ).ToList();

    public static int GetFirstAnswer(IEnumerable<Game> games)
        => games
            .Where(g => g.Colors.All(c => c is { Red: <= _redMax, Green: <= _greenMax, Blue: <= _blueMax }))
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
                var power = result.Red * result.Green * result.Blue;
                return power;
            }
        ).Sum();
}

