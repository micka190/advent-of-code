namespace Tests;

public class FilesystemCreatorTests
{
    [Fact]
    public void Create_ReturnsCorrectResults_GivenAdventOfCodeExampleInput()
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
        var creator = new FileSystemCreator(parser);

        // Act
        var rootDirectory = creator.Create(input);

        // Assert
        rootDirectory.Name.Should().Be("/");
        rootDirectory.Size.Should().Be(48381165);
        rootDirectory.Directories.Should().HaveCount(2);
        rootDirectory.Files.Should().HaveCount(2);

        rootDirectory.Files["b.txt"].Name.Should().Be("b.txt");
        rootDirectory.Files["b.txt"].Size.Should().Be(14848514);
        rootDirectory.Files["c.dat"].Name.Should().Be("c.dat");
        rootDirectory.Files["c.dat"].Size.Should().Be(8504156);

        rootDirectory.Directories["a"].Name.Should().Be("a");
        rootDirectory.Directories["a"].Size.Should().Be(94853);
        rootDirectory.Directories["a"].Directories.Should().HaveCount(1);
        rootDirectory.Directories["a"].Files.Should().HaveCount(3);
        
        rootDirectory.Directories["a"].Files["f"].Name.Should().Be("f");
        rootDirectory.Directories["a"].Files["f"].Size.Should().Be(29116);
        rootDirectory.Directories["a"].Files["g"].Name.Should().Be("g");
        rootDirectory.Directories["a"].Files["g"].Size.Should().Be(2557);
        rootDirectory.Directories["a"].Files["h.lst"].Name.Should().Be("h.lst");
        rootDirectory.Directories["a"].Files["h.lst"].Size.Should().Be(62596);

        rootDirectory.Directories["a"].Directories["e"].Name.Should().Be("e");
        rootDirectory.Directories["a"].Directories["e"].Size.Should().Be(584);
        rootDirectory.Directories["a"].Directories["e"].Directories.Should().BeEmpty();
        rootDirectory.Directories["a"].Directories["e"].Files.Should().HaveCount(1);
        
        rootDirectory.Directories["a"].Directories["e"].Files["i"].Name.Should().Be("i");
        rootDirectory.Directories["a"].Directories["e"].Files["i"].Size.Should().Be(584);
        
        rootDirectory.Directories["d"].Name.Should().Be("d");
        rootDirectory.Directories["d"].Size.Should().Be(24933642);
        rootDirectory.Directories["d"].Directories.Should().BeEmpty();
        rootDirectory.Directories["d"].Files.Should().HaveCount(4);
        
        rootDirectory.Directories["d"].Files["j"].Name.Should().Be("j");
        rootDirectory.Directories["d"].Files["j"].Size.Should().Be(4060174);
        rootDirectory.Directories["d"].Files["d.log"].Name.Should().Be("d.log");
        rootDirectory.Directories["d"].Files["d.log"].Size.Should().Be(8033020);
        rootDirectory.Directories["d"].Files["d.ext"].Name.Should().Be("d.ext");
        rootDirectory.Directories["d"].Files["d.ext"].Size.Should().Be(5626152);
        rootDirectory.Directories["d"].Files["k"].Name.Should().Be("k");
        rootDirectory.Directories["d"].Files["k"].Size.Should().Be(7214296);
    }
}