using System.Drawing;

namespace Solution;

public class Sensor
{
    public Point Position { get; set; } = new();
    public Beacon ClosestBeacon { get; set; } = new();
}