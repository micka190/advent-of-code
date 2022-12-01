namespace Solution;

public static class Solver
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