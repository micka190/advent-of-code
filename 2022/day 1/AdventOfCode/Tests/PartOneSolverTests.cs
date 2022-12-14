namespace Tests;

public class PartOneSolverTests
{
    [Fact]
    public void SolveFor_ReturnsExpectedAnswer_FromAdventOfCodeWebsiteExample()
    {
        // Arrange
        const string input = "1000\n2000\n3000\n\n4000\n\n5000\n6000\n\n7000\n8000\n9000\n\n10000";

        // Act
        var result = PartOneSolver.SolveFor(input);

        // Assert
        result.Should().Be(24000);
    }

    [Theory]
    [InlineData("1\n2\n3\n\n4\n5\n6\n\n7\n8\n\n9\n10", 19)]
    [InlineData("10\n10\n10\n\n1\n2\n3", 30)]
    [InlineData("5\n\n10\n1\n1\n\n1\n2\n3", 12)]
    public void SolveFor_ReturnsExpectedValue_ForAnyValidInput(string input, int expectedMax)
    {
        // Arrange
        // ...

        // Act
        var result = PartOneSolver.SolveFor(input);

        // Assert
        result.Should().Be(expectedMax);
    }

    [Fact]
    public void SolveFor_ReturnsZero_IfGivenAnEmptyInput()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = PartOneSolver.SolveFor(input);

        // Assert
        result.Should().Be(0);
    }

    [Fact]
    public void SolveFor_ReturnsExpectedValue_WhenInputHasEmptyLastLine()
    {
        // Arrange
        const string input = "10\n\n5\n\n0\n";

        // Act
        var result = PartOneSolver.SolveFor(input);

        // Assert
        result.Should().Be(10);
    }
}