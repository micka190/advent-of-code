namespace Solution;

public class InstructionParser
{
    public List<ICpuInstruction> Parse(string input) =>
        string.IsNullOrEmpty(input)
            ? new List<ICpuInstruction>()
            : input
                .Trim()
                .Split('\n')
                .Select(ParseLine)
                .ToList();

    private ICpuInstruction ParseLine(string line) =>
        line switch
        {
            "noop" => new NoopInstruction(),
            _ when line.StartsWith("addx ") => ParseAddToRegisterInstruction(line),
            _ => throw new ArgumentOutOfRangeException(nameof(line), line, "Unsupported instruction")
        };

    private RegisterAddInstruction ParseAddToRegisterInstruction(string input)
    {
        var segments = input.Split(' ');
        if (segments.Length != 2)
        {
            throw new FormatException($"Expected add instruction to be instruction and value separated by space. Got: \"{input}\"");
        }

        var registerCharacter = segments[0][^1]; 
        
        var register = registerCharacter switch
        {
            'x' => Register.X,
            _ => throw new ArgumentOutOfRangeException(nameof(registerCharacter), registerCharacter, "Unsupported register")
        };

        var value = int.Parse(segments[1]);

        return new RegisterAddInstruction(register, value);
    }
}