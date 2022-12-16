namespace Tests;

public class GraphTests
{
    [Fact]
    public void Prune_RemovesLeavesWithNoValues_GivenNodes()
    {
        // Arrange
        var a = new Node("A", 0); // Starting Node is never pruned
        var b = new Node("B", 0); // Empty leaf
        var c = new Node("C", 0); // Not a leaf
        var d = new Node("D", 10); // Non-empty leaf
        var e = new Node("E", 10); // Becomes non-empty leaf after "F" is removed
        var f = new Node("F", 0); // Becomes empty leaf once "G" is removed
        var g = new Node("G", 0); // Empty leaf

        a.Connect(b);
        a.Connect(c);
        c.Connect(d);
        c.Connect(e);
        e.Connect(f);
        f.Connect(g);

        var nodes = new List<Node> { a, b, c, d, e, f, g };
        var graph = new Graph(nodes, a);

        // Act
        graph.Prune();

        // Assert
        graph.Nodes.Should().HaveCount(4);
        graph.Nodes.Should().BeEquivalentTo(new List<Node> { a, c, d, e });
    }
}