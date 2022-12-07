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
    long score = 0;

    foreach (string line in File.ReadAllLines("input.txt"))
    {
        string[] parts = line.Split(' ');
        score += ScorePart1(char.Parse(parts[0]), char.Parse(parts[1]));
    }

    return score;
}

long ScorePart1(char theirs, char mine)
{
    long score = 0;

    switch (theirs)
    {
        case 'A': // rock
            if (mine == 'X')
                score = 3 + 1;
            else if (mine == 'Y')
                score = 6 + 2;
            else
                score = 0 + 3;
            break;

        case 'B': // paper
            if (mine == 'X')
                score = 0 + 1;
            else if (mine == 'Y')
                score = 3 + 2;
            else
                score = 6 + 3;
            break;

        case 'C': // scissors
            if (mine == 'X')
                score = 6 + 1;
            else if (mine == 'Y')
                score = 0 + 2;
            else
                score = 3 + 3;
            break;
    }

    return score;
}

long Part2()
{
    long score = 0;

    foreach (string line in File.ReadAllLines("input.txt"))
    {
        string[] parts = line.Split(' ');
        score += ScorePart2(char.Parse(parts[0]), char.Parse(parts[1]));
    }

    return score;
}

long ScorePart2(char theirs, char outcome)
{
    long score = 0;

    switch (theirs)
    {
        case 'A': // rock
            if (outcome == 'X')
                score = 0 + 3;
            else if (outcome == 'Y')
                score = 3 + 1;
            else
                score = 6 + 2;
            break;

        case 'B': // paper
            if (outcome == 'X')
                score = 0 + 1;
            else if (outcome == 'Y')
                score = 3 + 2;
            else
                score = 6 + 3;
            break;

        case 'C': // scissors
            if (outcome == 'X')
                score = 0 + 2;
            else if (outcome == 'Y')
                score = 3 + 3;
            else
                score = 6 + 1;
            break;
    }

    return score;
}
