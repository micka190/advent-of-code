namespace Solution;

public static class StrategyParser
{
    public static readonly Dictionary<string, Hand> Hands = new()
    {
        { "A", Hand.Rock },
        { "B", Hand.Paper },
        { "C", Hand.Scissors },
        
        { "X", Hand.Rock },
        { "Y", Hand.Paper },
        { "Z", Hand.Scissors },
    };

    public static (Hand Left, Hand Right) ParseLine(string input)
    {
        var tokens = input.Trim().Split(" ");
        
        if (tokens.Length != 2)
        {
            throw new ArgumentException(
                $"Invalid input provided to strategy parser. Expected 2 letters with a space between. Got \"{input}\"."
            );
        }
        else if (!Hands.ContainsKey(tokens[0]))
        {
            throw new ArgumentOutOfRangeException(nameof(input), "Left character is unsupported.");
        }
        else if (!Hands.ContainsKey(tokens[1]))
        {
            throw new ArgumentOutOfRangeException(nameof(input), "Right character is unsupported.");
        }
        
        return (Left: Hands[tokens[0]], Right: Hands[tokens[1]]);
    }
}