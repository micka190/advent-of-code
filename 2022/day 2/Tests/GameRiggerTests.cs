namespace Tests;

public class GameRiggerTests
{
    [Theory]
    [InlineData(Hand.Rock, Outcome.Win, Hand.Paper)]
    [InlineData(Hand.Rock, Outcome.Lose, Hand.Scissors)]
    [InlineData(Hand.Rock, Outcome.Draw, Hand.Rock)]
    [InlineData(Hand.Paper, Outcome.Win, Hand.Scissors)]
    [InlineData(Hand.Paper, Outcome.Lose, Hand.Rock)]
    [InlineData(Hand.Paper, Outcome.Draw, Hand.Paper)]
    [InlineData(Hand.Scissors, Outcome.Win, Hand.Rock)]
    [InlineData(Hand.Scissors, Outcome.Lose, Hand.Paper)]
    [InlineData(Hand.Scissors, Outcome.Draw, Hand.Scissors)]
    public void Rig_ReturnsTheHandNeededToGet_TheDesiredOutcome(Hand opponent, Outcome desired, Hand expectedHand)
    {
        // Arrange
        // ...

        // Act
        var result = GameRigger.Rig(opponent, desired);

        // Assert
        result.Should().Be(expectedHand);
    }
}