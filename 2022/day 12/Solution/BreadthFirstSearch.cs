namespace Solution;

public static class BreadthFirstSearch
{
    public static List<Cell> Search(HeightMap map, Cell start, Cell end)
    {
        var frontier = new Queue<Cell>();
        frontier.Enqueue(start);

        var cameFrom = new Dictionary<Cell, Cell?>
        {
            [start] = null
        };

        while (frontier.Count > 0)
        {
            var current = frontier.Dequeue();

            if (current == end)
            {
                break;
            }
            
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
            
            // cameFrom[map.Start] is the only null value. Since we can't access it in this loop, we can suppress null here. 
            pathCell = cameFrom[pathCell]!; 
        }
        path.Reverse();

        return path;
    }
}