using System.Drawing;

namespace Solution;

public class Solver
{
    private readonly StoneParser _parser;

    public Solver(StoneParser parser) => _parser = parser;

    public int SolveForPartOne(string input)
    {
        var parseResults = _parser.Parse(input);
        var cave = new CaveSlice(parseResults.Width, parseResults.Height, parseResults.Paths);

        var counter = 0;
        var result = SandResult.Stopped;
        while (result is SandResult.Stopped)
        {
            result = cave.SimulateGrainOfSand();
            if (result is SandResult.Stopped)
            {
                ++counter;
            }
        }

        return counter;
    }

    public int SolveForPartTwo(string input)
    {
        const int floorOffset = 2;
        
        var (paths, width, height) = _parser.Parse(input);

        height += floorOffset;

        var padding = width;
        
        paths.Add(new List<Point>
        {
            new (0, height - 1),
            new (width + padding - 1, height - 1),
        });

        var cave = new CaveSlice(width, height, paths, padding);

        var counter = 0;
        var result = SandResult.Stopped;
        while (result is SandResult.Stopped)
        {
            result = cave.SimulateGrainOfSand();
            if (result is SandResult.Stopped or SandResult.SourceBlocked)
            {
                ++counter;
            }
            // For debugging Advent of Code Part 2 example output with padding.
            // var visualization = cave.VisualizeChunk(new Point(488 + padding, 0), new Point(512 + padding, 11));
        }


        return counter;
    }
}