﻿using System.Diagnostics;

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
    return FindMarker(4);
}

long Part2()
{
    return FindMarker(14);
}

long FindMarker(int size)
{
    string line = File.ReadAllText("input.txt");

    for (int i = 0; i < line.Length; i++)
    {
        if (AreCharsUnique(line.Substring(i, size)))
            return i + size;
    }

    return -1;
}

bool AreCharsUnique(string value)
{
    foreach (char c in value)
    {
        if (value.Count(s => s == c) > 1)
            return false;
    }

    return true;
}
