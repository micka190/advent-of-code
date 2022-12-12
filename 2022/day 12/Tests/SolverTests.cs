namespace Tests;

public class SolverTests
{
    [Fact]
    public void SolveForPartOne_ReturnsExpectedAnswer_GivenAdventOfCodeExampleInput()
    {
        // Arrange
        const string input = "Sabqponm\n" +
                             "abcryxxl\n" +
                             "accszExk\n" +
                             "acctuvwj\n" +
                             "abdefghi\n";
        const int expectedSteps = 31;
        var solver = new Solver();

        // Act
        var steps = solver.SolveForPartOne(input);

        // Assert
        steps.Should().Be(expectedSteps);
    }
}