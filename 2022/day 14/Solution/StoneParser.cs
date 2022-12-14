using System.Drawing;

namespace Solution;

public class StoneParser
{
    public List<List<Point>> Parse(string input) =>
        string.IsNullOrEmpty(input)
            ? new List<List<Point>>()
            : input
                .Trim()
                .Split('\n')
                .Select(ParseLine)
                .ToList();

    private static List<Point> ParseLine(string line) =>
        line
            .Split(" -> ")
            .Select(ParseCoordinate)
            .ToList();

    private static Point ParseCoordinate(string coordinate)
    {
        var segments = coordinate.Split(',');
        if (segments.Length != 2)
        {
            throw new FormatException($"Expected two numbers separated by a comma. Got: \"{coordinate}\"");
        }

        return new Point(int.Parse(segments[0]), int.Parse(segments[1]));
    }
}