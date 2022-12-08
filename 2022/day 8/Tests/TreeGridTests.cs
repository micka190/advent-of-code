namespace Tests;

public class TreeGridTests
{
    [Fact]
    public void GetVisibleTrees_ReturnsCorrectNumberOfTrees_GivenAdventOfCodeExampleInput()
    {
        // Arrange
        var trees = new[,]
        {
            {3, 0, 3, 7, 3},
            {2, 5, 5, 1, 2},
            {6, 5, 3, 3, 2},
            {3, 3, 5, 4, 9},
            {3, 5, 3, 9, 0}
        };
        const int expectedNumberOfTrees = 21;
        var grid = new TreeGrid(trees);

        // Act
        var result = grid.GetVisibleTrees();

        // Assert
        result.Should().Be(expectedNumberOfTrees);
    }

    [Fact]
    public void GetHighestScenicScore_ReturnsCorrectScore_GivenAdventOfCodeExampleInput()
    {
        // Arrange
        var trees = new[,]
        {
            {3, 0, 3, 7, 3},
            {2, 5, 5, 1, 2},
            {6, 5, 3, 3, 2},
            {3, 3, 5, 4, 9},
            {3, 5, 3, 9, 0}
        };
        const int expectedScore = 8;
        var grid = new TreeGrid(trees);

        // Act
        var result = grid.GetHighestScenicScore();

        // Assert
        result.Should().Be(expectedScore);
    }
}