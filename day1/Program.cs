Part1();
Part2();

Console.WriteLine("\nPress any key to continue...");
Console.Read();

void Part1()
{
    int sum = 0;
    int maxSum = 0;

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

    Console.WriteLine(maxSum);
}

void Part2()
{
    int sum = 0;
    List<int> sums = new();

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
    int top3 = sums.TakeLast(3).Sum();

    Console.WriteLine(top3);
}