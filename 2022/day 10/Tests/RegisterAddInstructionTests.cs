namespace Tests;

public class RegisterAddInstructionTests
{
    [Theory]
    [InlineData(Register.X, 5)]
    [InlineData(Register.X, -5)]
    public void Perform_Takes2CyclesToAddToRegister(Register targetRegister, int value)
    {
        // Arrange
        var expectedValue = Cpu.StartingX + value;
        var cpu = new Cpu();
        var instruction = new RegisterAddInstruction(targetRegister, value);

        // Act
        instruction.Perform(cpu);

        // Assert
        cpu.Cycles[Register.X].Should().HaveCount(2);
        cpu.Cycles[Register.X][0].Should().Be(Cpu.StartingX);
        cpu.Cycles[Register.X][1].Should().Be(Cpu.StartingX);
        cpu.Registers[Register.X].Should().Be(expectedValue);
    }
}