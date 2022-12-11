namespace Tests;

public class SolverTests
{
    [Fact]
    public void SolveForPartOne_ReturnsCorrectAnswer_GivenAdventOfCodeExampleInput()
    {
        // Arrange
        const string input = "Monkey 0:\n" +
                             "  Starting items: 79, 98\n" +
                             "  Operation: new = old * 19\n" +
                             "  Test: divisible by 23\n" +
                             "    If true: throw to monkey 2\n" +
                             "    If false: throw to monkey 3\n" +
                             "\n" +
                             "Monkey 1:\n" +
                             "  Starting items: 54, 65, 75, 74\n" +
                             "  Operation: new = old + 6\n" +
                             "  Test: divisible by 19\n" +
                             "    If true: throw to monkey 2\n" +
                             "    If false: throw to monkey 0\n" +
                             "\n" +
                             "Monkey 2:\n" +
                             "  Starting items: 79, 60, 97\n" +
                             "  Operation: new = old * old\n" +
                             "  Test: divisible by 13\n" +
                             "    If true: throw to monkey 1\n" +
                             "    If false: throw to monkey 3\n" +
                             "\n" +
                             "Monkey 3:\n" +
                             "  Starting items: 74\n" +
                             "  Operation: new = old + 3\n" +
                             "  Test: divisible by 17\n" +
                             "    If true: throw to monkey 0\n" +
                             "    If false: throw to monkey 1\n";
        const uint expectedValue = 10605;
        
        var parser = new MonkeyParser();
        var solver = new Solver(parser);

        // Act
        var result = solver.SolveForPartOne(input);

        // Assert
        result.Should().Be(expectedValue);
    }
    
    [Fact]
    public void SolveForPartTwo_ReturnsCorrectAnswer_GivenAdventOfCodeExampleInput()
    {
        // Arrange
        const string input = "Monkey 0:\n" +
                             "  Starting items: 79, 98\n" +
                             "  Operation: new = old * 19\n" +
                             "  Test: divisible by 23\n" +
                             "    If true: throw to monkey 2\n" +
                             "    If false: throw to monkey 3\n" +
                             "\n" +
                             "Monkey 1:\n" +
                             "  Starting items: 54, 65, 75, 74\n" +
                             "  Operation: new = old + 6\n" +
                             "  Test: divisible by 19\n" +
                             "    If true: throw to monkey 2\n" +
                             "    If false: throw to monkey 0\n" +
                             "\n" +
                             "Monkey 2:\n" +
                             "  Starting items: 79, 60, 97\n" +
                             "  Operation: new = old * old\n" +
                             "  Test: divisible by 13\n" +
                             "    If true: throw to monkey 1\n" +
                             "    If false: throw to monkey 3\n" +
                             "\n" +
                             "Monkey 3:\n" +
                             "  Starting items: 74\n" +
                             "  Operation: new = old + 3\n" +
                             "  Test: divisible by 17\n" +
                             "    If true: throw to monkey 0\n" +
                             "    If false: throw to monkey 1\n";
        
        const uint expectedValue = 2713310158;
        
        var parser = new MonkeyParser();
        var solver = new Solver(parser);

        // Act
        var result = solver.SolveForPartTwo(input);

        // Assert
        result.Should().Be(expectedValue);
    }
}