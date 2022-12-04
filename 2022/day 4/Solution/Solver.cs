namespace Solution;

public static class Solver
{
    public static int SolveForPartOne(string input) =>
        string.IsNullOrEmpty(input)
            ? 0
            : input
                .Trim()
                .Split('\n')
                .Select(ComputeContainedSections)
                .Count(overlapping => overlapping);

    public static int SolveForPartTwo(string input) =>
        string.IsNullOrEmpty(input)
            ? 0
            : input
                .Trim()
                .Split('\n')
                .Select(ComputeOverlappingSections)
                .Count(overlapping => overlapping);
    
    private static bool ComputeContainedSections(string line)
    {
        var (first, second) = GetSectionRangesFromLine(line);
        return first.Contains(second) || second.Contains(first);
    }

    private static bool ComputeOverlappingSections(string line)
    {
        var (first, second) = GetSectionRangesFromLine(line);
        return first.Overlaps(second);
    }

    private static (SectionRange first, SectionRange second) GetSectionRangesFromLine(string line)
    {
        var segments = line.Split(',');
        if (segments.Length != 2)
        {
            throw new FormatException($"Invalid line format. Expected 2 ranges separated by a comma. Got: \"{line}\"");
        }

        var first = new SectionRange(segments[0]);
        var second = new SectionRange(segments[1]);
        
        return (first, second);
    }
}