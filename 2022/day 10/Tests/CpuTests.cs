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
}