using AdventOfCode.Solutions2023;
using FluentAssertions;

namespace AdventOfCode.Tests.Solutions2023;

public class Day2Tests
{
    private static readonly string _fileName = "Day2TestInput.txt";
    private static readonly int _firstAnswer = 8;
    private static readonly int _secondAnswer = 2286;

    [Fact]
    public static void ParseGamesFromStringInput_Returns_CorrectAnswer()
    {
        var input = Helper.ReadInputLines(_fileName);
        var games = Day2.ParseGamesFromStringInput(input);

        games.Should().NotBeEmpty();
        games.Should().HaveCount(5);
        games[0].Colors[0].Red.Should().Be(4);
        games[2].Id.Should().Be(3);
        games[2].Colors[0].Green.Should().Be(8);
        games[4].Colors[1].Green.Should().Be(2);
    }

    [Fact]
    public static void GetFirstAnswer_Returns_CorrectAnswer()
    {
        var games = ParseGames();
        var result = Day2.GetFirstAnswer(games);

        result.Should().Be(_firstAnswer);
    }

    [Fact]
    public static void GetSecondAnswer_Returns_CorrectAnswer()
    {
        var games = ParseGames();
        var result = Day2.GetSecondAnswer(games);

        result.Should().Be(_secondAnswer);
    }

    protected static IReadOnlyList<Day2.Game> ParseGames()
    {
        var input = Helper.ReadInputLines(_fileName);
        return Day2.ParseGamesFromStringInput(input);
    }
}
