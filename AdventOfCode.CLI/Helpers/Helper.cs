using AdventOfCode.Classes;
using AdventOfCode.Interfaces;

namespace AdventOfCode;

public static class Helper
{
    /// <summary>
    /// Get result for specified day.
    /// </summary>
    /// <param name="day">Solution day.</param>
    /// <param name="year">Solution year, defaults to 2023.</param>
    /// <returns></returns>
    public static DayResult GetResultForDay(int day, int year = 2023)
    {
        var className = $"AdventOfCode.Solutions{year}.Day{day}";
        var dayType = Type.GetType(className);

        if (dayType is null)
            Console.WriteLine($"Solution not found for day provided ({day}).");

        if (!typeof(IDay).IsAssignableFrom(dayType))
            Console.WriteLine($"Class {className} does not implement IDay.");

        var dayInstance = (IDay)Activator.CreateInstance(dayType!)!;
        return dayInstance.GetResultForDay();
    }

    /// <summary>
    /// Read a txt file from a specified folder.
    /// </summary>
    /// <param name="day">Day of the solution.</param>
    /// <param name="folder">Folder name, defaults to Solutions2023.</param>
    /// <param name="overrideFolderName">If folderName should be completely overwritten.</param>
    /// <returns></returns>
    public static string[] ReadInputLines(string day, string folder = "Solutions2023", bool overrideFolderNameByDay = false)
    {
        var basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..");
        var filePath = Path.Combine(basePath, folder, "InputData", overrideFolderNameByDay ? day : $"Day{day}Input.txt");

        return File.ReadAllLines(filePath);
    }
}
