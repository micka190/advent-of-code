namespace Solution;

public class Solver
{
    public int SolveForPartOne(string input)
    {
        var map = new HeightMap(input);
        var path = BreadthFirstSearch.Search(map, map.Start, map.End);
        return path.Count;
    }

    public int SolveForPartTwo(string input)
    {
        var map = new HeightMap(input);

        var possibleStartingPoints = new List<Cell> { map.Start };

        for (var y = 0; y < map.Rows; ++y)
        {
            for (var x = 0; x < map.Columns; ++x)
            {
                var cell = map[x, y];
                if (cell.Value == 'a')
                {
                    possibleStartingPoints.Add(cell);
                }
            }
        }

        var shortestPath = possibleStartingPoints
            .Select(startingPoint => BreadthFirstSearch.Search(map, startingPoint, map.End))
            .Where(path => path.Last().Value == map.End.Value)
            .Select(path => path.Count)
            .MinBy(steps => steps);

        return shortestPath;
    }
}