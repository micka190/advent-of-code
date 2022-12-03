namespace Solution;

public class Rucksack
{
    public List<char> Items { get; }
    public IEnumerable<char> FirstCompartment => Items.GetRange(0, Items.Count / 2);
    public IEnumerable<char> SecondCompartment => Items.GetRange(Items.Count / 2, Items.Count / 2);
    public IEnumerable<char> OverlappingItemTypes => FirstCompartment.Intersect(SecondCompartment);

    public Rucksack(string items)
    {
        Items = items.ToCharArray().ToList();
    }
}