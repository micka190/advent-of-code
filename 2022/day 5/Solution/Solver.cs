namespace Solution;

public static class Solver
{
    public static IEnumerable<char> SolveForPartOne(string input)
    {
        var inputParser = new InputParser(input);
        var cargoMap = new CrateMover9000(inputParser.CargoMapRepresentation);
        var instructionReader = new InstructionReader(inputParser.Instructions);

        foreach (var instruction in instructionReader.ReadInstructions())
        {
            cargoMap.Move(instruction.Count, instruction.From, instruction.To);
        }

        return cargoMap.TopMostCrates;
    }
}