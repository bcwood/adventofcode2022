using System.Diagnostics;

Stopwatch stopwatch1 = Stopwatch.StartNew();
long part1 = Part1();
stopwatch1.Stop();

Stopwatch stopwatch2 = Stopwatch.StartNew();
long part2 = Part2();
stopwatch2.Stop();

Console.WriteLine($"Part 1: {part1} ({stopwatch1.ElapsedMilliseconds}ms)");
Console.WriteLine($"Part 2: {part2} ({stopwatch2.ElapsedMilliseconds}ms)");

Console.WriteLine("\nPress any key to continue...");
Console.Read();

long Part1()
{
    long count = 0;

    foreach (string line in File.ReadAllLines("input.txt"))
    {
        string[] parts = line.Split(new[] { ',' });
        string[] firstParts = parts[0].Split(new[] { '-' });
        string[] secondParts = parts[1].Split(new[] { '-' });

        (int Low, int High) first = (int.Parse(firstParts[0]), int.Parse(firstParts[1]));
        (int Low, int High) second = (int.Parse(secondParts[0]), int.Parse(secondParts[1]));

        if (RangeContains(first, second) || RangeContains(second, first))
            count++;
    }

    return count;
}

bool RangeContains((int Low, int High) first, (int Low, int High) second)
{
    return (first.Low <= second.Low && first.High >= second.High);
}

long Part2()
{
    long count = 0;

    foreach (string line in File.ReadAllLines("input.txt"))
    {
        string[] parts = line.Split(new[] { ',' });
        string[] firstParts = parts[0].Split(new[] { '-' });
        string[] secondParts = parts[1].Split(new[] { '-' });

        (int Low, int High) first = (int.Parse(firstParts[0]), int.Parse(firstParts[1]));
        (int Low, int High) second = (int.Parse(secondParts[0]), int.Parse(secondParts[1]));

        if (RangeOverlaps(first, second) || RangeOverlaps(second, first))
            count++;
    }

    return count;
}

bool RangeOverlaps((int Low, int High) first, (int Low, int High) second)
{
    return (first.Low <= second.Low && first.High >= second.Low) ||
           (first.Low <= second.High && first.High >= second.High);
}
