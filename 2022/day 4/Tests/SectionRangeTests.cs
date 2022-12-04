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
}