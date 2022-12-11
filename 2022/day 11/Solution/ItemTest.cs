namespace Solution;

public class ItemTest
{
    public int Divisor { get; set; }
    public int TrueTarget { get; set; }
    public int FalseTarget { get; set; }
    
    public ItemTest(int divisor, int trueTarget, int falseTarget)
    {
        Divisor = divisor;
        TrueTarget = trueTarget;
        FalseTarget = falseTarget;
    }

    public int Perform(int itemWorryLevel) =>
        itemWorryLevel % Divisor == 0 
            ? TrueTarget 
            : FalseTarget;
}
