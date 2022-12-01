internal static class Day1
{
    public static void Part1()
    {
        int sum = 0;
        int maxSum = 0;

        foreach (string line in File.ReadAllLines($"{Constants.INPUT_PATH}/day1.txt"))
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

    public static void Part2()
    {
        int sum = 0;
        List<int> sums = new();

        foreach (string line in File.ReadAllLines($"{Constants.INPUT_PATH}/day1.txt"))
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
}