namespace Tests;

public class TerminalOutputParserTests
{
    [Fact]
    public void Parse_ReturnsExpectedCommands_GivenAdventOfCodeExampleInput()
    {
        // Arrange
        const string input = "$ cd /\n" +
                             "$ ls\n" +
                             "dir a\n" +
                             "14848514 b.txt\n" +
                             "8504156 c.dat\n" +
                             "dir d\n" +
                             "$ cd a\n" +
                             "$ ls\n" +
                             "dir e\n" +
                             "29116 f\n" +
                             "2557 g\n" +
                             "62596 h.lst\n" +
                             "$ cd e\n" +
                             "$ ls\n" +
                             "584 i\n" +
                             "$ cd ..\n" +
                             "$ cd ..\n" +
                             "$ cd d\n" +
                             "$ ls\n" +
                             "4060174 j\n" +
                             "8033020 d.log\n" +
                             "5626152 d.ext\n" +
                             "7214296 k\n";
        var parser = new TerminalOutputParser();

        // Act
        var commands = parser.Parse(input);

        // Assert
        commands.Should().HaveCount(input.Count(c => c == '$'));
        
        commands[0].FullCommand.Should().Be("cd /");
        commands[0].Command.Should().Be("cd");
        commands[0].Arguments.Should().Be("/");
        commands[0].Output.Should().BeEmpty();
        
        commands[1].FullCommand.Should().Be("ls");
        commands[1].Command.Should().Be("ls");
        commands[1].Arguments.Should().Be(string.Empty);
        commands[1].Output.Should().HaveCount(4);
        commands[1].Output[0].Should().Be("dir a");
        commands[1].Output[1].Should().Be("14848514 b.txt");
        commands[1].Output[2].Should().Be("8504156 c.dat");
        commands[1].Output[3].Should().Be("dir d");
        
        commands[2].FullCommand.Should().Be("cd a");
        commands[2].Command.Should().Be("cd");
        commands[2].Arguments.Should().Be("a");
        commands[2].Output.Should().BeEmpty();
        
        commands[3].FullCommand.Should().Be("ls");
        commands[3].Command.Should().Be("ls");
        commands[3].Arguments.Should().Be(string.Empty);
        commands[3].Output.Should().HaveCount(4);
        commands[3].Output[0].Should().Be("dir e");
        commands[3].Output[1].Should().Be("29116 f");
        commands[3].Output[2].Should().Be("2557 g");
        commands[3].Output[3].Should().Be("62596 h.lst");
        
        commands[4].FullCommand.Should().Be("cd e");
        commands[4].Command.Should().Be("cd");
        commands[4].Arguments.Should().Be("e");
        commands[4].Output.Should().BeEmpty();
        
        commands[5].FullCommand.Should().Be("ls");
        commands[5].Command.Should().Be("ls");
        commands[5].Arguments.Should().Be(string.Empty);
        commands[5].Output.Should().HaveCount(1);
        commands[5].Output[0].Should().Be("584 i");
        
        commands[6].FullCommand.Should().Be("cd ..");
        commands[6].Command.Should().Be("cd");
        commands[6].Arguments.Should().Be("..");
        commands[6].Output.Should().BeEmpty();
        
        commands[7].FullCommand.Should().Be("cd ..");
        commands[7].Command.Should().Be("cd");
        commands[7].Arguments.Should().Be("..");
        commands[7].Output.Should().BeEmpty();
        
        commands[8].FullCommand.Should().Be("cd d");
        commands[8].Command.Should().Be("cd");
        commands[8].Arguments.Should().Be("d");
        commands[8].Output.Should().BeEmpty();
        
        commands[9].FullCommand.Should().Be("ls");
        commands[9].Command.Should().Be("ls");
        commands[9].Arguments.Should().Be(string.Empty);
        commands[9].Output.Should().HaveCount(4);
        commands[9].Output[0].Should().Be("4060174 j");
        commands[9].Output[1].Should().Be("8033020 d.log");
        commands[9].Output[2].Should().Be("5626152 d.ext");
        commands[9].Output[3].Should().Be("7214296 k");
    }
}