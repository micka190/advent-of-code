namespace Solution;

public class Node
{
    public string Id { get; set; } = string.Empty;
    public int Value { get; set; }
    public readonly List<Node> Neighbors = new();
}