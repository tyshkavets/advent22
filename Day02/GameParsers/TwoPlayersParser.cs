namespace Day02.GameParsers;

public class TwoPlayersParser : GameParserBase
{
    protected override Func<Game, bool> GetSearchPredicate(string input)
    {
        return game => game.Opponent == ParseFirstSymbol(input) && game.Self == ParseSecondSymbol(input);
    }

    private static GameOption ParseSecondSymbol(string input) => input[2] switch
    {
        'X' => GameOption.Rock,
        'Y' => GameOption.Paper,
        'Z' => GameOption.Scissors,
        _ => throw new ArgumentOutOfRangeException()
    };
}
