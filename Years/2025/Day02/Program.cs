namespace Y2025.Day02;

internal class Program
{
    public static void Main(string[] args)
    {
        var path = $"./data/example.txt";
        
        var list = readFile(path).Split(",").ToList();

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
        
    }

    static string Part1(string[] input)
    {
        return string.Join('\n', input);
    }

    static string readFile(string path)
    {
        return File.ReadAllText(path);
    }
}
