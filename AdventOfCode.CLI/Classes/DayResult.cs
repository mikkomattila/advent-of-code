namespace AdventOfCode.CLI.Classes;

public record DayResult
{
    public DayResult(object firstPart, object secondPart)
    {
        FirstPart = firstPart?.ToString() ?? "No answer yet.";
        SecondPart = secondPart?.ToString() ?? "No answer yet.";
    }

    public string FirstPart { get; }

    public string SecondPart { get; }
}
