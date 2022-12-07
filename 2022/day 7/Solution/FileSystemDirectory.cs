namespace Solution;

public class FileSystemDirectory : IFileSystemItem
{
    public string Name { get; }
    public int Size => Files.Values.Sum(f => f.Size) + Directories.Values.Sum(d => d.Size);
    
    public FileSystemDirectory? Parent { get; private set; }
    
    public readonly Dictionary<string, FileSystemDirectory> Directories = new();
    public readonly Dictionary<string, FileSystemFile> Files = new();

    public FileSystemDirectory(string name)
    {
        Name = name;
    }

    public void AddChild(FileSystemDirectory child)
    {
        Directories.Add(child.Name, child);
        child.Parent = this;
    }
}