namespace Tests;

public class PacketFactoryTest
{
    [Fact]
    public void FromInput_ReturnsExpectedPair_GivenFirstPairFromAdventOfCodeExampleInput()
    {
        // Arrange
        const string firstPairInput = "[1,1,3,1,1]";
        const string secondPairInput = "[1,1,5,1,1]";
        const string input = $"{firstPairInput}\n{secondPairInput}";

        // Act
        var (left, right) = PacketFactory.FromInput(input)[0];

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
    public void FromInput_ReturnsExpectedPair_GivenSecondPairFromAdventOfCodeExampleInput()
    {
        // Arrange
        const string firstPairInput = "[[1],[2,3,4]]";
        const string secondPairInput = "[[1],4]";
        const string input = $"{firstPairInput}\n{secondPairInput}";

        // Act
        var (left, right) = PacketFactory.FromInput(input)[0];

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
    public void FromInput_ReturnsExpectedPair_GivenSeventhPairFromAdventOfCodeExampleInput()
    {
        // Arrange
        const string firstPairInput = "[[[]]]";
        const string secondPairInput = "[[]]";
        const string input = $"{firstPairInput}\n{secondPairInput}";

        // Act
        var (left, right) = PacketFactory.FromInput(input)[0];

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
}