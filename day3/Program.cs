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
    long sum = 0;

    foreach (string line in File.ReadAllLines("input.txt"))
    {
        string first = line.Substring(0, line.Length / 2);
        string second = line.Substring(line.Length / 2);

        foreach (char c in first)
        {
            if (second.Contains(c))
            {
                sum += GetPriority(c);
                break;
            }
        }
    }

    return sum;
}

long Part2()
{
    long sum = 0;
    string[] lines = File.ReadAllLines("input.txt");

    for (int i = 0; i < lines.Length - 2; i+=3)
    {
        string pack1 = lines[i];
        string pack2 = lines[i + 1];
        string pack3 = lines[i + 2];

        foreach (char c in pack1)
        {
            if (pack2.Contains(c) && pack3.Contains(c))
            {
                sum += GetPriority(c);
                break;
            }
        }
    }

    return sum;
}

int GetPriority(char c)
{
    string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    return chars.IndexOf(c) + 1;
}
