namespace Tests;

public class SolverTests
{
    [Fact]
    public void SolveForPartOne_ReturnsExpectedCrates_GivenAdventOfCodeExampleInput()
    {
        // Arrange
        const string input = "    [D]    \n" +
                             "[N] [C]    \n" +
                             "[Z] [M] [P]\n" +
                             " 1   2   3 \n" +
                             "\n" +
                             "move 1 from 2 to 1\n" +
                             "move 3 from 1 to 3\n" +
                             "move 2 from 2 to 1\n" +
                             "move 1 from 1 to 2\n";

        var expectedTopMostCrates = new List<char> { 'C', 'Z', 'M' };

        // Act
        var results = Solver.SolveForPartOne(input);


        // Assert
        results.Should().BeEquivalentTo(expectedTopMostCrates);
    }
}