namespace Y2025.Day04;

internal class Program
{
    public static void Main(string[] args)
    {
        var path = $"./data/input.txt";

        var list = File.ReadAllLines(path);

        foreach (string line in list)
        {
            Console.WriteLine(line);
        }
    }

    static string read(string[] input)
    {
        return string.Join('\n', input);
    }

    static string Part2(string[] input)
    {
        return string.Join('\n', input);
    }
}
