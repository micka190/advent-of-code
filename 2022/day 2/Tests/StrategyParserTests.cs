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
    
    [Theory]
    [InlineData("A X", Hand.Rock, Outcome.Lose)]
    [InlineData("B Y", Hand.Paper, Outcome.Draw)]
    [InlineData("C Z", Hand.Scissors, Outcome.Win)]
    public void ParseLiseAsHandAndOutcome_ReturnsTupleOfHandAndOutcome_GivenValidInput(string input, Hand expectedLeft, Outcome expectedRight)
    {
        // Arrange
        // ...

        // Act
        var (left, right) = StrategyParser.ParseLineAsHandAndOutcome(input);

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
    
    [Fact]
    public void ParseLiseAsHandAndOutcome_ThrowsArgumentException_WhenGivenInvalidInput()
    {
        // Arrange
        const string invalidInput = "A B ERROR\n ";

        // Act
        var act = () => StrategyParser.ParseLineAsHandAndOutcome(invalidInput);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData("_ X", "Left character is unsupported.")]
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
    
    [Theory]
    [InlineData("_ X", "Left character is unsupported.")]
    [InlineData("A _", "Right character is unsupported.")]
    public void ParseLiseAsHandAndOutcome_ThrowsArgumentOutOfRangeException_WhenGivenLettersItDoesNotKnow(string input, string errorMessage)
    {
        // Arrange
        var wildcardMessagePattern = $"*{errorMessage}*";

        // Act
        var act = () => StrategyParser.ParseLineAsHandAndOutcome(input);

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>().WithMessage(wildcardMessagePattern);
    }
}