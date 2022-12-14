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
}