namespace Solution;

public class CrateMover9000 : CrateMover
{
    public CrateMover9000(CargoMap cargoMap) : base(cargoMap)
    {
    }

    public override void Move(int count, int from, int to)
    {
        // Subtract 1 from "from" and "to", because the problem uses a 1-based index system, but we use a 0-based index system.
        var startIndex = from - 1;
        var endIndex = to - 1;

        for (var i = 0; i < count; ++i)
        {
            var crate = CargoMap.Stacks[startIndex].Pop();
            CargoMap.Stacks[endIndex].Push(crate);
        }
    }
}