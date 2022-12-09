namespace Tests;

public class MotionParserTests
{
    [Fact]
    public void Parse_ReturnsListOfMotions_GivenAdventOfCodeExampleInput()
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

        var expectedMotions = new List<Motion>
        {
            new(Direction.Right, 4),
            new(Direction.Up, 4),
            new(Direction.Left, 3),
            new(Direction.Down, 1),
            new(Direction.Right, 4),
            new(Direction.Down, 1),
            new(Direction.Left, 5),
            new(Direction.Right, 2),
        };

        var parser = new MotionParser();

        // Act
        var result = parser.Parse(input);

        // Assert
        result.Should().BeEquivalentTo(expectedMotions);
    }
}