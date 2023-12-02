namespace AdventOfCode.Classes;

public record DayResult
{
    public DayResult(string firstAnswer, string secondAnswer)
    {
        FirstAnswer = firstAnswer;
        SecondAnswer = secondAnswer;
    }

    public DayResult(int firstAnswer, int secondAnswer)
    {
        FirstAnswer = $"{firstAnswer}";
        SecondAnswer = $"{secondAnswer}";
    }

    public string FirstAnswer { get; set; } = null!;

    public string SecondAnswer { get; set; } = null!;
}
