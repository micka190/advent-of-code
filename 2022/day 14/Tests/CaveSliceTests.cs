using System.Drawing;

namespace Tests;

public class CaveSliceTests
{
    [Fact]
    public void Constructor_BuildsExpectedGrid_GivenAdventOfCodeExampleInput()
    {
        // Arrange
        var paths = new List<List<Point>>
        {
            new() { new Point(498, 4), new Point(498, 6), new Point(496, 6) },
            new() { new Point(503, 4), new Point(502, 4), new Point(502, 9), new Point(494, 9) },
        };

        var expectedStones = new List<Point>
        {
            // First path
            new(496, 6),
            new(497, 6),
            new(498, 6),
            new(498, 5),
            new(498, 4),

            // Second path
            new(494, 9),
            new(495, 9),
            new(496, 9),
            new(497, 9),
            new(498, 9),
            new(499, 9),
            new(500, 9),
            new(501, 9),
            new(502, 9),
            new(502, 8),
            new(502, 7),
            new(502, 6),
            new(502, 5),
            new(502, 4),
            new(503, 4),
        };

        // Act
        var caveSlice = new CaveSlice(504, 10, paths);

        // Assert
        caveSlice.Width.Should().Be(504);
        caveSlice.Height.Should().Be(10);

        caveSlice[CaveSlice.SandOriginX, CaveSlice.SandOriginY].Should().Be(Cell.SandOrigin);

        foreach (var stone in expectedStones)
        {
            caveSlice[stone.X, stone.Y].Should().Be(Cell.Stone);
        }
    }

    [Fact]
    public void Visualize_ReturnsExpectedStringVisualization_GivenValidGrid()
    {
        // Arrange
        const int width = 501;
        const int height = 10;
        const int newLinesAdded = height - 1; // "-1" because we trim the last one.
        const int widthWithNewline = width + 1;

        var caveSlice = new CaveSlice(width, height, new List<List<Point>>
        {
            new()
            {
                new Point(0, 0), new Point(3, 0),
            },
            new()
            {
                new Point(10, 6), new Point(10, 7),
            },
        });

        var expectedStones = new List<int>
        {
            // First path
            0, 1, 2, 3,

            // Second path
            6 * widthWithNewline + 10, 7 * widthWithNewline + 10,
        };

        // Act
        var visualization = caveSlice.Visualize();


        // Assert
        visualization.Should().HaveLength((width * height) + newLinesAdded);
        visualization[CaveSlice.SandOriginX].Should().Be('+');
        foreach (var index in expectedStones)
        {
            visualization[index].Should().Be('#');
        }
    }

    [Fact]
    public void VisualizeChunk_ReturnsExpectedChunk_GivenAdventOfCodeExampleInput()
    {
        // Arrange
        var paths = new List<List<Point>>
        {
            new() { new Point(498, 4), new Point(498, 6), new Point(496, 6) },
            new() { new Point(503, 4), new Point(502, 4), new Point(502, 9), new Point(494, 9) },
        };

        const string expectedChunk = "......+...\n" +
                                     "..........\n" +
                                     "..........\n" +
                                     "..........\n" +
                                     "....#...##\n" +
                                     "....#...#.\n" +
                                     "..###...#.\n" +
                                     "........#.\n" +
                                     "........#.\n" +
                                     "#########.";

        var caveSlice = new CaveSlice(504, 10, paths);

        // Act
        var chunk = caveSlice.VisualizeChunk(new Point(494, 0), new Point(503, 9));

        // Assert
        chunk.Should().Be(expectedChunk);
    }
}