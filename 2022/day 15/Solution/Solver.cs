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
}