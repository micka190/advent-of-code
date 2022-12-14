namespace Solution;

public static class Program
{
    public static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Error: Input file path not passed.");
            return;
        }
        else if (File.Exists(args[0]))
        {
            var input = File.ReadAllText(args[0]);
            Console.WriteLine($"PART 1: {PartOneSolver.SolveFor(input)}");
            Console.WriteLine($"PART 2: {PartTwoSolver.SolveFor(input)}");
        }
        else
        {
            Console.WriteLine($"Error: Could not open file {args[0]}");
        }
    }
}