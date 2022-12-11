namespace Tests;

public class ItemTestTests
{
    [Fact]
    public void Perform_ReturnsExpectedTarget_GivenAdventOfCodeExampleInput()
    {
        // Arrange
        var itemTest = new ItemTest(23, 2, 3);

        // Act
        var trueResult = itemTest.Perform(itemTest.Divisor * 3);
        var falseResult = itemTest.Perform(itemTest.Divisor + 1);

        // Assert
        trueResult.Should().Be(itemTest.TrueTarget);
        falseResult.Should().Be(itemTest.FalseTarget);
    }
}