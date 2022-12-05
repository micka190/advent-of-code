﻿namespace Tests;

public class CargoMapTests
{
    [Fact]
    public void Constructor_Parses_StringRepresentation()
    {
        // Arrange
        const string representation = "[x] [y] [z]\n" + 
                                      "[a] [b] [c]\n" + 
                                      " 1   2   3 ";

        // Act
        var map = new CargoMap(representation);

        // Assert
        map.Stacks.Count.Should().Be(3);
        map.TopMostCrates.Should().BeEquivalentTo(new List<char> { 'x', 'y', 'z' });
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
        var map = new CargoMap(representation);

        // Assert
        map.Stacks.Count.Should().Be(3);
        map.TopMostCrates.Should().BeEquivalentTo(new List<char> { '1', 'b', 'z' });
    }

    [Fact]
    public void MovePartOne_MovesACrate_FromOneStackToAnother()
    {
        // Arrange
        const string representation = "[1]        \n" +
                                      "[x]     [z]\n" +
                                      "[a] [b] [c]\n" +
                                      " 1   2   3 ";
        var map = new CargoMap(representation);

        // Act
        map.MovePartOne(1, 1, 2);

        // Assert
        map.Stacks.Count.Should().Be(3);
        map.TopMostCrates.Should().BeEquivalentTo(new List<char> { 'x', '1', 'z' });
    }

    [Fact]
    public void MovePartOne_MovesMultipleCrates_FromOneStackToAnother()
    {
        // Arrange
        const string representation = "[1]        \n" +
                                      "[x]     [z]\n" +
                                      "[a] [b] [c]\n" +
                                      " 1   2   3 ";

        var map = new CargoMap(representation);

        // Act
        map.MovePartOne(2, 1, 3);

        // Assert
        map.Stacks.Count.Should().Be(3);
        map.TopMostCrates.Should().BeEquivalentTo(new List<char> { 'a', 'b', 'x' });
        map.Stacks[0].Should().Equal('a');
        map.Stacks[1].Should().Equal('b');
        map.Stacks[2].Should().Equal('x', '1', 'z', 'c');
    }
}