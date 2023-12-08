using AdventOfCode.Solutions2023;
using FluentAssertions;

namespace AdventOfCode.Tests.Solutions2023;

public class Day8Tests
{
    [Fact]
    public void GetFirstPart_Returns_CorrectAnswer()
    {
        var input = Helper.ReadInputLines("8");
        var firstPart = Day8.GetFirstPart(input, "AAA", "ZZZ");

        firstPart.Should().Be(6);
    }

    //[Fact]
    //public void GetSecondPart_Returns_CorrectAnswer()
    //{
    //    var input = Helper.ReadInputLines("8");
    //    var secondPart = Day6.GetSecondPart(input);

    //    secondPart.Should().Be();
    //}
}
