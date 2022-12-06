namespace Tests;

public class SignalParserTests
{
    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void FindUniqueChunk_ReturnsCorrectValue_GivenAdventOfCodePartOneExampleInput(string input, int expectedStart)
    {
        // Arrange
        var parser = new SignalParser();

        // Act
        var result = parser.FindUniqueChunk(input, SignalParser.DefaultStartChunkSize);

        // Assert
        result.Should().Be(expectedStart);
    }
    
    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    public void FindUniqueChunk_ReturnsCorrectValue_GivenAdventOfCodePartTwoExampleInput(string input, int expectedStart)
    {
        // Arrange
        var parser = new SignalParser();

        // Act
        var result = parser.FindUniqueChunk(input, SignalParser.DefaultMessageChunkSize);

        // Assert
        result.Should().Be(expectedStart);
    }

    [Fact]
    public void FindUniqueChunk_ReturnsMinusOne_WhenNoUniqueChunkIsFound()
    {
        // Arrange
        const string input = "aaaaaaaaaaaa";
        const int chunkSize = 4;
        var parser = new SignalParser();

        // Act
        var result = parser.FindUniqueChunk(input, chunkSize);

        // Assert
        result.Should().Be(-1);
    }

    [Fact]
    public void FindUniqueChunk_ThrowsArgumentException_GivenInputSmallerThanChunkSize()
    {
        // Arrange
        const string input = "abc";
        var chunkSize = input.Length * 2;
        var parser = new SignalParser();

        // Act
        var act = () => parser.FindUniqueChunk(input, chunkSize);

        // Assert
        act.Should().Throw<ArgumentException>();
    }
}