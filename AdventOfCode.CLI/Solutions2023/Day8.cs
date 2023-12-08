using AdventOfCode.Classes;
using AdventOfCode.CLI.Helpers;
using AdventOfCode.Interfaces;

namespace AdventOfCode.Solutions2023;

public class Day8 : IDay
{
    record Network(string Instruction, IReadOnlyList<Node> Nodes);

    record Node(string Key, string Left, string Right);

    public DayResult GetResultForDay()
    {
        var input = Common.ReadInputLines("8");
        var firstPart = GetFirstPart(input);
        var secondPart = GetSecondPart(input);

        return new DayResult(firstPart, secondPart);
    }

    public static int GetFirstPart(string[] input, string currentKey = "AAA", string targetKey = "ZZZ")
    {
        var (instruction, nodes) = ParseNetwork(input);
        var nodeLookup = nodes.ToDictionary(n => n.Key);

        int steps = 0, i = 0;
        while (currentKey != targetKey)
        {
            if (i >= instruction.Length) i = 0;

            currentKey = instruction[i] == 'L'
                ? nodeLookup[currentKey].Left
                : nodeLookup[currentKey].Right;

            steps++;
            i++;
        }

        return steps;
    }

    public static long GetSecondPart(string[] input)
    {
        var (instruction, nodes) = ParseNetwork(input);
        var nodeLookup = nodes.ToDictionary(n => n.Key);
        var currentNodes = nodes.Where(x => x.Key.EndsWith('A'));

        int i = 0;
        List<long> stepList = new();

        foreach (var currentNode in currentNodes)
        {
            var steps = 0L;
            var node = currentNode;
            while (!node.Key.EndsWith('Z'))
            {
                if (i >= instruction.Length)
                    i = 0;

                node = nodeLookup[instruction[i] == 'L'
                    ? node.Left
                    : node.Right];

                steps++;
                i++;
            }
            stepList.Add(steps);
        }

        var result = Maths.FindLeastCommonMultiple(stepList.ToArray());
        return result;
    }

    private static Network ParseNetwork(string[] input)
        => new(
            input[0],
            input[2..]
                .Select(x =>
                    new Node(
                        x.Split("=")[0].Trim(),
                        x.Substring(x.IndexOf("(") + 1, x.IndexOf(",") - x.IndexOf("(") - 1).Trim(),
                        x.Substring(x.IndexOf(",") + 1, x.IndexOf(")") - x.IndexOf(",") - 1).Trim()
                    )
            ).ToList()
        );
}
