namespace Tests;

public class SolverTests
{
    [Fact]
    public void SolveForDayOne_ReturnsExpectedPositions_GivenAdventOfCodeExampleInput()
    {
        // Arrange
        const string input = "R 4\n" +
                             "U 4\n" +
                             "L 3\n" +
                             "D 1\n" +
                             "R 4\n" +
                             "D 1\n" +
                             "L 5\n" +
                             "R 2\n";
        const int expectedPositions = 13;
        
        var parser = new MotionParser();
        var rope = new Rope();
        var solver = new Solver(parser, rope);

        // Act
        var result = solver.SolveForPartOne(input);

        // Assert
        result.Should().Be(expectedPositions);
    }
}