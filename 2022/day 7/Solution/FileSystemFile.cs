namespace Solution;

public class FileSystemFile : IFileSystemItem
{
    public string Name { get; }
    public int Size { get; }

    public FileSystemFile(string name, int size)
    {
        Name = name;
        Size = size;
    }
}