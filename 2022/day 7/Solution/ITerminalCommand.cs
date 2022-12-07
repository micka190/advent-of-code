namespace Solution;

public interface ITerminalCommand
{
    public string FullCommand { get; }
    public string Command { get; }
    public string Arguments { get; }
    public List<string> Output { get; }
}