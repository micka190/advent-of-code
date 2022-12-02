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
    
    [InlineData("C X", 1 + 6)] // Rock: 1, Win: 6
    [InlineData("A Y", 2 + 6)] // Paper: 2, Win: 6
    [InlineData("B Z", 3 + 6)] // Scissors: 3, Win: 6
    
    [InlineData("B X", 1)] // Rock: 1, Lose: 0
    [InlineData("C Y", 2)] // Paper: 2, Lose: 0
    [InlineData("A Z", 3)] // Scissors: 3, Lose: 0
    public void SolveFor_ReturnsExpectedScore_WhenGivenRoundInput(string input, int expectedScore)
    {
        // Arrange
        // ...

        // Act
        var result = Solver.SolveFor(input);

        // Assert
        result.Should().Be(expectedScore);
    }

    [Fact]
    public void SolveFor_ReturnsExpectedScore_WhenGivenMultilineInput()
    {
        // Arrange
        const string input = "A Y\nB X\nB X\nC Y\nB X\nA Z\nB X\nB X\nC Z\nA Z\n";
        const int expectedScore = 27;

        // Act
        var result = Solver.SolveFor(input);

        // Assert
        result.Should().Be(expectedScore);
    }

}