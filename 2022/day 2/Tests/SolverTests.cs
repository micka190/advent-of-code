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

    [Theory]
    [InlineData("", 0)] // No  round
    [InlineData("A X", 1 + 3)] // Rock: 1, Draw: 3
    [InlineData("B Y", 2 + 3)] // Paper: 2, Draw: 3
    [InlineData("C Z", 3 + 3)] // Scissors: 3, Draw: 3
    [InlineData("A Z", 1 + 6)] // Rock: 1, Win: 6
    [InlineData("B X", 2 + 6)] // Paper: 2, Win: 6
    [InlineData("C Y", 3 + 6)] // Scissors: 3, Win: 6
    [InlineData("A Y", 1)] // Rock: 1, Lose: 0
    [InlineData("B Z", 2)] // Paper: 2, Lose: 0
    [InlineData("C X", 3)] // Scissors: 3, Lose: 0
    public void SolveFor_ReturnsExpectedScore_WhenGivenInput(string input, int expectedScore)
    {
        // Arrange
        // ...

        // Act
        var result = Solver.SolveFor(input);

        // Assert
        result.Should().Be(expectedScore);
    }
}