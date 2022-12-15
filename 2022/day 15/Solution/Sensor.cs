using System.Drawing;

namespace Solution;

public class Sensor
{
    public Point Position { get; set; }
    public Beacon ClosestBeacon { get; set; } = new();

    public int DistanceToBeacon => DistanceTo(ClosestBeacon.Position);
    
    public int DistanceTo(Point position) =>
        Math.Abs(Position.X - position.X) +
        Math.Abs(Position.Y - position.Y);
}