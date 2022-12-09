namespace Solution;

public class Solver
{
    private readonly MotionParser _parser;
    private readonly Rope _rope;

    public Solver(MotionParser parser, Rope rope)
    {
        _parser = parser;
        _rope = rope;
    }

    public int SolveForPartOne(string input)
    {
        var motions = _parser.Parse(input);
        foreach (var motion in motions)
        {
            _rope.PerformMotion(motion);
        }

        return _rope.UniqueTailPositions.Count;
    }
}