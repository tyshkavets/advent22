namespace Day02.GameParsers;

public abstract class GameParserBase : IGameParser
{
    public virtual Game Parse(string input) => GameRules.Search(GetSearchPredicate(input));

    protected abstract Func<Game, bool> GetSearchPredicate(string input);
    
    protected GameOption ParseFirstSymbol(string input) => input[0] switch
    {
        'A' => GameOption.Rock,
        'B' => GameOption.Paper,
        'C' => GameOption.Scissors,
        _ => throw new ArgumentOutOfRangeException()
    };
}
