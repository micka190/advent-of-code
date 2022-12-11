namespace Tests;

public class MonkeyParserTest
{
    [Fact]
    public void Parse_ReturnsExpectedListOfMonkeys_GivenAdventOfCodeExampleInput()
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

        var expectedMonkeys = new List<Monkey>
        {
            new()
            {
                Items = new List<long> { 79, 98 },
                Operation = new Operation("old * 19"),
                ItemTest = new ItemTest(23, 2, 3),
            },
            new()
            {
                Items = new List<long> { 54, 65, 75, 74 },
                Operation = new Operation("old + 6"),
                ItemTest = new ItemTest(19, 2, 0),
            },
            new()
            {
                Items = new List<long> { 79, 60, 97 },
                Operation = new Operation("old * old"),
                ItemTest = new ItemTest(13, 1, 3),
            },
            new()
            {
                Items = new List<long> { 74 },
                Operation = new Operation("old + 3"),
                ItemTest = new ItemTest(17, 0, 1),
            },
        };

        var parser = new MonkeyParser();

        // Act
        var results = parser.Parse(input);

        // Assert
        results.Should().BeEquivalentTo(expectedMonkeys);
    }
}