using AdventOfCode.Classes;
using AdventOfCode.Interfaces;

namespace AdventOfCode.Solutions2023;

public class Day8 : IDay
{
    record Network(string Instruction, IReadOnlyList<Node> Nodes);

    record Node(string Key, string Left, string Right);

    public DayResult GetResultForDay()
    {
        var input = Helper.ReadInputLines("8");
        var firstPart = GetFirstPart(input);
        var secondPart = GetSecondPart(input);

        return new DayResult(firstPart, secondPart);
    }

    public static int GetFirstPart(string[] input)
    {
        var network = ParseNetwork(input);

        var currentKey = "AAA";
        var count = 0;
        var i = 0;

        while (currentKey != "ZZZ")
        {
            if (i >= network.Instruction.Length) i = 0;
            var instruction = network.Instruction[i];
            var node = network.Nodes.First(n => n.Key == currentKey);

            currentKey = instruction == 'L'
                ? node.Left
                : node.Right;

            count++;
            i++;
        }

        return count;
    }

    public static long GetSecondPart(string[] input)
    {
        var network = ParseNetwork(input);

        return 0;
    }

    private static Network ParseNetwork(string[] input)
        => new(
            input[0],
            input[2..]
                .Select(x =>
                {
                    var key = x.Split("=")[0].Trim();

                    var first = x.IndexOf("(");
                    var comma = x.IndexOf(",");
                    var second = x.IndexOf(")");

                    var left = x.Substring(first + 1, comma - first - 1).Trim();
                    var right = x.Substring(comma + 1, second - comma - 1).Trim();

                    return new Node(key, left, right);
                }
            ).ToList()
        );
}
