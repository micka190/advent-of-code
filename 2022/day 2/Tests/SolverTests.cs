namespace Tests;

public class SolverTests
{
    [Fact]
    public void SolveFor_ReturnsScore_FromAdventOfCodeWebsiteExample()
    {
        // Arrange
        const string input = "A Y\nB X\nC Z\n";
        const int expectedScore = 15;

        // Act
        var result = Solver.SolveFor(input);

        // Assert
        result.Should().Be(expectedScore);
    }
}