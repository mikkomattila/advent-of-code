using FluentAssertions;

namespace AdventOfCode.Tests.Helpers;

public class HelperTests
{
    [InlineData(2, 2023, "8", "2286")]
    [InlineData(4, 2023, "13", "30")]
    [Theory]
    public void GetResultForDay_Returns_CorrectResult(int day, int year, string firstPart, string secondPart)
    {
        var result = Helper.GetResultForDay(day, year);

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
        var result = Helper.ReadInputLines(fileName, overrideFolderNameByDay: overrideFolder);

        result.Length.Should().Be(expected);
    }

    [Theory]
    [InlineData(4, 6, 2)]
    [InlineData(8, 12, 4)]
    [InlineData(5, 7, 1)]
    public void GetGreatestCommonDivisor_Returns_CorrectResult(long a, long b, long expected)
    {
        var result = Helper.GetGreatestCommonDivisor(a, b);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(4, 6, 12)]
    [InlineData(5, 7, 35)]
    [InlineData(10, 15, 30)]
    public void GetLeastCommonMultiple_Returns_CorrectResult(long a, long b, long expected)
    {
        var result = Helper.GetLeastCommonMultiple(a, b);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(new long[] { 4, 6, 8, 10 }, 120)]
    [InlineData(new long[] { 3, 5, 7 }, 105)]
    [InlineData(new long[] { 2, 3, 4, 5, 6 }, 60)]
    public void FindLeastCommonMultiple_Returns_CorrectResult(long[] numbers, long expected)
    {
        var result = Helper.FindLeastCommonMultiple(numbers);

        result.Should().Be(expected);
    }
}
