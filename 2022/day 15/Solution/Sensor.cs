using System.Drawing;

namespace Solution;

public class Sensor
{
    public Point Position { get; set; }
    public Beacon ClosestBeacon { get; set; } = new();

    public int DistanceToBeacon => 
        Math.Abs(Position.X - ClosestBeacon.Position.X) + 
        Math.Abs(Position.Y - ClosestBeacon.Position.Y);
}