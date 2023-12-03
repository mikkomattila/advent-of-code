using AdventOfCode.Solutions2023;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Solutions2023;

public class Day3Tests
{
    private static readonly string _fileName = "Day3TestInput.txt";

    [Fact]
    public void FirstAnswer()
    {
        var input = Helper.ReadInputLines(_fileName);
        var result = Day3.ParseNumericValues(input).Sum();

        result.Should().Be(4361);
    }
}
