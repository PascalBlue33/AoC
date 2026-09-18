namespace Y2025.Day03;

internal class Program
{
    public static void Main(string[] args)
    {
        var path = $"./data/input.txt";

        var list = File.ReadAllLines(path);

        long max = 0;

        foreach (string line in list)
        {
            max += getBiggestCombination(line);
        }

        Console.WriteLine("Sum: " + max);
    }

    static long getBiggestCombination(string number)
    {
        var n = "";

        for (int i = 0; i < 12; i++)
        {
            var remaining = 12 - i;

            var biggest = getBiggest(number, remaining);

            int index = number.IndexOf(biggest);

            number = number[(index + 1)..];

            n += biggest;
        }
        return Convert.ToInt64(n);
    }

    static string getBiggest(string number, int remaining)
    {
        int max = 0;

        for (int i = 0; i <= number.Length - remaining; i++)
        {
            char num = number[i];
            var n = Convert.ToInt32(num.ToString());

            if (n > max) max = n;
        }

        return max.ToString();
    }
}
