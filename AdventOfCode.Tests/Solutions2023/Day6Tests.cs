using AdventOfCode.Solutions2023;
using FluentAssertions;

namespace AdventOfCode.Tests.Solutions2023;

public class Day6Tests
{
    [Fact]
    public void GetFirstPart_Returns_CorrectAnswer()
    {
        var input = Common.ReadInputLines("6");
        var firstPart = Day6.GetFirstPart(input);

        firstPart.Should().Be(288);
    }

    [Fact]
    public void GetSecondPart_Returns_CorrectAnswer()
    {
        var input = Common.ReadInputLines("6");
        var secondPart = Day6.GetSecondPart(input);

        secondPart.Should().Be(71503);
    }
}
