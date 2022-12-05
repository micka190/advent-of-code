namespace Tests;

public class CargoMapTests
{
    [Fact]
    public void Constructor_Parses_StringRepresentation()
    {
        // Arrange
        const string representation = "[x] [y] [z]\n" + 
                                      "[a] [b] [c]\n" + 
                                      " 1   2   3 ";

        // Act
        var map = new CargoMap(representation);

        // Assert
        map.Stacks.Count.Should().Be(3);
        map.TopMostCrates.Should().BeEquivalentTo(new List<char> { 'x', 'y', 'z' });
    }

    [Fact]
    public void Constructor_Parses_UnevenStringRepresentation()
    {
        // Arrange
        const string representation = "[1]        \n" +
                                      "[x]     [z]\n" +
                                      "[a] [b] [c]\n" +
                                      " 1   2   3 ";

        // Act
        var map = new CargoMap(representation);

        // Assert
        map.Stacks.Count.Should().Be(3);
        map.TopMostCrates.Should().BeEquivalentTo(new List<char> { '1', 'b', 'z' });
    }
}