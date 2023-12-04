using AdventOfCode.Solutions2023;
using FluentAssertions;

namespace AdventOfCode.Tests.Solutions2023;

public class Day4Tests
{
    [Fact]
    public void GetFirstAnswer_Returns_CorrectAnswer()
    {
        var input = GetInput();
        var firstAnswer = Day4.GetFirstAnswer(input);

        firstAnswer.Should().Be(13.0);
    }

    [Fact]
    public void GetSecondAnswer_Returns_CorrectAnswer()
    {
        var input = GetInput();
        var firstAnswer = Day4.GetSecondAnswer(input);

        firstAnswer.Should().Be(30.0);
    }

    protected static string[] GetInput() 
        => Helper.ReadInputLines("4");
}
