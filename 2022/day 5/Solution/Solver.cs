namespace Solution;

public static class Solver
{
    public static IEnumerable<char> SolveForPartOne(string input)
    {
        var inputParser = new InputParser(input);
        var cargoMap = new CargoMap(inputParser.CargoMapRepresentation);
        var instructionReader = new InstructionReader(inputParser.Instructions);
        var mover = new CrateMover9000(cargoMap);

        foreach (var instruction in instructionReader.ReadInstructions())
        {
            mover.Move(instruction.Count, instruction.From, instruction.To);
        }

        return cargoMap.TopMostCrates;
    }
    
    public static IEnumerable<char> SolveForPartTwo(string input)
    {
        var inputParser = new InputParser(input);
        var cargoMap = new CargoMap(inputParser.CargoMapRepresentation);
        var instructionReader = new InstructionReader(inputParser.Instructions);
        var mover = new CrateMover9001(cargoMap);

        foreach (var instruction in instructionReader.ReadInstructions())
        {
            mover.Move(instruction.Count, instruction.From, instruction.To);
        }

        return cargoMap.TopMostCrates;
    }
}