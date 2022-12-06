namespace Solution;

public class Solver
{
    public int SolveForPartOne(string input)
    {
        var parser = new SignalParser();
        return parser.FindUniqueChunk(input, SignalParser.DefaultStartChunkSize);
    }
}