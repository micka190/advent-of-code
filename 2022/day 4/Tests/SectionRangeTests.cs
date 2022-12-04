namespace Tests;

public class SectionRangeTests
{
    [Fact]
    public void Constructor_ThrowsFormatException_WhenGivenInvalidInputFormat()
    {
        // Arrange
        const string invalidInput = "123-456-789-0";

        // Act
        var act = () => new SectionRange(invalidInput);

        // Assert
        act.Should().Throw<FormatException>();
    }

    [Fact]
    public void Constructor_ThrowsFormatException_WhenGivenInputWithoutNumbers()
    {
        // Arrange
        const string inputWithoutNumbers = "abc-def";

        // Act
        var act = () => new SectionRange(inputWithoutNumbers);

        // Assert
        act.Should().Throw<FormatException>();
    }

    [Fact]
    public void Constructor_ParsesSectionIdNumbers_WhenGivenValidInput()
    {
        // Arrange
        const int start = 2;
        const int end = 8;
        var range = $"{start}-{end}";

        // Act
        var sectionRange = new SectionRange(range);

        // Assert
        sectionRange.Start.Should().Be(start);
        sectionRange.End.Should().Be(end);
    }

    [Theory]
    [InlineData("0-9", "0-9")]
    [InlineData("0-9", "0-3")]
    [InlineData("0-9", "7-9")]
    [InlineData("0-9", "3-5")]
    public void Contains_ReturnsTrue_WhenRangeContainsAnotherRange(string parentRange, string childRange)
    {
        // Arrange
        var parent = new SectionRange(parentRange);
        var child = new SectionRange(childRange);

        // Act
        var result = parent.Contains(child);

        // Assert
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData("0-9", "0-9")]
    [InlineData("0-9", "0-3")]
    [InlineData("0-9", "7-9")]
    [InlineData("0-9", "3-5")]
    public void Overlaps_ReturnsTrue_WhenRangeOverlapsWithAnotherRange(string firstRange, string secondRange)
    {
        // Arrange
        var first = new SectionRange(firstRange);
        var second = new SectionRange(secondRange);

        // Act
        var firstResult = first.Overlaps(second);
        var secondResult = second.Overlaps(first);

        // Assert
        firstResult.Should().BeTrue();
        secondResult.Should().BeTrue();
    }
    
    [Theory]
    [InlineData("0-3", "4-9")] // Left *smaller* than right.
    [InlineData("4-9", "0-3")] // Right *smaller* than left.
    public void Overlaps_ReturnsFalse_WhenRangeDoesNotOverlapsWithAnotherRange(string firstRange, string secondRange)
    {
        // Arrange
        var first = new SectionRange(firstRange);
        var second = new SectionRange(secondRange);

        // Act
        var firstResult = first.Overlaps(second);
        var secondResult = second.Overlaps(first);

        // Assert
        firstResult.Should().BeFalse();
        secondResult.Should().BeFalse();
    }
}