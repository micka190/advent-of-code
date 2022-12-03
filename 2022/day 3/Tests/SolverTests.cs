namespace Tests;

public class SolverTests
{
    [Fact]
    public void SolveForPartOne_ReturnsCorrectSum_ForAdventOfCodeWebsiteDemo()
    {
        // Arrange
        const string input = "vJrwpWtwJgWrhcsFMMfFFhFp\njqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL\nPmmdzqPrVvPwwTWBwg\nwMqvLMZHhHMvwLHjbvcjnnSBnvTQFn\nttgJtRGJQctTZtZT\nCrZsJsPPZsGzwwsLwLmpwMDw\n";
        const int expectedSum = 157;

        // Act
        var result = Solver.SolveForPartOne(input);

        // Assert
        result.Should().Be(expectedSum);
    }

    [Theory]
    [InlineData("aa\naa\naa", 3)] // a = 1, *3, total: 3
    [InlineData("abbc\nXX\n", 52)] // b = 2, X = 50, total: 52
    [InlineData("CC\nBcqefeabgp\nabcd123a", 35)] // C = 29, e = 5, a = 1, total: 35
    public void SolveForPartOne_ReturnsExpectedSum_ForGivenInput(string input, int expectedSum)
    {
        // Arrange
        // ...

        // Act
        var result = Solver.SolveForPartOne(input);

        // Assert
        result.Should().Be(expectedSum);
    }

    [Fact]
    public void SolveForPartTwo_ReturnsCorrectSum_ForAdventOfCodeWebsiteDemo()
    {
        // Arrange
        const string input = "vJrwpWtwJgWrhcsFMMfFFhFp\njqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL\nPmmdzqPrVvPwwTWBwg\nwMqvLMZHhHMvwLHjbvcjnnSBnvTQFn\nttgJtRGJQctTZtZT\nCrZsJsPPZsGzwwsLwLmpwMDw\n";
        const int expectedSum = 70;

        // Act
        var result = Solver.SolveForPartTwo(input);

        // Assert
        result.Should().Be(expectedSum);
    }
}