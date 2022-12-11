namespace Solution;

public class Solver
{
    private readonly MonkeyParser _parser;
    
    public Solver(MonkeyParser parser) => _parser = parser;

    public long SolveForPartOne(string input)
    {
        const int numberOfRounds = 20;
        var monkeys = _parser.Parse(input);
        var stressManagementStrategy = (long itemWorryValue) => itemWorryValue / 3;
        
        return Solve(numberOfRounds, monkeys, stressManagementStrategy);
    }

    public long SolveForPartTwo(string input)
    {
        const int numberOfRounds = 10000;
        var monkeys = _parser.Parse(input);
        var leastCommonMultiple = monkeys.Select(monkey => monkey.ItemTest.Divisor).Aggregate((a, b) => a * b);
        var stressManagementStrategy = (long itemWorryValue) => itemWorryValue % leastCommonMultiple;

        return Solve(numberOfRounds, monkeys, stressManagementStrategy);
    }

    private static long Solve(int numberOfRounds, List<Monkey> monkeys, Func<long, long> stressStrategy)
    {
        var game = new KeepAwayGame(stressStrategy);
        game.Monkeys.AddRange(monkeys);

        for (var i = 0; i < numberOfRounds; ++i)
        {
            game.DoRound();
        }

        return game.Monkeys
            .OrderByDescending(monkey => monkey.InspectCount)
            .Take(2)
            .Select(monkey => (long)monkey.InspectCount)
            .Aggregate((a, b) => a * b);
    }
}