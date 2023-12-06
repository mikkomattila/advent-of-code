using AdventOfCode.Solutions2023;
using FluentAssertions;

namespace AdventOfCode.Tests.Solutions2023;

public class Day4Tests
{
    [Fact]
    public void GetFirstPart_Returns_CorrectAnswer()
    {
        var input = GetInput();
        var firstPart = Day4.GetFirstPart(input);

        firstPart.Should().Be(13.0);
    }

    [Fact]
    public void GetSecondPart_Returns_CorrectAnswer()
    {
        var input = GetInput();
        var secondPart = Day4.GetSecondPart(input);

        secondPart.Should().Be(30.0);
    }

    protected static string[] GetInput() 
        => Helper.ReadInputLines("4");
}
