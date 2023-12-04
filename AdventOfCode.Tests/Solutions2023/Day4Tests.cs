using AdventOfCode.Solutions2023;
using FluentAssertions;

namespace AdventOfCode.Tests.Solutions2023;
public class Day4Tests
{
    private static readonly string _fileName = "Day4TestInput.txt";
    private static readonly double _firstAnswer = 13.0;
    private static readonly double _secondAnswer = 30.0;

    [Fact]
    public void GetFirstAnswer_Returns_CorrectResult()
    {
        var input = Helper.ReadInputLines(_fileName);
        var firstAnswer = Day4.GetFirstAnswer(input);

        firstAnswer.Should().Be(_firstAnswer);
    }
}
