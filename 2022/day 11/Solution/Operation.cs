namespace Solution;

public class Operation
{
    public string Left { get; }
    public string Right { get; }
    public string Operator { get; }

    public Operation(string input)
    {
        var segments = input.Split(' ');

        if (segments.Length != 3)
        {
            throw new FormatException("Invalid operation input format.");
        }

        if (segments[1] is not "*" and not "+")
        {
            throw new ArgumentException(
                $"Invalid operator found in input string. Expected \"+\" or \"*\". Got \"{segments[1]}\".",
                nameof(input)
            );
        }

        if (segments[0] != "old" && !int.TryParse(segments[0], out _))
        {
            throw new ArgumentException($"Invalid left value in input string. Expected \"old\" or integer. Got \"{segments[0]}\"");
        }
        
        if (segments[2] != "old" && !int.TryParse(segments[2], out _))
        {
            throw new ArgumentException($"Invalid right value in input string. Expected \"old\" or integer. Got \"{segments[0]}\"");
        }

        Left = segments[0];
        Operator = segments[1];
        Right = segments[2];
    }

    public long Perform(long itemWorryLevel)
    {
        var left = Left == "old" ? itemWorryLevel : long.Parse(Left);
        var right = Right == "old" ? itemWorryLevel : long.Parse(Right);
        return Operator switch
        {
            "*" => left * right,
            "+" => left + right,
            _ => throw new ArgumentOutOfRangeException(Operator, "Unsupported operator")
        };
    }
}