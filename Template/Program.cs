namespace ${PROJECT};

internal class Program
{
    public static void Main(string[] args)
    {
        var data = File.ReadAllLines();

        foreach(var line in data)
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