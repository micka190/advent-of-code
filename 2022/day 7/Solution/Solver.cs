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

    public int SolveForPartTwo(string input)
    {
        const int totalSizeOnDevice = 70000000;
        const int sizeRequiredForUpdate = 30000000;

        var root = _fileSystemCreator.Create(input);

        var flattenedFileSystem = FlattenDirectory(root, new List<FileSystemDirectory>())
            .OrderBy(dir => dir.Size)
            .ToList();

        var unusedSize = totalSizeOnDevice - root.Size;
        
        if (unusedSize >= sizeRequiredForUpdate)
        {
            return unusedSize;
        }

        foreach (var directory in flattenedFileSystem)
        {
            var size = directory.Size;
                
            if (size + unusedSize >= sizeRequiredForUpdate)
            {
                return size;
            }
        }

        return -1;
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

    private static List<FileSystemDirectory> FlattenDirectory(FileSystemDirectory directory, List<FileSystemDirectory> directories)
    {
        foreach (var child in directory.Directories.Values)
        {
            directories.Add(child);
            FlattenDirectory(child, directories);
        }
        
        return directories;
    }
}