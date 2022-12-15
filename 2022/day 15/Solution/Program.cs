namespace Solution;

public static class Program
{
    public static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Error: Input file path not passed.");
        }
        else if (File.Exists(args[0]))
        {
            var input = File.ReadAllText(args[0]);
            var parser = new InputParser();
            var solver = new Solver(parser);

            Console.WriteLine($"PART 1 - {solver.SolveForPartOne(input, 2000000)}");
            // TODO: Part 2
        }
        else
        {
            Console.WriteLine($"Error: Could not open file {args[0]}");
        }
    }
}