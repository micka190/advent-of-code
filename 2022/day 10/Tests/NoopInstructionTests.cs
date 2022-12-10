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
        instruction.IsDone.Should().BeTrue();
        cpu.Registers[Register.X].Should().Be(Cpu.StartingX);
        cpu.Cycles[Register.X].Should().HaveCount(2);
        foreach (var cycle in cpu.Cycles[Register.X])
        {
            cycle.Should().Be(Cpu.StartingX);
        }
    }
}