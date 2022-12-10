namespace Solution;

public class NoopInstruction : ICpuInstruction
{
    public void Perform(Cpu cpu)
    {
        cpu.Tick();
    }
}