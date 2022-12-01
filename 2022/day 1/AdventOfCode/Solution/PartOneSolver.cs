namespace Solution;

public static class PartOneSolver
{
    public static int SolveFor(string input) =>
        string.IsNullOrEmpty(input)
            ? 0
            : input
                .Trim()
                .Split("\n\n")
                .Select(segment => segment.Split('\n').Sum(int.Parse))
                .Max();
}