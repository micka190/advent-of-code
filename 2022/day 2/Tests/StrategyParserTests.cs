namespace Tests;

public class StrategyParserTests
{
    [Theory]
    [InlineData("A X", Hand.Rock, Hand.Rock)]
    [InlineData("B Y", Hand.Paper, Hand.Paper)]
    [InlineData("C Z", Hand.Scissors, Hand.Scissors)]
    public void ParseLine_ReturnsTupleOfHands_GivenValidInput(string input, Hand expectedLeft, Hand expectedRight)
    {
        // Arrange
        // ...

        // Act
        var (left, right) = StrategyParser.ParseLine(input);

        // Assert
        left.Should().Be(expectedLeft);
        right.Should().Be(expectedRight);
    }

    [Fact]
    public void ParseLine_ThrowsArgumentException_WhenGivenInvalidInput()
    {
        // Arrange
        const string invalidInput = "A B ERROR\n ";

        // Act
        var act = () => StrategyParser.ParseLine(invalidInput);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData("_ A", "Left character is unsupported.")]
    [InlineData("A _", "Right character is unsupported.")]
    public void ParseLine_ThrowsArgumentOutOfRangeException_WhenGivenLettersItDoesNotKnow(string input, string errorMessage)
    {
        // Arrange
        var wildcardMessagePattern = $"*{errorMessage}*";

        // Act
        var act = () => StrategyParser.ParseLine(input);

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>().WithMessage(wildcardMessagePattern);
    }
}