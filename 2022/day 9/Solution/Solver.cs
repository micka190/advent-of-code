namespace Solution;

public class Solver
{
    private readonly MotionParser _parser;

    public Solver(MotionParser parser)
    {
        _parser = parser;
    }

    public int SolveForPartOne(string input)
    {
        var rope = new Rope();
        var motions = _parser.Parse(input);
        foreach (var motion in motions)
        {
            rope.PerformMotion(motion);
        }

        return rope.UniqueTailPositions.Count;
    }
    
    public int SolveForPartTwo(string input)
    {
        const int numberOfKnots = 10;
        var rope = new Rope(numberOfKnots);
        var motions = _parser.Parse(input);
        foreach (var motion in motions)
        {
            rope.PerformMotion(motion);
        }

        return rope.UniqueTailPositions.Count;
    }
}