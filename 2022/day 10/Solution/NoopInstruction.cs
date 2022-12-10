namespace Solution;

public class NoopInstruction : ICpuInstruction
{
    public bool IsDone { get; private set; }
    
    public void Perform(Cpu cpu)
    {
        cpu.Tick();
        IsDone = true;
    }
}