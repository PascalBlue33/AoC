namespace Y2025.Day05;

internal class Program
{
    public static void Main(string[] args)
    {
        var path = $"./data/example.txt";

        var list = File.ReadAllLines(path);

        Part2(list);
    }

    public static void Part2(string[] list)
    {
        int cutIndex = 0;

        long total = 0;

        for (int i = 0; i < list.Length; i++)
        {
            string? line = list[i];
            if (line == "")
            {
                cutIndex = i;
            }
        }

        List<Tuple<long, long>> numberRanges = new List<Tuple<long, long>>();
        List<Tuple<long, long>> checkedRanges = new List<Tuple<long, long>>();

        var stringRanges = list[..cutIndex].ToList();

        foreach(var line in stringRanges)
        {
            long minValue = Convert.ToInt64(line.Split("-")[0]);
            long maxValue = Convert.ToInt64(line.Split("-")[1]);
            numberRanges.Add(new Tuple<long, long>(minValue, maxValue));
        }

        foreach (Tuple<long, long> range in numberRanges)
        {
            bool isOverlapping = IsOverlapping(range, checkedRanges);
            
            if (isOverlapping)
            {
                var overlap = CalculateOverlap(range, checkedRanges);
                total += overlap;
                Console.WriteLine("Monte man Yeessss");
            }
            else
            {
                total += range.Item2 - range.Item1 + 1;
            }

            
        }
        Console.WriteLine($"Total fresh Id's: {total}");
    }

    public static bool IsOverlapping(Tuple<long, long> range, List<Tuple<long, long>> checkedRanges)
    {
        foreach (var checkedRange in checkedRanges)
        {
            if (range.Item1 < checkedRange.Item2 && range.Item2 > checkedRange.Item1)
            {
                return true;
            }
        }
        return false;
    }

    public static long CalculateOverlap(Tuple<long, long> range, List<Tuple<long, long>> checkedRanges)
    {
        long overlap = 0;
        foreach (var checkedRange in checkedRanges)
        {
            if (range.Item1 < checkedRange.Item2 && range.Item2 > checkedRange.Item1)
            {
                var diff1 = range.Item2 - checkedRange.Item1;
                var diff2 = range.Item2 - range.Item1;
                overlap = diff2-diff1;
            }
        }
        return overlap;
    }

    public static void Part1(string[] list)
    {
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

            foreach (var id in idsToCheck.ToList())
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
