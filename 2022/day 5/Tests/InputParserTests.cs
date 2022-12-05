namespace Tests;

public class InputParserTests
{
    [Fact]
    public void Constructor_SplitsInputIntoMapAndInstructions_WhenGivenValidInput()
    {
        // Arrange
        const string cargoMap = "[a] [b] [c]\n 1   2   3";
        const string instructions = "move 1 from 1 to 2\nmove 2 from 2 to 3\n";
        const string input = $"{cargoMap}\n\n{instructions}";

        // Act
        var parser = new InputParser(input);

        // Assert
        parser.CargoMap.Should().Be(cargoMap);
        parser.Instructions.Should().Be(instructions);
    }
}