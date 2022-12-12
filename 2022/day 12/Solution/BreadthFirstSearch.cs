namespace Solution;

public static class BreadthFirstSearch
{
    public static List<Cell> Search(HeightMap map)
    {
        var frontier = new Queue<Cell>();
        frontier.Enqueue(map.Start);

        var cameFrom = new Dictionary<Cell, Cell?>
        {
            [map.Start] = null
        };

        while (frontier.Count > 0)
        {
            var current = frontier.Dequeue();
            foreach (var next in map.GetNeighbors(current))
            {
                if (!cameFrom.ContainsKey(next))
                {
                    frontier.Enqueue(next);
                    cameFrom[next] = current;
                }
            }
        }

        return BuildPath(map, cameFrom);
    }

    private static List<Cell> BuildPath(HeightMap map, IReadOnlyDictionary<Cell, Cell?> cameFrom)
    {
        var pathCell = map.End;
        var path = new List<Cell>();
        
        while (pathCell != map.Start)
        {
            path.Add(pathCell);
            pathCell = cameFrom[pathCell];
        }
        path.Reverse();

        return path;
    }
}