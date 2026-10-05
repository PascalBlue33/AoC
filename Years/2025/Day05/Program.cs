namespace Y2025.Day05;

internal class Program
{
    public static void Main(string[] args)
    {
        var path = $"./data/input.txt";

        var list = File.ReadAllLines(path);

        int cutIndex = 0;

        var counter = 0;

        for (int i = 0; i < list.Length; i++)
        {
            string? line = list[i];
            if (line == "")
            {
                cutIndex = i;
            }
        }

        var freshIdRanges = list[..cutIndex];

        List<string> idsToCheck = list[(cutIndex + 1)..].ToList();

        foreach (string line in freshIdRanges)
        {
            long minValue = Convert.ToInt64(line.Split("-")[0]);
            long maxValue = Convert.ToInt64(line.Split("-")[1]);

            foreach(var id in idsToCheck.ToList())
            {
                var idNum = Convert.ToInt64(id);
                if (idNum >= minValue && idNum <= maxValue)
                {
                    counter++;
                    idsToCheck.Remove(id);
                }
            }
        }        
        Console.WriteLine(counter);
    }
}
