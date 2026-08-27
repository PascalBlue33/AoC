namespace Y2025.Day01;

internal class Program
{
    public static void Main(string[] args)
    {
        const string examplePath = @".\data\example.txt";
        const string inputPath = @".\data\input.txt";

        int dial = 50;
        
        var list = getFile(inputPath);

        var zeroCounter = 0;
        
        foreach (var line in list)
        {
            dial = moveDial(line[0].ToString(), Convert.ToInt32(line.Substring(1)), dial);
            
            if (dial== 0)
            {
                zeroCounter++;
            }
        }
        Console.WriteLine(zeroCounter);
    }

    static List<string> getFile(string path)
    {
        return File.ReadAllLines(path).ToList();
    }

    static int moveDial(string direction, int count, int dial)
    {
        if (direction.Trim() == "L")
        {
            dial -= count;
        }

        if (direction.Trim() == "R")
        {
            dial += count;
        }
        
        while (dial > 99)
        {
            dial -= 100;
        }

        while (dial < 0)
        {
            dial += 100;
        }
        return dial;
    }
}
