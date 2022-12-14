namespace Tests;

public class SolverTests
{
    [Fact]
    public void SolveForPartOne_ReturnsCorrectUnitOfSandCount_GivenAdventOfCodeExampleInput()
    {
        // Arrange
        const string input = "498,4 -> 498,6 -> 496,6\n" +
                             "503,4 -> 502,4 -> 502,9 -> 494,9\n";
        const int expectedUnitsOfSand = 24;
        
        var parser = new StoneParser();
        var solver = new Solver(parser);

        // Act
        var result = solver.SolveForPartOne(input);

        // Assert
        result.Should().Be(expectedUnitsOfSand);
    }

    [Fact]
    public void SolveForPartTwo_ReturnsCorrectUnitOfSandCount_GivenAdventOfCodeExampleInput()
    {
        // Arrange
        const string input = "498,4 -> 498,6 -> 496,6\n" +
                             "503,4 -> 502,4 -> 502,9 -> 494,9\n";
        const int expectedUnitsOfSand = 93;
        
        var parser = new StoneParser();
        var solver = new Solver(parser);

        // Act
        var result = solver.SolveForPartTwo(input);

        // Assert
        result.Should().Be(expectedUnitsOfSand);
    }
}