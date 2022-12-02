namespace Tests;

public class StrategyParserTests
{
    [Theory]
    [InlineData("A X", Hand.Rock, Hand.Rock)]
    [InlineData("B Y", Hand.Paper, Hand.Paper)]
    [InlineData("C Z", Hand.Scissors, Hand.Scissors)]
    public void ParseLiseAsHandAndHand_ReturnsTupleOfHands_GivenValidInput(string input, Hand expectedLeft, Hand expectedRight)
    {
        // Arrange
        // ...

        // Act
        var (left, right) = StrategyParser.ParseLineAsHandAndHand(input);

        // Assert
        left.Should().Be(expectedLeft);
        right.Should().Be(expectedRight);
    }

    [Fact]
    public void ParseLiseAsHandAndHand_ThrowsArgumentException_WhenGivenInvalidInput()
    {
        // Arrange
        const string invalidInput = "A B ERROR\n ";

        // Act
        var act = () => StrategyParser.ParseLineAsHandAndHand(invalidInput);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData("_ A", "Left character is unsupported.")]
    [InlineData("A _", "Right character is unsupported.")]
    public void ParseLiseAsHandAndHand_ThrowsArgumentOutOfRangeException_WhenGivenLettersItDoesNotKnow(string input, string errorMessage)
    {
        // Arrange
        var wildcardMessagePattern = $"*{errorMessage}*";

        // Act
        var act = () => StrategyParser.ParseLineAsHandAndHand(input);

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>().WithMessage(wildcardMessagePattern);
    }
}