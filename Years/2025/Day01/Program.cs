namespace Y2025.Day01;

internal class Program
{
    public static void Main(string[] args)
    {
        const string path = @".\data\input.txt";
        var list = getFile(path);
        
        var dial = 50;
        var zeroCounter = 0;

        foreach (var line in list)
        {
            (var zeros, dial) = moveDial(line[0].ToString(), Convert.ToInt32(line.Substring(1)), dial);
            zeroCounter += zeros;
        }

        Console.WriteLine(zeroCounter);
    }

    static List<string> getFile(string path)
    {
        return File.ReadAllLines(path).ToList();
    }

    static int checkNum(int dial)
    {
        while (dial < 0)
        {
            dial += 100;
        }

        while (dial > 99)
        {
            dial -= 100;
        }

        return dial;
    }
    static (int, int) moveDial(string direction, int count, int dial)
    {
        var zeroCounter = 0;

        switch (direction.Trim())
        {
            case "R":
                for (int i = 0; i < count; i++)
                {
                    dial = checkNum(dial);
                    if (dial == 0)
                    {
                        zeroCounter++;
                    }

                    dial++;
                }

                break;

            case "L":
                for (int i = 0; i < count; i++)
                {
                    dial = checkNum(dial);
                    if (dial == 0)
                    {
                        zeroCounter++;
                    }

                    dial--;
                }

                break;
        }
        Console.WriteLine(dial);

        return (zeroCounter, dial);
    }
}