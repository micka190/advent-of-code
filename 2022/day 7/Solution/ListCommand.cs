namespace Solution;

public class ListCommand : ITerminalCommand
{
    public string FullCommand => Command;
    public string Command => "ls";
    public string Arguments => string.Empty;
    public List<string> Output { get; } = new();
}