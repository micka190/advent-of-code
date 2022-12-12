namespace Solution;

public class Solver
{
    public int SolveForPartOne(string input)
    {
        var map = new HeightMap(input);
        var path = BreadthFirstSearch.Search(map);
        return path.Count;
    }
}