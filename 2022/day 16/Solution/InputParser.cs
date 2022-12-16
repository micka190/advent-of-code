namespace Solution;

public class InputParser
{
    private const int ValveNameIndex = 6;
    private const int FlowRateIndex = 23;
    private const int MultipleTunnelsIndex = 23;
    private const int SingleTunnelIndex = 22; // "Tunnels" becomes "Tunnel"
    
    private readonly Dictionary<string, Valve> _valves = new();
    private readonly Dictionary<string, List<string>> _valveTunnels = new();

    public List<Valve> Parse(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return new List<Valve>();
        }

        _valves.Clear();
        _valveTunnels.Clear();
        
        var lines = input.Trim().Split('\n');
        var pairs = lines.Select(ParseLine).ToList();

        foreach (var (valveSegment, tunnelSegment) in pairs)
        {
            var valve = ValveFromSegment(valveSegment);
            var tunnels = TunnelsFromSegment(tunnelSegment);
            _valves[valve.Name] = valve;
            _valveTunnels[valve.Name] = tunnels;
        }

        foreach (var (valveName, tunnels) in _valveTunnels)
        {
            var valve = _valves[valveName];
            
            foreach (var tunnel in tunnels)
            {
                valve.TunnelsToVales.Add(_valves[tunnel]);
            }
        }

        return _valves.Values.ToList();
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

    private static Valve ValveFromSegment(string segment)
    {
        var name = segment.Substring(ValveNameIndex, 2);
        var flowRate = int.Parse(segment[FlowRateIndex..]);
        return new Valve
        {
            Name = name,
            FlowRate = flowRate,
        };
    }

    private static List<string> TunnelsFromSegment(string segment) =>
        segment.Contains(", ")
            ? segment[MultipleTunnelsIndex..]
                .Split(", ")
                .ToList()
            : new List<string> { segment[SingleTunnelIndex..] };
}