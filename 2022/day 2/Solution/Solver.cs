namespace Solution;

public static class Solver
{
    public static readonly Dictionary<Hand, int> HandScores = new()
    {
        {Hand.Rock, 1},
        {Hand.Paper, 2},
        {Hand.Scissors, 3},
    };
    
    public static readonly Dictionary<Outcome, int> OutcomeScores = new()
    {
        { Outcome.Win, 6},
        { Outcome.Lose, 0},
        { Outcome.Draw, 3},
    };

    public static int SolveFor(string input)
    {
        return 0;
    }
}