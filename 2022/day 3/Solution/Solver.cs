namespace Solution;

public static class Solver<TPriorityProvider> 
    where TPriorityProvider : IPriorityProvider, new()
{
    public static int SolveForPartOne(string input) =>
        string.IsNullOrEmpty(input)
            ? 0
            : input
                .Trim()
                .Split('\n')
                .Select(line => new Rucksack(line))
                .Sum(ComputeRucksackPriority);

    private static int ComputeRucksackPriority(Rucksack rucksack)
    {
        var priorityProvider = new TPriorityProvider();
        var overlappingItemTypes = rucksack.OverlappingItemTypes.ToList();
        
        if (overlappingItemTypes.Count != 1)
        {
            throw new InvalidOperationException(
                $"Rucksack has unexpected amount of overlapping item types. Expected 1, got {overlappingItemTypes.Count}"
            );
        }

        return priorityProvider.GetPriority(overlappingItemTypes[0]);
    }
}