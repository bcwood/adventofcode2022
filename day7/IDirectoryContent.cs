internal interface IDirectoryContent
{
    string Name { get; set; }
    long Size { get; }
    DirectoryContent? Parent { get; set; }
}

internal class DirectoryContent : IDirectoryContent
{
    public string Name { get; set; }
    public DirectoryContent? Parent { get; set; }
    public List<IDirectoryContent> Contents { get; set; }

    public long Size => this.Contents.Sum(c => c.Size);

    public DirectoryContent(string name, DirectoryContent? parent)
    {
        Name = name;
        Parent = parent;
        Contents = new();
    }
}

internal class FileContent : IDirectoryContent
{
    public string Name { get; set; }
    public long Size { get; set; }
    public DirectoryContent? Parent { get; set; }

    public FileContent(string name, long size, DirectoryContent? parent)
    {
        Name = name;
        Size = size;
        Parent = parent;
    }
}
