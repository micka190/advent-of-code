namespace Tests;

public class PacketFactoryTest
{
    [Fact]
    public void PairsFromInput_ReturnsExpectedPair_GivenFirstPairFromAdventOfCodeExampleInput()
    {
        // Arrange
        const string firstPairInput = "[1,1,3,1,1]";
        const string secondPairInput = "[1,1,5,1,1]";
        const string input = $"{firstPairInput}\n{secondPairInput}";

        // Act
        var (left, right) = PacketFactory.PairsFromInput(input)[0];

        // Assert
        left.Should().BeOfType<ListPacket>();
        right.Should().BeOfType<ListPacket>();

        (left as ListPacket).Values.Should().BeEquivalentTo(new[]
        {
            new NumberPacket(1),
            new NumberPacket(1),
            new NumberPacket(3),
            new NumberPacket(1),
            new NumberPacket(1),
        });

        (right as ListPacket).Values.Should().BeEquivalentTo(new[]
        {
            new NumberPacket(1),
            new NumberPacket(1),
            new NumberPacket(5),
            new NumberPacket(1),
            new NumberPacket(1),
        });
    }

    [Fact]
    public void PairsFromInput_ReturnsExpectedPair_GivenSecondPairFromAdventOfCodeExampleInput()
    {
        // Arrange
        const string firstPairInput = "[[1],[2,3,4]]";
        const string secondPairInput = "[[1],4]";
        const string input = $"{firstPairInput}\n{secondPairInput}";

        // Act
        var (left, right) = PacketFactory.PairsFromInput(input)[0];

        // Assert
        left.Should().BeOfType<ListPacket>();
        right.Should().BeOfType<ListPacket>();

        var firstLeftList = (left as ListPacket)!.Values[0];
        var secondLeftList = (left as ListPacket)!.Values[1];
        var firstRightList = (right as ListPacket)!.Values[0];

        firstLeftList.Should().BeOfType<ListPacket>();
        (firstLeftList as ListPacket).Values[0].Should().Be(new NumberPacket(1));

        secondLeftList.Should().BeOfType<ListPacket>();
        (secondLeftList as ListPacket).Values[0].Should().Be(new NumberPacket(2));
        (secondLeftList as ListPacket).Values[1].Should().Be(new NumberPacket(3));
        (secondLeftList as ListPacket).Values[2].Should().Be(new NumberPacket(4));

        firstRightList.Should().BeOfType<ListPacket>();
        (firstRightList as ListPacket).Values[0].Should().Be(new NumberPacket(1));

        (right as ListPacket)!.Values[1].Should().Be(new NumberPacket(4));
    }

    [Fact]
    public void PairsFromInput_ReturnsExpectedPair_GivenSeventhPairFromAdventOfCodeExampleInput()
    {
        // Arrange
        const string firstPairInput = "[[[]]]";
        const string secondPairInput = "[[]]";
        const string input = $"{firstPairInput}\n{secondPairInput}";

        // Act
        var (left, right) = PacketFactory.PairsFromInput(input)[0];

        // Assert
        left.Should().BeOfType<ListPacket>();
        right.Should().BeOfType<ListPacket>();

        var innerLeftList = (left as ListPacket)!.Values[0];
        var innerRightList = (right as ListPacket)!.Values[0];

        innerLeftList.Should().BeOfType<ListPacket>();
        innerRightList.Should().BeOfType<ListPacket>();

        var innerInnerLeftList = (innerLeftList as ListPacket)!.Values[0];
        innerInnerLeftList.Should().BeOfType<ListPacket>();
    }

    [Fact]
    public void ListFromInput_ReturnsCorrectNumberOfElements_GivenAdventOfCodeExampleInput()
    {
        // Arrange
        const string input = "[1,1,3,1,1]\n" +
                             "[1,1,5,1,1]\n" +
                             "\n" +
                             "[[1],[2,3,4]]\n" +
                             "[[1],4]\n" +
                             "\n" +
                             "[9]\n" +
                             "[[8,7,6]]\n" +
                             "\n" +
                             "[[4,4],4,4]\n" +
                             "[[4,4],4,4,4]\n" +
                             "\n" +
                             "[7,7,7,7]\n" +
                             "[7,7,7]\n" +
                             "\n" +
                             "[]\n" +
                             "[3]\n" +
                             "\n" +
                             "[[[]]]\n" +
                             "[[]]\n" +
                             "\n" +
                             "[1,[2,[3,[4,[5,6,7]]]],8,9]\n" +
                             "[1,[2,[3,[4,[5,6,0]]]],8,9]\n";

        const int expectedNumberOfElements = 16;

        // Act
        var results = PacketFactory.ListFromInput(input);

        // Assert
        results.Should().HaveCount(expectedNumberOfElements);
    }
}