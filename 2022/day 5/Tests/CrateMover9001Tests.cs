namespace Tests;

public class CrateMover9001Tests
{
    [Fact]
    public void Move_MovesACrate_FromOneStackToAnother()
    {
        // Arrange
        const string representation = "[1]        \n" +
                                      "[x]     [z]\n" +
                                      "[a] [b] [c]\n" +
                                      " 1   2   3 ";
        var map = new CargoMap(representation);
        var mover = new CrateMover9001(map);

        // Act
        mover.Move(1, 1, 2);

        // Assert
        map.Stacks.Count.Should().Be(3);
        map.TopMostCrates.Should().BeEquivalentTo(new List<char> { 'x', '1', 'z' });
    }

    [Fact]
    public void Move_MovesMultipleCrates_FromOneStackToAnother()
    {
        // Arrange
        const string representation = "[1]        \n" +
                                      "[x]     [z]\n" +
                                      "[a] [b] [c]\n" +
                                      " 1   2   3 ";

        var map = new CargoMap(representation);
        var mover = new CrateMover9001(map);

        // Act
        mover.Move(2, 1, 3);

        // Assert
        map.Stacks.Count.Should().Be(3);
        map.TopMostCrates.Should().BeEquivalentTo(new List<char> { 'a', 'b', '1' });
        map.Stacks[0].Should().Equal('a');
        map.Stacks[1].Should().Equal('b');
        map.Stacks[2].Should().Equal('1', 'x', 'z', 'c');
    }
}