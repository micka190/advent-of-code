namespace Solution;

public class Solver
{
    private readonly FileSystemCreator _fileSystemCreator;
    public Solver(FileSystemCreator fileSystemCreator) => _fileSystemCreator = fileSystemCreator;

    public int SolveForPartOne(string input)
    {
        const int sizeLimit = 100000;
        var root = _fileSystemCreator.Create(input);
        var smallDirectories = FindSmallDirectories(root, new List<FileSystemDirectory>(), sizeLimit);
        return smallDirectories.Sum(dir => dir.Size);
    }

    private static List<FileSystemDirectory> FindSmallDirectories(
        FileSystemDirectory directory, 
        List<FileSystemDirectory> smallDirectories, 
        int sizeLimit
        )
    {
        foreach (var child in directory.Directories.Values)
        {
            if (child.Size < sizeLimit)
            {
                smallDirectories.Add(child);
            }
            
            if (child.Directories.Count > 0)
            {
                FindSmallDirectories(child, smallDirectories, sizeLimit);
            }
        }

        return smallDirectories;
    }
}