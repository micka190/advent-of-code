namespace Tests;

public class SolverTests
{
    [Fact]
    public void Solver_ReturnsLargestAmountOfCalories_FromInputString()
    {
        // Arrange
        const string input = $"1000\n2000\n3000\n\n4000\n\n5000\n6000\n\n7000\n8000\n9000\n\n10000";
        var solver = new Solver();

        // Act
        var result = solver.SolveFor(input);

        // Assert
        result.Max.Should().Be(24000);
        result.ElfIndex.Should().Be(3);
    }
}