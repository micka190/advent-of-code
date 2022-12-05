namespace Solution;

public static class Solver
{
    public static IEnumerable<char> SolveForPartOne(string input)
    {
        var inputParser = new InputParser(input);
        var cargoMap = new CargoMap(inputParser.CargoMapRepresentation);
        var instructionReader = new InstructionReader(inputParser.Instructions);

        foreach (var instruction in instructionReader.ReadInstructions())
        {
            cargoMap.MovePartOne(instruction.Count, instruction.From, instruction.To);
        }

        return cargoMap.TopMostCrates;
    }
}