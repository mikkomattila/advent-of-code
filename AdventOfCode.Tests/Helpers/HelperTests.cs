using FluentAssertions;

namespace AdventOfCode.Tests.Helpers;

public class HelperTests
{
    private readonly string _inputFolder = "Solutions2023";
    private static readonly string _fileName = "Day2TestInput.txt";

    [Fact]
    public void ReadInputLines_Returns_CorrectAmountOfRows()
    {
        var input1 = Helper.ReadInputLines(_inputFolder, "Day1TestInput2.txt");
        var input2 = Helper.ReadInputLines(_inputFolder, "Day2TestInput.txt");

        input1.Length.Should().Be(7);
        input2.Length.Should().Be(5);
    }
}
