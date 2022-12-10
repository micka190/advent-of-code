namespace Solution;

public interface ICpuInstruction
{
    public bool IsDone { get; }
    
    public void Perform(Cpu cpu);
}