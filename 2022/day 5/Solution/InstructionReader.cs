namespace Solution;

public class InstructionReader
{
    private readonly List<string> _instructions;

    public InstructionReader(string instructions)
    {
        _instructions = instructions
            .Trim()
            .Split('\n')
            .ToList();
    }

    public IEnumerable<Instruction> ReadInstructions()
    {
        foreach (var instruction in _instructions)
        {
            var segments = instruction.Split(' ');
            if (segments.Length != 6)
            {
                throw new FormatException(
                    $"Expected instruction line to have format \"move [number] from [number] to [number]\". Got \"{instruction}\""
                );
            }

            var count = int.Parse(segments[1]);
            var from = int.Parse(segments[3]);
            var to = int.Parse(segments[5]);
            
            yield return new Instruction(count, from, to);
        }
    }
}