namespace Tests;

public class SignalParserTests
{
    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void FindStart_ReturnsCorrectValue_GivenAdventOfCodeExampleInput(string input, int expectedStart)
    {
        // Arrange
        const int chunkSize = 4;
        var parser = new SignalParser();

        // Act
        var result = parser.FindStart(input, chunkSize);

        // Assert
        result.Should().Be(expectedStart);
    }

    [Fact]
    public void FindStart_ReturnsMinusOne_WhenNoUniqueChunkIsFound()
    {
        // Arrange
        const string input = "aaaaaaaaaaaa";
        const int chunkSize = 4;
        var parser = new SignalParser();

        // Act
        var result = parser.FindStart(input, chunkSize);

        // Assert
        result.Should().Be(-1);
    }

    [Fact]
    public void FindStart_ThrowsArgumentException_GivenInputSmallerThanChunkSize()
    {
        // Arrange
        const string input = "abc";
        var chunkSize = input.Length * 2;
        var parser = new SignalParser();

        // Act
        var act = () => parser.FindStart(input, chunkSize);

        // Assert
        act.Should().Throw<ArgumentException>();
    }
}