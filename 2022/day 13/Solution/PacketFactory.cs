using System.Text.Json;

namespace Solution;

public static class PacketFactory
{
    public static List<(Packet Left, Packet Right)> PairsFromInput(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return new List<(Packet Left, Packet Right)>();
        }
        
        var pairs = input
            .Trim()
            .Split("\n\n")
            .Select(pair => pair.Split('\n'));

        return pairs
            .Select(segments => (
                Left: FromJsonString(segments[0]),
                Right: FromJsonString(segments[1])
            ))
            .ToList();
    }

    private static Packet FromJsonString(string json)
    {
        var element = (JsonElement)JsonSerializer.Deserialize<object>(json)!;
        return FromJsonElement(element);
    }

    private static Packet FromJsonElement(JsonElement element) =>
        element.ValueKind switch
        {
            JsonValueKind.Number => new NumberPacket(element.GetInt32()),
            JsonValueKind.Array => new ListPacket(element.EnumerateArray().Select(FromJsonElement).ToArray()),
            _ => throw new ArgumentOutOfRangeException(nameof(element), "Unsupported JSON element type"),
        };
}