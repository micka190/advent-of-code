namespace Tests;

public class GraphDistanceMapperTests
{
    [Fact]
    public void MapDistanceBetweenValueNodes_ComputesTheDistancesBetweenNodesWithValuesInGraph_GivenGraph()
    {
        // Arrange
        var a = new Node("a", 0);
        var b = new Node("b", 10);
        var c = new Node("c", 0);
        var d = new Node("d", 4);

        a.Connect(new []{b, c});
        b.Connect(c);
        c.Connect(d);

        var graph = new Graph(new List<Node> { a, b, c, d }, a);
        var mapper = new GraphDistanceMapper();

        // Act
        mapper.MapDistanceBetweenValueNodes(graph);

        // Assert
        
        // Immediate neighbors
        mapper.GetDistance(a, b).Should().Be(1);
        
        // Further away
        mapper.GetDistance(a, d).Should().Be(2); // "a" -> "c" -> "d"
        mapper.GetDistance(b, d).Should().Be(2); // "b" -> "c" -> "d"
        mapper.GetDistance(d, b).Should().Be(2); // Same as above but in reverse argument order.
    }
}