namespace Tests;

public class RopeTests
{
    [Fact]
    public void PerformMotion_UpdatesTailPositions_GivenAdventOfCodeExampleInput()
    {
        // Arrange
        var input = new List<Motion>
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
        const int expectedPositions = 13;

        var rope = new Rope();

        // Act
        foreach (var motion in input)
        {
            rope.PerformMotion(motion);
        }

        // Assert
        rope.UniqueTailPositions.Count.Should().Be(expectedPositions);
    }
}