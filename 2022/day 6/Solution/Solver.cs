namespace Solution;

public class Solver
{
    public int SolveForPartOne(string input)
    {
        const int chunkSize = 4;
        var parser = new SignalParser();
        return parser.FindStart(input, chunkSize);
    }
}