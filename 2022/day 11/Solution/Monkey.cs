namespace Solution;

public class Monkey
{
    public List<int> Items { get; init; } = new();

    public Operation Operation { get; init; } = new("0 + 0");
    public ItemTest ItemTest { get; init; } = new(0, 0, 0);

    public int InspectCount { get; set; }
}