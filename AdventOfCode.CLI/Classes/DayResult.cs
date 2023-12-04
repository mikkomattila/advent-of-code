namespace AdventOfCode.Classes;

public record DayResult
{
    public DayResult(string firstAnswer, string secondAnswer)
    {
        FirstAnswer = string.IsNullOrEmpty(firstAnswer) 
            ? "No answer yet." 
            : firstAnswer;

        SecondAnswer = string.IsNullOrEmpty(secondAnswer) 
            ? "No answer yet." 
            : secondAnswer;
    }

    public DayResult(int firstAnswer, int secondAnswer)
    {
        FirstAnswer = $"{firstAnswer}";
        SecondAnswer = $"{secondAnswer}";
    }

    public string FirstAnswer { get; set; } = null!;

    public string SecondAnswer { get; set; } = null!;
}
