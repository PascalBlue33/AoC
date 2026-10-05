namespace Y2025.Day05;

internal class Program
{
    public static void Main(string[] args)
    {
        var path = $"./data/input.txt";

        var list = File.ReadAllLines(path);

        List<long> freshIds = new List<long>();

        int cutIndex = 0;

        for (int i = 0; i < list.Length; i++)
        {
            string? line = list[i];
            if (line == "")
            {
                cutIndex = i;
            }
        }

        var freshIdRanges = list[..cutIndex];

        var idsToCheck = list[(cutIndex + 1)..];

        foreach (string line in freshIdRanges)
        {
            long minValue = Convert.ToInt64(line.Split("-")[0]);
            long maxValue = Convert.ToInt64(line.Split("-")[1]);

            for (long i = minValue; i <= maxValue; i++)
            {
                if (!freshIds.Contains(i))
                {
                    freshIds.Add(i);
                }
            }
        }

        var counter = 0;

        foreach (var idString in idsToCheck)
        {
            long id = Convert.ToInt64(idString);

            if (freshIds.Contains(id))
            {
                counter += 1;
            }

        }
        Console.WriteLine(counter);
    }
}
