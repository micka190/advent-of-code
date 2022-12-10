namespace Solution;

public class Cpu
{
    public const int StartingX = 1;

    public readonly Dictionary<Register, int> Registers = new()
    {
        { Register.X, StartingX },
    };

    public readonly Dictionary<Register, List<int>> Cycles = new()
    {
        { Register.X, new List<int> { StartingX } }
    };

    public void Tick()
    {
        foreach (var (register, cycle) in Cycles)
        {
            cycle.Add(Registers[register]);
        }
    }
}