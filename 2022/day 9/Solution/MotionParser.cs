namespace Solution;

public class MotionParser
{
    private readonly Dictionary<string, Direction> _directions = new()
    {
        {"U", Direction.Up},
        {"D", Direction.Down},
        {"L", Direction.Left},
        {"R", Direction.Right},
    };

    public IEnumerable<Motion> Parse(string input) =>
        string.IsNullOrEmpty(input)
            ? new List<Motion>()
            : input
                .Trim()
                .Split('\n')
                .Select(ParseLine)
                .ToList();

    private Motion ParseLine(string line)
    {
        var segments = line.Split(' ');

        if (segments.Length != 2)
        {
            throw new FormatException($"Expected direction character and number of steps separated by space. Got: \"{line}\"");
        }

        var direction = _directions[segments[0]];
        var steps = int.Parse(segments[1]);
        
        return new Motion(direction, steps);
    }
}