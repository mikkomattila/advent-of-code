using AdventOfCode.CLI.Helpers;
using FluentAssertions;

namespace AdventOfCode.Tests.Helpers;
public class MathsTests
{

    [Theory]
    [InlineData(4, 6, 2)]
    [InlineData(8, 12, 4)]
    [InlineData(5, 7, 1)]
    public void GetGreatestCommonDivisor_Returns_CorrectResult(long a, long b, long expected)
    {
        var result = Maths.GetGreatestCommonDivisor(a, b);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(4, 6, 12)]
    [InlineData(5, 7, 35)]
    [InlineData(10, 15, 30)]
    public void GetLeastCommonMultiple_Returns_CorrectResult(long a, long b, long expected)
    {
        var result = Maths.GetLeastCommonMultiple(a, b);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(new long[] { 4, 6, 8, 10 }, 120)]
    [InlineData(new long[] { 3, 5, 7 }, 105)]
    [InlineData(new long[] { 2, 3, 4, 5, 6 }, 60)]
    public void FindLeastCommonMultiple_Returns_CorrectResult(long[] numbers, long expected)
    {
        var result = Maths.FindLeastCommonMultiple(numbers);

        result.Should().Be(expected);
    }
}
