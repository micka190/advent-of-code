namespace Solution;

public class Solver
{
    private readonly InstructionParser _parser;
    public Solver(InstructionParser parser) => _parser = parser;

    public int SolveForPartOne(string input)
    {
        const int signalStartIndex = 20;
        const int signalSteps = 40;
        
        var instructions = _parser.Parse(input);
        var cpu = new Cpu();
        cpu.PerformInstructions(instructions);

        var signalStrength = 0;
        for (var i = signalStartIndex; i < cpu.Cycles[Register.X].Count; i += signalSteps)
        {
            // CPU cycle indexes are 0-based, but the Part 1 signal strength loop is using 1-based indexing.
            var zeroBasedCycleIndex = i - 1;
            
            var cycleStrength = cpu.Cycles[Register.X][zeroBasedCycleIndex] * i;
            signalStrength += cycleStrength;
        }

        return signalStrength;
    }
}