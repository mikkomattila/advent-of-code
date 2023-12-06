using AdventOfCode.Solutions2023;
using FluentAssertions;

namespace AdventOfCode.Tests.Solutions2023;

public class Day1Tests
{
    [Fact]
    public void GetFirstPart_Returns_CorrectAnswer()
    {
        var input = Helper.ReadInputLines("Day1Input1.txt", overrideFolderNameByDay: true);
        var result = Day1.GetFirstPart(input);

        result.Should().Be(142);
    }

    [Fact]
    public void GetSecondPart_Returns_CorrectAnswer()
    {
        var input = Helper.ReadInputLines("Day1Input2.txt", overrideFolderNameByDay: true);
        var result = Day1.GetSecondPart(input);

        result.Should().Be(281);
    }
}

