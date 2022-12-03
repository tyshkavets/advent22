namespace Day02;

public record Game(GameOption Opponent, GameOption Self, Outcome Outcome)
{
    public int Score()
    {
        return ScoreOutcome() + ScoreSelf();
    }

    private int ScoreOutcome() => Outcome switch
    {
        Outcome.Loss => 0,
        Outcome.Draw => 3,
        Outcome.Win => 6,
        _ => throw new ArgumentOutOfRangeException()
    };

    private int ScoreSelf() => Self switch
    {
        GameOption.Rock => 1,
        GameOption.Paper => 2,
        GameOption.Scissors => 3,
        _ => throw new ArgumentOutOfRangeException()
    };
}
