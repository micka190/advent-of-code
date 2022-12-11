namespace Solution;

public class MonkeyParser
{
    private const int MonkeyLineIndex = 0;
    private const int StartingItemsLineIndex = 1;
    private const int OperationLineIndex = 2;
    private const int ItemTestLineIndex = 3;
    
    private const string StartingItemsPrefix = "Starting items: ";
    private const string ItemTestPrefix = "Test: divisible by ";
    private const string OperationPrefix = "Operation: new = ";
    private const string TruePrefix = "If true: throw to monkey ";
    private const string FalsePrefix = "If false: throw to monkey ";
    
    public List<Monkey> Parse(string input) =>
        string.IsNullOrEmpty(input)
            ? new List<Monkey>()
            : input
                .Trim()
                .Split("\n\n")
                .Select(ParseMonkeyBlock)
                .ToList();

    private Monkey ParseMonkeyBlock(string block)
    {
        var lines = block.Split('\n');
        ValidatePrefix(lines[MonkeyLineIndex], "Monkey ");
        
        return new Monkey
        {
            Items = ParseStartingItems(lines[StartingItemsLineIndex].Trim()),
            Operation = ParseOperation(lines[OperationLineIndex].Trim()),
            ItemTest = ParseItemTest(lines[ItemTestLineIndex..].Select(line => line.Trim()).ToArray())
        };
    }

    private static List<int> ParseStartingItems(string line)
    {
        ValidatePrefix(line, StartingItemsPrefix);
        var items = line[StartingItemsPrefix.Length..].Split(", ");
        return items.Select(int.Parse).ToList();
    }

    private static Operation ParseOperation(string line)
    {
        ValidatePrefix(line, OperationPrefix);
        var operation = line[OperationPrefix.Length..];
        return new Operation(operation);
    }

    private static ItemTest ParseItemTest(string[] lines)
    {
        if (lines.Length != 3)
        {
            throw new ArgumentException("There are 3 lines in an item test block.", nameof(lines));
        }
        
        ValidatePrefix(lines[0], ItemTestPrefix);
        ValidatePrefix(lines[1], TruePrefix);
        ValidatePrefix(lines[2], FalsePrefix);

        var divisor = int.Parse(lines[0][ItemTestPrefix.Length..]);
        var trueTarget = int.Parse(lines[1][TruePrefix.Length..]);
        var falseTarget = int.Parse(lines[2][FalsePrefix.Length..]);
        
        return new ItemTest(divisor, trueTarget, falseTarget);
    }

    private static void ValidatePrefix(string line, string prefix)
    {
        if (!line.StartsWith(prefix))
        {
            throw new FormatException($"Expected line to start with \"{prefix}\". Got: \"{line}\"");
        }
    }
}