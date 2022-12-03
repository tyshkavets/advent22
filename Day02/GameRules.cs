namespace Day02;

public static class GameRules
{
    private static readonly ICollection<(GameOption Winner, GameOption Loser)> SimpleRules =
        new List<(GameOption Winner, GameOption Loser)>
        {
            (GameOption.Paper, GameOption.Rock),
            (GameOption.Rock, GameOption.Scissors),
            (GameOption.Scissors, GameOption.Paper),
        };

    private static readonly ICollection<Game> AllPossibleOutcomes;

    static GameRules()
    {
        AllPossibleOutcomes = new List<Game>();

        var allGameOptions = Enum.GetValues<GameOption>();

        foreach (var opponentMove in allGameOptions)
        {
            foreach (var selfMove in allGameOptions)
            {
                var gameOutcome = GetGameOutcome(opponentMove, selfMove);
                AllPossibleOutcomes.Add(new Game(opponentMove, selfMove, gameOutcome));
            }
        }
    }

    public static Game Search(Func<Game, bool> predicate)
    {
        return AllPossibleOutcomes.FirstOrDefault(predicate) ??
               throw new InvalidOperationException("Incompatible game state.");
    }

    private static Outcome GetGameOutcome(GameOption opponent, GameOption self)
    {
        if (opponent == self)
        {
            return Outcome.Draw;
        }

        return SimpleRules.Contains((opponent, self)) ? Outcome.Loss : Outcome.Win;
    }
}
