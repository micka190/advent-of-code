namespace Solution;

public class KeepAwayGame
{
    public readonly List<Monkey> Monkeys = new();
    

    public void DoRound()
    {
        foreach (var monkey in Monkeys)
        {
            while (monkey.Items.Count > 0)
            {
                monkey.InspectCount++;
                
                var item = monkey.Operation.Perform(monkey.Items[0]) / 3;
                var target = monkey.ItemTest.Perform(item);
                
                monkey.Items.RemoveAt(0);
                Monkeys[target].Items.Add(item);
            }
        }
    }
}