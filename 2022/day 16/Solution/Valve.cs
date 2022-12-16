namespace Solution;

public class Valve
{
    public string Name { get; set; } = string.Empty;
    public int FlowRate { get; set; }
    public readonly List<Valve> TunnelsToVales = new();
}