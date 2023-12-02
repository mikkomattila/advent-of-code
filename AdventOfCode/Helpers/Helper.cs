namespace AdventOfCode;

public static class Helper
{
    public static string[] ReadInputLines(string fileName, string folder = "Solutions2023")
    {
        var basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..");
        var filePath = Path.Combine(basePath, folder, "Data", fileName);
        return File.ReadAllLines(filePath);
    }
}
