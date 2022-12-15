namespace Solution;

public class InputParser
{
    private const string SensorPrefix = "Sensor at ";
    private const string BeaconPrefix = "closest beacon is at ";

    private readonly Dictionary<string, Sensor> _sensors = new(); // Dictionary in case Part 2 introduces duplicate sensor coordinates.
    private readonly Dictionary<string, Beacon> _beacons = new();

    public (List<Sensor> Sensors, List<Beacon> Beacons) Parse(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return (new List<Sensor>(), new List<Beacon>());
        }

        _sensors.Clear();
        _beacons.Clear();


        var lines = input.Trim().Split('\n');
        foreach (var line in lines)
        {
            ParseLine(line);
        }

        return (
            Sensors: _sensors.Values.ToList(),
            Beacons: _beacons.Values.ToList()
        );
    }

    private void ParseLine(string line)
    {
        var segments = line.Split(": ");
        if (segments.Length != 2)
        {
            throw new FormatException($"Expected sensor and beacon coordinates separated by colon. Got: \"{line}\"");
        }

        var beaconString = segments[1][BeaconPrefix.Length..];
        var beacon = ParseBeacon(beaconString);

        var sensorString = segments[0][SensorPrefix.Length..];
        ParseSensor(sensorString, beacon);
    }

    private Beacon ParseBeacon(string key)
    {
        if (!_beacons.ContainsKey(key))
        {
            var beacon = new Beacon
            {
                Position = ParseCoordinateString(key)
            };
            _beacons[key] = beacon;
        }

        return _beacons[key];
    }

    private void ParseSensor(string key, Beacon closestBeacon)
    {
        if (!_sensors.ContainsKey(key))
        {
            var sensor = new Sensor
            {
                Position = ParseCoordinateString(key),
                ClosestBeacon = closestBeacon,
            };
            _sensors[key] = sensor;
        }
    }

    private static Coordinate ParseCoordinateString(string coordinateString)
    {
        var segments = coordinateString.Split(", ");
        if (segments.Length != 2)
        {
            throw new FormatException($"Expected \"x=[number], y=[number]\". Got: \"{coordinateString}\"");
        }

        var x = long.Parse(segments[0]["x=".Length..]);
        var y = long.Parse(segments[1]["y=".Length..]);

        return new Coordinate(x, y);
    }
}