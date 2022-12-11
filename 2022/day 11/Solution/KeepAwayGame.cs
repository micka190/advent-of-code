namespace Solution;

public class KeepAwayGame
{
    public readonly List<Monkey> Monkeys = new();

    private readonly Func<long, long> _stressManagementStrategy;

    public KeepAwayGame(Func<long, long> stressManagementStrategy) => _stressManagementStrategy = stressManagementStrategy;

    public void DoRound()
    {
        foreach (var monkey in Monkeys)
        {
            while (monkey.Items.Count > 0)
            {
                monkey.InspectCount++;

                var worryLevel = monkey.Operation.Perform(monkey.Items[0]);
                
                worryLevel = _stressManagementStrategy(worryLevel);
                
                var targetIndex = monkey.ItemTest.Perform(worryLevel);
                
                monkey.Items.RemoveAt(0);
                Monkeys[targetIndex].Items.Add(worryLevel);
            }
        }
    }
}