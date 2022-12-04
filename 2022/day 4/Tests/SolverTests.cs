namespace Tests;

public class SolverTests
{
    [Fact]
    public void SolveForPartOne_ReturnsNumberOfOverlappingAssignments_GivenAdventOfCodeExampleInput()
    {
        // Arrange
        const string input = "2-4,6-8\n2-3,4-5\n5-7,7-9\n2-8,3-7\n6-6,4-6\n2-6,4-8\n";
        const int expectedCount = 2;

        // Act
        var result = Solver.SolveForPartOne(input);

        // Assert
        result.Should().Be(expectedCount);
    }

    [Theory]
    [InlineData("", 0)]
    [InlineData("1-4,5-9\n0-3,5-8", 0)]
    [InlineData("0-9,0-9\n1-2,3-5\n0-6,5-6\n", 2)]
    [InlineData("3-5,3-4\n1-6,4-6\n0-9,9-10", 2)]
    public void SolveForPartOne_ReturnsExpectedNumberOfOverlappingAssignments_GivenValidInput(string input, int expectedCount)
    {
        // Arrange
        // ...

        // Act
        var result = Solver.SolveForPartOne(input);

        // Assert
        result.Should().Be(expectedCount);
    }
}