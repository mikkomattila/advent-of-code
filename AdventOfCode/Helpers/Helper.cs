namespace AdventOfCode;

public static class Helper
{
    public static string[] ReadInputLines(string folder, string fileName)
    {
        var basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..");
        var filePath = Path.Combine(basePath, folder, "Data", fileName);
        return File.ReadAllLines(filePath);
    }
}
