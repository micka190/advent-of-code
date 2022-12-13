namespace Tests;

public class SolverTests
{
    [Fact]
    public void SolveForPartOne_ReturnsCorrectAnswer_GivenAdventOfCodeExampleInput()
    {
        // Arrange
        const string input = "[1,1,3,1,1]\n" +
                "[1,1,5,1,1]\n" +
                "\n" +
                "[[1],[2,3,4]]\n" +
                "[[1],4]\n" +
                "\n" +
                "[9]\n" +
                "[[8,7,6]]\n" +
                "\n" +
                "[[4,4],4,4]\n" +
                "[[4,4],4,4,4]\n" +
                "\n" +
                "[7,7,7,7]\n" +
                "[7,7,7]\n" +
                "\n" +
                "[]\n" +
                "[3]\n" +
                "\n" +
                "[[[]]]\n" +
                "[[]]\n" +
                "\n" +
                "[1,[2,[3,[4,[5,6,7]]]],8,9]\n" +
                "[1,[2,[3,[4,[5,6,0]]]],8,9]\n";

        const int expectedSumOfPairs = 13;

        var solver = new Solver();

        // Act
        var result = solver.SolveForPartOne(input);

        // Assert
        result.Should().Be(expectedSumOfPairs);
    }
}