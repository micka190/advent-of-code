namespace Solution;

public class TerminalOutputParser
{
    private const string CommandPrefix = "$";
    private const string ChangeDirectoryCommandString = $"{CommandPrefix} cd ";
    private const string ListDirectoryCommandString = $"{CommandPrefix} ls";

    public List<ITerminalCommand> Parse(string input)
    {
        var commands = new List<ITerminalCommand>();

        if (!string.IsNullOrEmpty(input))
        {
            foreach (var line in GetFormattedLines(input))
            {
                if (LineIsCommand(line))
                {
                    commands.Add(ProcessCommand(line));
                }
                else
                {
                    commands.Last().Output.Add(line);
                }
            }
        }

        return commands;
    }

    private static ITerminalCommand ProcessCommand(string line)
    {
        if (line.StartsWith(ChangeDirectoryCommandString))
        {
            var args = line[ChangeDirectoryCommandString.Length..];
            return new ChangeDirectoryCommand(args);
        }

        if (line.StartsWith(ListDirectoryCommandString))
        {
            return new ListCommand();
        }
        
        throw new ArgumentOutOfRangeException(nameof(line), "Unsupported command");
    }

    private static IEnumerable<string> GetFormattedLines(string input) => input.Trim().Split('\n');

    private static bool LineIsCommand(string line) => line.StartsWith(CommandPrefix);
}