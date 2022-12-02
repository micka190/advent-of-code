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

    public static readonly Dictionary<string, Outcome> Outcomes = new()
    {
        { "X", Outcome.Lose },
        { "Y", Outcome.Draw },
        { "Z", Outcome.Win },
    };

    public static (Hand Left, Hand Right) ParseLineAsHandAndHand(string input)
    {
        var tokens = GetTokens(input);
        ValidateTokens(tokens, Hands);
        
        return (Left: Hands[tokens[0]], Right: Hands[tokens[1]]);
    }

    public static (Hand Left, Outcome Right) ParseLineAsHandAndOutcome(string input)
    {
        var tokens = GetTokens(input);
        ValidateTokens(tokens, Outcomes);
        
        return (Left: Hands[tokens[0]], Right: Outcomes[tokens[1]]);
    }

    private static string[] GetTokens(string input)
    {
        var tokens = input.Trim().Split(" ");
        
        if (tokens.Length != 2)
        {
            throw new ArgumentException(
                $"Invalid input provided to strategy parser. Expected 2 letters with a space between. Got \"{input}\"."
            );
        }

        return tokens;
    }

    private static void ValidateTokens<T>(string[] tokens, IReadOnlyDictionary<string, T> rightSideDictionary)
    {
        // Left is always supposed to be a Hands key.
        if (!Hands.ContainsKey(tokens[0]))
        {
            throw new ArgumentOutOfRangeException(nameof(tokens), "Left character is unsupported.");
        }
        
        // Right might be a Hands key or an Outcomes key.
        if (!rightSideDictionary.ContainsKey(tokens[1]))
        {
            throw new ArgumentOutOfRangeException(nameof(tokens), "Right character is unsupported.");
        }
    }
}