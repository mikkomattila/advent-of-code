namespace AdventOfCode.CLI.Helpers;

public class Maths
{
    public static long GetGreatestCommonDivisor(long a, long b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    public static long GetLeastCommonMultiple(long a, long b) => (a * b) / GetGreatestCommonDivisor(a, b);

    public static long FindLeastCommonMultiple(long[] numbers)
    {
        var lcm = 1L;

        foreach (var number in numbers)
            lcm = GetLeastCommonMultiple(lcm, number);

        return lcm;
    }
}
