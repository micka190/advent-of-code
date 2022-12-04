namespace Solution;

public class SectionRange
{
    public int Start { get; set; }
    public int End { get; set; }

    public SectionRange(string range)
    {
        var segments = range.Split('-');
        
        if (segments.Length != 2)
        {
            throw new FormatException($"Invalid range input. Expected 2 numbers separated by a dash. Got: \"{range}\"");
        }
        
        Start = int.Parse(segments[0]);
        End = int.Parse(segments[1]);
    }
}