namespace Tests;

public class GameResolverTests
{
    [Theory]
    [InlineData(Hand.Rock, Hand.Rock, Outcome.Draw)]
    [InlineData(Hand.Rock, Hand.Paper, Outcome.Lose)]
    [InlineData(Hand.Rock, Hand.Scissors, Outcome.Win)]
    [InlineData(Hand.Paper, Hand.Rock, Outcome.Win)]
    [InlineData(Hand.Paper, Hand.Paper, Outcome.Draw)]
    [InlineData(Hand.Paper, Hand.Scissors, Outcome.Lose)]
    [InlineData(Hand.Scissors, Hand.Rock, Outcome.Lose)]
    [InlineData(Hand.Scissors, Hand.Paper, Outcome.Win)]
    [InlineData(Hand.Scissors, Hand.Scissors, Outcome.Draw)]
    public void Resolve_ReturnsOutcome_OfGivenHandCombination(Hand player, Hand opponent, Outcome expected)
    {
        // Arrange
        // ...

        // Act
        var outcome = GameResolver.Resolve(player, opponent);

        // Assert
        outcome.Should().Be(expected);
    }
}