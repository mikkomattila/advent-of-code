using AdventOfCode.Solutions2023;
using FluentAssertions;

namespace AdventOfCode.Tests.Solutions2023;

public class Day6Tests
{
    [Fact]
    public void GetFirstAnswer_Returns_CorrectAnswer()
    {
        var input = Helper.ReadInputLines("6");
        var firstAnswer = Day6.GetFirstAnswer(input);

        firstAnswer.Should().Be(288);
    }

    [Fact]
    public void GetSecondAnswer_Returns_CorrectAnswer()
    {
        var input = Helper.ReadInputLines("6");
        var firstAnswer = Day6.GetSecondAnswer(input);

        firstAnswer.Should().Be(71503);
    }
}
