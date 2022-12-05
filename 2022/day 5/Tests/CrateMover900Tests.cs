namespace Tests;

public class CrateMover900Tests
{
    [Fact]
    public void Constructor_Parses_StringRepresentation()
    {
        // Arrange
        const string representation = "[x] [y] [z]\n" + 
                                      "[a] [b] [c]\n" + 
                                      " 1   2   3 ";

        // Act
        var crateMover = new CrateMover9000(representation);

        // Assert
        crateMover.Stacks.Count.Should().Be(3);
        crateMover.TopMostCrates.Should().BeEquivalentTo(new List<char> { 'x', 'y', 'z' });
    }

    [Fact]
    public void Constructor_Parses_UnevenStringRepresentation()
    {
        // Arrange
        const string representation = "[1]        \n" +
                                      "[x]     [z]\n" +
                                      "[a] [b] [c]\n" +
                                      " 1   2   3 ";

        // Act
        var crateMover = new CrateMover9000(representation);

        // Assert
        crateMover.Stacks.Count.Should().Be(3);
        crateMover.TopMostCrates.Should().BeEquivalentTo(new List<char> { '1', 'b', 'z' });
    }

    [Fact]
    public void Move_MovesACrate_FromOneStackToAnother()
    {
        // Arrange
        const string representation = "[1]        \n" +
                                      "[x]     [z]\n" +
                                      "[a] [b] [c]\n" +
                                      " 1   2   3 ";
        var crateMover = new CrateMover9000(representation);

        // Act
        crateMover.Move(1, 1, 2);

        // Assert
        crateMover.Stacks.Count.Should().Be(3);
        crateMover.TopMostCrates.Should().BeEquivalentTo(new List<char> { 'x', '1', 'z' });
    }

    [Fact]
    public void Move_MovesMultipleCrates_FromOneStackToAnother()
    {
        // Arrange
        const string representation = "[1]        \n" +
                                      "[x]     [z]\n" +
                                      "[a] [b] [c]\n" +
                                      " 1   2   3 ";

        var crateMover = new CrateMover9000(representation);

        // Act
        crateMover.Move(2, 1, 3);

        // Assert
        crateMover.Stacks.Count.Should().Be(3);
        crateMover.TopMostCrates.Should().BeEquivalentTo(new List<char> { 'a', 'b', 'x' });
        crateMover.Stacks[0].Should().Equal('a');
        crateMover.Stacks[1].Should().Equal('b');
        crateMover.Stacks[2].Should().Equal('x', '1', 'z', 'c');
    }
}