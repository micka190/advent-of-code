namespace Tests;

public class OperationTests
{
    [Theory]
    [InlineData("old + old")]
    [InlineData("5 + 2")]
    [InlineData("old + 7")]
    [InlineData("5 + old")]
    [InlineData("old * old")]
    [InlineData("5 * 2")]
    [InlineData("old * 3")]
    [InlineData("7 * old")]
    public void Constructor_ProperlyParsesInputString_GivenValidString(string input)
    {
        // Arrange
        var segments = input.Split(' ');
        var left = segments[0];
        var op = segments[1];
        var right = segments[2];

        // Act
        var operation = new Operation(input);

        // Assert
        operation.Left.Should().Be(left);
        operation.Right.Should().Be(right);
        operation.Operator.Should().Be(op);
    }
    
    [Theory]
    [InlineData("old + old", 1, 2)]
    [InlineData("5 + 2", -1, 7)]
    [InlineData("old + 7", 3, 10)]
    [InlineData("5 + old", 3, 8)]
    [InlineData("old * old", 5, 25)]
    [InlineData("5 * 2", -1, 10)]
    [InlineData("old * 3", 8, 24)]
    [InlineData("7 * old", 3, 21)]
    public void Perform_ReturnsExpectedValue_GivenValidInput(string input, int itemWorryLevel, int expectedValue)
    {
        // Arrange
        var operation = new Operation(input);

        // Act
        var result = operation.Perform(itemWorryLevel);

        // Assert
        result.Should().Be(expectedValue);
    }
}