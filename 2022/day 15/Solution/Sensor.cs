using System.Drawing;

namespace Solution;

public class Sensor
{
    public Coordinate Position { get; set; }
    public Beacon ClosestBeacon { get; set; } = new();

    public long DistanceToBeacon => DistanceTo(ClosestBeacon.Position);
    
    public long DistanceTo(Coordinate position) =>
        Math.Abs(Position.X - position.X) +
        Math.Abs(Position.Y - position.Y);
}