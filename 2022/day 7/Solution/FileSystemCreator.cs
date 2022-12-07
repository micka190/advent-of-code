namespace Solution;

public class FileSystemCreator
{
    private const string ChangeDirectoryToRoot = "cd /";

    private readonly TerminalOutputParser _parser;

    public FileSystemCreator(TerminalOutputParser parser) => _parser = parser;

    public FileSystemDirectory Create(string input)
    {
        var commands = _parser.Parse(input);
        ValidateCommands(commands);

        var root = new FileSystemDirectory(commands[0].Arguments);
        var currentDirectory = root;

        for (var i = 1; i < commands.Count; ++i)
        {
            var command = commands[i];

            if (command is ChangeDirectoryCommand)
            {
                currentDirectory = GetNextDirectory(command, root, currentDirectory);
            }
            else if (command is ListCommand listCommand)
            {
                PopulateDirectory(currentDirectory, listCommand);
            }
        }

        return root;
    }

    private static void ValidateCommands(IReadOnlyList<ITerminalCommand> commands)
    {
        if (commands.Count == 0)
        {
            throw new ArgumentException("Could not produce commands from input");
        }

        if (commands[0].FullCommand != ChangeDirectoryToRoot)
        {
            throw new InvalidOperationException(
                $"Can not build File System tree if first command is not \"cd /\". Got \"{commands[0].FullCommand}\""
            );
        }
    }
    
    private static FileSystemDirectory GetNextDirectory(ITerminalCommand command, FileSystemDirectory root, FileSystemDirectory current) =>
        command.Arguments switch
        {
            "/" => root,
            ".." when current.Parent is not null => current.Parent,
            ".." => throw new ArgumentNullException(
                nameof(current.Parent),
                "Tried changing to a non-existent parent."
            ),
            _ => current.Directories[command.Arguments]
        };

    private static void PopulateDirectory(FileSystemDirectory directory, ListCommand command)
    {
        foreach (var line in command.Output)
        {
            if (line.StartsWith("dir "))
            {
                var name = line["dir ".Length..];
                var child = new FileSystemDirectory(name);
                directory.AddChild(child);
            }
            else
            {
                var firstSpaceIndex = line.IndexOf(' ');
                var size = int.Parse(line[..firstSpaceIndex]);
                var name = line[(firstSpaceIndex + 1)..];
                var file = new FileSystemFile(name, size);
                directory.Files.Add(name, file);
            }
        }
    }
}