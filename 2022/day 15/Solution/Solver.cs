using System.Drawing;

namespace Solution;

public class Solver
{
    private readonly InputParser _parser;

    public Solver(InputParser parser) => _parser = parser;

    public int SolveForPartOne(string input)
    {
        const int targetY = 10;
        
        var (sensors, beacons) = _parser.Parse(input);

        sensors.Sort((left, right) => left.Position.X - right.Position.X);
        beacons.Sort((left, right) => left.Position.X - right.Position.X);
        
        var rangeStart = Math.Min(sensors[0].Position.X, beacons[0].Position.X);
        var rangeEnd = Math.Max(sensors[^1].Position.X, beacons[^1].Position.X);

        var invalidPositionCount = 0;

        for (var x = rangeStart; x < rangeEnd; ++x)
        {
            var position = new Point(x, targetY);
            if (sensors.Any(sensor => position != sensor.ClosestBeacon.Position && sensor.DistanceToBeacon >= sensor.DistanceTo(position)))
            {
                ++invalidPositionCount;
            }
        }
        
        return invalidPositionCount;
    }
}