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

    string[] lines = File.ReadAllLines("input.txt");
    for (int y = 0; y < lines.Length; y++)
    {
        for (int x = 0; x < lines[y].Length; x++)
        {
            if (x == 0 || x == lines[y].Length - 1 ||
                y == 0 || y == lines.Length - 1)
                count++;
            else if (IsVisibleInDirection(lines, x, y, 0, 1) ||
                     IsVisibleInDirection(lines, x, y, 0, -1) ||
                     IsVisibleInDirection(lines, x, y, 1, 0) ||
                     IsVisibleInDirection(lines, x, y, -1, 0))
                count++;
        }
    }

    return count;
}

bool IsVisibleInDirection(string[] lines, int x, int y, int diffX, int diffY)
{
    int height = lines[y][x];
    
    x += diffX;
    y += diffY;

    while (y >= 0 && y < lines.Length && x >= 0 && x < lines[y].Length)
    {
        if (height <= lines[y][x])
            return false;

        x += diffX;
        y += diffY;
    }

    return true;
}

long Part2()
{
    int maxScore = 0;

    string[] lines = File.ReadAllLines("input.txt");
    for (int y = 0; y < lines.Length; y++)
    {
        for (int x = 0; x < lines[y].Length; x++)
        {
            int score = GetViewingDistance(lines, x, y, 0, 1) *
                        GetViewingDistance(lines, x, y, 0, -1) *
                        GetViewingDistance(lines, x, y, 1, 0) *
                        GetViewingDistance(lines, x, y, -1, 0);

            if (score > maxScore)
                maxScore = score;
        }
    }

    return maxScore;
}

int GetViewingDistance(string[] lines, int x, int y, int diffX, int diffY)
{
    int height = lines[y][x];
    int score = 0;

    x += diffX;
    y += diffY;

    while (y >= 0 && y < lines.Length && x >= 0 && x < lines[y].Length)
    {
        score++;
        
        if (height <= lines[y][x])
            break;

        x += diffX;
        y += diffY;
    }

    return score;
}