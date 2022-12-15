using System.Drawing;

namespace Solution;

public class Sensor
{
    public Point Position { get; set; }
    public Beacon ClosestBeacon { get; set; } = new();
}