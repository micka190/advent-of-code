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

    public static int SolveForPartTwo(string input) =>
        string.IsNullOrEmpty(input)
            ? 0
            : input
                .Trim()
                .Split('\n')
                .Select(line => new Rucksack(line))
                .Chunk(3)
                .Sum(ComputeBadgeItemTypePriority);

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

    private static int ComputeBadgeItemTypePriority(Rucksack[] groupRucksacks)
    {
        var priorityProvider = new TPriorityProvider();
        var rucksacks = groupRucksacks.ToList();

        if (rucksacks.Count <= 1)
        {
            throw new ArgumentException("Need multiple rucksacks to compute group badge priority.");
        }

        var intersections = rucksacks[0].Items.Intersect(rucksacks[1].Items);

        if (rucksacks.Count > 2)
        {
            for (var i = 2; i < rucksacks.Count; ++i)
            {
                intersections = intersections.Intersect(rucksacks[i].Items);
            }
        }

        var intersectionsList = intersections.ToList();
        if (intersectionsList.Count != 1)
        {
            throw new InvalidOperationException(
                $"Rucksacks have unexpected amount of overlapping item types. Expected 1, got {intersectionsList.Count}"
            );
        }

        return priorityProvider.GetPriority(intersectionsList[0]);
    }
}