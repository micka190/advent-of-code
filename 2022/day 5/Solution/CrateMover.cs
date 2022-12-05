namespace Solution;

public abstract class CrateMover
{
    protected readonly CargoMap CargoMap;

    protected CrateMover(CargoMap cargoMap) => CargoMap = cargoMap;
    
    public abstract void Move(int count, int from, int to);
}