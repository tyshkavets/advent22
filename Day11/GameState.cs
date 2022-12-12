namespace Day11;

public class GameState
{
    private readonly List<Monkey> _monkeys;

    public GameState(string input)
    {
        _monkeys = new List<Monkey>();
        var monkeyParts = input.Split(Environment.NewLine + Environment.NewLine);

        foreach (var monkeyPart in monkeyParts)
        {
            _monkeys.Add(Monkey.ParseMonkey(monkeyPart));
        }
    }

    public long RunGame(int operationCount, bool calm = true)
    {
        for (var i = 0; i < operationCount; i++)
        {
            PlayRound(calm);
        }

        var topMonkeys = _monkeys.Select(m => m.Counter).OrderByDescending(c => c).Take(2).ToList();

        return (long)topMonkeys[0] * topMonkeys[1];
    }

    private void PlayRound(bool calm)
    {
        long commonModulo = 0;
                
        if (!calm)
        {
            commonModulo = _monkeys.Select(m => m.DivisibleCheck).Aggregate((x, y) => x * y);
        }

        foreach (var monkey in _monkeys)
        {
            while (monkey.HasGotItemsToPlayWith())
            {
                var result = monkey.Play(commonModulo, calm);
                
                _monkeys[result.TargetMonkey].CatchItem(result.WorryLevel);
            }
        }
    }
}