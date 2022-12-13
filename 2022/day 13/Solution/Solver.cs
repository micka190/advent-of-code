namespace Solution;

public class Solver
{
    private readonly PacketFactory _factory;
    private readonly PacketComparer _comparer;

    public Solver(PacketFactory factory, PacketComparer comparer)
    {
        _factory = factory;
        _comparer = comparer;
    }

    public int SolveForPartOne(string input)
    {
        var pairs = _factory.PairsFromInput(input);
        return pairs
            .Select((pair, index) => (Order: _comparer.Compare(pair.Left, pair.Right), Index: index + 1)) // "+ 1" for 1-based indexing
            .Where(data => data.Order == PacketComparer.RightOrder)
            .Sum(data => data.Index);
    }

    public int SolveForPartTwo(string input)
    {
        var firstDividerPacket = new ListPacket(new Packet[] { new NumberPacket(2) });
        var secondDividerPacket = new ListPacket(new Packet[] { new NumberPacket(6) });
        
        var packets = _factory.ListFromInput(input);
        packets.Add(firstDividerPacket);
        packets.Add(secondDividerPacket);
        packets.Sort(_comparer);

        var firstDividerIndex = packets.FindIndex(packet => packet == firstDividerPacket) + 1; // "+ 1" for 1-based indexing
        var secondDividerIndex = packets.FindIndex(packet => packet == secondDividerPacket) + 1; // "+ 1" for 1-based indexing

        return firstDividerIndex * secondDividerIndex;
    }
}