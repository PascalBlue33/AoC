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
        int index = 0;

        int max = 0;
        for (int i = 0; i < number.Length - 1; i++)
        {
            char c = number[i];
            int num = Convert.ToInt32(c.ToString());

            if (num > max)
            {
                max = num;
                index = i;
            }
        }

        var newNumber = number.Substring(index + 1);

        int max2 = 0;

        foreach (char c in newNumber)
        {
            int num = Convert.ToInt32(c.ToString());

            if (num > max2)
            {
                max2 = num;
            }
        }

        var final = Convert.ToString(max) + Convert.ToString(max2);
        Console.WriteLine($"Max1: {max}, Max2: {max2}, Final: {final}");
        return Convert.ToInt64(final);
    }
}
