using FluentAssertions;

namespace AdventOfCode.Tests;

public class HelperTests
{
    private readonly string _inputFolder = "Solutions2023";
    private static readonly string _fileName = "Day2TestInput.txt";

    [Fact]
    public void ReadInputLines_ReturnsCorrectAmountOfRows()
    {
        var input = Helper.ReadInputLines(_inputFolder, _fileName);
        input.Length.Should().Be(5);
    }
}
