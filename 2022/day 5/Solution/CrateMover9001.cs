namespace Solution;

public class CrateMover9001 : CrateMover
{
    public CrateMover9001(CargoMap cargoMap) : base(cargoMap)
    {
    }
    
    public override void Move(int count, int from, int to)
    {
        // Subtract 1 from "from" and "to", because the problem uses a 1-based index system, but we use a 0-based index system.
        var startIndex = from - 1;
        var endIndex = to - 1;

        var temp = new Stack<char>();
        
        for (var i = 0; i < count; ++i)
        {
            var crate = CargoMap.Stacks[startIndex].Pop();
            temp.Push(crate);
        }

        for (var i = 0; i < count; ++i)
        {
            var crate = temp.Pop();
            CargoMap.Stacks[endIndex].Push(crate);
        }
    }
}