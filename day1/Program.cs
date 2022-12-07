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
    long maxSum = 0;
    int sum = 0;
    
    foreach (string line in File.ReadAllLines("input.txt"))
    {
        if (!string.IsNullOrWhiteSpace(line))
            sum += int.Parse(line);
        else
        {
            if (sum > maxSum)
                maxSum = sum;

            sum = 0;
        }
    }

    return maxSum;
}

long Part2()
{
    List<long> sums = new();
    long sum = 0;
    
    foreach (string line in File.ReadAllLines("input.txt"))
    {
        if (!string.IsNullOrWhiteSpace(line))
            sum += int.Parse(line);
        else
        {
            sums.Add(sum);
            sum = 0;
        }
    }

    sums.Sort();

    return sums.TakeLast(3).Sum();
}