using System.Diagnostics;

Stopwatch stopwatch1 = Stopwatch.StartNew();
string part1 = Part1();
stopwatch1.Stop();

Stopwatch stopwatch2 = Stopwatch.StartNew();
string part2 = Part2();
stopwatch2.Stop();

Console.WriteLine($"Part 1: {part1} ({stopwatch1.ElapsedMilliseconds}ms)");
Console.WriteLine($"Part 2: {part2} ({stopwatch2.ElapsedMilliseconds}ms)");

Console.WriteLine("\nPress any key to continue...");
Console.Read();

string Part1()
{
    var stacks = ParseStacks();

    // find the bottom of the stack
    string[] input = File.ReadAllLines("input.txt");
    int bottom = 0;
    foreach (string line in input)
    {
        if (line == string.Empty)
            break;

        bottom++;
    }

    for (int i = bottom + 1; i < input.Length; i++)
    {
        string line = input[i];
        string[] parts = line.Split(' ');
        int number = int.Parse(parts[1]);
        int source = int.Parse(parts[3]) - 1;
        int dest = int.Parse(parts[5]) - 1;

        for (int j = 0; j < number; j++)
        {
            stacks[dest].Push(stacks[source].Pop());
        }
    }

    string result = "";

    for (int i = 0; i < stacks.Length; i++)
    {
        result += stacks[i].Peek();
    }

    return result;
}

string Part2()
{
    var stacks = ParseStacks();

    // find the bottom of the stack
    string[] input = File.ReadAllLines("input.txt");
    int bottom = 0;
    foreach (string line in input)
    {
        if (line == string.Empty)
            break;

        bottom++;
    }

    for (int i = bottom + 1; i < input.Length; i++)
    {
        string line = input[i];
        string[] parts = line.Split(' ');
        int number = int.Parse(parts[1]);
        int source = int.Parse(parts[3]) - 1;
        int dest = int.Parse(parts[5]) - 1;

        // save in string to preserve order
        string toMove = "";

        for (int j = 0; j < number; j++)
        {
            toMove += stacks[source].Pop();
        }

        // reverse order of Pop() to preserve original order
        foreach (char c in toMove.Reverse())
        {
            stacks[dest].Push(c);
        }
    }

    string result = "";

    for (int i = 0; i < stacks.Length; i++)
    {
        result += stacks[i].Peek();
    }

    return result;
}

Stack<char>[] ParseStacks()
{
    Stack<char>[] stacks = new Stack<char>[9];

    for (int i = 0; i < stacks.Length; i++)
        stacks[i] = new Stack<char>();

    // find the bottom of the stack
    string[] input = File.ReadAllLines("input.txt");
    int bottom = 0;
    foreach (string line in input)
    {
        if (line == string.Empty)
            break;

        bottom++;
    }

    // build the stacks from the bottom up
    for (int i = bottom - 2; i >= 0; i--)
    {
        for (int j = 0; j < 9; j++)
        {
            int index = (j * 3) + (j + 1);
            char value = input[i][index];
            if (value != ' ')
                stacks[j].Push(value);
        }
    }

    return stacks;
}