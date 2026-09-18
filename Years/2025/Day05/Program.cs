namespace Y2025.Day05;

internal class Program
{
    public static void Main(string[] args)
    {
        var path = $"./data/input.txt";

        var list = File.ReadAllLines(path);

        List<int> freshIds = new List<int>();

        List<string> freshIdsRanges = new List<string>();

        List<int> idsToCheck = new List<int>();

        foreach (string line in list)
        {
            
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
