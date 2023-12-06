using FluentAssertions;

namespace AdventOfCode.Tests.Helpers;

public class HelperTests
{
    [InlineData(2, 2023, "8", "2286")]
    [InlineData(4, 2023, "13", "30")]
    [Theory]
    public void GetResultForDay_Returns_CorrectAnswer(int day, int year, string firstPart, string secondPart)
    {
        var result = Helper.GetResultForDay(day, year);

        result.FirstPart.Should().NotBeEmpty();
        result.SecondPart.Should().NotBeEmpty();

        result.FirstPart.Should().BeEquivalentTo(firstPart);
        result.SecondPart.Should().BeEquivalentTo(secondPart);
    }

    [Fact]
    public void ReadInputLines_Returns_CorrectAmountOfRows()
    {
        var input1 = Helper.ReadInputLines("Day1Input2.txt", overrideFolderNameByDay: true);
        var input2 = Helper.ReadInputLines("2");

        input1.Length.Should().Be(7);
        input2.Length.Should().Be(5);
    }
}
