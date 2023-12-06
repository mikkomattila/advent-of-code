namespace AdventOfCode.Classes;

public record DayResult
{
    public DayResult(string firstPart, string secondPart)
    {
        FirstPart = string.IsNullOrEmpty(firstPart) 
            ? "No answer yet." 
            : firstPart;

        SecondPart = string.IsNullOrEmpty(secondPart) 
            ? "No answer yet." 
            : secondPart;
    }

    public DayResult(int firstPart, int secondPart)
    {
        FirstPart = $"{firstPart}";
        SecondPart = $"{secondPart}";
    }

    public string FirstPart { get; set; } = null!;

    public string SecondPart { get; set; } = null!;
}
