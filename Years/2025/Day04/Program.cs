namespace Y2025.Day04;

internal class Program
{
    public static void Main(string[] args)
    {
        var path = $"./data/input.txt";

        var list = File.ReadAllLines(path);

        int counter = 0;

        for (int i = 0; i < list.Length; i++)
        {
            string line = list[i];
            for (int j = 0; j < line.Length; j++)
            {
                char c = line[j];
                if (c.ToString() == "@")
                {
                    if (canTake(
                        i > 0 ? list[i - 1] : null,
                        list[i],
                        i < list.Length - 1 ? list[i + 1] : null,
                        j))
                    {
                        counter++;
                    }
                }
            }
        }
        Console.WriteLine(counter);
    }

    static bool canTake(string? previousLine, string actualLine, string? nextLine, int index)
    {
        int counter = 0;

        for (int i = index - 1; i <= index + 1; i++)
        {
            if (i < 0 || i >= actualLine.Length)
                continue;

            if (previousLine != null && previousLine[i] == '@')
                counter++;

            if (nextLine != null && nextLine[i] == '@')
                counter++;
        }

        if (index > 0 && actualLine[index - 1] == '@') counter++;

        if (index < actualLine.Length - 1 && actualLine[index + 1] == '@') counter++;

        return counter < 4;
    }
}
