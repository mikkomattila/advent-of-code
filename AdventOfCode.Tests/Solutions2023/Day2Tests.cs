using AdventOfCode.CLI.Helpers;
using AdventOfCode.CLI.Solutions2023;
using FluentAssertions;

namespace AdventOfCode.Tests.Solutions2023;

public class Day2Tests
{
    [Fact]
    public static void GetFirstPart_Returns_CorrectAnswer()
    {
        var games = ParseGames();
        var result = Day2.GetFirstPart(games);

        result.Should().Be(8);
    }

    [Fact]
    public static void GetSecondPart_Returns_CorrectAnswer()
    {
        var games = ParseGames();
        var result = Day2.GetSecondPart(games);

        result.Should().Be(2286);
    }

    [Fact]
    public static void ParseGamesFromInput_Returns_CorrectAnswer()
    {
        var input = Common.ReadInputLines("2");
        var games = Day2.ParseGamesFromInput(input);

        games.Should().NotBeEmpty();
        games.Should().HaveCount(5);
        games[0].Colors[0].Red.Should().Be(4);
        games[2].Id.Should().Be(3);
        games[2].Colors[0].Green.Should().Be(8);
        games[4].Colors[1].Green.Should().Be(2);
    }

    protected static IReadOnlyList<Day2.Game> ParseGames()
    {
        var input = Common.ReadInputLines("2");
        return Day2.ParseGamesFromInput(input);
    }
}
