namespace Tests;

public class PriorityProviderTests
{
    [Theory]
    [InlineData('a', 1)]
    [InlineData('b', 2)]
    [InlineData('c', 3)]
    [InlineData('x', 24)]
    [InlineData('y', 25)]
    [InlineData('z', 26)]
    public void GetPriority_ReturnsPositionInAlphabet_ForLowercaseCharacters(char itemType, int expectedPriority)
    {
        // Arrange
        var provider = new PriorityProvider();

        // Act
        var priority = provider.GetPriority(itemType);

        // Assert
        priority.Should().Be(expectedPriority);
    }
    
    [Theory]
    [InlineData('A', 1 + 26)]
    [InlineData('B', 2 + 26)]
    [InlineData('C', 3 + 26)]
    [InlineData('X', 24 + 26)]
    [InlineData('Y', 25 + 26)]
    [InlineData('Z', 26 + 26)]
    public void GetPriority_ReturnsPositionInAlphabetPlus26_ForUppercaseCharacters(char itemType, int expectedPriority)
    {
        // Arrange
        var provider = new PriorityProvider();

        // Act
        var priority = provider.GetPriority(itemType);

        // Assert
        priority.Should().Be(expectedPriority);
    }
}