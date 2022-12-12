namespace Tests;

public class HeightMapTests
{
    [Fact]
    public void Constructor_BuildsGrid_FromMapRepresentation()
    {
        // Arrange
        const string representation = "aaaaa\n" +
                                      "bbbbb\n" +
                                      "ccccc\n";

        // Act
        var map = new HeightMap(representation);

        // Assert
        map.Rows.Should().Be(3);
        map.Columns.Should().Be(5);

        map.Grid.Should().BeEquivalentTo(new[,]
        {
            { new Cell(0, 0, 'a'), new Cell(1, 0, 'a'), new Cell(2, 0, 'a'), new Cell(3, 0, 'a'), new Cell(4, 0, 'a'), },
            { new Cell(0, 1, 'b'), new Cell(1, 1, 'b'), new Cell(2, 1, 'b'), new Cell(3, 1, 'b'), new Cell(4, 1, 'b'), },
            { new Cell(0, 2, 'c'), new Cell(1, 2, 'c'), new Cell(2, 2, 'c'), new Cell(3, 2, 'c'), new Cell(4, 2, 'c'), },
        });
    }

    [Theory]
    [InlineData(0, 0, 2)] // Top left
    [InlineData(1, 0, 3)] // Top middle
    [InlineData(2, 0, 2)] // Top right
    [InlineData(0, 1, 3)] // Center left
    [InlineData(1, 1, 4)] // Center middle
    [InlineData(2, 1, 3)] // Center right
    [InlineData(0, 2, 2)] // Bottom left
    [InlineData(1, 2, 3)] // Bottom middle
    [InlineData(2, 2, 2)] // Bottom right
    public void GetNeighbors_DoesNotGoOutOfBounds_GivenCoordinate(int x, int y, int expectedNumberOfNeighbors)
    {
        // Arrange
        const string representation = "aaa\n" +
                                      "aaa\n" +
                                      "aaa\n";
        var map = new HeightMap(representation);

        // Act
        var neighbors = map.GetNeighbors(map[x, y]);

        // Assert
        neighbors.Should().HaveCount(expectedNumberOfNeighbors);
    }

    [Fact]
    public void GetNeighbors_OnlyReturnsNeighborsWithValidValues_GivenCoordinate()
    {
        // Arrange
        const string representation = "abaa\n" +
                                      "Scda\n" +
                                      "Ezaa\n";
        var map = new HeightMap(representation);

        // Act
        var topLeftNeighbors = map.GetNeighbors(map[0, 0]); // Neighbors are Starting or greater by 1.
        var topMiddleNeighbors = map.GetNeighbors(map[1, 0]); // Neighbors are all smaller by 1 or greater by 1.
        var centerNeighbors = map.GetNeighbors(map[1, 1]); // Neighbors are all smaller, Starting, or greater by 1.
        var centerLeft = map.GetNeighbors(map[0, 1]); // Neighbors are smaller. Ending is not a valid neighbor or Starting.
        var bottomLeftZ = map.GetNeighbors(map[1, 2]); // Neihgbors are smaller or Ending.
        

        // Assert
        topLeftNeighbors.Should().BeEquivalentTo(new List<Cell>
        {
            new(1, 0, 'b'), 
            new(0, 1, 'S')
        });
        
        topMiddleNeighbors.Should().BeEquivalentTo(new List<Cell>
        {
            new(0, 0, 'a'),
            new(2, 0, 'a'),
            new(1, 1, 'c'),
        });
        
        centerNeighbors.Should().BeEquivalentTo(new List<Cell>
        {
            new(1, 0, 'b'),
            new(0, 1, 'S'),
            new(2, 1, 'd'),
        });
        
        centerLeft.Should().BeEquivalentTo(new List<Cell>
        {
            new(0, 0, 'a'),
        });
        
        bottomLeftZ.Should().BeEquivalentTo(new List<Cell>
        {
            new(0, 2, 'E'),
            new(2, 2, 'a'),
            new(1, 1, 'c'),
        });
    }
}