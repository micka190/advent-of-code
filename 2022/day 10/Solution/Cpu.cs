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
        { Register.X, new List<int>() }
    };

    public void Tick()
    {
        foreach (var (register, cycle) in Cycles)
        {
            cycle.Add(Registers[register]);
        }
    }

    public void PerformInstructions(IEnumerable<ICpuInstruction> instructions)
    {
        foreach (var instruction in instructions)
        {
            instruction.Perform(this);
        }
    }
}