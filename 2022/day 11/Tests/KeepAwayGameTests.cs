namespace Tests;

public class KeepAwayGameTests
{
    [Fact]
    public void DoRound_CausesMonkeysToExchangeItems_GivenAdventOfCodeExample()
    {
        // Arrange
        var game = new KeepAwayGame();
        game.Monkeys.Add(new()
        {
            Items = new List<int> { 79, 98 },
            Operation = new Operation("old * 19"),
            ItemTest = new ItemTest(23, 2, 3),
        });
        game.Monkeys.Add(new()
        {
            Items = new List<int> { 54, 65, 75, 74 },
            Operation = new Operation("old + 6"),
            ItemTest = new ItemTest(19, 2, 0),
        });
        game.Monkeys.Add(new()
        {
            Items = new List<int> { 79, 60, 97 },
            Operation = new Operation("old * old"),
            ItemTest = new ItemTest(13, 1, 3),
        });
        game.Monkeys.Add(new()
        {
            Items = new List<int> { 74 },
            Operation = new Operation("old + 3"),
            ItemTest = new ItemTest(17, 0, 1),
        });

        // Act
        game.DoRound();

        // Assert
        game.Monkeys[0].Items.Should().BeEquivalentTo(new List<int> { 20, 23, 27, 26 });
        game.Monkeys[1].Items.Should().BeEquivalentTo(new List<int> { 2080, 25, 167, 207, 401, 1046 });
        game.Monkeys[2].Items.Should().BeEmpty();
        game.Monkeys[3].Items.Should().BeEmpty();
    }

    [Fact]
    public void DoRound_TracksHowManyTimesMonkeysInspectItems_GivenAdventOfCodeExample()
    {
        // Arrange
        var game = new KeepAwayGame();
        game.Monkeys.Add(new()
        {
            Items = new List<int> { 79, 98 },
            Operation = new Operation("old * 19"),
            ItemTest = new ItemTest(23, 2, 3),
        });
        game.Monkeys.Add(new()
        {
            Items = new List<int> { 54, 65, 75, 74 },
            Operation = new Operation("old + 6"),
            ItemTest = new ItemTest(19, 2, 0),
        });
        game.Monkeys.Add(new()
        {
            Items = new List<int> { 79, 60, 97 },
            Operation = new Operation("old * old"),
            ItemTest = new ItemTest(13, 1, 3),
        });
        game.Monkeys.Add(new()
        {
            Items = new List<int> { 74 },
            Operation = new Operation("old + 3"),
            ItemTest = new ItemTest(17, 0, 1),
        });

        // Act
        for (var i = 0; i < 20; ++i)
        {
            game.DoRound();
        }


        // Assert
        game.Monkeys[0].InspectCount.Should().Be(101);
        game.Monkeys[1].InspectCount.Should().Be(95);
        game.Monkeys[2].InspectCount.Should().Be(7);
        game.Monkeys[3].InspectCount.Should().Be(105);
    }
}