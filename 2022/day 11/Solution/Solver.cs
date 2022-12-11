namespace Solution;

public class Solver
{
    private readonly MonkeyParser _parser;


    public Solver(MonkeyParser parser) => _parser = parser;

    public int SolveForPartOne(string input)
    {
        const int numberOfRounds = 20;
        var monkeys = _parser.Parse(input);
        var game = new KeepAwayGame();
        game.Monkeys.AddRange(monkeys);

        for (var i = 0; i < numberOfRounds; ++i)
        {
            game.DoRound();
        }

        var topActiveMonkeyCounts = game.Monkeys
            .OrderByDescending(monkey => monkey.InspectCount)
            .Take(2)
            .Select(monkey => monkey.InspectCount)
            .ToArray();

        return topActiveMonkeyCounts[0] * topActiveMonkeyCounts[1];
    }
}