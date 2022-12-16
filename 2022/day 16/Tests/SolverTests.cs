namespace Tests;

public class SolverTests
{
    [Fact]
    public void SolveForPartOne_ReturnsCorrectAnswer_GivenAdventOfCodeExampleInput()
    {
        // Arrange
        const string input = "Valve AA has flow rate=0; tunnels lead to valves DD, II, BB\n" +
                             "Valve BB has flow rate=13; tunnels lead to valves CC, AA\n" +
                             "Valve CC has flow rate=2; tunnels lead to valves DD, BB\n" +
                             "Valve DD has flow rate=20; tunnels lead to valves CC, AA, EE\n" +
                             "Valve EE has flow rate=3; tunnels lead to valves FF, DD\n" +
                             "Valve FF has flow rate=0; tunnels lead to valves EE, GG\n" +
                             "Valve GG has flow rate=0; tunnels lead to valves FF, HH\n" +
                             "Valve HH has flow rate=22; tunnel leads to valve GG\n" +
                             "Valve II has flow rate=0; tunnels lead to valves AA, JJ\n" +
                             "Valve JJ has flow rate=21; tunnel leads to valve II\n";
        const int expectedAnswer = 1651;

        var parser = new InputParser();
        var distanceMapper = new GraphDistanceMapper();
        var solver = new Solver(parser, distanceMapper);

        // Act
        var result = solver.SolveForPartOne(input);

        // Assert
        result.Should().Be(expectedAnswer);
    }
}