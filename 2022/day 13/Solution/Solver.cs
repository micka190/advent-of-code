namespace Solution;

public class Solver
{
    public int SolveForPartOne(string input)
    {
        var pairs = PacketFactory.PairsFromInput(input);
        var comparer = new PacketComparer();
        return pairs
            .Select((pair, index) => (Order: comparer.Compare(pair.Left, pair.Right), Index: index + 1)) // "+ 1" for 1-based indexing
            .Where(data => data.Order == PacketComparer.RightOrder)
            .Sum(data => data.Index);
    }

    public int SolveForPartTwo(string input)
    {
        var firstDividerPacket = new ListPacket(new Packet[] { new NumberPacket(2) });
        var secondDividerPacket = new ListPacket(new Packet[] { new NumberPacket(6) });

        var comparer = new PacketComparer();
        var packets = PacketFactory.ListFromInput(input);
        packets.Add(firstDividerPacket);
        packets.Add(secondDividerPacket);
        packets.Sort(comparer);

        var firstDividerIndex = packets.FindIndex(packet => packet == firstDividerPacket) + 1; // "+ 1" for 1-based indexing
        var secondDividerIndex = packets.FindIndex(packet => packet == secondDividerPacket) + 1; // "+ 1" for 1-based indexing

        return firstDividerIndex * secondDividerIndex;
    }
}