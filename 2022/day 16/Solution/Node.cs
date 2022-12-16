namespace Solution;

public class Node
{
    public readonly string Id;
    public readonly int Value;
    public readonly HashSet<Node> Neighbors = new();

    public Node(string id, int value)
    {
        Id = id;
        Value = value;
    }
    
    public void Connect(Node neighbor)
    {
        Neighbors.Add(neighbor);
        neighbor.Neighbors.Add(this);
    }

    public void Connect(IEnumerable<Node> nodes)
    {
        foreach (var node in nodes)
        {
            Connect(node);
        }
    }
    
    private bool Equals(Node other) => Id == other.Id;

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Node)obj);
    }

    public override int GetHashCode() => Id.GetHashCode();

    public static bool operator ==(Node? left, Node? right) => Equals(left, right);
    public static bool operator !=(Node? left, Node? right) => !Equals(left, right);
}