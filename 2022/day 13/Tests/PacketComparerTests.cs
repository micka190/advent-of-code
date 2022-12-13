namespace Tests;

public class PacketComparerTests
{
    [Theory]
    [InlineData("[1,1,3,1,1]\n[1,1,5,1,1]", PacketComparer.RightOrder)]
    [InlineData("[[1],[2,3,4]]\n[[1],4]", PacketComparer.RightOrder)]
    [InlineData("[9]\n[[8,7,6]]", PacketComparer.WrongOrder)]
    [InlineData("[[4,4],4,4]\n[[4,4],4,4,4]", PacketComparer.RightOrder)]
    [InlineData("[7,7,7,7]\n[7,7,7]", PacketComparer.WrongOrder)]
    [InlineData("[]\n[3]", PacketComparer.RightOrder)]
    [InlineData("[[[]]]\n[[]]", PacketComparer.WrongOrder)]
    [InlineData("[1,[2,[3,[4,[5,6,7]]]],8,9]\n[1,[2,[3,[4,[5,6,0]]]],8,9]", PacketComparer.WrongOrder)]
    public void Compare_ReturnsExpectedAnswer_GivenAdventOfCodeExamplePairs(string packetPair, int expectedComparisonResult)
    {
        // Arrange
        var (left, right) = PacketFactory.PairsFromInput(packetPair)[0];
        var comparer = new PacketComparer();

        // Act
        var result = comparer.Compare(left, right);

        // Assert
        result.Should().Be(expectedComparisonResult);
    }
}