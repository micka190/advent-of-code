namespace Solution;

public class RegisterAddInstruction : ICpuInstruction
{
    public readonly Register TargetRegister;
    public readonly int Value;
    
    public RegisterAddInstruction(Register targetRegister, int value)
    {
        TargetRegister = targetRegister;
        Value = value;
    }

    public void Perform(Cpu cpu)
    {
        cpu.Tick();
        cpu.Tick();
        cpu.Registers[TargetRegister] += Value;
    }
}