namespace Solution;

public class CargoMap
{
    public List<Stack<char>> Stacks { get; } = new();
    public IEnumerable<char> TopMostCrates => Stacks.Select(stack => stack.Peek());

    public CargoMap(string representation)
    {
        var lines = representation.Split('\n');
        var lastLine = lines.Last().Trim();
        var lastLineNumbers = lastLine.Split(' ');
        var count = int.Parse(lastLineNumbers.Last());

        for (var i = 0; i < count; ++i)
        {
            Stacks.Add(new Stack<char>());
        }

        const int startIndex = 1;
        const int gapBetweenCharacters = 4;
        foreach (var line in lines[..^1].Reverse())
        {
            for (var col = 0; col < count; ++col)
            {
                var index = startIndex + col * gapBetweenCharacters;
                var character = line[index];
                if (character != ' ')
                {
                    Stacks[col].Push(character);
                }
            }
        }
    }

    public void MovePartOne(int count, int from, int to)
    {
        // Subtract 1 from "from" and "to", because the problem uses a 1-based index system, but we use a 0-based index system.
        var startIndex = from - 1;
        var endIndex = to - 1;

        for (var i = 0; i < count; ++i)
        {
            var crate = Stacks[startIndex].Pop();
            Stacks[endIndex].Push(crate);
        }
    }
}