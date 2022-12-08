namespace Tests;

public class GridParserTests
{
    [Fact]
    public void Parse_ReturnsCorrectGrid_GivenAdventOfCodeExampleInput()
    {
        // Arrange
        const string input = "30373\n" +
                             "25512\n" +
                             "65332\n" +
                             "33549\n" +
                             "35390\n";

        var expectedGrid = new[,]
        {
            {3, 0, 3, 7, 3},
            {2, 5, 5, 1, 2},
            {6, 5, 3, 3, 2},
            {3, 3, 5, 4, 9},
            {3, 5, 3, 9, 0}
        };

        var parser = new GridParser();

        // Act
        var results = parser.Parse(input);

        // Assert
        results.Should().BeEquivalentTo(expectedGrid);
    }
}