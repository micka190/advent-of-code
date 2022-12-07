namespace Solution;

public class TerminalOutputParser
{
    private const string ChangeDirectoryCommandString = "$ cd ";

    public List<ITerminalCommand> Parse(string input)
    {
        var commands = new List<ITerminalCommand>();

        if (!string.IsNullOrEmpty(input))
        {
            var lines = input.Trim().Split('\n');
            
            for (var i = 0; i < lines.Length; ++i)
            {
                var line = lines[i].Trim();
                
                if (line.StartsWith(ChangeDirectoryCommandString))
                {
                    var args = line[ChangeDirectoryCommandString.Length..];
                    commands.Add(new ChangeDirectoryCommand(args));
                }
                else if (line == "$ ls")
                {
                    var output = new List<string>();

                    do
                    {
                        ++i;
                        line = lines[i].Trim();
                        output.Add(line);

                    } while (i < lines.Length - 1 && !lines[i + 1].Trim().StartsWith('$'));
                    
                    commands.Add(new ListCommand(output));
                }
            }
        }
        
        return commands;
    }
}