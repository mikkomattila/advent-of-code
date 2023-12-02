namespace AdventOfCode;

public static class Helpers
{
    public static string[] ReadInputLines(string fileName)
    {
        var basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..");
        var filePath = Path.Combine(basePath, "Solutions2023", "Data", fileName);
        return File.ReadAllLines(filePath);
    }
}
