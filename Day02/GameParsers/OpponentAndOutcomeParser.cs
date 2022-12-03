namespace Day02.GameParsers;

public class OpponentAndOutcomeParser : GameParserBase
{
    protected override Func<Game, bool> GetSearchPredicate(string input)
    {
        return game => game.Opponent == ParseFirstSymbol(input) && game.Outcome == ParseSecondSymbol(input);
    }

    private static Outcome ParseSecondSymbol(string input) => input[2] switch
    {
        'X' => Outcome.Loss,
        'Y' => Outcome.Draw,
        'Z' => Outcome.Win,
        _ => throw new ArgumentOutOfRangeException()
    };
}
