namespace Solution;

public static class GameRigger
{
    public static Hand Rig(Hand opponent, Outcome desired)
    {
        if (desired is Outcome.Draw)
        {
            return opponent;
        }
        else if (desired is Outcome.Win)
        {
            return opponent switch
            {
                Hand.Rock => Hand.Paper,
                Hand.Paper => Hand.Scissors,
                Hand.Scissors => Hand.Rock,
                _ => throw new ArgumentOutOfRangeException(nameof(opponent), opponent, "Unsupported hand.")
            };
        }
        else
        {
            return opponent switch
            {
                Hand.Rock => Hand.Scissors,
                Hand.Paper => Hand.Rock,
                Hand.Scissors => Hand.Paper,
                _ => throw new ArgumentOutOfRangeException(nameof(opponent), opponent, "Unsupported hand.")
            };
        }
    }
}