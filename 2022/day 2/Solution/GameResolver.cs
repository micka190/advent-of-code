namespace Solution;

public static class GameResolver
{
    public static Outcome Resolve(Hand player, Hand opponent)
    {
        if (player == opponent)
        {
            return Outcome.Draw;
        }

        if (
            (player == Hand.Rock && opponent == Hand.Scissors) ||
            (player == Hand.Paper && opponent == Hand.Rock) ||
            (player == Hand.Scissors && opponent == Hand.Paper)
            )
        {
            return Outcome.Win;
        }

        return Outcome.Lose;
    }
}