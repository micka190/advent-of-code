﻿namespace Solution;

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
            // TODO: Use input to solve problem.
        }
        else
        {
            Console.WriteLine($"Error: Could not open file {args[0]}");
        }
    }
}