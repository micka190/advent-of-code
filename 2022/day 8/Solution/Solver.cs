namespace Solution;

public class Solver
{
    private readonly GridParser _parser;
    public Solver(GridParser parser) => _parser = parser;

    public int SolveForPartOne(string input)
    {
        var inputGrid = _parser.Parse(input);
        var grid = new TreeGrid(inputGrid);
        return grid.GetVisibleTrees();
    }
}