namespace Tests;

public class SolverTests
{
    [Fact]
    public void SolveForPartOne_ReturnsExpectedNumberOfTrees_GivenAdventOfCodeExampleInput()
    {
        // Arrange
        const string input = "30373\n" +
                             "25512\n" +
                             "65332\n" +
                             "33549\n" +
                             "35390\n";
        const int expectedNumberOfTrees = 21;
        var parser = new GridParser();
        var solver = new Solver(parser);

        // Act
        var result = solver.SolveForPartOne(input);

        // Assert
        result.Should().Be(expectedNumberOfTrees);
    }
}