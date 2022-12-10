namespace Tests;

public class NoopInstructionTests
{
    [Fact]
    public void Perform_OnlyIncrementsCycles_InGivenCpu()
    {
        // Arrange
        var instruction = new NoopInstruction();
        var cpu = new Cpu();

        // Act
        instruction.Perform(cpu);

        // Assert
        cpu.Registers[Register.X].Should().Be(Cpu.StartingX);
        cpu.Cycles[Register.X].Should().HaveCount(1);
        cpu.Cycles[Register.X][0].Should().Be(Cpu.StartingX);
    }
}