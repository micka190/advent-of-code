using System.Drawing;

namespace Tests;

public class StoneParserTests
{
    [Fact]
    public void Parse_ReturnsExpectedCoordinates_GivenValidInput()
    {
        // Arrange
        const string input = "0,0 -> 1,1 -> 2,2\n" +
                             "3,3 -> 4,4 -> 10,3\n" +
                             "9,10 -> 2,4\n";
        var parser = new StoneParser();

        // Act
        var result = parser.Parse(input);

        // Assert
        result.Max.X.Should().Be(10);
        result.Max.Y.Should().Be(10);
        result.Min.X.Should().Be(0);
        result.Min.Y.Should().Be(0);
        
        result.Paths.Should().HaveCount(3);
        
        result.Paths[0].Should().HaveCount(3);
        result.Paths[1].Should().HaveCount(3);
        result.Paths[2].Should().HaveCount(2);

        result.Paths[0].Should().BeEquivalentTo(new[] { new Point(0, 0), new Point(1, 1), new Point(2, 2) });
        result.Paths[1].Should().BeEquivalentTo(new[] { new Point(3, 3), new Point(4, 4), new Point(10, 3) });
        result.Paths[2].Should().BeEquivalentTo(new[] { new Point(9, 10), new Point(2, 4) });
    }
}