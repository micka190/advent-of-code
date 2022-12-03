namespace Solution;

public class Rucksack
{
    public List<string> Items { get; }
    public IEnumerable<string> FirstCompartment => Items.GetRange(0, Items.Count / 2);
    public IEnumerable<string> SecondCompartment => Items.GetRange(Items.Count / 2, Items.Count / 2);
    public IEnumerable<string> OverlappingItemTypes => FirstCompartment.Intersect(SecondCompartment);

    public Rucksack(List<string> items)
    {
        Items = items;
    }
}