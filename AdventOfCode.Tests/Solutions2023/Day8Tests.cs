using AdventOfCode.Solutions2023;
using FluentAssertions;

namespace AdventOfCode.Tests.Solutions2023;

public class Day8Tests
{
    [Fact]
    public void GetFirstPart_Returns_CorrectAnswer()
    {
        var input = Common.ReadInputLines("Day8Input1.txt", overrideFolderNameByDay: true);
        var firstPart = Day8.GetFirstPart(input);

        firstPart.Should().Be(6);
    }

    [Fact]
    public void GetSecondPart_Returns_CorrectAnswer()
    {
        var input = Common.ReadInputLines("Day8Input2.txt", overrideFolderNameByDay: true);
        var secondPart = Day8.GetSecondPart(input);

        secondPart.Should().Be(6);
    }
}
