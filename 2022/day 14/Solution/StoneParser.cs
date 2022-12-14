using System.Drawing;

namespace Solution;

public class StoneParser
{
    private int _minX;
    private int _minY;
    private int _maxX;
    private int _maxY;
    
    public ParserResult Parse(string input)
    {
        _minX = 0;
        _minY = 0;
        _maxX = 0;
        _maxY = 0;
        
        var paths = string.IsNullOrEmpty(input)
            ? new List<List<Point>>()
            : input
                .Trim()
                .Split('\n')
                .Select(ParseLine)
                .ToList();

        return new ParserResult(paths, new Point(_maxX, _maxY), new Point(_minX, _minY));
    }

    private List<Point> ParseLine(string line) =>
        line
            .Split(" -> ")
            .Select(ParseCoordinate)
            .ToList();

    private Point ParseCoordinate(string coordinateString)
    {
        var segments = coordinateString.Split(',');
        if (segments.Length != 2)
        {
            throw new FormatException($"Expected two numbers separated by a comma. Got: \"{coordinateString}\"");
        }

        var coordinate = new Point(int.Parse(segments[0]), int.Parse(segments[1]));
        
        _minX = Math.Min(_minX, coordinate.X);
        _minY = Math.Min(_minY, coordinate.Y);
        _maxX = Math.Max(_maxX, coordinate.X);
        _maxY = Math.Max(_maxY, coordinate.Y);

        return coordinate;
    }
}