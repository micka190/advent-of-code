namespace Tests;

public class SolverTests
{
    [Fact]
    public void SolveForPartOne_ReturnsExpectedPositions_GivenAdventOfCodeExampleInput()
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
        var solver = new Solver(parser);

        // Act
        var result = solver.SolveForPartOne(input);

        // Assert
        result.Should().Be(expectedPositions);
    }

    [Fact]
    public void SolveForPartTwo_ReturnsExpectedPositions_GivenAdventOfCodeExampleInput()
    {
        // Arrange
        const string input = "R 5\n" +
                             "U 8\n" +
                             "L 8\n" +
                             "D 3\n" +
                             "R 17\n" +
                             "D 10\n" +
                             "L 25\n" +
                             "U 20\n";
        const int expectedPositions = 36;
        
        var parser = new MotionParser();
        var solver = new Solver(parser);

        // Act
        var result = solver.SolveForPartTwo(input);

        // Assert
        result.Should().Be(expectedPositions);
    }
}