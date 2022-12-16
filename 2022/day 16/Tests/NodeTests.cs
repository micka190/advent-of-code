namespace Tests;

public class NodeTests
{
    [Fact]
    public void Connect_MakesBothNodesNeighbor_GivenTwoNodes()
    {
        // Arrange
        var a = new Node("a", 0);
        var b = new Node("b", 0);

        // Act
        a.Connect(b);

        // Assert
        a.Neighbors.Should().Contain(b);
        b.Neighbors.Should().Contain(a);
    }

    [Fact]
    public void Connect_MakesAllNodesNeighborsOfTheTarget_GivenMultipleNodes()
    {
        // Arrange
        var a = new Node("a", 0);
        var b = new Node("b", 0);
        var c = new Node("c", 0);
        var d = new Node("d", 0);

        // Act
        a.Connect(new []{b, c, d});

        // Assert
        a.Neighbors.Should().BeEquivalentTo(new []{b, c, d});
        b.Neighbors.Should().OnlyContain(node => node == a);
        c.Neighbors.Should().OnlyContain(node => node == a);
        d.Neighbors.Should().OnlyContain(node => node == a);
    }
}