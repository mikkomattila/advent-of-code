using AdventOfCode.Classes;
using AdventOfCode.Interfaces;

namespace AdventOfCode;

public static class Helper
{
    public static DayResult GetResultForDay(int day, int year = 2023)
    {
        var className = $"AdventOfCode.Solutions{year}.Day{day}";
        var dayType = Type.GetType(className);

        if (dayType == null)
            Console.WriteLine($"Solution not found for day provided ({day}).");

        if (!typeof(IDay).IsAssignableFrom(dayType))
            Console.WriteLine($"Class {className} does not implement IDay.");

        var dayInstance = (IDay)Activator.CreateInstance(dayType!)!;
        return dayInstance.GetResultForDay();
    }

    public static string[] ReadInputLines(string fileName, string folder = "Solutions2023")
    {
        var basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..");
        var filePath = Path.Combine(basePath, folder, "Data", fileName);
        return File.ReadAllLines(filePath);
    }
}
