namespace Solution;

public class Graph
{
    public readonly List<Node> Nodes;
    public Node StartingNode { get; set; }

    public Graph(IEnumerable<Node> nodes, Node startingNode)
    {
        StartingNode = startingNode;
        Nodes = new List<Node>(nodes);
    }

    public void Prune()
    {
        var leaves = FindEmptyLeaves();
        while (leaves.Count > 0)
        {
            foreach (var leaf in leaves)
            {
                // Leaves only have 1 neighbor.
                leaf.Neighbors.First().Neighbors.Remove(leaf);
                Nodes.Remove(leaf);
            }

            leaves = FindEmptyLeaves();
        }
    }

    private List<Node> FindEmptyLeaves() => Nodes.Where(node => node is { Value: 0, Neighbors.Count: 1 } && node != StartingNode).ToList();
}