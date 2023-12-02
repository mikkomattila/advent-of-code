using FluentAssertions;

namespace AdventOfCode.Tests.Helpers;

public class HelperTests
{
    [Fact]
    public void ReadInputLines_Returns_CorrectAmountOfRows()
    {
        var input1 = Helper.ReadInputLines("Day1TestInput2.txt");
        var input2 = Helper.ReadInputLines("Day2TestInput.txt");

        input1.Length.Should().Be(7);
        input2.Length.Should().Be(5);
    }
}
