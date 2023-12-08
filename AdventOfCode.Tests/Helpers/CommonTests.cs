using FluentAssertions;

namespace AdventOfCode.Tests.Helpers;

public class CommonTests
{
    [InlineData(2, 2023, "8", "2286")]
    [InlineData(4, 2023, "13", "30")]
    [Theory]
    public void GetResultForDay_Returns_CorrectResult(int day, int year, string firstPart, string secondPart)
    {
        var result = Common.GetResultForDay(day, year);

        result.FirstPart.Should().NotBeEmpty();
        result.SecondPart.Should().NotBeEmpty();

        result.FirstPart.Should().BeEquivalentTo(firstPart);
        result.SecondPart.Should().BeEquivalentTo(secondPart);
    }

    [Theory]
    [InlineData("Day1Input2.txt", true, 7)]
    [InlineData("2", false, 5)]
    public void ReadInputLines_Returns_CorrectAmountOfRows(string fileName, bool overrideFolder, int expected)
    {
        var result = Common.ReadInputLines(fileName, overrideFolderNameByDay: overrideFolder);

        result.Length.Should().Be(expected);
    }
}
