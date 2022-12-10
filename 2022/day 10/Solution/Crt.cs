namespace Solution;

// NOTE: This class has no unit tests, because we're already testing its only behavior
// in the SolverTests file (Solver.SolveForPartTwo tests).

public class Crt
{
    public int Width { get; set; } = 40;
    public int Height { get; set; } = 6;

    public string Blank { get; set; } = ".";
    public string Solid { get; set; } = "#";
    
    public string ImageFromCycles(Cpu cpu, Register targetRegister)
    {
        var image = string.Empty;

        var pixel = 0;
        for (var row = 0; row < Height; ++row)
        {
            for (var col = 0; col < Width; ++col)
            {
                var spritePosition = cpu.Cycles[targetRegister][pixel];

                image += col == spritePosition ||
                         col == spritePosition - 1 ||
                         col == spritePosition + 1
                    ? Solid
                    : Blank;

                ++pixel;
            }

            image += "\n";
        }

        return image.Trim();
    }
}