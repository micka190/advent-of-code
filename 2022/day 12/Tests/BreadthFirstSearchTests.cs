namespace Tests;

public class BreadthFirstSearchTests
{
    [Fact]
    public void Search_ReturnsExpectedPathCount_GivenAdventOfCodeExampleInput()
    {
        // Arrange
        const string representation = "Sabqponm\n" +
            "abcryxxl\n" +
            "accszExk\n" +
            "acctuvwj\n" +
            "abdefghi\n";
        const int expectedSteps = 31;
        var map = new HeightMap(representation);

        // Act
        var path = BreadthFirstSearch.Search(map);

        // Assert
        path.Should().HaveCount(expectedSteps);
    }
}