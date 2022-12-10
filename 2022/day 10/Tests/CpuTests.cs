namespace Tests;

public class CpuTests
{
    [Fact]
    public void Tick_UpdatedCyclesInformation_WhenCalled()
    {
        // Arrange
        const int expectedValue = Cpu.StartingX;
        var cpu = new Cpu();

        // Act
        var originalX = cpu.Registers[Register.X];
        cpu.Tick();
        var firstTickX = cpu.Cycles[Register.X][0];
        cpu.Tick();
        var secondTickX = cpu.Cycles[Register.X][1];

        // Assert
        originalX.Should().Be(expectedValue);
        firstTickX.Should().Be(expectedValue);
        secondTickX.Should().Be(expectedValue);

        cpu.Cycles[Register.X].Should().HaveCount(2);
    }

    [Fact]
    public void Perform_CorrectlyAffectsXRegister_GivenAdventOfCodeSmallExampleInput()
    {
        // Arrange
        var input = new List<ICpuInstruction>
        {
            new NoopInstruction(),
            new RegisterAddInstruction(Register.X, 3),
            new RegisterAddInstruction(Register.X, -5)
        };
        
        var cpu = new Cpu();

        // Act
        cpu.PerformInstructions(input);

        // Assert
        cpu.Cycles[Register.X].Should().HaveCount(5);
        cpu.Cycles[Register.X][0].Should().Be(Cpu.StartingX); // noop starts
        cpu.Cycles[Register.X][1].Should().Be(Cpu.StartingX); // noop ends, addx 3 starts
        cpu.Cycles[Register.X][2].Should().Be(Cpu.StartingX); // addx 3 continues
        cpu.Cycles[Register.X][3].Should().Be(Cpu.StartingX + 3); // addx 3 ends, addx -5 starts
        cpu.Cycles[Register.X][4].Should().Be(Cpu.StartingX + 3); // addx -5 continues
        cpu.Registers[Register.X].Should().Be(Cpu.StartingX + 3 - 5); // addx -5 ends
    }
}