namespace Solution;

public class PacketComparer : IComparer<Packet>
{
    public const int RightOrder = -1;
    public const int WrongOrder = 1;
    public const int TiedOrder = 0;
    
    public int Compare(Packet? left, Packet? right)
    {
        if (left is null)
        {
            throw new ArgumentException("Unexpected comparison target type.", nameof(left));
        }
        
        if (right is null)
        {
            throw new ArgumentException("Unexpected comparison target type.", nameof(right));
        }

        return ComparePackets(left, right);
    }

    private static int ComparePackets(Packet left, Packet right)
    {
        // Both values are numbers, so compare the packets' values.
        if (left is NumberPacket leftNumber && right is NumberPacket rightNumber)
        {
            return leftNumber.Value.CompareTo(rightNumber.Value);
        }
        
        // From this point on, AT LEAST ONE of the two packets is a list.
        var leftList = ConvertToList(left);
        var rightList = ConvertToList(right);
        var lowerBoundLimit = Math.Min(leftList.Values.Length, rightList.Values.Length);

        // Both lists were empty, there's nothing to compare against.
        if (leftList.Values.Length == rightList.Values.Length && lowerBoundLimit == 0)
        {
            return TiedOrder;
        }
        
        // From this point on, both lists have numbers in them, so let's compare each number.
        for (var i = 0; i < lowerBoundLimit; ++i)
        {
            var comparisonResult = ComparePackets(leftList.Values[i], rightList.Values[i]);
            if (comparisonResult != 0)
            {
                return comparisonResult;
            }
        }

        // We've reached the end of the shortest list. Comparing both lists' length will return 0 if both had the same length.
        return leftList.Values.Length.CompareTo(rightList.Values.Length);
    }

    private static ListPacket ConvertToList(Packet input) =>
        input switch
        {
            ListPacket listPacket => listPacket,
            NumberPacket numberPacket => new ListPacket(new Packet[] { numberPacket }),
            _ => throw new ArgumentOutOfRangeException(nameof(input), input, "Unsupported input type")
        };
}