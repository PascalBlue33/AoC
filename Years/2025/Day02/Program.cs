namespace Y2025.Day02;

internal class Program
{
    public static void Main(string[] args)
    {
        var path = $"./data/input.txt";
        
        var list = readFile(path).Split(",").ToList();

        long count = 0;

        foreach (var item in list)
        {
            var array = item.Split("-");
            var min = Convert.ToInt64(array[0]);
            var max = Convert.ToInt64(array[1]);
            var listOfRepeatingNumbers = getRepeatetNumbers(min, max);

            foreach(var number in listOfRepeatingNumbers)
            {
                count += number;
            }
        }
        
        Console.WriteLine($"Sum of repeating numbers: {count}");
    }

    static List<long> getRepeatetNumbers(long min, long max)
    {
        var repeatetNumberList = new List<long>();
        for (long i = min; i <= max; i++)
        {
            if (isRepeatedNumber(i))
            {
                repeatetNumberList.Add(i);
            }
        }
        return repeatetNumberList;
    }

    static bool isRepeatedNumber(long number)
    {
        int lenght = number.ToString().Length;
        if (lenght % 2 != 0) return false;
        var firstHalf = long.Parse(number.ToString().Substring(0, lenght / 2));
        var lastHalf = long.Parse(number.ToString().Substring(lenght / 2));
        if (firstHalf == lastHalf)
        {
            return true;
        }
        return false;
    }

    static string readFile(string path)
    {
        return File.ReadAllText(path);
    }
}
