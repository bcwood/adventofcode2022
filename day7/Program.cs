using System.Diagnostics;

long totalFileSize;

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
    var directories = ParseDirectories();

    return directories.Where(d => d.Size <= 100000).Sum(d => d.Size);
}

long Part2()
{
    var directories = ParseDirectories();

    long diskSize = 70000000;
    long freeSpace = diskSize - totalFileSize;
    long reqFreeSpace = 30000000;
    long targetSize = reqFreeSpace - freeSpace;

    return directories.OrderBy(d => d.Size)
                      .First(d => d.Size >= targetSize)
                      .Size;
}

List<IDirectoryContent> ParseDirectories()
{
    DirectoryContent currentDir = new DirectoryContent("/", null);
    var directoryContents = new List<IDirectoryContent>();
    totalFileSize = 0;

    var lines = File.ReadAllLines("input.txt");

    for (int i = 1; i < lines.Length; i++)
    {
        string line = lines[i];

        if (line.StartsWith("$ ls"))
        {
            line = lines[++i];
            while (!line.StartsWith("$"))
            {
                if (line.StartsWith("dir "))
                {
                    string dirName = line.Substring("dir ".Length);
                    var dir = new DirectoryContent(dirName, currentDir);
                    currentDir.Contents.Add(dir);
                    directoryContents.Add(dir);
                }
                else
                {
                    string[] parts = line.Split(' ');
                    int size = int.Parse(parts[0]);
                    string fileName = parts[1];
                    currentDir.Contents.Add(new FileContent(fileName, size, currentDir));
                    totalFileSize += size;
                }

                if (i < lines.Length - 1)
                    line = lines[++i];
                else
                    break;
            }

            i--; // back up 1 line so we can start here next time through outer loop
        }
        else if (line.StartsWith("$ cd"))
        {
            string dirName = line.Substring("$ cd ".Length);
            if (dirName == "..")
                currentDir = currentDir.Parent;
            else
                currentDir = (DirectoryContent)currentDir.Contents.Single(d => d.Name == dirName);
        }
    }

    return directoryContents;
}
