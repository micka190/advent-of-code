namespace Solution;

public class Solver
{
    public int SolveForPartOne(string input)
    {
        var pairs = PacketFactory.PairsFromInput(input);
        var comparer = new PacketComparer();
        return pairs
            .Select((pair, index) => (Order: comparer.Compare(pair.Left, pair.Right), Index: index + 1))
            .Where(data => data.Order  == PacketComparer.RightOrder)
            .Sum(data => data.Index);
    }
}