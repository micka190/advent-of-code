namespace Tests;

public class InstructionReaderTests
{
    [Fact]
    public void ReadInstructions_ReturnsAnEnumerableOfInstructions_WhenGivenValidInput()
    {
        // Arrange
        const string instructions = "move 3 from 1 to 4\n" +
                                    "move 2 from 2 to 5\n" +
                                    "move 1 from 3 to 6\n";
        var reader = new InstructionReader(instructions);

        // Act
        var results = reader.ReadInstructions();

        // Assert
        results.Should().BeEquivalentTo(new List<Instruction>
        {
            new(3, 1, 4),
            new(2, 2, 5),
            new(1, 3, 6),
        });
    }
}