namespace Tests;

public class InstructionParserTests
{
    [Fact]
    public void Parse_ReturnsExpectedInstructions_GivenAdventOfCodeSmallExample()
    {
        // Arrange
        const string input = "noop\n" +
                             "addx 3\n" +
                             "addx -5\n";
        
        var expectedInstructions = new List<ICpuInstruction>
        {
            new NoopInstruction(),
            new RegisterAddInstruction(Register.X, 3),
            new RegisterAddInstruction(Register.X, -5),
        };

        var parser = new InstructionParser();

        // Act
        var results = parser.Parse(input);

        // Assert
        results.Should().HaveCount(expectedInstructions.Count);
        results[0].Should().BeOfType(typeof(NoopInstruction));
        results[1].Should().BeOfType(typeof(RegisterAddInstruction));
        results[2].Should().BeOfType(typeof(RegisterAddInstruction));

        for (var i = 1; i < results.Count; ++i)
        {
            var addInstruction = results[i] as RegisterAddInstruction;
            var expectedInstruction = expectedInstructions[i] as RegisterAddInstruction;
            
            addInstruction.Value.Should().Be(expectedInstruction.Value);
            addInstruction.TargetRegister.Should().Be(expectedInstruction.TargetRegister);
        }
    }
}