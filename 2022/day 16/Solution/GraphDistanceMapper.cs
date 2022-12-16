namespace Solution;

public class GraphDistanceMapper
{
    private readonly Dictionary<string, int> _distances = new();

    public List<Node> NodesUsed { get; private set; } = new();

    public void MapDistanceBetweenValueNodes(Graph graph)
    {
        _distances.Clear();

        NodesUsed = graph.Nodes.Where(node => node.Value > 0 || node == graph.StartingNode).ToList();

        foreach (var start in NodesUsed)
        {
            foreach (var end in NodesUsed)
            {
                if (start != end)
                {
                    var key = GetDistanceKey(start, end);
                    if (!_distances.ContainsKey(key))
                    {
                        _distances[key] = ComputeDistance(start, end);
                    }
                }
            }
        }
    }

    private int ComputeDistance(Node start, Node end)
    {
        var frontier = new Queue<Node>();
        frontier.Enqueue(start);

        var cameFrom = new Dictionary<Node, Node?>
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

            foreach (var next in current.Neighbors)
            {
                if (!cameFrom.ContainsKey(next))
                {
                    frontier.Enqueue(next);
                    cameFrom[next] = current;
                }
            }
        }

        var steps = 0;

        var pathNode = end;
        while (pathNode != start)
        {
            ++steps;
            pathNode = cameFrom[pathNode]!;
        }
        
        return steps;
    }

    public int GetDistance(Node a, Node b)
    {
        var key = GetDistanceKey(a, b);

        if (_distances.ContainsKey(key))
        {
            return _distances[key];
        }

        throw new KeyNotFoundException(
            $"Distance between Nodes ({a.Id} and {b.Id}) was not found in mapper. Make sure to call Map() method first."
            );
    }

    private static string GetDistanceKey(Node a, Node b) =>
        string.Compare(a.Id, b.Id, StringComparison.Ordinal) == -1
            ? $"{a.Id}-{b.Id}"
            : $"{b.Id}-{a.Id}";
}