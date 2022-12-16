namespace Solution;

public class InputParser
{
    private const int ValveNameIndex = 6;
    private const int FlowRateIndex = 23;
    private const int MultipleTunnelsIndex = 23;
    private const int SingleTunnelIndex = 22; // "Tunnels" becomes "Tunnel"
    
    private readonly Dictionary<string, Node> _nodes = new();
    private readonly Dictionary<string, List<string>> _nodeNeighbors = new();

    public List<Node> Parse(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return new List<Node>();
        }

        _nodes.Clear();
        _nodeNeighbors.Clear();
        
        var lines = input.Trim().Split('\n');
        var pairs = lines.Select(ParseLine).ToList();

        foreach (var (valveSegment, tunnelSegment) in pairs)
        {
            var node = NodeFromSegment(valveSegment);
            var neighbors = NeighborsFromSegment(tunnelSegment);
            _nodes[node.Id] = node;
            _nodeNeighbors[node.Id] = neighbors;
        }

        foreach (var (name, neighbors) in _nodeNeighbors)
        {
            var node = _nodes[name];
            
            foreach (var tunnel in neighbors)
            {
                node.Neighbors.Add(_nodes[tunnel]);
            }
        }

        return _nodes.Values.ToList();
    }

    private static (string ValveSegment, string TunnelsSegment) ParseLine(string line)
    {
        var segments = line.Split("; ");
        if (segments.Length != 2)
        {
            throw new FormatException($"Expected valve and tunnel segments. Got: \"{line}\"");
        }

        return (ValveSegment: segments[0], TunnelsSegment: segments[1]);
    }

    private static Node NodeFromSegment(string segment)
    {
        var id = segment.Substring(ValveNameIndex, 2);
        var value = int.Parse(segment[FlowRateIndex..]);
        return new Node(id, value);
    }

    private static List<string> NeighborsFromSegment(string segment) =>
        segment.Contains(", ")
            ? segment[MultipleTunnelsIndex..]
                .Split(", ")
                .ToList()
            : new List<string> { segment[SingleTunnelIndex..] };
}