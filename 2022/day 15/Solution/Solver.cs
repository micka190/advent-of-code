using System.Drawing;

namespace Solution;

public class Solver
{
    private readonly InputParser _parser;

    public Solver(InputParser parser) => _parser = parser;

    public long SolveForPartOne(string input, int y)
    {
        var (sensors, beacons) = _parser.Parse(input);

        sensors.Sort((left, right) => left.Position.X.CompareTo(right.Position.X));
        beacons.Sort((left, right) => left.Position.X.CompareTo(right.Position.X));

        var leftMostSensorRadiusEdge = sensors.Select(sensor => sensor.Position.X - sensor.DistanceToBeacon).Order().First();
        var rightMostSensorRadiusEdge = sensors.Select(sensor => sensor.Position.X + sensor.DistanceToBeacon).OrderDescending().First();

        var rangeStart = Math.Min(leftMostSensorRadiusEdge, beacons[0].Position.X);
        var rangeEnd = Math.Max(rightMostSensorRadiusEdge, beacons[^1].Position.X);

        long invalidPositionCount = 0;

        for (var x = rangeStart; x < rangeEnd; ++x)
        {
            var position = new Coordinate(x, y);
            if (sensors.Any(sensor => position != sensor.ClosestBeacon.Position && sensor.DistanceToBeacon >= sensor.DistanceTo(position)))
            {
                ++invalidPositionCount;
            }
        }

        return invalidPositionCount;
    }

    public long SolveForPartTwo(string input, long upperLimit)
    {
        const int tuningFrequencyMultiplier = 4000000;

        var (sensors, beacons) = _parser.Parse(input);
        var edgeCoordinates = sensors
            .Select(GetEdgeCoordinates)
            .SelectMany(coordinate => coordinate);

        foreach (var coordinate in edgeCoordinates)
        {
            if (coordinate.X > 0 && coordinate.X < upperLimit && 
                coordinate.Y > 0 && coordinate.Y < upperLimit)
            {
                var inSensorRange = sensors.Any(sensor => sensor.DistanceToBeacon >= sensor.DistanceTo(coordinate));

                if (!inSensorRange)
                {
                    return coordinate.X * tuningFrequencyMultiplier + coordinate.Y;
                }
            }
        }
        
        return -1;
    }

    private static List<Coordinate> GetEdgeCoordinates(Sensor sensor)
    {
        var left = new Coordinate(sensor.Position.X - sensor.DistanceToBeacon - 1, sensor.Position.Y);
        var right = new Coordinate(sensor.Position.X + sensor.DistanceToBeacon + 1, sensor.Position.Y);
        var top = new Coordinate(sensor.Position.X, sensor.Position.Y + sensor.DistanceToBeacon + 1);
        var bottom = new Coordinate(sensor.Position.X, sensor.Position.Y - sensor.DistanceToBeacon - 1);

        var edges = new List<Coordinate>();

        edges = edges
            .Concat(GetCoordinatesBetween(left, top))
            .Concat(GetCoordinatesBetween(bottom, right))
            .Concat(GetCoordinatesBetween(top, right))
            .Concat(GetCoordinatesBetween(left, bottom))
            .ToList();

        return edges;
    }

    private static IEnumerable<Coordinate> GetCoordinatesBetween(Coordinate start, Coordinate end)
    {
        var (left, right) = start.X <= end.X ? (start, end) : (end, start);
        var coordinates = new List<Coordinate>();

        if (left.Y <= end.Y)
        {
            for (var offset = 0; offset <= right.X - left.X; ++offset)
            {
                coordinates.Add(new Coordinate(left.X + offset, left.Y + offset));
            }
        }
        else
        {
            for (var offset = 0; offset <= right.X - left.X; ++offset)
            {
                coordinates.Add(new Coordinate(left.X + offset, left.Y - offset));
            }
        }

        return coordinates;
    }
}