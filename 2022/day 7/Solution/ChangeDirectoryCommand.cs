namespace Solution;

public class ChangeDirectoryCommand : ITerminalCommand
{
    public string FullCommand => $"{Command} {Arguments}";
    public string Command => "cd";
    public string Arguments { get; }
    public List<string> Output { get; } = new();

    public ChangeDirectoryCommand(string arguments)
    {
        Arguments = arguments;
    }
}