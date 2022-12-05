namespace Solution;

public class InputParser
{
    public readonly string CargoMapRepresentation;
    public readonly string Instructions;
    
    public InputParser(string input)
    {
        var segments = input.Split("\n\n");
        if (segments.Length != 2)
        {
            throw new FormatException($"Invalid input. Expected map and instructions to be divided by an empty line. Got {input}");
        }

        CargoMapRepresentation = segments[0];
        Instructions = segments[1];
    }
}