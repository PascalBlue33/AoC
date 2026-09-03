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

            foreach (var number in listOfRepeatingNumbers)
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
            if (isRepeatedNumber(i.ToString()))
            {
                repeatetNumberList.Add(i);
            }
        }
        return repeatetNumberList;
    }

    static List<long> getDivisors(long n)
    {
        List<long> divisors = new List<long>();

        for (long i = 1; i <= n; i++)
        {
            if (n % i == 0)
            {
                divisors.Add(i);
            }
        }

        return divisors;
    }

    static bool isRepeatedNumber(string number)
    {
        var length = number.Length;

        var divisorsOfLength = getDivisors(length);
        divisorsOfLength.RemoveAt(0);

        foreach(long divisor in divisorsOfLength)
        {
            var splitted = splitIntoEqualParts(number, divisor);
            if (areAllSame(splitted)) return true;
        }
        return false;
    }

    static List<string> splitIntoEqualParts(string number, long divisor)
    {
        var list = new List<string>();

        int chunkSize = (int)(number.Length / divisor);

        for (int i = 0; i < divisor; i++)
        {
            string element = number.Substring(i * chunkSize, chunkSize);
            list.Add(element);
        }

        return list;
    }

    static bool areAllSame(List<string> list)
    {
        string example = list[0];

        foreach (var element in list)
        {
            if (element != example)
            {
                return false;
            }
        }
        return true;
    }

    static string readFile(string path)
    {
        return File.ReadAllText(path);
    }
}
