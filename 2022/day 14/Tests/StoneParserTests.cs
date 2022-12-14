using System.Drawing;

namespace Tests;

public class StoneParserTests
{
    [Fact]
    public void Parse_ReturnsExpectedCoordinates_GivenValidInput()
    {
        // Arrange
        const string input = "0,0 -> 1,1 -> 2,2\n" +
                             "3,3 -> 4,4 -> 10,10\n" +
                             "9,3 -> 2,4\n";
        var parser = new StoneParser();

        // Act
        var paths = parser.Parse(input);

        // Assert
        paths.Should().HaveCount(3);
        
        paths[0].Should().HaveCount(3);
        paths[1].Should().HaveCount(3);
        paths[2].Should().HaveCount(2);

        paths[0].Should().BeEquivalentTo(new[] { new Point(0, 0), new Point(1, 1), new Point(2, 2) });
        paths[1].Should().BeEquivalentTo(new[] { new Point(3, 3), new Point(4, 4), new Point(10, 10) });
        paths[2].Should().BeEquivalentTo(new[] { new Point(9, 3), new Point(2, 4) });
    }
}