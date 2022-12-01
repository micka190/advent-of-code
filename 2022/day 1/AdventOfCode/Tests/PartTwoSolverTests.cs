namespace Tests;

public class PartTwoSolverTests
{
    [Fact]
    public void PartTwoSolver_SolvesExample_FromAdventOfCodeWebsite()
    {
        // Arrange
        const string input = "1000\n2000\n3000\n\n4000\n\n5000\n6000\n\n7000\n8000\n9000\n\n10000";

        // Act
        var result = PartTwoSolver.SolveFor(input);

        // Assert
        result.Should().Be(45000);
    }
    
    [Theory]
    [InlineData("1\n2\n3\n\n4\n5\n6\n\n7\n8\n\n9\n10", 49)]
    [InlineData("10\n10\n10\n\n1\n2\n3", 36)]
    [InlineData("5\n\n10\n1\n1\n\n1\n2\n3", 23)]
    public void PartTwoSolver_Solves_ForAnyValidInput(string input, int expectedSum)
    {
        // Arrange
        // ...

        // Act
        var result = PartTwoSolver.SolveFor(input);

        // Assert
        result.Should().Be(expectedSum);
    }
    
    [Fact]
    public void PartTwoSolver_ReturnsZero_IfGivenAnEmptyInput()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = PartTwoSolver.SolveFor(input);

        // Assert
        result.Should().Be(0);
    }
    
    [Fact]
    public void PartTwoSolver_Works_WithEmptyLastLine()
    {
        // Arrange
        const string input = "1000\n2000\n3000\n\n4000\n\n5000\n6000\n\n7000\n8000\n9000\n\n10000\n";;

        // Act
        var result = PartTwoSolver.SolveFor(input);

        // Assert
        result.Should().Be(45000);
    }
}