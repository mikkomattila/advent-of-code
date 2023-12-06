using AdventOfCode.Solutions2023;
using FluentAssertions;

namespace AdventOfCode.Tests.Solutions2023;

public class Day6Tests
{
    [Fact]
    public void GetFirstAnswer_Returns_CorrectAnswer()
    {
        var input = Helper.ReadInputLines("6");
        var race = Day6.ParseRaceInput(input);
        var firstAnswer = Day6.GetFirstAnswer(race);

        firstAnswer.Should().Be(288);
    }
}
